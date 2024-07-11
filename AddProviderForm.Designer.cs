
namespace supply_activity_app
{
    partial class AddProviderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProviderForm));
            this.clbMaterials = new System.Windows.Forms.CheckedListBox();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // clbMaterials
            // 
            this.clbMaterials.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clbMaterials.BackColor = System.Drawing.Color.White;
            this.clbMaterials.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.clbMaterials.ForeColor = System.Drawing.Color.Violet;
            this.clbMaterials.FormattingEnabled = true;
            this.clbMaterials.Location = new System.Drawing.Point(453, 106);
            this.clbMaterials.Name = "clbMaterials";
            this.clbMaterials.Size = new System.Drawing.Size(194, 76);
            this.clbMaterials.TabIndex = 24;
            this.clbMaterials.Validating += new System.ComponentModel.CancelEventHandler(this.clbMaterials_Validating);
            this.clbMaterials.Validated += new System.EventHandler(this.clbMaterials_Validated);
            // 
            // tbYear
            // 
            this.tbYear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbYear.BackColor = System.Drawing.Color.White;
            this.tbYear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbYear.ForeColor = System.Drawing.Color.Black;
            this.tbYear.Location = new System.Drawing.Point(181, 157);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(147, 23);
            this.tbYear.TabIndex = 23;
            this.tbYear.Validating += new System.ComponentModel.CancelEventHandler(this.tbYear_Validating);
            this.tbYear.Validated += new System.EventHandler(this.tbYear_Validated);
            // 
            // tbName
            // 
            this.tbName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.tbName.ForeColor = System.Drawing.Color.Black;
            this.tbName.Location = new System.Drawing.Point(181, 103);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(147, 23);
            this.tbName.TabIndex = 22;
            this.tbName.Validating += new System.ComponentModel.CancelEventHandler(this.tbName_Validating);
            this.tbName.Validated += new System.EventHandler(this.tbName_Validated);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label3.Location = new System.Drawing.Point(376, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Materials";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label2.Location = new System.Drawing.Point(76, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 20;
            this.label2.Text = "Founded";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.label1.Location = new System.Drawing.Point(76, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 19;
            this.label1.Text = "Name";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnAdd.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F);
            this.btnAdd.Location = new System.Drawing.Point(278, 222);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(142, 31);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddProviderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepPink;
            this.ClientSize = new System.Drawing.Size(724, 353);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.clbMaterials);
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::supply_activity_app.Properties.Settings.Default, "pref", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = global::supply_activity_app.Properties.Settings.Default.pref;
            this.Name = "AddProviderForm";
            this.Text = "Add provider";
            this.Load += new System.EventHandler(this.AddProviderForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddProviderForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbMaterials;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}