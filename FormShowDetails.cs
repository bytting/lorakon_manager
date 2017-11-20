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
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using Microsoft.Win32;

namespace lorakon_manager
{
    public partial class FormShowDetails : Form
    {        
        LorakonManagerSettings Settings = null;
        Guid id = Guid.Empty;

        // Registry key for the Genie2k installation path
        const string GenieRegistry = @"SOFTWARE\Wow6432Node\Canberra Industries, Inc.\Genie-2000 Environment";
        string GeniePath;

        public FormShowDetails(LorakonManagerSettings s, Guid sid)
        {
            InitializeComponent();
            Settings = s;    
            id = sid;
        }

        private void FormShowDetails_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Settings.WebServiceUri))
                return;

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/get_spectrum_info/" + id.ToString();
                string json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                SpectrumInfo spec = JsonConvert.DeserializeObject<SpectrumInfo>(json);

                tbLabName.Text = spec.Laboratory;
                tbRefDate.Text = spec.ReferenceDate.ToString();
                tbOperator.Text = spec.Operator;
                tbExternalID.Text = spec.ExternalID;
                tbSampleType.Text = spec.SampleType;
                tbSigma.Text = spec.Sigma.ToString();
                tbComponent.Text = spec.SampleComponent;
                tbLocType.Text = spec.LocationType;
                tbLocation.Text = spec.Location;
                tblatitude.Text = spec.Latitude.ToString();
                tbLongitude.Text = spec.Longitude.ToString();
                tbAltitude.Text = spec.Altitude.ToString();
                tbCreateDate.Text = spec.CreateDate.ToString();
                tbUpdateDate.Text = spec.UpdateDate.ToString();
                tbAqusitionDate.Text = spec.AcquisitionDate.ToString();
                tbBackgroundFile.Text = spec.BackgroundFile;
                tbLibraryFile.Text = spec.LibraryFile;
                tbCommunity.Text = spec.Community;
                tbSampleWeight.Text = spec.SampleWeight.ToString();
                tbSampleWeightUnit.Text = spec.SampleWeightUnit;
                tbGeometry.Text = spec.SampleGeometry;
                cbxApproved.Checked = spec.Approved;
                cbxRejected.Checked = spec.Rejected;
                tbLiveTime.Text = spec.Livetime.ToString();
                tbComment.Text = spec.Comment;

                req = Settings.WebServiceUri + "/api/spectrum/get_spectrum_results_from_specid?specid=" + id.ToString();
                json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                List<SpectrumResult> resList = JsonConvert.DeserializeObject<List<SpectrumResult>>(json);

                gridNuclideResults.Rows.Clear();
                foreach (SpectrumResult res in resList)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.SpectrumInfoID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.CreateDate });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.UpdateDate });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.NuclideName });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Confidence });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Activity });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ActivityUncertainty });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.MDA });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Evaluated });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Approved });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.ApprovedIsMDA });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ApprovedStatus });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Rejected });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Comment });

                    gridNuclideResults.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            // FIXME: Check and initialize environment
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

            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/get_spectrum_file_content_from_specinfo/" + id.ToString();
                string json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                SpectrumFileContent cont = JsonConvert.DeserializeObject<SpectrumFileContent>(json);
                byte[] content = Convert.FromBase64String(cont.Base64Data);
                string filename = Path.GetTempFileName() + ".cnf";
                File.WriteAllBytes(filename, content);
                Process.Start(genieExecutable, filename);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string req = Settings.WebServiceUri + "/api/spectrum/update_spectrum_info_approved?id=" + id.ToString() + "&approved=" + cbxApproved.Checked.ToString();
                string json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                req = Settings.WebServiceUri + "/api/spectrum/update_spectrum_info_rejected?id=" + id.ToString() + "&rejected=" + cbxRejected.Checked.ToString();
                json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                foreach (DataGridViewRow row in gridNuclideResults.Rows)
                {
                    string id = row.Cells["colID"].Value.ToString();
                    bool approved = Convert.ToBoolean(row.Cells["colApproved"].Value);
                    bool rejected = Convert.ToBoolean(row.Cells["colRejected"].Value);

                    req = Settings.WebServiceUri + "/api/spectrum/update_spectrum_result_approved?id=" + id + "&approved=" + approved.ToString();
                    json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                    req = Settings.WebServiceUri + "/api/spectrum/update_spectrum_result_rejected?id=" + id + "&rejected=" + rejected.ToString();
                    json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);

                    req = Settings.WebServiceUri + "/api/spectrum/update_spectrum_result_evaluated?id=" + id + "&evaluated=true";
                    json = WebApi.MakeRequest(req, WebRequestMethods.Http.Get);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
