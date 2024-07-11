using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_activity_app
{
    public partial class MaterialsForm : Form
    {
        #region Attributes
        private List<Material> _materials = new List<Material>();
        private string connectionString = "Data Source=database.db";
        #endregion

        public MaterialsForm(List<Material> materials)
        {
            InitializeComponent();
            _materials = materials;
        }

        #region Methods
        public void DisplayMaterials()
        {
            dgvMaterials.Rows.Clear();
            foreach (Material material in _materials)
            {
                int rowIndex = dgvMaterials.Rows.Add(new object[]
                {
                    material.Name,
                    material.Price,
                });
                DataGridViewRow row = dgvMaterials.Rows[rowIndex];
                row.Tag = material;
            }
        }

        //private void LoadMaterials()
        //{
        //    string query = "SELECT * FROM Materials";

        //    using (SqliteConnection connection = new SqliteConnection(connectionString))
        //    {
        //        SqliteCommand command = new SqliteCommand(query, connection);

        //        connection.Open();
        //        using (SqliteDataReader reader = command.ExecuteReader())
        //        {
        //            while (reader.Read())
        //            {
        //                long id = (long)reader["Id"];
        //                string name = (string)reader["Name"];
        //                long price = (long)reader["Price"];

        //                Material material = new Material(id, name, price);
        //                _materials.Add(material);
        //            }
        //        }
        //    }
        //}
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMaterialForm addForm = new AddMaterialForm(_materials);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                DisplayMaterials();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the material whose information you want to edit!");
                return;
            }

            DataGridViewRow row = dgvMaterials.SelectedRows[0];
            Material material = (Material)row.Tag;
            EditMaterialForm editForm = new EditMaterialForm(material, _materials);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                DisplayMaterials();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the material whose information you want to delete!");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Delete material", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataGridViewRow row = dgvMaterials.SelectedRows[0];
                Material material = (Material)row.Tag;

                string query = "DELETE FROM Materials WHERE Id=@id";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@id", material.Id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    _materials.Remove(material);
                }
                DisplayMaterials();
            }
        }

        private void MaterialeForm_Load(object sender, EventArgs e)
        {
            //LoadMaterials();
            DisplayMaterials();
        }
        #endregion

        #region Shortcuts
        private void MaterialeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                btnAdd_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString() == "E")
            {
                btnEdit_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString() == "D")
            {
                btnDelete_Click(sender, e);
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        #endregion
    }
}
