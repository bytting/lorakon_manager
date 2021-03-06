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
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;

namespace lorakon_manager
{
    public partial class FormShowDetails : Form
    {
        public bool HasUpdated = false;

        private LorakonManagerSettings Settings = null;
        private Guid id = Guid.Empty;
        private string GeniePath;

        public FormShowDetails(LorakonManagerSettings s, Guid sid)
        {
            InitializeComponent();
            Settings = s;    
            id = sid;
        }

        private void FormShowDetails_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            if (String.IsNullOrEmpty(Settings.WebServiceUri))
                return;

            try
            {
                string req = Settings.WebServiceUri + "/spectrum/get_spectrum_info/" + id.ToString();
                string json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

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
                tbCreateDate.Text = spec.CreateDate.ToString(Utils.PrettyDateFormat);
                tbUpdateDate.Text = spec.UpdateDate.ToString(Utils.PrettyDateFormat);
                tbAqusitionDate.Text = spec.AcquisitionDate.ToString(Utils.PrettyDateFormat);
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

                req = Settings.WebServiceUri + "/spectrum/get_spectrum_results_from_specid?specid=" + id.ToString();
                json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                List<SpectrumResult> resList = JsonConvert.DeserializeObject<List<SpectrumResult>>(json);

                resList.Sort((i1, i2) => i1.NuclideName.CompareTo(i2.NuclideName));

                gridNuclideResults.Rows.Clear();
                foreach (SpectrumResult res in resList)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.SpectrumInfoID });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.CreateDate.ToString(Utils.PrettyDateFormat) });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.UpdateDate.ToString(Utils.PrettyDateFormat) });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.NuclideName });                    
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Activity });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ActivityUncertainty });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Confidence });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.MDA });                    
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Approved });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.ApprovedIsMDA });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.ApprovedStatus });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Rejected });
                    row.Cells.Add(new DataGridViewTextBoxCell { Value = res.Comment });
                    row.Cells.Add(new DataGridViewCheckBoxCell { Value = res.Evaluated });

                    gridNuclideResults.Rows.Add(row);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                        
            GeniePath = Utils.GetGeniePath();
            if (String.IsNullOrEmpty(GeniePath))            
                MessageBox.Show("Genie2k katalog ble ikke funnet");
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
                string req = Settings.WebServiceUri + "/spectrum/get_spectrum_file_content_from_specinfo/" + id.ToString();
                string json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

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
                string req = Settings.WebServiceUri + "/spectrum/update_spectrum_info_approved?id=" + id.ToString() + "&approved=" + cbxApproved.Checked.ToString();
                string json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                req = Settings.WebServiceUri + "/spectrum/update_spectrum_info_rejected?id=" + id.ToString() + "&rejected=" + cbxRejected.Checked.ToString();
                json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                foreach (DataGridViewRow row in gridNuclideResults.Rows)
                {
                    string resId = row.Cells["colID"].Value.ToString();
                    bool approved = Convert.ToBoolean(row.Cells["colApproved"].Value);
                    bool rejected = Convert.ToBoolean(row.Cells["colRejected"].Value);
                    bool ismda = Convert.ToBoolean(row.Cells["colIsMDA"].Value);

                    req = Settings.WebServiceUri + "/spectrum/update_spectrum_result_approved?id=" + resId + "&approved=" + approved.ToString();
                    json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                    req = Settings.WebServiceUri + "/spectrum/update_spectrum_result_rejected?id=" + resId + "&rejected=" + rejected.ToString();
                    json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                    req = Settings.WebServiceUri + "/spectrum/update_spectrum_result_ismda?id=" + resId + "&ismda=" + ismda.ToString();
                    json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);

                    req = Settings.WebServiceUri + "/spectrum/update_spectrum_result_evaluated?id=" + resId + "&evaluated=true";
                    json = WebApi.MakeGetRequest(req, Utils.Username, Utils.Password);
                }

                HasUpdated = true;
                lblStatus.Text = DateTime.Now.ToString(Utils.PrettyDateFormat) + " - Spektrum " + id + " oppdatert";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
