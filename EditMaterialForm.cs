using Microsoft.Data.Sqlite;
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
    public partial class EditMaterialForm : Form
    {
        #region Attributes
        private Material material = new Material();
        private List<Material> materials = new List<Material>();
        private string connectionString = "Data Source=database.db";
        #endregion

        public EditMaterialForm(Material material, List<Material> materials)
        {
            InitializeComponent();
            this.material = material;
            this.materials = materials;
        }

        #region Methods
        public void EditMaterial(Material _material)
        {
            string query = "UPDATE Materials SET Name = @name, Price = @price WHERE Id = @id;";


            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);

                command.Parameters.AddWithValue("@name", _material.Name);
                command.Parameters.AddWithValue("@price", _material.Price);
                command.Parameters.AddWithValue("@id", _material.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Events
        private void EditMaterialForm_Load(object sender, EventArgs e)
        {
            tbName.Text = material.Name;
            tbPrice.Text = material.Price.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (tbName.Text == "" || tbPrice.Text == "")
            {
                MessageBox.Show("You have not filled all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool test = false;
            foreach (Material m in materials)
            {
                if (m.Name == tbName.Text && m.Name != material.Name)
                {
                    test = true;
                }
            }

            if (!test)
            {
                material.Name = tbName.Text;
                material.Price = Convert.ToInt32(tbPrice.Text);
                EditMaterial(material);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("This material already exists !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tbPrice_Validating(object sender, CancelEventArgs e)
        {
            int price = 0;
            bool numeric = int.TryParse(tbPrice.Text, out price);

            if (tbPrice.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(tbPrice, "The price field must not be empty!");
                e.Cancel = true;
            }
            else if (!numeric)
            {
                errorProvider1.SetError(tbPrice, "The price field must contain only numbers!");
                e.Cancel = true;
            }
            else if (price <= 0)
            {
                errorProvider1.SetError(tbPrice, "The price must not be less than 1!");
                e.Cancel = true;
            }
        }

        private void tbPrice_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbPrice, null);
        }
        #endregion

        #region Shortcuts
        private void EditMaterialForm_KeyDown(object sender, KeyEventArgs e)
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
