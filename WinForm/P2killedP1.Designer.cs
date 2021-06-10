
namespace WinForm
{
    partial class P2killedP1
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
            this.P2killedP1Label = new System.Windows.Forms.Label();
            this.Vack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // P2killedP1Label
            // 
            this.P2killedP1Label.AutoSize = true;
            this.P2killedP1Label.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2killedP1Label.Location = new System.Drawing.Point(964, 239);
            this.P2killedP1Label.Name = "P2killedP1Label";
            this.P2killedP1Label.Size = new System.Drawing.Size(535, 120);
            this.P2killedP1Label.TabIndex = 0;
            this.P2killedP1Label.Text = "P2 killed P1!";
            // 
            // Vack
            // 
            this.Vack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Vack.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Vack.Location = new System.Drawing.Point(1061, 522);
            this.Vack.Name = "Vack";
            this.Vack.Size = new System.Drawing.Size(335, 113);
            this.Vack.TabIndex = 1;
            this.Vack.Text = "Back";
            this.Vack.UseVisualStyleBackColor = true;
            this.Vack.Click += new System.EventHandler(this.Vack_Click);
            // 
            // P2killedP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Vack);
            this.Controls.Add(this.P2killedP1Label);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "P2killedP1";
            this.Size = new System.Drawing.Size(2540, 1499);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label P2killedP1Label;
        private System.Windows.Forms.Button Vack;
    }
}
