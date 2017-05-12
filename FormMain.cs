﻿//  lorakon_manager - Manager for Lorakon database
//  Copyright (C) 2017  Norwegian Radiation Protection Autority
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
// Authors: Dag Robole,

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;

namespace lorakon_manager
{
    public partial class FormMain : Form
    {
        SqlConnection connection = null;

        private string ParsExecutable, GetParsExecutable;

        string InstallationDirectory;
        private static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "LorakonManager";
        private static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "Settings.xml";
        private string SampleTypeFile = SettingsPath + Path.DirectorySeparatorChar + "sample-types.xml";

        private Settings SettingsData = new Settings();

        public FormMain()
        {
            InitializeComponent();            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Width = (Screen.FromControl(this).Bounds.Right - Screen.FromControl(this).Bounds.Left) / 2;
            Height = (Screen.FromControl(this).Bounds.Bottom - Screen.FromControl(this).Bounds.Top) / 2;

            tabs.Appearance = TabAppearance.FlatButtons;
            tabs.ItemSize = new Size(0, 1);
            tabs.SizeMode = TabSizeMode.Fixed;

            tabs_SelectedIndexChanged(sender, e);

            cboxAccount.DisplayMember = "Name";
            cboxAccount.ValueMember = "ID";
            cboxEditAccountName.DisplayMember = "Name";
            cboxEditAccountName.ValueMember = "ID";

            dtFrom.Value = DateTime.Now - new TimeSpan(30, 0, 0, 0);
            dtTo.Value = DateTime.Now;

            InstallationDirectory = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + Path.DirectorySeparatorChar;

            if (!Directory.Exists(SettingsPath))
                Directory.CreateDirectory(SettingsPath);

            if (!File.Exists(SettingsPath + Path.DirectorySeparatorChar + "sample-types.xml"))
                File.Copy(InstallationDirectory + Path.DirectorySeparatorChar + "sample-types.xml", SampleTypeFile, false);

            LoadSettings();
            lblStatus.Text = "Kontakter databasen, vennligst vent...";

            ParsExecutable = InstallationDirectory + "pars.exe";
            if (!File.Exists(ParsExecutable))
            {
                MessageBox.Show("Finner ikke filen: " + ParsExecutable);
                Application.Exit();
            }

            GetParsExecutable = InstallationDirectory + "getpars.exe";
            if (!File.Exists(GetParsExecutable))
            {
                MessageBox.Show("Finner ikke filen: " + GetParsExecutable);
                Application.Exit();
            }

            // Load sample types
            string[] sampTypes = GetSampleTypes();
            foreach (string st in sampTypes)
                cboxEditSampleType.Items.Add(new SampleType(GetLabelFromSampleType(st), st));
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            Enabled = false;

            try
            {
                string[] files = Directory.GetFiles(Path.GetTempPath(), "*.cnf");
                foreach (string file in files)
                    File.Delete(file);
            }
            catch { }            

            try
            {
                connection = new SqlConnection(SettingsData.ConnectionString);                
                connection.Open();

                SqlCommand command = new SqlCommand("select ID, vchName from Account order by vchName", connection);
                SqlDataReader reader = command.ExecuteReader();

                cboxAccount.Items.Add(new Account(Guid.Empty, ""));
                cboxEditAccountName.Items.Add(new Account(Guid.Empty, ""));
                while (reader.Read())
                {
                    Guid id = new Guid(Convert.ToString(reader["ID"]));
                    string name = Convert.ToString(reader["vchName"]);

                    cboxAccount.Items.Add(new Account(id, name));
                    cboxEditAccountName.Items.Add(new Account(id, name));
                }
                reader.Close();                

                BindGridValidation();
                BindGridGeometries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Feil");
                Application.Exit();
            }
            finally
            {
                lblStatus.Text = "";
                Enabled = true;
            }
        }

        private void FormMain_Paint(object sender, PaintEventArgs e)
        {            
        }

