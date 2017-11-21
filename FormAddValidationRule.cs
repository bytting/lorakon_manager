using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace lorakon_manager
{
    public partial class FormAddValidationRule : Form
    {
        public ValidationRule Rule = new ValidationRule();

        public FormAddValidationRule()
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
            Rule.NuclideName = tbNuclideName.Text;
            Rule.ActivityMin = Convert.ToSingle(tbActivityMin.Text, CultureInfo.InvariantCulture);
            Rule.ActivityMax = Convert.ToSingle(tbActivityMax.Text, CultureInfo.InvariantCulture);
            Rule.CanBeAutoApproved = cbCanBeAutoApproved.Checked;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
