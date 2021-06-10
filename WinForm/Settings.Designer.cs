
namespace WinForm
{
    partial class Settings
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
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.MusicOn = new System.Windows.Forms.Button();
            this.MusicOff = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Music = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Segoe UI", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SettingsLabel.Location = new System.Drawing.Point(875, 192);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(678, 219);
            this.SettingsLabel.TabIndex = 0;
            this.SettingsLabel.Text = "Settings";
            // 
            // MusicOn
            // 
            this.MusicOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusicOn.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MusicOn.Location = new System.Drawing.Point(1127, 487);
            this.MusicOn.Name = "MusicOn";
            this.MusicOn.Size = new System.Drawing.Size(144, 100);
            this.MusicOn.TabIndex = 2;
            this.MusicOn.Text = "On";
            this.MusicOn.UseVisualStyleBackColor = true;
            this.MusicOn.Click += new System.EventHandler(this.MusicOn_Click);
            // 
            // MusicOff
            // 
            this.MusicOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusicOff.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MusicOff.Location = new System.Drawing.Point(1346, 487);
            this.MusicOff.Name = "MusicOff";
            this.MusicOff.Size = new System.Drawing.Size(144, 100);
            this.MusicOff.TabIndex = 3;
            this.MusicOff.Text = "Off";
            this.MusicOff.UseVisualStyleBackColor = true;
            this.MusicOff.Click += new System.EventHandler(this.MusicOff_Click);
            // 
            // Back
            // 
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Back.Location = new System.Drawing.Point(1070, 677);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(335, 113);
            this.Back.TabIndex = 4;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Music
            // 
            this.Music.AutoSize = true;
            this.Music.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Music.Location = new System.Drawing.Point(875, 507);
            this.Music.Name = "Music";
            this.Music.Size = new System.Drawing.Size(153, 61);
            this.Music.TabIndex = 5;
            this.Music.Text = "Music:";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.Music);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.MusicOff);
            this.Controls.Add(this.MusicOn);
            this.Controls.Add(this.SettingsLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(2498, 1429);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        private System.Windows.Forms.Label SettingsLabel;
        private System.Windows.Forms.Button MusicOn;
        private System.Windows.Forms.Button MusicOff;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label Music;
    }
}
