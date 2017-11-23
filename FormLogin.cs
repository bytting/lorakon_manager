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
    public partial class FormLogin : Form
    {
        public string Username, Password;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            tbUsername.Select();
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                tbPassword.Select();
            }
        }

        private void tbPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
                btnOk_Click(sender, e);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string u = tbUsername.Text.Trim();
            string p = tbPassword.Text.Trim();
            if (String.IsNullOrEmpty(u) || String.IsNullOrEmpty(p))
            {
                lblStatus.Text = "Mangler brukernavn eller passord";
                return;
            }

            Username = u;
            Password = p;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
