
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
            this.defeat1 = new WinForm.Defeat();
            this.draw1 = new WinForm.Draw();
            this.game1 = new WinForm.Game();
            this.mainMenu1 = new WinForm.MainMenu();
            this.p1Died1 = new WinForm.P1Died();
            this.p1Score1 = new WinForm.P1Score();
            this.p1killedP21 = new WinForm.P1killedP2();
            this.p2Died1 = new WinForm.P2Died();
            this.p2Score1 = new WinForm.P2Score();
            this.p2killedP11 = new WinForm.P2killedP1();
            this.settings1 = new WinForm.Settings();
            this.victory1 = new WinForm.Victory();
            this.finish1 = new WinForm.Finish();
            this.time1 = new WinForm.Time();
            this.SuspendLayout();
            // 
            // defeat1
            // 
            this.defeat1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.defeat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.defeat1.Location = new System.Drawing.Point(0, 0);
            this.defeat1.Name = "defeat1";
            this.defeat1.Size = new System.Drawing.Size(5726, 3357);
            this.defeat1.TabIndex = 0;
            this.defeat1.Visible = false;
            this.defeat1.OnBack += new System.EventHandler(this.defeat1_OnBack);
            // 
            // draw1
            // 
            this.draw1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.draw1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.draw1.Location = new System.Drawing.Point(0, 0);
            this.draw1.Name = "draw1";
            this.draw1.Size = new System.Drawing.Size(5738, 3344);
            this.draw1.TabIndex = 1;
            this.draw1.Visible = false;
            this.draw1.OnBack += new System.EventHandler(this.draw1_OnBack);
            // 
            // game1
            // 
            this.game1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.game1.difficulty = 0;
            this.game1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.game1.InterfaceFieldPrevious = null;
            this.game1.level = 0;
            this.game1.Location = new System.Drawing.Point(0, 0);
            this.game1.logic = null;
            this.game1.mode = null;
            this.game1.Name = "game1";
            this.game1.Size = new System.Drawing.Size(2465, 1403);
            this.game1.TabIndex = 2;
            this.game1.Visible = false;
            this.game1.OnMainMenu += new System.EventHandler(this.game1_OnMainMenu);
            this.game1.OnP1killedP2 += new System.EventHandler(this.game1_OnP1killedP2);
            this.game1.OnP2killedP1 += new System.EventHandler(this.game1_OnP2killedP1);
            this.game1.OnP1Score += new System.EventHandler(this.game1_OnP1Score);
            this.game1.OnP2Score += new System.EventHandler(this.game1_OnP2Score);
            this.game1.OnP1Died += new System.EventHandler(this.game1_OnP1Died);
            this.game1.OnP2Died += new System.EventHandler(this.game1_OnP2Died);
            this.game1.OnDraw += new System.EventHandler(this.game1_OnDraw);
            this.game1.OnVictory += new System.EventHandler(this.game1_OnVictory);
            this.game1.OnDeath += new System.EventHandler(this.game1_OnDeath);
            this.game1.OnTime += new System.EventHandler(this.game1_OnTime);
            this.game1.OnFinish += new System.EventHandler(this.game1_OnFinish);
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
            // p1Died1
            // 
            this.p1Died1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1Died1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p1Died1.Location = new System.Drawing.Point(0, 0);
            this.p1Died1.Name = "p1Died1";
            this.p1Died1.Size = new System.Drawing.Size(5652, 3366);
            this.p1Died1.TabIndex = 4;
            this.p1Died1.Visible = false;
            this.p1Died1.OnBack += new System.EventHandler(this.p1Died1_OnBack);
            // 
            // p1Score1
            // 
            this.p1Score1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1Score1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p1Score1.Location = new System.Drawing.Point(0, 0);
            this.p1Score1.Name = "p1Score1";
            this.p1Score1.Size = new System.Drawing.Size(5760, 3404);
            this.p1Score1.TabIndex = 5;
            this.p1Score1.Visible = false;
            this.p1Score1.OnBack += new System.EventHandler(this.p1Score1_OnBack);
            // 
            // p1killedP21
            // 
            this.p1killedP21.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1killedP21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p1killedP21.Location = new System.Drawing.Point(0, 0);
            this.p1killedP21.Name = "p1killedP21";
            this.p1killedP21.Size = new System.Drawing.Size(5764, 3402);
            this.p1killedP21.TabIndex = 6;
            this.p1killedP21.Visible = false;
            this.p1killedP21.OnBack += new System.EventHandler(this.p1killedP21_OnBack);
            // 
            // p2Died1
            // 
            this.p2Died1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2Died1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p2Died1.Location = new System.Drawing.Point(0, 0);
            this.p2Died1.Name = "p2Died1";
            this.p2Died1.Size = new System.Drawing.Size(5744, 3391);
            this.p2Died1.TabIndex = 7;
            this.p2Died1.Visible = false;
            this.p2Died1.OnBack += new System.EventHandler(this.p2Died1_OnBack);
            // 
            // p2Score1
            // 
            this.p2Score1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2Score1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p2Score1.Location = new System.Drawing.Point(0, 0);
            this.p2Score1.Name = "p2Score1";
            this.p2Score1.Size = new System.Drawing.Size(5722, 3380);
            this.p2Score1.TabIndex = 8;
            this.p2Score1.Visible = false;
            this.p2Score1.OnBack += new System.EventHandler(this.p2Score1_OnBack);
            // 
            // p2killedP11
            // 
            this.p2killedP11.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2killedP11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.p2killedP11.Location = new System.Drawing.Point(0, 0);
            this.p2killedP11.Name = "p2killedP11";
            this.p2killedP11.Size = new System.Drawing.Size(5715, 3373);
            this.p2killedP11.TabIndex = 9;
            this.p2killedP11.Visible = false;
            this.p2killedP11.OnBack += new System.EventHandler(this.p2killedP11_OnBack);
            // 
            // settings1
            // 
            this.settings1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.settings1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.settings1.Location = new System.Drawing.Point(0, 0);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(5620, 3215);
            this.settings1.TabIndex = 10;
            this.settings1.Visible = false;
            this.settings1.OnBack += new System.EventHandler(this.settings1_OnBack);
            // 
            // victory1
            // 
            this.victory1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.victory1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.victory1.Location = new System.Drawing.Point(0, 0);
            this.victory1.Name = "victory1";
            this.victory1.Size = new System.Drawing.Size(5738, 3402);
            this.victory1.TabIndex = 11;
            this.victory1.Visible = false;
            this.victory1.OnBack += new System.EventHandler(this.victory1_OnBack);
            // 
            // finish1
            // 
            this.finish1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.finish1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.finish1.ForeColor = System.Drawing.Color.Maroon;
            this.finish1.Location = new System.Drawing.Point(0, 0);
            this.finish1.Name = "finish1";
            this.finish1.Size = new System.Drawing.Size(5634, 3359);
            this.finish1.TabIndex = 12;
            this.finish1.Visible = false;
            this.finish1.OnBack += new System.EventHandler(this.finish1_OnBack);
            // 
            // time1
            // 
            this.time1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.time1.ForeColor = System.Drawing.Color.Maroon;
            this.time1.Location = new System.Drawing.Point(0, 0);
            this.time1.Name = "time1";
            this.time1.Size = new System.Drawing.Size(5594, 3348);
            this.time1.TabIndex = 13;
            this.time1.Visible = false;
            this.time1.OnBack += new System.EventHandler(this.time1_OnBack);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2465, 1403);
            this.Controls.Add(this.time1);
            this.Controls.Add(this.finish1);
            this.Controls.Add(this.victory1);
            this.Controls.Add(this.settings1);
            this.Controls.Add(this.p2killedP11);
            this.Controls.Add(this.p2Score1);
            this.Controls.Add(this.p2Died1);
            this.Controls.Add(this.p1killedP21);
            this.Controls.Add(this.p1Score1);
            this.Controls.Add(this.p1Died1);
            this.Controls.Add(this.mainMenu1);
            this.Controls.Add(this.game1);
            this.Controls.Add(this.draw1);
            this.Controls.Add(this.defeat1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Defeat defeat1;
        private Draw draw1;
        private Game game1;
        private MainMenu mainMenu1;
        private P1Died p1Died1;
        private P1Score p1Score1;
        private P1killedP2 p1killedP21;
        private P2Died p2Died1;
        private P2Score p2Score1;
        private P2killedP1 p2killedP11;
        private Settings settings1;
        private Victory victory1;
        private Finish finish1;
        private Time time1;
    }
}