        public void LoadSettings()
        {
            if (!File.Exists(SettingsFile))
                return;

            // Deserialize settings from file
            using (StreamReader sr = new StreamReader(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(SettingsData.GetType());
                SettingsData = x.Deserialize(sr) as Settings;
            }
        }

        private void SaveSettings()
        {
            // Serialize settings to file
            using (StreamWriter sw = new StreamWriter(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(SettingsData.GetType());
                x.Serialize(sw, SettingsData);
            }
        }

        string LogSeverityString(int severity)
        {
            if (severity == 0)
                return "Normal";
            else if(severity == 1)
                return "Warning";
            else if (severity == 2)
                return "Critical";
            return String.Empty;
        }

        private string[] GetLogMessages(DateTime fromDate, DateTime toDate)
        {
            List<string> logMessages = new List<string>();

            SqlCommand command = new SqlCommand("proc_spectrum_log_select", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    DateTime createDate = Convert.ToDateTime(reader["CreateDate"]);
                    int severity = Convert.ToInt32(reader["Severity"]);
                    string message = Convert.ToString(reader["Message"]);

                    logMessages.Add(createDate.ToString("yyyy.MM.dd HH:mm:ss") + " [" + LogSeverityString(severity) + "]: " + message);
                }
            }

            return logMessages.ToArray();
        }

        private string[] GetLogMessages(DateTime fromDate, DateTime toDate, int severity)
        {
            List<string> logMessages = new List<string>();

            SqlCommand command = new SqlCommand("proc_spectrum_log_select_severity", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FromDate", fromDate);
            command.Parameters.AddWithValue("@ToDate", toDate);
            command.Parameters.AddWithValue("@Severity", severity);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    DateTime createDate = Convert.ToDateTime(reader["CreateDate"]);
                    int sev = Convert.ToInt32(reader["Severity"]);
                    string message = Convert.ToString(reader["Message"]);

                    logMessages.Add(createDate.ToString("yyyy.MM.dd HH:mm:ss") + " [" + LogSeverityString(sev) + "]: " + message);
                }
            }

            return logMessages.ToArray();
        }

