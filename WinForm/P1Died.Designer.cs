
namespace WinForm
{
    partial class P1Died
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.P1DiedLabel = new System.Windows.Forms.Label();
            this.Explanation = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // P1DiedLabel
            // 
            this.P1DiedLabel.AutoSize = true;
            this.P1DiedLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1DiedLabel.Location = new System.Drawing.Point(984, 292);
            this.P1DiedLabel.Name = "P1DiedLabel";
            this.P1DiedLabel.Size = new System.Drawing.Size(384, 120);
            this.P1DiedLabel.TabIndex = 0;
            this.P1DiedLabel.Text = "P2 Won!";
            // 
            // Explanation
            // 
            this.Explanation.AutoSize = true;
            this.Explanation.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Explanation.Location = new System.Drawing.Point(994, 470);
            this.Explanation.Name = "Explanation";
            this.Explanation.Size = new System.Drawing.Size(374, 61);
            this.Explanation.TabIndex = 1;
            this.Explanation.Text = "P1 died to a bot...";
            // 
            // Back
            // 
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Back.Location = new System.Drawing.Point(1037, 642);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(259, 90);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // P1Died
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Explanation);
            this.Controls.Add(this.P1DiedLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "P1Died";
            this.Size = new System.Drawing.Size(2512, 1496);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label P1DiedLabel;
        private System.Windows.Forms.Label Explanation;
        private System.Windows.Forms.Button Back;
    }
}
