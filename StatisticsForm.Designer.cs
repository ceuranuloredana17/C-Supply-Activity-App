
namespace supply_activity_app
{
    partial class StatisticsForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.donutChartControl1 = new ChartLibrary.DonutChartControl();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(293, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(218, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "Contracts signed / year";
            // 
            // donutChartControl1
            // 
            this.donutChartControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.donutChartControl1.ForeColor = System.Drawing.Color.Black;
            this.donutChartControl1.Location = new System.Drawing.Point(129, 116);
            this.donutChartControl1.Name = "donutChartControl1";
            this.donutChartControl1.Size = new System.Drawing.Size(583, 298);
            this.donutChartControl1.TabIndex = 27;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(828, 454);
            this.Controls.Add(this.donutChartControl1);
            this.Controls.Add(this.label4);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::supply_activity_app.Properties.Settings.Default, "pref", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = global::supply_activity_app.Properties.Settings.Default.pref;
            this.Name = "StatisticsForm";
            this.Text = "StatisticsForm";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private ChartLibrary.DonutChartControl donutChartControl1;
    }
}