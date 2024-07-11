
namespace supply_activity_app
{
    partial class EditProviderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProviderForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.clbMaterials = new System.Windows.Forms.CheckedListBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label1.Location = new System.Drawing.Point(103, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label2.Location = new System.Drawing.Point(103, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Founded";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label3.Location = new System.Drawing.Point(103, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Materials";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOk.BackColor = System.Drawing.Color.Black;
            this.btnOk.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.Location = new System.Drawing.Point(175, 261);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 31);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = " Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbName.ForeColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(199, 65);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(143, 23);
            this.tbName.TabIndex = 4;
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            this.tbName.Validated += new System.EventHandler(this.tbName_Validated);
            // 
            // tbYear
            // 
            this.tbYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbYear.BackColor = System.Drawing.Color.White;
            this.tbYear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbYear.ForeColor = System.Drawing.Color.White;
            this.tbYear.Location = new System.Drawing.Point(199, 104);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(143, 23);
            this.tbYear.TabIndex = 5;
            this.tbYear.Validating += new System.ComponentModel.CancelEventHandler(this.tbYear_Validating);
            this.tbYear.Validated += new System.EventHandler(this.tbYear_Validated);
            // 
            // clbMaterials
            // 
            this.clbMaterials.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clbMaterials.BackColor = System.Drawing.Color.White;
            this.clbMaterials.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.clbMaterials.ForeColor = System.Drawing.Color.Gray;
            this.clbMaterials.Location = new System.Drawing.Point(199, 154);
            this.clbMaterials.Name = "clbMaterials";
            this.clbMaterials.Size = new System.Drawing.Size(143, 76);
            this.clbMaterials.TabIndex = 7;
            this.clbMaterials.Validating += new System.ComponentModel.CancelEventHandler(this.clbMaterials_Validating);
            this.clbMaterials.Validated += new System.EventHandler(this.clbMaterials_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // EditProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(445, 361);
            this.Controls.Add(this.clbMaterials);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::supply_activity_app.Properties.Settings.Default, "pref", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = global::supply_activity_app.Properties.Settings.Default.pref;
            this.Name = "EditProviderForm";
            this.Text = "Edit Provider";
            this.Load += new System.EventHandler(this.EditProvidersForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditProvidersForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.CheckedListBox clbMaterials;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}