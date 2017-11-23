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
    public partial class FormAddGeometryRule : Form
    {
        private bool Updating = false;
        public GeometryRule Rule = new GeometryRule();

        public FormAddGeometryRule()
        {
            InitializeComponent();            
        }

        public FormAddGeometryRule(Guid id, string geometryName, string unit, float minimum, float maximum)
        {
            InitializeComponent();

            Updating = true;
            Rule.Id = id;
            tbName.Text = geometryName;
            tbUnit.Text = unit;
            tbMinimum.Text = minimum.ToString();
            tbMaximum.Text = maximum.ToString();
        }

        private void FormAddGeometryRule_Load(object sender, EventArgs e)
        {
            tbName.KeyPress += CustomEvents.Alpha_KeyPress;
            tbUnit.KeyPress += CustomEvents.Alpha_KeyPress;
            tbMinimum.KeyPress += CustomEvents.Numeric_KeyPress;
            tbMaximum.KeyPress += CustomEvents.Numeric_KeyPress;
            tbName.Select();
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
            Rule.Geometry = tbName.Text;
            Rule.Unit = tbUnit.Text;
            Rule.Minimum = Convert.ToSingle(tbMinimum.Text);
            Rule.Maximum = Convert.ToSingle(tbMaximum.Text);
            DialogResult = DialogResult.OK;
            Close();
        }        
    }
}
