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
using System.Xml.Serialization;

namespace supply_activity_app
{
    public partial class MainForm : Form
    {
        #region Attributes
        private List<Contract> contracts = new List<Contract>();
        private List<Provider> providers = new List<Provider>();
        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private string connectionString = "Data Source=database.db";
        LoginForm loginForm;
        private int printIndex = 0;
        #endregion

        public MainForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        #region Methods
        public void DisplayContracts()
        {
            dgvContracts.Rows.Clear();

            foreach (Contract contract in contracts)
            {
                int rowIndex = dgvContracts.Rows.Add(new object[]
                {
                    contract.Provider.Name,
                    contract.SignDate,
                    contract.Validity,
                    contract.Value
                });

                DataGridViewRow row = dgvContracts.Rows[rowIndex];
                row.Tag = contract;
                if(contract.signDate.AddYears((int)contract.Validity) < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void LoadContracts()
        {
            string query = "SELECT * FROM Contracts";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);

                connection.Open();
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        long id = (long)reader["Id"];
                        string providerName = (string)reader["Provider"];
                        Provider provider = new Provider();
                        bool test = false;
                        foreach (Provider p in providers)
                        {
                            if (providerName == p.Name)
                            {
                                provider = p;
                                test = true;
                            }
                        }
                        DateTime signDate = DateTime.Parse((string)reader["SignDate"]);
                        long validity = (long)reader["Validity"];
                        long value = (long)reader["Value"];

                        if (test)
                        {
                            Contract contract = new Contract(id, provider, signDate, validity, value);
                            contracts.Add(contract);
                        }
                    }
                }
            }
        }

        private void DeleteContract()
        {
            if (dgvContracts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select the contract whose information you want to delete!");
                return;
            }

            if (MessageBox.Show("Are you sure?", "Delete contract", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataGridViewRow row = dgvContracts.SelectedRows[0];
                Contract contract = (Contract)row.Tag;

                string query = "DELETE FROM Contracts WHERE Id=@id";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@id", contract.Id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    contracts.Remove(contract);
                }
                DisplayContracts();
            }
        }
        #endregion

