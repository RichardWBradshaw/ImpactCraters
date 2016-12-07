namespace ImpactCraters
    {
    partial class DetailsDialog
        {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing)
            {
            if (disposing && ( components != null ))
                {
                components.Dispose ();
                }
            base.Dispose (disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
            {
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsTextBox.Location = new System.Drawing.Point(10, 10);
            this.detailsTextBox.Multiline = true;
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.detailsTextBox.Size = new System.Drawing.Size(560, 450);
            this.detailsTextBox.TabIndex = 0;
            // 
            // DetailsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 476);
            this.Controls.Add(this.detailsTextBox);
            this.Name = "DetailsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Details_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TextBox detailsTextBox;
        }
    }