
namespace supply_activity_app
{
    partial class EditContractForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditContractForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbProviders = new System.Windows.Forms.ComboBox();
            this.dtpSignDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbValidity = new System.Windows.Forms.TextBox();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackColor = System.Drawing.Color.Black;
            this.btnOk.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnOk.Location = new System.Drawing.Point(256, 290);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = " Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label2.Location = new System.Drawing.Point(138, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Provider";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label3.Location = new System.Drawing.Point(138, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Signing date";
            // 
            // cbProviders
            // 
            this.cbProviders.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbProviders.BackColor = System.Drawing.SystemColors.Window;
            this.cbProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.cbProviders.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbProviders.FormattingEnabled = true;
            this.cbProviders.Location = new System.Drawing.Point(271, 71);
            this.cbProviders.Name = "cbProviders";
            this.cbProviders.Size = new System.Drawing.Size(230, 24);
            this.cbProviders.TabIndex = 9;
            this.cbProviders.Validating += new System.ComponentModel.CancelEventHandler(this.cbProviders_Validating);
            this.cbProviders.Validated += new System.EventHandler(this.cbProviders_Validated);
            // 
            // dtpSignDate
            // 
            this.dtpSignDate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dtpSignDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.dtpSignDate.Location = new System.Drawing.Point(271, 120);
            this.dtpSignDate.Name = "dtpSignDate";
            this.dtpSignDate.Size = new System.Drawing.Size(230, 22);
            this.dtpSignDate.TabIndex = 10;
            this.dtpSignDate.Validating += new System.ComponentModel.CancelEventHandler(this.dtpSignDate_Validating);
            this.dtpSignDate.Validated += new System.EventHandler(this.dtpSignDate_Validated);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label4.Location = new System.Drawing.Point(138, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Validity";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label5.Location = new System.Drawing.Point(138, 223);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Value";
            // 
            // tbValidity
            // 
            this.tbValidity.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbValidity.BackColor = System.Drawing.Color.White;
            this.tbValidity.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbValidity.ForeColor = System.Drawing.Color.Black;
            this.tbValidity.Location = new System.Drawing.Point(271, 169);
            this.tbValidity.Name = "tbValidity";
            this.tbValidity.Size = new System.Drawing.Size(230, 23);
            this.tbValidity.TabIndex = 13;
            this.tbValidity.Validating += new System.ComponentModel.CancelEventHandler(this.tbValidity_Validating);
            this.tbValidity.Validated += new System.EventHandler(this.tbValidity_Validated);
            // 
            // tbValue
            // 
            this.tbValue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbValue.BackColor = System.Drawing.Color.White;
            this.tbValue.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbValue.ForeColor = System.Drawing.Color.Black;
            this.tbValue.Location = new System.Drawing.Point(271, 220);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(230, 23);
            this.tbValue.TabIndex = 14;
            this.tbValue.Validating += new System.ComponentModel.CancelEventHandler(this.tbValue_Validating);
            this.tbValue.Validated += new System.EventHandler(this.tbValue_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(618, 384);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbValidity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpSignDate);
            this.Controls.Add(this.cbProviders);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOk);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::supply_activity_app.Properties.Settings.Default, "pref", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = global::supply_activity_app.Properties.Settings.Default.pref;
            this.Name = "EditContractForm";
            this.Text = "Edit Contract";
            this.Load += new System.EventHandler(this.EditContractForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditContractForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbProviders;
        private System.Windows.Forms.DateTimePicker dtpSignDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbValidity;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}