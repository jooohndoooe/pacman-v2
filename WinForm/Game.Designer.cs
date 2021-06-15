
namespace WinForm
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.P1ScoreLabel = new System.Windows.Forms.Label();
            this.P2ScoreLabel = new System.Windows.Forms.Label();
            this.P1ScoreAmount = new System.Windows.Forms.Label();
            this.P2ScoreAmount = new System.Windows.Forms.Label();
            this.P1x = new System.Windows.Forms.Label();
            this.P2x = new System.Windows.Forms.Label();
            this.P1xAmount = new System.Windows.Forms.Label();
            this.P2xAmount = new System.Windows.Forms.Label();
            this.P1y = new System.Windows.Forms.Label();
            this.P2y = new System.Windows.Forms.Label();
            this.P1yAmount = new System.Windows.Forms.Label();
            this.P2yAmount = new System.Windows.Forms.Label();
            this.P1Lives = new System.Windows.Forms.Label();
            this.P1LivesAmount = new System.Windows.Forms.Label();
            this.P1Health = new System.Windows.Forms.Label();
            this.P1HealthAmount = new System.Windows.Forms.Label();
            this.P2Lives = new System.Windows.Forms.Label();
            this.P2LivesAmount = new System.Windows.Forms.Label();
            this.P2Health = new System.Windows.Forms.Label();
            this.P2HealthAmount = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.TimeAmount = new System.Windows.Forms.Label();
            this.Hint = new System.Windows.Forms.Label();
            this.HintValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // P1ScoreLabel
            // 
            this.P1ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1ScoreLabel.AutoSize = true;
            this.P1ScoreLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1ScoreLabel.Location = new System.Drawing.Point(55, 1192);
            this.P1ScoreLabel.Name = "P1ScoreLabel";
            this.P1ScoreLabel.Size = new System.Drawing.Size(209, 61);
            this.P1ScoreLabel.TabIndex = 0;
            this.P1ScoreLabel.Text = "P1 Score:";
            this.P1ScoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // P2ScoreLabel
            // 
            this.P2ScoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2ScoreLabel.AutoSize = true;
            this.P2ScoreLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2ScoreLabel.Location = new System.Drawing.Point(55, 1245);
            this.P2ScoreLabel.Name = "P2ScoreLabel";
            this.P2ScoreLabel.Size = new System.Drawing.Size(209, 61);
            this.P2ScoreLabel.TabIndex = 1;
            this.P2ScoreLabel.Text = "P2 Score:";
            // 
            // P1ScoreAmount
            // 
            this.P1ScoreAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1ScoreAmount.AutoSize = true;
            this.P1ScoreAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1ScoreAmount.Location = new System.Drawing.Point(265, 1192);
            this.P1ScoreAmount.Name = "P1ScoreAmount";
            this.P1ScoreAmount.Size = new System.Drawing.Size(51, 61);
            this.P1ScoreAmount.TabIndex = 2;
            this.P1ScoreAmount.Text = "0";
            // 
            // P2ScoreAmount
            // 
            this.P2ScoreAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2ScoreAmount.AutoSize = true;
            this.P2ScoreAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2ScoreAmount.Location = new System.Drawing.Point(265, 1245);
            this.P2ScoreAmount.Name = "P2ScoreAmount";
            this.P2ScoreAmount.Size = new System.Drawing.Size(51, 61);
            this.P2ScoreAmount.TabIndex = 3;
            this.P2ScoreAmount.Text = "0";
            // 
            // P1x
            // 
            this.P1x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1x.AutoSize = true;
            this.P1x.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1x.Location = new System.Drawing.Point(322, 1192);
            this.P1x.Name = "P1x";
            this.P1x.Size = new System.Drawing.Size(64, 61);
            this.P1x.TabIndex = 4;
            this.P1x.Text = "X:";
            // 
            // P2x
            // 
            this.P2x.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2x.AutoSize = true;
            this.P2x.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2x.Location = new System.Drawing.Point(322, 1245);
            this.P2x.Name = "P2x";
            this.P2x.Size = new System.Drawing.Size(64, 61);
            this.P2x.TabIndex = 5;
            this.P2x.Text = "X:";
            // 
            // P1xAmount
            // 
            this.P1xAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1xAmount.AutoSize = true;
            this.P1xAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1xAmount.Location = new System.Drawing.Point(377, 1192);
            this.P1xAmount.Name = "P1xAmount";
            this.P1xAmount.Size = new System.Drawing.Size(51, 61);
            this.P1xAmount.TabIndex = 6;
            this.P1xAmount.Text = "0";
            this.P1xAmount.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // P2xAmount
            // 
            this.P2xAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2xAmount.AutoSize = true;
            this.P2xAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2xAmount.Location = new System.Drawing.Point(377, 1245);
            this.P2xAmount.Name = "P2xAmount";
            this.P2xAmount.Size = new System.Drawing.Size(51, 61);
            this.P2xAmount.TabIndex = 7;
            this.P2xAmount.Text = "0";
            // 
            // P1y
            // 
            this.P1y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1y.AutoSize = true;
            this.P1y.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1y.Location = new System.Drawing.Point(451, 1192);
            this.P1y.Name = "P1y";
            this.P1y.Size = new System.Drawing.Size(62, 61);
            this.P1y.TabIndex = 8;
            this.P1y.Text = "Y:";
            // 
            // P2y
            // 
            this.P2y.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2y.AutoSize = true;
            this.P2y.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2y.Location = new System.Drawing.Point(451, 1245);
            this.P2y.Name = "P2y";
            this.P2y.Size = new System.Drawing.Size(62, 61);
            this.P2y.TabIndex = 9;
            this.P2y.Text = "Y:";
            // 
            // P1yAmount
            // 
            this.P1yAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1yAmount.AutoSize = true;
            this.P1yAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1yAmount.Location = new System.Drawing.Point(512, 1192);
            this.P1yAmount.Name = "P1yAmount";
            this.P1yAmount.Size = new System.Drawing.Size(51, 61);
            this.P1yAmount.TabIndex = 10;
            this.P1yAmount.Text = "0";
            // 
            // P2yAmount
            // 
            this.P2yAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2yAmount.AutoSize = true;
            this.P2yAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2yAmount.Location = new System.Drawing.Point(512, 1245);
            this.P2yAmount.Name = "P2yAmount";
            this.P2yAmount.Size = new System.Drawing.Size(51, 61);
            this.P2yAmount.TabIndex = 11;
            this.P2yAmount.Text = "0";
            // 
            // P1Lives
            // 
            this.P1Lives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1Lives.AutoSize = true;
            this.P1Lives.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1Lives.Location = new System.Drawing.Point(647, 1192);
            this.P1Lives.Name = "P1Lives";
            this.P1Lives.Size = new System.Drawing.Size(134, 61);
            this.P1Lives.TabIndex = 12;
            this.P1Lives.Text = "Lives:";
            // 
            // P1LivesAmount
            // 
            this.P1LivesAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1LivesAmount.AutoSize = true;
            this.P1LivesAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1LivesAmount.Location = new System.Drawing.Point(767, 1192);
            this.P1LivesAmount.Name = "P1LivesAmount";
            this.P1LivesAmount.Size = new System.Drawing.Size(51, 61);
            this.P1LivesAmount.TabIndex = 13;
            this.P1LivesAmount.Text = "0";
            // 
            // P1Health
            // 
            this.P1Health.AccessibleName = "P1Health";
            this.P1Health.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1Health.AutoSize = true;
            this.P1Health.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1Health.Location = new System.Drawing.Point(811, 1192);
            this.P1Health.Name = "P1Health";
            this.P1Health.Size = new System.Drawing.Size(167, 61);
            this.P1Health.TabIndex = 14;
            this.P1Health.Text = "Health:";
            // 
            // P1HealthAmount
            // 
            this.P1HealthAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P1HealthAmount.AutoSize = true;
            this.P1HealthAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P1HealthAmount.Location = new System.Drawing.Point(971, 1192);
            this.P1HealthAmount.Name = "P1HealthAmount";
            this.P1HealthAmount.Size = new System.Drawing.Size(51, 61);
            this.P1HealthAmount.TabIndex = 15;
            this.P1HealthAmount.Text = "0";
            // 
            // P2Lives
            // 
            this.P2Lives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2Lives.AutoSize = true;
            this.P2Lives.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2Lives.Location = new System.Drawing.Point(647, 1245);
            this.P2Lives.Name = "P2Lives";
            this.P2Lives.Size = new System.Drawing.Size(134, 61);
            this.P2Lives.TabIndex = 16;
            this.P2Lives.Text = "Lives:";
            // 
            // P2LivesAmount
            // 
            this.P2LivesAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2LivesAmount.AutoSize = true;
            this.P2LivesAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2LivesAmount.Location = new System.Drawing.Point(767, 1245);
            this.P2LivesAmount.Name = "P2LivesAmount";
            this.P2LivesAmount.Size = new System.Drawing.Size(51, 61);
            this.P2LivesAmount.TabIndex = 17;
            this.P2LivesAmount.Text = "0";
            // 
            // P2Health
            // 
            this.P2Health.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2Health.AutoSize = true;
            this.P2Health.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2Health.Location = new System.Drawing.Point(811, 1245);
            this.P2Health.Name = "P2Health";
            this.P2Health.Size = new System.Drawing.Size(167, 61);
            this.P2Health.TabIndex = 18;
            this.P2Health.Text = "Health:";
            // 
            // P2HealthAmount
            // 
            this.P2HealthAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.P2HealthAmount.AutoSize = true;
            this.P2HealthAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.P2HealthAmount.Location = new System.Drawing.Point(971, 1245);
            this.P2HealthAmount.Name = "P2HealthAmount";
            this.P2HealthAmount.Size = new System.Drawing.Size(51, 61);
            this.P2HealthAmount.TabIndex = 19;
            this.P2HealthAmount.Text = "0";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimeLabel.Location = new System.Drawing.Point(1373, 1192);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(135, 61);
            this.TimeLabel.TabIndex = 20;
            this.TimeLabel.Text = "Time:";
            // 
            // TimeAmount
            // 
            this.TimeAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TimeAmount.AutoSize = true;
            this.TimeAmount.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TimeAmount.Location = new System.Drawing.Point(1509, 1192);
            this.TimeAmount.Name = "TimeAmount";
            this.TimeAmount.Size = new System.Drawing.Size(133, 61);
            this.TimeAmount.TabIndex = 21;
            this.TimeAmount.Text = "00:00";
            // 
            // Hint
            // 
            this.Hint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Hint.AutoSize = true;
            this.Hint.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Hint.Location = new System.Drawing.Point(1706, 1192);
            this.Hint.Name = "Hint";
            this.Hint.Size = new System.Drawing.Size(120, 61);
            this.Hint.TabIndex = 22;
            this.Hint.Text = "Hint:";
            this.Hint.Visible = false;
            this.Hint.Click += new System.EventHandler(this.Hint_Click);
            // 
            // HintValue
            // 
            this.HintValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HintValue.AutoSize = true;
            this.HintValue.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HintValue.Location = new System.Drawing.Point(1833, 1192);
            this.HintValue.Name = "HintValue";
            this.HintValue.Size = new System.Drawing.Size(136, 61);
            this.HintValue.TabIndex = 23;
            this.HintValue.Text = "None";
            this.HintValue.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.HintValue);
            this.Controls.Add(this.Hint);
            this.Controls.Add(this.TimeAmount);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.P2HealthAmount);
            this.Controls.Add(this.P2Health);
            this.Controls.Add(this.P2LivesAmount);
            this.Controls.Add(this.P2Lives);
            this.Controls.Add(this.P1HealthAmount);
            this.Controls.Add(this.P1Health);
            this.Controls.Add(this.P1LivesAmount);
            this.Controls.Add(this.P1Lives);
            this.Controls.Add(this.P2yAmount);
            this.Controls.Add(this.P1yAmount);
            this.Controls.Add(this.P2y);
            this.Controls.Add(this.P1y);
            this.Controls.Add(this.P2xAmount);
            this.Controls.Add(this.P1xAmount);
            this.Controls.Add(this.P2x);
            this.Controls.Add(this.P1x);
            this.Controls.Add(this.P2ScoreAmount);
            this.Controls.Add(this.P1ScoreAmount);
            this.Controls.Add(this.P2ScoreLabel);
            this.Controls.Add(this.P1ScoreLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Name = "Game";
            this.Size = new System.Drawing.Size(2511, 1338);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label P1ScoreLabel;
        private System.Windows.Forms.Label P2ScoreLabel;
        private System.Windows.Forms.Label P1ScoreAmount;
        private System.Windows.Forms.Label P2ScoreAmount;
        private System.Windows.Forms.Label P1x;
        private System.Windows.Forms.Label P2x;
        private System.Windows.Forms.Label P1xAmount;
        private System.Windows.Forms.Label P2xAmount;
        private System.Windows.Forms.Label P1y;
        private System.Windows.Forms.Label P2y;
        private System.Windows.Forms.Label P1yAmount;
        private System.Windows.Forms.Label P2yAmount;
        private System.Windows.Forms.Label P1Lives;
        private System.Windows.Forms.Label P1LivesAmount;
        private System.Windows.Forms.Label P1Health;
        private System.Windows.Forms.Label P1HealthAmount;
        private System.Windows.Forms.Label P2Lives;
        private System.Windows.Forms.Label P2LivesAmount;
        private System.Windows.Forms.Label P2Health;
        private System.Windows.Forms.Label P2HealthAmount;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label TimeAmount;
        private System.Windows.Forms.Label Hint;
        private System.Windows.Forms.Label HintValue;
    }
}
