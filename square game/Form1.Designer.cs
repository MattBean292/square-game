namespace square_game
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player1scoreLabel = new System.Windows.Forms.Label();
            this.player2scoreLabel = new System.Windows.Forms.Label();
            this.timerLabel = new System.Windows.Forms.Label();
            this.victoryLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // player1scoreLabel
            // 
            this.player1scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player1scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player1scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.player1scoreLabel.Location = new System.Drawing.Point(117, 9);
            this.player1scoreLabel.Name = "player1scoreLabel";
            this.player1scoreLabel.Size = new System.Drawing.Size(38, 27);
            this.player1scoreLabel.TabIndex = 0;
            // 
            // player2scoreLabel
            // 
            this.player2scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.player2scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player2scoreLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.player2scoreLabel.Location = new System.Drawing.Point(620, 9);
            this.player2scoreLabel.Name = "player2scoreLabel";
            this.player2scoreLabel.Size = new System.Drawing.Size(38, 27);
            this.player2scoreLabel.TabIndex = 1;
            // 
            // timerLabel
            // 
            this.timerLabel.BackColor = System.Drawing.Color.Transparent;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.timerLabel.Location = new System.Drawing.Point(378, 9);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(40, 27);
            this.timerLabel.TabIndex = 2;
            // 
            // victoryLabel
            // 
            this.victoryLabel.BackColor = System.Drawing.Color.Transparent;
            this.victoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.victoryLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.victoryLabel.Location = new System.Drawing.Point(261, 303);
            this.victoryLabel.Name = "victoryLabel";
            this.victoryLabel.Size = new System.Drawing.Size(267, 55);
            this.victoryLabel.TabIndex = 3;
            this.victoryLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.titleLabel.Location = new System.Drawing.Point(223, 36);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(319, 27);
            this.titleLabel.TabIndex = 4;
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 700);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.victoryLabel);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.player2scoreLabel);
            this.Controls.Add(this.player1scoreLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Click += new System.EventHandler(this.Form1_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label player1scoreLabel;
        private System.Windows.Forms.Label player2scoreLabel;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Label victoryLabel;
        private System.Windows.Forms.Label titleLabel;
    }
}

