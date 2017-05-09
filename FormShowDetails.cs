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
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace lorakon_manager
{
    public partial class FormShowDetails : Form
    {
        SqlConnection connection = null;
        Guid id = Guid.Empty;

        // Registry key for the Genie2k installation path
        const string GenieRegistry = @"SOFTWARE\Wow6432Node\Canberra Industries, Inc.\Genie-2000 Environment";
        string GeniePath;

        public FormShowDetails(SqlConnection conn, Guid sid)
        {
            InitializeComponent();
            connection = conn;
            id = sid;
        }

        private void FormShowDetails_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select a.vchName, si.* from Account a, SpectrumInfo si where si.id = @SID and a.ID = si.AccountID", connection);
            command.Parameters.AddWithValue("@SID", id);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                    return;

                reader.Read();
                tbLabName.Text = reader["vchName"].ToString();                
                tbRefDate.Text = reader["ReferenceDate"].ToString();
                tbOperator.Text = reader["Operator"].ToString();
                tbExternalID.Text = reader["ExternalID"].ToString();
                tbSampleType.Text = reader["SampleType"].ToString();
                tbSigma.Text = reader["Sigma"].ToString();
                tbComponent.Text = reader["SampleComponent"].ToString();
                tbLocType.Text = reader["LocationType"].ToString();
                tbLocation.Text = reader["Location"].ToString();
                tblatitude.Text = reader["Latitude"].ToString();
                tbLongitude.Text = reader["Longitude"].ToString();
                tbAltitude.Text = reader["Altitude"].ToString();
                tbCreateDate.Text = reader["CreateDate"].ToString();
                tbUpdateDate.Text = reader["UpdateDate"].ToString();
                tbAqusitionDate.Text = reader["AcquisitionDate"].ToString();
                tbBackgroundFile.Text = reader["BackgroundFile"].ToString();                
                tbLibraryFile.Text = reader["LibraryFile"].ToString();
                tbCommunity.Text = reader["Community"].ToString();
                tbSampleWeight.Text = reader["SampleWeight"].ToString();
                tbSampleWeightUnit.Text = reader["SampleWeightUnit"].ToString();
                tbGeometry.Text = reader["SampleGeometry"].ToString();
                cbxApproved.Checked = Convert.ToBoolean(reader["Approved"]);                
                cbxRejected.Checked = Convert.ToBoolean(reader["Rejected"]);
                tbLiveTime.Text = reader["Livetime"].ToString();
                tbComment.Text = reader["Comment"].ToString();
            }
            
            command.CommandText = "select * from SpectrumResult where SpectrumInfoID = @SID";
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            gridNuclideResults.DataSource = dt;

            foreach (DataGridViewColumn col in gridNuclideResults.Columns)
                col.ReadOnly = true;

            gridNuclideResults.Columns[0].Visible = false;
            gridNuclideResults.Columns[1].Visible = false;

            gridNuclideResults.Columns[gridNuclideResults.Columns.Count - 2].ReadOnly = false;
            gridNuclideResults.Columns[gridNuclideResults.Columns.Count - 3].ReadOnly = false;            
            gridNuclideResults.Columns[gridNuclideResults.Columns.Count - 5].ReadOnly = false;

            // Check and initialize environment
            GeniePath = GetGeniePath();
            if (String.IsNullOrEmpty(GeniePath))
            {
                MessageBox.Show("Genie2k katalog ble ikke funnet");                
            }
        }

        private string GetGeniePath()
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(GenieRegistry, false);
            String value = (String)rk.GetValue("GENIE2K");
            if (!String.IsNullOrEmpty(value))
                return value;

            if (Directory.Exists("C:\\GENIE2K\\"))
                return "C:\\GENIE2K\\";

            return String.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOpenInGenie_Click(object sender, EventArgs e)
        {
            if (gridNuclideResults.SelectedRows.Count < 1)
                return;

            string genieExecutable = GeniePath + "EXEFILES\\mvcg.exe";
            if (!File.Exists(genieExecutable))
            {
                MessageBox.Show("Finner ikke Genie programmet");
                return;
            }

            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand("select SpectrumFileContent from SpectrumFile where SpectrumInfoID = @SID", connection);
                command.Parameters.AddWithValue("@SID", id);
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    byte[] content = (byte[])reader["SpectrumFileContent"];
                    string filename = Path.GetTempFileName() + ".cnf";
                    File.WriteAllBytes(filename, content);
                    Process.Start(genieExecutable, filename);
                }                
            }
            finally
            {
                if(reader != null)
                    reader.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