        #region Events
        private void btnProviders_Click(object sender, EventArgs e)
        {
            ProvidersForm providersForm = new ProvidersForm(this);
            this.Hide();
            if (providersForm.ShowDialog() == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            bool fileExist = File.Exists("providers.bin");
            if (!fileExist)
            {
                MessageBox.Show("There are currently no providers in the list of providers. You must add at least one provider!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using (FileStream stream = File.OpenRead("providers.bin"))
                {
                    try
                    {
                        providers = (List<Provider>)formatter.Deserialize(stream);
                        AddContractForm addForm = new AddContractForm(contracts, providers);
                        if (addForm.ShowDialog() == DialogResult.OK)
                        {
                            DisplayContracts();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There are currently no providers in the list of providers. You must add at least one provider!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvContracts_MouseDown(object sender, MouseEventArgs e)
        {
            rowIndexFromMouseDown = dgvContracts.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1)
            {
                Size dragSize = SystemInformation.DragSize;

                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                               e.Y - (dragSize.Height / 2)),
                                    dragSize);
            }
            else
                dragBoxFromMouseDown = Rectangle.Empty;
        }

        private void dgvContracts_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                if (dragBoxFromMouseDown != Rectangle.Empty &&
                    !dragBoxFromMouseDown.Contains(e.X, e.Y))
                {
                    dgvContracts.DoDragDrop(dgvContracts.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Delete contract", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                DataGridViewRow row = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                Contract contract = (Contract)row.Tag;

                string query = "DELETE FROM Contracts WHERE Id=@id";
                using (SqliteConnection connection = new SqliteConnection(connectionString))
                {
                    SqliteCommand command = new SqliteCommand(query, connection);
                    command.Parameters.AddWithValue("@id", contract.Id);

                    connection.Open();
                    command.ExecuteNonQuery();

                    contracts.Remove(contract);
                }

                DisplayContracts();
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.dgvContracts.SelectedRows.Count > 0)
            {
                StringBuilder ClipboardBuillder = new StringBuilder();
                foreach (DataGridViewRow Row in dgvContracts.SelectedRows)
                {
                    foreach (DataGridViewColumn Column in dgvContracts.Columns)
                    {
                        ClipboardBuillder.Append(Row.Cells[Column.Index].FormattedValue.ToString() + ", ");
                    }
                    ClipboardBuillder.Length -= 2;
                    ClipboardBuillder.AppendLine();
                }

                Clipboard.SetText(ClipboardBuillder.ToString());
            }
            else
            {
                MessageBox.Show("This function is only valid if you select the whole row!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            menuStrip1.BackColor = Color.FromArgb(44, 43, 68);
            menuStrip1.ForeColor = Color.White;
            MessageBox.Show("You are logged in", "Login successful");
            BinaryFormatter formatter = new BinaryFormatter();
            bool fileExist = File.Exists("providers.bin");
            if (!fileExist)
            { 
                return;
            }
            else
            {
                using (FileStream stream = File.OpenRead("providers.bin"))
                {
                    try
                    {
                        providers = (List<Provider>)formatter.Deserialize(stream);
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }

            LoadContracts();
            DisplayContracts();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            bool fileExist = File.Exists("providers.bin");
            if (!fileExist)
            {
                MessageBox.Show("Impossible to edit! The list of currently registered providers is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                using (FileStream stream = File.OpenRead("providers.bin"))
                {
                    try
                    {
                        if (dgvContracts.SelectedRows.Count == 0)
                        {
                            MessageBox.Show("Select the contract whose information you want to edit!");
                            return;
                        }

                        providers = (List<Provider>)formatter.Deserialize(stream);
                        DataGridViewRow row = dgvContracts.SelectedRows[0];
                        Contract contract = (Contract)row.Tag;
                        EditContractForm editForm = new EditContractForm(contract, providers, contracts);
                        if (editForm.ShowDialog() == DialogResult.OK)
                        {
                            DisplayContracts();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Impossible to edit! The list of currently registered providers is empty!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void stergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteContract();
        }

        private void fileToolStripMenuItem1_MouseHover(object sender, EventArgs e)
        {
            fileToolStripMenuItem1.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fileToolStripMenuItem1.ForeColor = Color.Black;
        }

        private void fileToolStripMenuItem1_MouseLeave(object sender, EventArgs e)
        {
            fileToolStripMenuItem1.ForeColor = Color.White;
        }

        private void exportToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ForeColor = Color.Black;
        }

        private void exportToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            exportToolStripMenuItem.ForeColor = Color.White;
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            loginForm.Show();
        }

        private void btnStatistics_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm(contracts);
            statisticsForm.ShowDialog();
        }
        #endregion

        #region Shortcuts
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode.ToString() == "E")
            {
                btnEdit_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString() == "A")
            {
                btnAdd_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString() == "P")
            {
                btnProviders_Click(sender, e);
            }

            if (e.Control && e.KeyCode.ToString() == "L")
            {
                btnLogout_Click(sender, e);
                this.DialogResult = DialogResult.OK;
            }

            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (e.Control && e.KeyCode.ToString() == "D")
            {
                DeleteContract();
            }
        }
        #endregion

        #region Printer
        private void printDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            printIndex = 0;
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font font = new Font("Times New Roman", 14);
            Font font1 = new Font("Times New Roman", 14, FontStyle.Bold);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            var pageSettings = e.PageSettings;

            var printAreaHeight = e.MarginBounds.Height;
            var printAreaWidth = e.MarginBounds.Width;

            var marginLeft = e.MarginBounds.Left;
            var marginTop = e.MarginBounds.Top;

            int rowHeight = 50;
            var columnWidth = printAreaWidth / 4;

            var currentY = marginTop;

            if(printIndex == 0)
            {
                var currentX = marginLeft;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    printAreaWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    "Provider",
                    font1,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    "Signing Date",
                    font1,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    "Validity(years)",
                    font1,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    "Value(RON)",
                    font1,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentY += rowHeight;
            }

            while (printIndex < contracts.Count)
            {
                var currentX = marginLeft;

                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    printAreaWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    contracts[printIndex].Provider.Name,
                    font,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    contracts[printIndex].SignDate.ToString(),
                    font,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    contracts[printIndex].Validity.ToString(),
                    font,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentX += columnWidth;
                e.Graphics.DrawRectangle(
                    Pens.Black,
                    currentX,
                    currentY,
                    columnWidth,
                    rowHeight
                    );

                e.Graphics.DrawString(
                    contracts[printIndex].Value.ToString(),
                    font,
                    Brushes.Black,
                    new RectangleF(currentX, currentY, columnWidth, rowHeight),
                    format
                    );

                currentY += rowHeight;

                printIndex++;

                if (currentY - marginTop + rowHeight > printAreaHeight)
                {
                    e.HasMorePages = true;
                    break;
                }
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pageSetupDialog.ShowDialog() == DialogResult.OK)
                printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
        }
        #endregion

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    try
                    {
                        contracts.Clear();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // Debug: Print the line being read
                            Console.WriteLine(line);

                            string[] parts = line.Split(',');
                            if (parts.Length == 5)
                            {
                                // Debug: Print the parts array
                                Console.WriteLine(string.Join(", ", parts));

                                Contract contract = new Contract
                                {
                                    Id = long.Parse(parts[0]),
                                    Provider = new Provider { Name = parts[1].Trim('"') },
                                    SignDate = DateTime.ParseExact(parts[2].Trim('"'), "dd.MM.yyyy", null),
                                    Validity = long.Parse(parts[3].Trim('"')),
                                    Value = long.Parse(parts[4].Trim('"'))
                                };
                                contracts.Add(contract);
                            }
                        }
                        DisplayContracts();
                    }
                    catch (FormatException ex)
                    {
                        MessageBox.Show($"Error importing data: Invalid format in file. {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importing data: {ex.Message}");
                    }
                }
            }
        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to Text File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    // Write the header line
                    writer.WriteLine("Id,Provider name,Signing date,Validity,Value");

                    // Write each contract's data
                    foreach (Contract contract in contracts)
                    {
                        string line = string.Format("{0},{1},{2},{3},{4}",
                            contract.Id,
                            contract.Provider.Name,
                            contract.SignDate.ToString("dd.MM.yyyy"),
                            contract.Validity,
                            contract.Value);
                        writer.WriteLine(line);
                    }
                }

                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void importToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            openFileDialog.Title = "Import from Binary File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    contracts = (List<Contract>)formatter.Deserialize(fs);
                }

                DisplayContracts();
                MessageBox.Show("Data imported successfully.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void exportToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Binary files (*.bin)|*.bin|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to Binary File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, contracts);
                }

                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ImportFromXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contract>));
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                contracts = (List<Contract>)serializer.Deserialize(fs);
            }
            DisplayContracts();
        }
        private void importToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            openFileDialog.Title = "Import from XML File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImportFromXml(openFileDialog.FileName);
                MessageBox.Show("Data imported successfully.", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExportToXml(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Contract>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, contracts);
            }
        }

        private void exportToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog.Title = "Export to XML File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToXml(saveFileDialog.FileName);
                MessageBox.Show("Data exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
