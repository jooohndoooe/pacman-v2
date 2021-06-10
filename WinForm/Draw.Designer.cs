
namespace WinForm
{
    partial class Draw
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
            this.DrawLabel = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.Joke = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DrawLabel
            // 
            this.DrawLabel.AutoSize = true;
            this.DrawLabel.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DrawLabel.Location = new System.Drawing.Point(891, 194);
            this.DrawLabel.Name = "DrawLabel";
            this.DrawLabel.Size = new System.Drawing.Size(701, 120);
            this.DrawLabel.TabIndex = 0;
            this.DrawLabel.Text = "Draw...seriously?";
            // 
            // Back
            // 
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Back.Location = new System.Drawing.Point(1033, 602);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(375, 123);
            this.Back.TabIndex = 1;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Joke
            // 
            this.Joke.AutoSize = true;
            this.Joke.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Joke.Location = new System.Drawing.Point(847, 354);
            this.Joke.Name = "Joke";
            this.Joke.Size = new System.Drawing.Size(793, 61);
            this.Joke.TabIndex = 2;
            this.Joke.Text = "You do realize how improbable that is?";
            // 
            // Draw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Joke);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.DrawLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "Draw";
            this.Size = new System.Drawing.Size(2550, 1486);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DrawLabel;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label Joke;
    }
}
