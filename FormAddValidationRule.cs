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
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace lorakon_manager
{
    public partial class FormAddValidationRule : Form
    {
        private bool Updating = false;
        public ValidationRule Rule = new ValidationRule();

        public FormAddValidationRule()
        {
            InitializeComponent();
        }

        public FormAddValidationRule(Guid id, string nuclideName, float activityMin, float activityMax, float confidenceMin, bool canBeAutoApproved)
        {
            InitializeComponent();
            Updating = true;
            Rule.Id = id;
            tbNuclideName.Text = nuclideName;
            tbActivityMin.Text = activityMin.ToString();
            tbActivityMax.Text = activityMax.ToString();
            tbConfidenceMin.Text = confidenceMin.ToString();
            cbCanBeAutoApproved.Checked = canBeAutoApproved;
        }        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {   
            if(!Updating)         
                Rule.Id = Guid.NewGuid();
            Rule.NuclideName = tbNuclideName.Text;
            Rule.ActivityMin = Convert.ToSingle(tbActivityMin.Text);
            Rule.ActivityMax = Convert.ToSingle(tbActivityMax.Text);
            Rule.ConfidenceMin = Convert.ToSingle(tbConfidenceMin.Text);
            Rule.CanBeAutoApproved = cbCanBeAutoApproved.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
