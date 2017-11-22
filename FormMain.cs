//  lorakon_manager - Manager for Lorakon database
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
using System.Drawing;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;

namespace lorakon_manager
{
    public partial class FormMain : Form
    {
        private string ParsExecutable, GetParsExecutable;

        string InstallationDirectory, GeniePath;
        private static string SettingsPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments) + Path.DirectorySeparatorChar + "LorakonManager";
        private static string SettingsFile = SettingsPath + Path.DirectorySeparatorChar + "Settings.xml";
        private string SampleTypeFile = SettingsPath + Path.DirectorySeparatorChar + "sample-types.xml";

        private LorakonManagerSettings Settings = new LorakonManagerSettings();

        List<ValidationRule> ValidationRules = new List<ValidationRule>();

        public FormMain()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
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

            GeniePath = Utils.GetGeniePath();
            if (String.IsNullOrEmpty(GeniePath))
                MessageBox.Show("Genie2k katalog ble ikke funnet");
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
                string req = Settings.WebServiceUri + "/api/spectrum/get_all_accounts_basic";
                string json = WebApi.MakeGetRequest(req);

                List<AccountBasic> accs = JsonConvert.DeserializeObject<List<AccountBasic>>(json);

                cboxAccount.Items.Add(new AccountBasic(Guid.Empty, ""));
                cboxEditAccountName.Items.Add(new AccountBasic(Guid.Empty, ""));
                foreach(AccountBasic acc in accs)
                {
                    cboxAccount.Items.Add(new AccountBasic(acc.ID, acc.Username));
                    cboxEditAccountName.Items.Add(new AccountBasic(acc.ID, acc.Username));
                }

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

