using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace lorakon_manager
{
    public partial class FormAddGeometryRule : Form
    {
        public GeometryRule Rule = new GeometryRule();

        public FormAddGeometryRule()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Rule.Id = Guid.NewGuid();
            Rule.Geometry = tbName.Text;
            Rule.Unit = tbUnit.Text;
            Rule.Minimum = Convert.ToSingle(tbMinimum.Text, CultureInfo.InvariantCulture);
            Rule.Maximum = Convert.ToSingle(tbMaximum.Text, CultureInfo.InvariantCulture);
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
