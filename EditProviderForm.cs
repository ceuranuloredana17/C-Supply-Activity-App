using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_activity_app
{
    public partial class EditProviderForm : Form
    {
        #region Attributes
        private List<Material> materials = new List<Material>();
        private List<Provider> providers = new List<Provider>();
        private Provider provider = new Provider();
        #endregion

        public EditProviderForm(Provider provider, List<Material> materials, List<Provider> providers)
        {
            InitializeComponent();
            this.materials = materials;
            this.provider = provider;
            this.providers = providers;
        }

        #region Events
        private void EditProvidersForm_Load(object sender, EventArgs e)
        {
            tbName.Text = provider.Name;
            tbYear.Text = provider.Founded.ToString();
            foreach (Material material in materials)
            {
                clbMaterials.Items.Add(material.Name);
            }


            for (int i = 0; i < clbMaterials.Items.Count; i++)
            {
                string item = clbMaterials.Items[i].ToString();
                foreach (Material material in provider.Materials)
                {
                    if (item == material.Name)
                    {
                        clbMaterials.SetItemChecked(i, true);
                    }
                }

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            bool test = false;
            foreach (Provider p in providers)
            {
                if (p.Name == tbName.Text && p.Name != provider.Name)
                {
                    test = true;
                }
            }

            if (!test)
            {
                if (tbName.Text == "" || tbYear.Text == "" || clbMaterials.CheckedItems.Count == 0)
                {
                    MessageBox.Show("You have not filled all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                provider.Name = tbName.Text;
                provider.Founded = Convert.ToInt32(tbYear.Text);

                List<Material> selectedMaterials = new List<Material>();
                foreach (string s in clbMaterials.CheckedItems)
                {
                    foreach (Material m in materials)
                    {
                        if (s == m.Name)
                        {
                            selectedMaterials.Add(m);
                        }
                    }
                }
                provider.Materials = selectedMaterials;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("The provider already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validations
        private void tbName_Validating(object sender, CancelEventArgs e)
        {
            if (tbName.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbName, "The name field must not be empty!");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(tbName.Text, @"^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(tbName, "The name must contain only letters!");
                e.Cancel = true;
            }
        }

        private void tbName_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbName, null);
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            int year = 0;
            bool numeric = int.TryParse(tbYear.Text, out year);

            if (tbYear.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbYear, "The field of founded year must not be empty!");
                e.Cancel = true;
            }
            else if (!numeric)
            {
                errorProvider1.SetError(tbYear, "The field of founded year must contain only numbers!");
                e.Cancel = true;
            }
            else if (year <= 1600)
            {
                errorProvider1.SetError(tbYear, "The year must be more recent than the year 1600!");
                e.Cancel = true;
            }
        }

        private void tbYear_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbYear, null);
        }

        private void clbMaterials_Validating(object sender, CancelEventArgs e)
        {
            if (clbMaterials.CheckedItems.Count == 0)
            {
                errorProvider1.SetError(clbMaterials, "You must check at least one material!");
                e.Cancel = true;
            }
        }

        private void clbMaterials_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(clbMaterials, null);
        }
        #endregion

        #region Shortcuts
        private void EditProvidersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                btnOk_Click(sender, e);
            }
        }
        #endregion
    }
}
