namespace DooDooDungeon
{
    partial class WinScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.winLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(0, 23);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(600, 113);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Mr. Roll Wins!";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winLabel
            // 
            this.winLabel.Font = new System.Drawing.Font("Impact", 20F);
            this.winLabel.ForeColor = System.Drawing.Color.White;
            this.winLabel.Location = new System.Drawing.Point(0, 101);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(600, 113);
            this.winLabel.TabIndex = 4;
            this.winLabel.Text = "Mr. Roll escaped  from the Waste Warrior";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DooDooDungeon.Properties.Resources.New_Piskel__2_;
            this.pictureBox1.Location = new System.Drawing.Point(239, 175);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // playAgainButton
            // 
            this.playAgainButton.Font = new System.Drawing.Font("Impact", 17F);
            this.playAgainButton.Location = new System.Drawing.Point(389, 344);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(171, 45);
            this.playAgainButton.TabIndex = 10;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = true;
            this.playAgainButton.Click += new System.EventHandler(this.playAgainButton_Click);
            this.playAgainButton.Enter += new System.EventHandler(this.playAgainButton_Enter);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Impact", 17F);
            this.exitButton.Location = new System.Drawing.Point(212, 344);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(171, 45);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Exit Game";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Impact", 17F);
            this.menuButton.Location = new System.Drawing.Point(35, 344);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(171, 45);
            this.menuButton.TabIndex = 8;
            this.menuButton.Text = "Return to Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            this.menuButton.Enter += new System.EventHandler(this.menuButton_Enter);
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.winLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(600, 500);
            this.Load += new System.EventHandler(this.WinScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button playAgainButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button menuButton;
    }
}
