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
    public partial class ProvidersForm : Form
    {
        #region Attributes
        private List<Material> materials = new List<Material>();
        private List<Provider> providers = new List<Provider>();
        MainForm mainForm;
        private string connectionString = "Data Source=database.db";
        #endregion

        public ProvidersForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        #region Methods
        public void DisplayProviders()
        {
            dgvProviders.Rows.Clear();
            foreach (Provider provider in providers)
            {
                string materialNames = "";
                int nb = 1;
                foreach(Material m in provider.Materials)
                {
                    if (nb < provider.Materials.Count)
                    {
                        materialNames += m.Name + ", ";
                        nb++;
                    }
                    else
                    {
                        materialNames += m.Name;
                    }
                }
                int rowIndex = dgvProviders.Rows.Add(new object[]
                {
                    provider.Name,
                    provider.Founded,
                    materialNames,
                });
                DataGridViewRow row = dgvProviders.Rows[rowIndex];
                row.Tag = provider;
            }
        }

        private void LoadMaterials()
        {
            string query = "SELECT * FROM Materials";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);

                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["Id"];
                        string name = (string)reader["Name"];
                        long price = (long)reader["Price"];

                        Material material = new Material(id, name, price);
                        materials.Add(material);
                    }
                }
            }
        }
        #endregion

        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {    
            AddProviderForm addForm = new AddProviderForm(materials, providers);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                DisplayProviders();
            }
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            MaterialsForm materialsForm = new MaterialsForm(materials);
            materialsForm.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {          
            if (dgvProviders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the provider whose information you want to edit!");
                return;
            }

            DataGridViewRow row = dgvProviders.SelectedRows[0];
            Provider provider = (Provider)row.Tag;
            EditProviderForm editForm = new EditProviderForm(provider, materials, providers);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                DisplayProviders();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProviders.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the provider whose information you want to delete!");
                return;
            }
            if (MessageBox.Show("Are you sure?", "Delete providers", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataGridViewRow row = dgvProviders.SelectedRows[0];
                Provider furnizor = (Provider)row.Tag;
                providers.Remove(furnizor);
                DisplayProviders();
            }
        }

        private void ProvidersForm_Load(object sender, EventArgs e)
        {
            LoadMaterials();

            BinaryFormatter formatter = new BinaryFormatter();
            bool fileExist = File.Exists("providers.bin");
            if (!fileExist)
            {
                File.Create("providers.bin");
                MessageBox.Show("Welcome! The table of suppliers is empty.");
            }
            else
            {
                using (FileStream stream = File.OpenRead("providers.bin"))
                {
                    try
                    {
                        providers = (List<Provider>)formatter.Deserialize(stream);
                        DisplayProviders();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Welcome! The table of providers is empty.");
                    }
                }
            }
        }

        private void ProvidersForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = File.Create("providers.bin"))
            {
                if (providers.Any())
                {
                    formatter.Serialize(stream, providers);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show();
        }
        #endregion

        #region Shortcuts
        private void FurnizoriForm_KeyDown(object sender, KeyEventArgs e)
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

            if (e.Control && e.KeyCode.ToString() == "M")
            {
                btnMaterials_Click(sender, e);
            }

            if (e.KeyCode == Keys.Back)
            {
                btnBack_Click(sender, e);
                this.DialogResult = DialogResult.OK;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }
        #endregion
    }
}