        public void LoadSettings()
        {
            if (!File.Exists(SettingsFile))
                SaveSettings();

            // Deserialize settings from file
            using (StreamReader sr = new StreamReader(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(Settings.GetType());
                Settings = x.Deserialize(sr) as LorakonManagerSettings;
            }

            if (!String.IsNullOrEmpty(Settings.WebServiceUri) && Settings.WebServiceUri.EndsWith("/"))
                Settings.WebServiceUri = Settings.WebServiceUri.TrimEnd(new char[] { '/' });

            tbSettingsUrl.Text = Settings.WebServiceUri;
        }

        private void SaveSettings()
        {
            // Serialize settings to file
            using (StreamWriter sw = new StreamWriter(SettingsFile))
            {
                XmlSerializer x = new XmlSerializer(Settings.GetType());
                x.Serialize(sw, Settings);
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
            string req = Settings.WebServiceUri + "/api/spectrum/get_log_entries?from=" + fromDate.ToString("yyyyMMdd_hhmmss") + "&to=" + toDate.ToString("yyyyMMdd_hhmmss");
            string json = WebApi.MakeGetRequest(req);
            List<LogEntry> ents = JsonConvert.DeserializeObject<List<LogEntry>>(json);

            List<string> logMessages = new List<string>();
            foreach (LogEntry ent in ents)            
                logMessages.Add(ent.CreateDate.ToString("yyyy.MM.dd HH:mm:ss") + " [" + LogSeverityString(ent.Severity) + "]: " + ent.Message);            

            return logMessages.ToArray();
        }

        private string[] GetLogMessages(DateTime fromDate, DateTime toDate, int severity)
        {
            string req = Settings.WebServiceUri + "/api/spectrum/get_log_entries_severity?from=" + fromDate.ToString("yyyyMMdd_hhmmss") + "&to=" + toDate.ToString("yyyyMMdd_hhmmss") + "&severity=" + severity.ToString();
            string json = WebApi.MakeGetRequest(req);
            List<LogEntry> ents = JsonConvert.DeserializeObject<List<LogEntry>>(json);

            List<string> logMessages = new List<string>();
            foreach (LogEntry ent in ents)
                logMessages.Add(ent.CreateDate.ToString("yyyy.MM.dd HH:mm:ss") + " [" + LogSeverityString(ent.Severity) + "]: " + ent.Message);

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
            SaveSettings();
        }

        private void populateGrid()
        {
            // /api/spectrum/get_spectrum_info_latest?from=20100101_120000&to=20171201_120000&accid=&samp=&appr=true&rej=false

            if (String.IsNullOrEmpty(Settings.WebServiceUri))
                return;

            string fromString = "from=" + dtFrom.Value.ToString("yyyyMMdd_hhmmss");
            string toString = "to=" + dtTo.Value.ToString("yyyyMMdd_hhmmss");
            string accidString = "accid=";
            if (!String.IsNullOrEmpty(cboxAccount.Text))
            {
                AccountBasic a = cboxAccount.SelectedItem as AccountBasic;
                accidString += a.ID.ToString();
            }
            string sampString = "samp=";
            if (!String.IsNullOrEmpty(tbSearchSampleType.Text))
            {
                sampString += "%" + tbSearchSampleType.Text.Trim() + "%";
            }
            string apprString = "appr=" + ((cbApproved.Checked) ? "true" : "false");
            string rejString = "rej=" + ((cbRejected.Checked) ? "true" : "false");

            string req = Settings.WebServiceUri + "/api/spectrum/get_spectrum_info_latest?" + fromString + "&" + toString + "&" + accidString + "&" + sampString + "&" + apprString + "&" + rejString;

            string json = WebApi.MakeGetRequest(req);
            
            List<SpectrumInfo> specs = JsonConvert.DeserializeObject<List<SpectrumInfo>>(json);

            gridSearch.Rows.Clear();

            foreach (SpectrumInfo spec in specs)
            {
                DataGridViewRow row = new DataGridViewRow();

                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.ID });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.AccountName });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.Operator });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.CreateDate.ToString(Utils.PrettyDateFormat) });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.AcquisitionDate.ToString(Utils.PrettyDateFormat) });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.ReferenceDate.ToString(Utils.PrettyDateFormat) });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.SampleType });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.SampleComponent });
                row.Cells.Add(new DataGridViewCheckBoxCell { Value = spec.Approved });
                row.Cells.Add(new DataGridViewTextBoxCell { Value = spec.ApprovedStatus });
                row.Cells.Add(new DataGridViewCheckBoxCell { Value = spec.Rejected });

                gridSearch.Rows.Add(row);
            }
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
        
        private void menuItemOpenFiles_Click(object sender, EventArgs e)
        {            
            if(ofd.ShowDialog() == DialogResult.OK)
            {
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

                        string req = Settings.WebServiceUri + "/api/spectrum/get_account_name/" + id.ToString();
                        string json = WebApi.MakeGetRequest(req);
                        AccountName accName = JsonConvert.DeserializeObject<AccountName>(json);
                        if (!String.IsNullOrEmpty(accName.Name))
                            accountName = accName.Name;
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
            btnBack.Visible = true;
            btnSpectrumDelete.Visible = false;
            separatorMain.Visible = true;
            menuItemOpenFiles.Visible = false;
            btnEditOpen.Visible = false;
            btnValidationAdd.Visible = false;
            btnValidationEdit.Visible = false;
            btnValidationTrash.Visible = false;
            btnGeometryAdd.Visible = false;
            btnGeometryEdit.Visible = false;
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
                btnValidationAdd.Visible = true;
                btnValidationEdit.Visible = true;
                btnValidationTrash.Visible = true;
            }
            else if (tabs.SelectedTab == pageGeometries)
            {
                btnGeometryAdd.Visible = true;
                btnGeometryEdit.Visible = true;
                btnGeometryTrash.Visible = true;
            }
            else if(tabs.SelectedTab == pageSearch)
            {
                btnSpectrumDelete.Visible = true;
            }
            else if(tabs.SelectedTab == pageMain)
            {
                btnBack.Visible = false;
                separatorMain.Visible = false;
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
            AccountBasic account = cboxEditAccountName.SelectedItem as AccountBasic;
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
                    row.Cells["colAccountName"].Value = account.Username;
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
            AccountBasic account = cboxEditAccountName.SelectedItem as AccountBasic;
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
            string req = Settings.WebServiceUri + "/api/spectrum/get_all_validation_rules";
            string json = WebApi.MakeGetRequest(req);
            List<ValidationRule> rules = JsonConvert.DeserializeObject<List<ValidationRule>>(json);
            gridValidation.DataSource = rules;
            gridValidation.Columns[0].Visible = false;
        }        
        
        private void menuItemDeleteNuclide_Click(object sender, EventArgs e)
        {
            if (gridValidation.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Er du sikker på at du vil slette?", "Advarsel", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            
            DataGridViewRow row = gridValidation.SelectedRows[0];
            string nuclideName = row.Cells["NuclideName"].Value.ToString();
            if (String.IsNullOrEmpty(nuclideName.Trim()))
                return;

            string req = Settings.WebServiceUri + "/api/spectrum/delete_validation_rule?name=" + nuclideName;
            string json = WebApi.MakeGetRequest(req);
            
            BindGridValidation();
        }

        private void BindGridGeometries()
        {
            string req = Settings.WebServiceUri + "/api/spectrum/get_all_geometry_rules";
            string json = WebApi.MakeGetRequest(req);
            List<GeometryRule> rules = JsonConvert.DeserializeObject<List<GeometryRule>>(json);
            gridGeometries.DataSource = rules;
            gridGeometries.Columns[0].Visible = false;
        }

        private void menuItemDeleteGeometry_Click(object sender, EventArgs e)
        {
            if (gridGeometries.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Er du sikker på at du vil slette?", "Advarsel", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            DataGridViewRow row = gridGeometries.SelectedRows[0];
            string geometry = row.Cells["Geometry"].Value.ToString();
            if (String.IsNullOrEmpty(geometry.Trim()))
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/delete_geometry_rule?name=" + geometry;
                string json = WebApi.MakeGetRequest(req);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            BindGridGeometries();
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMain;
        }

        private void btnSettingsOk_Click(object sender, EventArgs e)
        {
            Settings.WebServiceUri = tbSettingsUrl.Text;
            SaveSettings();
            tabs.SelectedTab = pageMain;
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            tbSettingsUrl.Text = Settings.WebServiceUri;
            tabs.SelectedTab = pageSettings;
        }

        private void menuItemNewValidationRule_Click(object sender, EventArgs e)
        {
            FormAddValidationRule form = new FormAddValidationRule();
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/insert_validation_rule";
                WebApi.MakePostRequest(req, form.Rule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BindGridValidation();
        }

        private void menuItemNewGeometryRule_Click(object sender, EventArgs e)
        {
            FormAddGeometryRule form = new FormAddGeometryRule();
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/insert_geometry_rule";
                WebApi.MakePostRequest(req, form.Rule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BindGridGeometries();
        }

        private void menuItemEditValidationRule_Click(object sender, EventArgs e)
        {
            if (gridValidation.SelectedRows.Count < 1)
                return;
            
            DataGridViewRow row = gridValidation.SelectedRows[0];
            Guid Id = new Guid(row.Cells["ID"].Value.ToString());
            if (Id == Guid.Empty)
                return;
            string nuclideName = row.Cells["NuclideName"].Value.ToString();
            float activityMin = Convert.ToSingle(row.Cells["ActivityMin"].Value);
            float activityMax = Convert.ToSingle(row.Cells["ActivityMax"].Value);
            float confidenceMin = Convert.ToSingle(row.Cells["ConfidenceMin"].Value);
            bool canBeAutoApproved = Convert.ToBoolean(row.Cells["CanBeAutoApproved"].Value);

            FormAddValidationRule form = new FormAddValidationRule(Id, nuclideName, activityMin, activityMax, confidenceMin, canBeAutoApproved);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/update_validation_rule?id=" + Id.ToString();
                WebApi.MakePostRequest(req, form.Rule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BindGridValidation();
        }

        private void menuItemEditGeometryRule_Click(object sender, EventArgs e)
        {
            if (gridGeometries.SelectedRows.Count <= 0)
                return;
            
            DataGridViewRow row = gridGeometries.SelectedRows[0];
            Guid Id = new Guid(row.Cells["ID"].Value.ToString());
            if (Id == Guid.Empty)
                return;
            string geometryName = row.Cells["Geometry"].Value.ToString();
            string unit = row.Cells["Unit"].Value.ToString();
            float min = Convert.ToSingle(row.Cells["Minimum"].Value);
            float max = Convert.ToSingle(row.Cells["Maximum"].Value);

            FormAddGeometryRule form = new FormAddGeometryRule(Id, geometryName, unit, min, max);
            if (form.ShowDialog() == DialogResult.Cancel)
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/update_geometry_rule?id=" + Id.ToString();
                WebApi.MakePostRequest(req, form.Rule);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            BindGridGeometries();
        }

        private void menuItemShowDetails_Click(object sender, EventArgs e)
        {
            if (gridSearch.SelectedRows.Count < 1)
                return;

            DataGridViewRow row = gridSearch.SelectedRows[0];
            Guid id = new Guid(row.Cells["ID"].Value.ToString());
            FormShowDetails form = new FormShowDetails(Settings, id);
            form.ShowDialog();
        }

        private void menuItemDeleteSpectrum_Click(object sender, EventArgs e)
        {
            if (gridSearch.SelectedRows.Count < 1)
                return;

            if (MessageBox.Show("Er du sikker på at du vil slette?", "Advarsel", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                DataGridViewRow row = gridSearch.SelectedRows[0];
                Guid Id = new Guid(row.Cells["ID"].Value.ToString());

                string req = Settings.WebServiceUri + "/api/spectrum/delete_spectrum_info/" + Id.ToString();
                string json = WebApi.MakeGetRequest(req);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            populateGrid();
        }

        private void menuItemOpenSpectrum_Click(object sender, EventArgs e)
        {            
            if (gridSearch.SelectedRows.Count < 1)
                return;
            
            DataGridViewRow row = gridSearch.SelectedRows[0];
            Guid Id = new Guid(row.Cells["ID"].Value.ToString());
            if (Id == Guid.Empty)
                return;

            string genieExecutable = GeniePath + "EXEFILES\\mvcg.exe";
            if (!File.Exists(genieExecutable))
            {
                MessageBox.Show("Finner ikke Genie programmet");
                return;
            }

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/get_spectrum_file_content_from_specinfo/" + Id.ToString();
                string json = WebApi.MakeGetRequest(req);

                SpectrumFileContent cont = JsonConvert.DeserializeObject<SpectrumFileContent>(json);
                byte[] content = Convert.FromBase64String(cont.Base64Data);
                string filename = Path.GetTempFileName() + ".cnf";
                File.WriteAllBytes(filename, content);
                Process.Start(genieExecutable, filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
}