        private void AddSampleTypes(XmlNode node, ref List<string> sampleTypes)
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Element && n.Name.ToLower() == "sampletype")
                {
                    sampleTypes.Add(GetNodePath(n));
                    AddSampleTypes(n, ref sampleTypes);
                }
            }
        }

        private string[] GetSampleTypes()
        {
            List<string> sampleTypes = new List<string>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(SampleTypeFile);
                XmlElement root = doc.DocumentElement;
                AddSampleTypes(root, ref sampleTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return sampleTypes.ToArray();
        }

        private string GetNodePath(XmlNode node)
        {
            string path = node.Attributes["name"].InnerText;
            XmlNode search = null;
            while ((search = node.ParentNode).Name.ToLower() != "sampletypes")
            {
                path = search.Attributes["name"].InnerText + "/" + path;
                node = search;
            }
            return path;
        }

        private string GetSampleTypeFromLabel(string lbl)
        {
            string[] items = lbl.Split(new string[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length > 1)
                return items[1];
            else return String.Empty;
        }

        private string GetLabelFromSampleType(string st)
        {
            string[] items = st.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length > 0)
                return items[items.Length - 1] + " -> " + st;
            else return String.Empty;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemBack_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMain;
        }

        private void btnMainSearch_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSearch;
            populateGrid();
        }

        private void btnMenuValidation_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageValidation;
        }

        private void btnMenuGeometry_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageGeometries;
        }

        private void btnMainEdit_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageEdit;
        }

        private void btnMainLog_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageLog;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(connection != null && connection.State == ConnectionState.Open)
                connection.Close();

            SaveSettings();
        }

        private void populateGrid()
        {
            if (connection == null || connection.State != ConnectionState.Open)
                return;

            SqlCommand command = new SqlCommand("", connection);

            command.CommandText = @"
select a.vchName as 'Laboratorie', 
	sil.Operator,
	cast(sil.CreateDate as datetime2(0)) as 'Opprettet',
	cast(sil.AcquisitionDate as datetime2(0)) as 'Måledato',
	cast(sil.ReferenceDate as datetime2(0)) as 'Ref.dato',		
	sil.SampleType as 'Prøvetype', 
	sil.SampleComponent as 'Bestandel',		
	sil.Approved as 'Godkjent',	
    sil.ApprovedStatus as 'Godkj. status',
    sil.Rejected as 'Forkastet',	
    sil.ID
from SpectrumInfoLatest sil 
inner join Account a on a.ID = sil.AccountID
where 1=1
";

            if (!String.IsNullOrEmpty(cboxAccount.Text))
            {
                Account a = cboxAccount.SelectedItem as Account;
                command.CommandText += " and AccountID like '" + a.ID.ToString() + "'";
            }

            if (!String.IsNullOrEmpty(tbSearchSampleType.Text))
            {
                command.CommandText += " and SampleType like '%" + tbSearchSampleType.Text.Trim() + "%'";
            }
            
            command.CommandText += " and Approved = @Approved";
            command.Parameters.AddWithValue("@Approved", cbApproved.Checked);

            command.CommandText += " and Rejected = @Rejected";
            command.Parameters.AddWithValue("@Rejected", cbRejected.Checked);

            command.CommandText += " and CreateDate between @dateFrom and @dateTo";
            command.Parameters.AddWithValue("@dateFrom", dtFrom.Value);
            command.Parameters.AddWithValue("@dateTo", dtTo.Value);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.SelectCommand.Connection = connection;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridSearch.DataSource = dt;            

            foreach (DataGridViewColumn col in gridSearch.Columns)
                col.ReadOnly = true;

            gridSearch.Columns[gridSearch.Columns.Count - 1].Visible = false;
            gridSearch.Columns[gridSearch.Columns.Count - 2].ReadOnly = false;            
        }

        private void tbSearchSampleType_TextChanged(object sender, EventArgs e)
        {            
            populateGrid();
        }

        private void cboxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            populateGrid();
        }                

        private void cbRejected_CheckedChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void cbApproved_CheckedChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void cboxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateGrid();
        }

        private void visDetaljerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridSearch.SelectedRows.Count < 1)
                return;

            DataGridViewRow row = gridSearch.SelectedRows[0];
            Guid id = new Guid(row.Cells["ID"].Value.ToString());            
            FormShowDetails form = new FormShowDetails(connection, id);
            form.ShowDialog();
        }        

        private void menuItemOpenFiles_Click(object sender, EventArgs e)
        {            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                SqlCommand command = new SqlCommand("select vchName from Account where ID = @ID", connection);

                gridEditFiles.Rows.Clear();
                Application.DoEvents();

                Enabled = false;
                progress.Minimum = 0;
                progress.Maximum = ofd.FileNames.Length;
                progress.Step = 1;
                progress.Value = 0;
                progress.Visible = true;
                
                foreach(string filename in ofd.FileNames)
                {
                    progress.Value++;

                    string stype = GetSpectrumParameter(filename, "STYPE");
                    stype += " - " + GetSpectrumParameter(filename, "STITLE");
                    string lab = GetSpectrumParameter(filename, "SSPRSTR1");
                    string accountID = GetSpectrumParameter(filename, "SURSTRING1");
                    string accountName = "";
                    if (!String.IsNullOrEmpty(accountID))
                    {
                        Guid id = new Guid(accountID);
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@ID", id);
                        object o = command.ExecuteScalar();
                        if (o != null && o != DBNull.Value)
                            accountName = o.ToString();
                    }                    
                    string sampleType = GetSpectrumParameter(filename, "SUCSTRING1");
                    string sampleComponent = GetSpectrumParameter(filename, "SUCSTRING2");

                    string[] items = { filename, stype, lab, accountName, accountID, sampleType, sampleComponent };

                    gridEditFiles.Rows.Add(items);

                    Application.DoEvents();
                }

                progress.Visible = false;
                Enabled = true;
                Application.DoEvents();
            }
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            menuItemOpenFiles.Visible = false;
            btnEditOpen.Visible = false;
            btnValidationTrash.Visible = false;
            btnGeometryTrash.Visible = false;

            if (tabs.SelectedTab == pageEdit)
            {
                menuItemOpenFiles.Visible = true;
                btnEditOpen.Visible = true;
            }
            else if (tabs.SelectedTab == pageLog)
            {
                dtLogFrom.Value = DateTime.Now.AddDays(-14);
                dtLogTo.Value = DateTime.Now.AddDays(1);

                lbLogMessages.Items.Clear();
                lbLogMessages.Items.AddRange(GetLogMessages(dtLogFrom.Value, dtLogTo.Value));
            }
            else if (tabs.SelectedTab == pageValidation)
            {
                btnValidationTrash.Visible = true;
            }
            else if (tabs.SelectedTab == pageGeometries)
            {
                btnGeometryTrash.Visible = true;
            }

            lblPage.Text = tabs.SelectedTab.Text;
        }

        private string GetSpectrumParameter(string filename, string param)
        {
            string args = "\"" + filename + "\" /" + param;
            Process p = new Process();
            p.StartInfo.FileName = GetParsExecutable;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            string cout = p.StandardOutput.ReadToEnd();
            string cerr = p.StandardError.ReadToEnd();

            p.WaitForExit();

            if (p.ExitCode != 0)
                return String.Empty;

            string[] items = cout.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length < 2)
            {
                MessageBox.Show("FEIL: getpars.exe: Resultat har for få componenter (" + cout + ")");
                return String.Empty;
            }

            return items[1].Trim();
        }

        private void cboxEditSampleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sampleType = GetSampleTypeFromLabel(cboxEditSampleType.Text);
            string[] items = sampleType.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(SampleTypeFile);

                cboxEditSampleComponent.Items.Clear();
                cboxEditSampleComponent.Items.Add("");
                cboxEditSampleComponent.Text = String.Empty;
                string samplePath = "/";
                foreach (string st in items)
                {
                    samplePath += "/sampletype[@name='" + st + "']";
                    XmlNodeList componentNodes = xmlDoc.SelectNodes(samplePath + "/component");
                    foreach (XmlNode sNode in componentNodes)
                        cboxEditSampleComponent.Items.Insert(1, sNode.Attributes["name"].InnerText);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditSave_Click(object sender, EventArgs e)
        {
            String labName = tbEditLab.Text.Trim();
            Account account = cboxEditAccountName.SelectedItem as Account;
            SampleType sampleType = cboxEditSampleType.SelectedItem as SampleType;
            String sampleComponent = cboxEditSampleComponent.SelectedItem as String;

            Application.DoEvents();

            Enabled = false;
            progress.Minimum = 0;
            progress.Maximum = gridEditFiles.SelectedRows.Count;
            progress.Step = 1;
            progress.Value = 0;
            progress.Visible = true;

            foreach (DataGridViewRow row in gridEditFiles.SelectedRows)
            {
                progress.Value++;

                string filename = row.Cells["colFilename"].Value.ToString();
                if (!File.Exists(filename))
                    continue;

                if(!String.IsNullOrEmpty(labName))
                {
                    SetSpectrumParameter(filename, "SSPRSTR1", labName);
                    row.Cells["colLab"].Value = labName;
                }

                if (account != null && account.ID != Guid.Empty)
                {
                    SetSpectrumParameter(filename, "SURSTRING1", account.ID.ToString());
                    row.Cells["colAccountID"].Value = account.ID.ToString();
                    row.Cells["colAccountName"].Value = account.Name;
                }

                if (sampleType != null && !String.IsNullOrEmpty(sampleType.Value))
                {
                    SetSpectrumParameter(filename, "SUCSTRING1", sampleType.Value);
                    row.Cells["colSampleType"].Value = sampleType.Value;
                }

                sampleComponent = String.IsNullOrEmpty(sampleComponent) ? "" : sampleComponent;
                SetSpectrumParameter(filename, "SUCSTRING2", sampleComponent);
                row.Cells["colSampleComponent"].Value = sampleComponent;

                Application.DoEvents();
            }

            progress.Visible = false;
            Enabled = true;
            Application.DoEvents();
        }

        private void cboxEditAccountName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Account account = cboxEditAccountName.SelectedItem as Account;
            if (account != null && account.ID != Guid.Empty)
                tbEditAccountID.Text = account.ID.ToString();
            else tbEditAccountID.Text = "";
        }        

        void PopulateLog()
        {
            lbLogMessages.Items.Clear();
            string severity = cboxLogSeverity.Text;

            if (String.IsNullOrEmpty(severity))
                lbLogMessages.Items.AddRange(GetLogMessages(dtLogFrom.Value, dtLogTo.Value));
            else
            {
                if (severity == "Normal")
                    lbLogMessages.Items.AddRange(GetLogMessages(dtLogFrom.Value, dtLogTo.Value, 0));
                else if (severity == "Warning")
                    lbLogMessages.Items.AddRange(GetLogMessages(dtLogFrom.Value, dtLogTo.Value, 1));
                else if (severity == "Critical")
                    lbLogMessages.Items.AddRange(GetLogMessages(dtLogFrom.Value, dtLogTo.Value, 2));
            }
        }

        private void dtLogFrom_ValueChanged(object sender, EventArgs e)
        {
            PopulateLog();
        }

        private void dtLogTo_ValueChanged(object sender, EventArgs e)
        {
            PopulateLog();
        }

        private void cboxLogSeverity_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateLog();
        }

        private void BindGridValidation()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from SpectrumValidationRules", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridValidation.DataSource = dt;
            gridValidation.Columns[0].Visible = false;
        }        

        private void gridValidation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!gridValidation.IsCurrentRowDirty)
                    return;

                SqlCommand command = GetInsertOrUpdateCommand(e);
                command.ExecuteNonQuery();
                gridValidation.Update();
                gridValidation.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public SqlCommand GetInsertOrUpdateCommand(DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = gridValidation.Rows[e.RowIndex];

            string nuclideName = row.Cells["NuclideName"].Value.ToString();            

            SqlCommand command = new SqlCommand("select count(*) from SpectrumValidationRules where NuclideName = '" + nuclideName + "'", connection);
            int cnt = (int)command.ExecuteScalar();            

            if (cnt <= 0)
            {
                command.CommandText = "insert into SpectrumValidationRules values (@ID, @NuclideName, @ActivityMin, @ActivityMax, @ConfidenceMin, @CanBeAutoApproved)";
                command.Parameters.AddWithValue("@ID", Guid.NewGuid());
            }
            else
            {
                command.CommandText = "update SpectrumValidationRules set ActivityMin=@ActivityMin, ActivityMax=@ActivityMax, ConfidenceMin=@ConfidenceMin, CanBeAutoApproved=@CanBeAutoApproved where NuclideName=@NuclideName";                
            }

            bool canBeAutoApproved;
            if (row.Cells["CanBeAutoApproved"].Value == null || row.Cells["CanBeAutoApproved"].Value == DBNull.Value)
                canBeAutoApproved = false;
            else canBeAutoApproved = Convert.ToBoolean(row.Cells["CanBeAutoApproved"].Value);

            command.Parameters.AddWithValue("@NuclideName", row.Cells["NuclideName"].Value);
            command.Parameters.AddWithValue("@ActivityMin", row.Cells["ActivityMin"].Value);
            command.Parameters.AddWithValue("@ActivityMax", row.Cells["ActivityMax"].Value);
            command.Parameters.AddWithValue("@ConfidenceMin", row.Cells["ConfidenceMin"].Value);
            command.Parameters.AddWithValue("@CanBeAutoApproved", canBeAutoApproved);

            return command;
        }

        private void menuItemDeleteNuclide_Click(object sender, EventArgs e)
        {
            if (gridValidation.SelectedCells.Count <= 0)
                return;

            if (MessageBox.Show("Er du sikker på at du vil slette?", "Advarsel", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            DataGridViewCell cell = gridValidation.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            string nuclideName = row.Cells["NuclideName"].Value.ToString();
            if (String.IsNullOrEmpty(nuclideName.Trim()))
                return;

            SqlCommand command = new SqlCommand("delete from SpectrumValidationRules where NuclideName=@NuclideName", connection);
            command.Parameters.AddWithValue("@NuclideName", nuclideName);
            command.ExecuteNonQuery();            
            BindGridValidation();
        }

        private void BindGridGeometries()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("select * from SpectrumGeometryRules", connection);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridGeometries.DataSource = dt;
            gridGeometries.Columns[0].Visible = false;
        }

        private void gridGeometries_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (!gridGeometries.IsCurrentRowDirty)
                    return;

                SqlCommand command = GetInsertOrUpdateCommandForGeometries(e);
                command.ExecuteNonQuery();
                gridGeometries.Update();
                gridGeometries.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public SqlCommand GetInsertOrUpdateCommandForGeometries(DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = gridGeometries.Rows[e.RowIndex];

            string geometryName = row.Cells["Geometry"].Value.ToString();

            SqlCommand command = new SqlCommand("select count(*) from SpectrumGeometryRules where Geometry = '" + geometryName + "'", connection);
            int cnt = (int)command.ExecuteScalar();

            if (cnt <= 0)
            {
                command.CommandText = "insert into SpectrumGeometryRules values (@ID, @Geometry, @Unit, @Minimum, @Maximum)";
                command.Parameters.AddWithValue("@ID", Guid.NewGuid());
            }
            else
            {
                command.CommandText = "update SpectrumGeometryRules set Unit=@Unit, Minimum=@Minimum, Maximum=@Maximum where Geometry=@Geometry";
            }

            command.Parameters.AddWithValue("@Geometry", row.Cells["Geometry"].Value);
            command.Parameters.AddWithValue("@Unit", row.Cells["Unit"].Value);
            command.Parameters.AddWithValue("@Minimum", row.Cells["Minimum"].Value);
            command.Parameters.AddWithValue("@Maximum", row.Cells["Maximum"].Value);            

            return command;
        }

        private void menuItemDeleteGeometry_Click(object sender, EventArgs e)
        {
            if (gridGeometries.SelectedCells.Count <= 0)
                return;

            if (MessageBox.Show("Er du sikker på at du vil slette?", "Advarsel", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            DataGridViewCell cell = gridGeometries.SelectedCells[0];
            DataGridViewRow row = cell.OwningRow;
            string geometry = row.Cells["Geometry"].Value.ToString();
            if (String.IsNullOrEmpty(geometry.Trim()))
                return;

            SqlCommand command = new SqlCommand("delete from SpectrumGeometryRules where Geometry=@Geometry", connection);
            command.Parameters.AddWithValue("@Geometry", geometry);
            command.ExecuteNonQuery();
            BindGridGeometries();
        }        

        private bool SetSpectrumParameter(string filename, string param, string val)
        {
            string args = "\"" + filename + "\" /" + param + "=\"" + val + "\"";
            Process p = new Process();
            p.StartInfo.FileName = ParsExecutable;
            p.StartInfo.Arguments = args;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();

            string cout = p.StandardOutput.ReadToEnd();
            string cerr = p.StandardError.ReadToEnd();

            p.WaitForExit();

            if (p.ExitCode != 0)
                return false;

            return true;
        }
    }

    public class Account
    {
        public Account(Guid id, string name)
        {
            ID = id;
            Name = name;
        }

        public Guid ID { get; }
        public string Name { get; }
    }

    public class SampleType
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public SampleType(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
