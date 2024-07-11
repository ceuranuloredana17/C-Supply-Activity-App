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
    public partial class EditContractForm : Form
    {
        #region Attributes
        private Contract contract = new Contract();
        private List<Provider> providers = new List<Provider>();
        private List<Contract> contracts = new List<Contract>();
        private string connectionString = "Data Source=database.db";
        #endregion

        public EditContractForm(Contract contract, List<Provider> providers, List<Contract> contracts)
        {
            InitializeComponent();
            this.contract = contract;
            this.providers = providers;
            this.contracts = contracts;
        }

        #region Methods
        public void EditContract(Contract _contract)
        {
            string query = "UPDATE Contracts SET Provider = @provider, SignDate = @signDate, Validity = @validity, Value = @value WHERE Id = @id;";


            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                SqliteCommand command = new SqliteCommand(query, connection);

                command.Parameters.AddWithValue("@provider", _contract.Provider.Name);
                command.Parameters.AddWithValue("@signDate", _contract.SignDate);
                command.Parameters.AddWithValue("@validity", _contract.Validity);
                command.Parameters.AddWithValue("@value", _contract.Value);
                command.Parameters.AddWithValue("@id", _contract.Id);

                connection.Open();

                command.ExecuteNonQuery();
            }
        }
        #endregion

        #region Events
        private void EditContractForm_Load(object sender, EventArgs e)
        {
            foreach (Provider provider in providers)
            {
                cbProviders.Items.Add(provider.Name);
            }
            cbProviders.SelectedItem = contract.Provider.Name;
            dtpSignDate.Value = contract.SignDate;
            tbValidity.Text = contract.Validity.ToString();
            tbValue.Text = contract.Value.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (cbProviders.SelectedIndex < 0 || tbValidity.Text == "" || tbValue.Text == "")
            {
                MessageBox.Show("You have not filled all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Provider p in providers)
            {
                if ((string)cbProviders.SelectedItem == p.Name)
                {
                    contract.Provider = p;
                }
            }
            contract.SignDate = dtpSignDate.Value;
            contract.Validity = Convert.ToInt32(tbValidity.Text);
            contract.Value = Convert.ToInt32(tbValue.Text);

            EditContract(contract);
            this.DialogResult = DialogResult.OK;
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
        private void EditContractForm_KeyDown(object sender, KeyEventArgs e)
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
