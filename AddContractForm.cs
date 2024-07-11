using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_activity_app
{
    public partial class AddContractForm : Form
    {
        #region Attributes
        private List<Contract> contracts = new List<Contract>();
        private List<Provider> providers = new List<Provider>();
        private string connectionString = "Data Source=database.db";
        #endregion

        public AddContractForm(List<Contract> contracts, List<Provider> providers)
        {
            InitializeComponent();
            this.contracts = contracts;
            this.providers = providers;
        }

        #region Methods
        public void AddContract(Contract contract)
        {
            string query = "INSERT INTO Contracts(Provider, SignDate, Validity, Value) VALUES(@provider, @signDate, @validity, @value); SELECT last_insert_rowid()";


            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);
                command.Parameters.AddWithValue("@provider", contract.Provider.Name);
                command.Parameters.AddWithValue("@signDate", contract.SignDate);
                command.Parameters.AddWithValue("@validity", contract.Validity);
                command.Parameters.AddWithValue("@value", contract.Value);

                connection.Open();

                long id = (long)command.ExecuteScalar();
                contract.Id = id;

                contracts.Add(contract);
            }
        }
        #endregion

        #region Events
        private void AddContractForm_Load(object sender, EventArgs e)
        {
            foreach (Provider provider in providers)
            {
                cbProviders.Items.Add(provider.Name);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cbProviders.SelectedIndex < 0 || tbValidity.Text == "" || tbValue.Text == "")
            {
                MessageBox.Show("You have not filled all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Provider provider = new Provider();
            foreach(Provider p in providers)
            {
                if(cbProviders.Text == p.Name)
                {
                    provider = p;
                }
            }
            DateTime date = dtpSignDate.Value;
            long validity = Convert.ToInt64(tbValidity.Text);
            long value = Convert.ToInt64(tbValue.Text);
            try
            {
                Contract contract = new Contract(provider, date, validity, value);

                bool test = false;
                foreach (Contract c in contracts)
                {
                    if (c == contract)
                    {
                        test = true;
                    }
                }

                if (!test)
                {
                    this.DialogResult = DialogResult.OK;
                    AddContract(contract);
                }
                else
                {
                    MessageBox.Show("The contract already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (InvalidSignDateException ex)
            {
                MessageBox.Show(string.Format("The signing date {0} is invalid!", ex.SignDate));
            }
            catch (Exception)
            {
                MessageBox.Show("Exception.");
            }
        }
        #endregion

        #region Validations
        private void cbProviders_Validating(object sender, CancelEventArgs e)
        {
            if (cbProviders.SelectedIndex < 0)
            {
                errorProvider1.SetError(cbProviders, "You must choose one of the options!");
                e.Cancel = true;
            }
        }

        private void cbProviders_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cbProviders, null);
        }

        private void dtpSignDate_Validating(object sender, CancelEventArgs e)
        {
            DateTime todayDate = DateTime.Today;
            if (todayDate.AddDays(1) < dtpSignDate.Value)
            {
                errorProvider1.SetError(dtpSignDate, "The date of signing must be today or a date in the past!");
                e.Cancel = true;
            }
        }

        private void dtpSignDate_Validated(object sender, EventArgs e)
        {

            errorProvider1.SetError(dtpSignDate, null);
        }

        private void tbValidity_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            bool isNumeric = int.TryParse(tbValidity.Text, out val);

            if (!isNumeric || val <= 0 || val > 10)
            {
                errorProvider1.SetError(tbValidity, "The duration of the contract must contain only numbers, have a" +
                    "positive value and be a maximum of 10 years!");
                e.Cancel = true;
            }
        }

        private void tbValidity_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbValidity, null);
        }

        private void tbValue_Validating(object sender, CancelEventArgs e)
        {
            int val = 0;
            bool isNumeric = int.TryParse(tbValue.Text, out val);

            if (!isNumeric || val <= 0)
            {
                errorProvider1.SetError(tbValue, "The value of the contract must be positive and contain only numbers!");
                e.Cancel = true;
            }
        }

        private void tbValue_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(tbValue, null);
        }
        #endregion

        #region Shortcuts
        private void AddContractForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                btnAdd_Click(sender, e);
            }
        }
        #endregion
    }
}
