
namespace WinForm
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.game1 = new WinForm.Game();
            this.mainMenu1 = new WinForm.MainMenu();
            this.victory1 = new WinForm.Victory();
            this.settings1 = new WinForm.Settings();
            this.SuspendLayout();
            // 
            // game1
            // 
            this.game1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.game1.difficulty = 0;
            this.game1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.game1.GameActiveStatus = false;
            this.game1.InterfaceFieldPrevious = null;
            this.game1.level = 0;
            this.game1.Location = new System.Drawing.Point(0, 0);
            this.game1.logic = null;
            this.game1.logicBackup = null;
            this.game1.mode = null;
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(2465, 1403);
            this.game1.TabIndex = 2;
            this.game1.Visible = false;
            this.game1.OnMainMenu += new System.EventHandler(this.game1_OnMainMenu);
            this.game1.OnEnd += new System.EventHandler<WinForm.EndEventArgs>(this.game1_OnEnd);
            // 
            // mainMenu1
            // 
            this.mainMenu1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainMenu1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mainMenu1.ForeColor = System.Drawing.Color.Maroon;
            this.mainMenu1.Location = new System.Drawing.Point(0, 0);
            this.mainMenu1.Name = "mainMenu1";
            this.mainMenu1.Size = new System.Drawing.Size(5648, 3357);
            this.mainMenu1.TabIndex = 3;
            this.mainMenu1.OnExit += new System.EventHandler(this.mainMenu1_OnExit);
            this.mainMenu1.OnLoadLevel += new System.EventHandler<WinForm.LoadLevelEventArgs>(this.mainMenu1_OnLoadLevel);
            this.mainMenu1.OnSettings += new System.EventHandler(this.mainMenu1_OnSettings);
            // 
            // victory1
            // 
            this.victory1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.victory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.victory1.Location = new System.Drawing.Point(0, 0);
            this.victory1.Name = "victory1";
            this.victory1.result = null;
            this.victory1.Size = new System.Drawing.Size(5738, 3402);
            this.victory1.TabIndex = 11;
            this.victory1.Visible = false;
            this.victory1.OnBack += new System.EventHandler(this.victory1_OnBack);
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.settings1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.settings1.Location = new System.Drawing.Point(0, 0);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(5620, 3215);
            this.settings1.TabIndex = 12;
            this.settings1.Visible = false;
            this.settings1.OnBack += new System.EventHandler(this.settings1_OnBack);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2465, 1403);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.victory1);
            this.Controls.Add(this.mainMenu1);
            this.Controls.Add(this.game1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private Game game1;
        private MainMenu mainMenu1;
        private Victory victory1;
        private Settings settings1;
    }
}