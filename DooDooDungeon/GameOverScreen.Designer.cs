namespace DooDooDungeon
{
    partial class GameOverScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameOverScreen));
            this.titleLabel = new System.Windows.Forms.Label();
            this.gameOverLabel = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.playAgainButton = new System.Windows.Forms.Button();
            this.dookiePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dookiePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(0, 35);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(600, 113);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Game Over!";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.Font = new System.Drawing.Font("Impact", 20F);
            this.gameOverLabel.ForeColor = System.Drawing.Color.White;
            this.gameOverLabel.Location = new System.Drawing.Point(0, 123);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(600, 113);
            this.gameOverLabel.TabIndex = 3;
            this.gameOverLabel.Text = "You were caught by the Waste Warrior";
            this.gameOverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Impact", 17F);
            this.menuButton.Location = new System.Drawing.Point(38, 375);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(171, 45);
            this.menuButton.TabIndex = 5;
            this.menuButton.Text = "Return to Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Enter += new System.EventHandler(this.menuButton_Enter);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Impact", 17F);
            this.exitButton.Location = new System.Drawing.Point(215, 375);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(171, 45);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Exit Game";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            // 
            // playAgainButton
            // 
            this.playAgainButton.Font = new System.Drawing.Font("Impact", 17F);
            this.playAgainButton.Location = new System.Drawing.Point(392, 375);
            this.playAgainButton.Name = "playAgainButton";
            this.playAgainButton.Size = new System.Drawing.Size(171, 45);
            this.playAgainButton.TabIndex = 7;
            this.playAgainButton.Text = "Play Again";
            this.playAgainButton.UseVisualStyleBackColor = true;
            this.playAgainButton.Enter += new System.EventHandler(this.playAgainButton_Enter);
            // 
            // dookiePicture
            // 
            this.dookiePicture.Image = ((System.Drawing.Image)(resources.GetObject("dookiePicture.Image")));
            this.dookiePicture.Location = new System.Drawing.Point(227, 219);
            this.dookiePicture.Name = "dookiePicture";
            this.dookiePicture.Size = new System.Drawing.Size(150, 150);
            this.dookiePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dookiePicture.TabIndex = 4;
            this.dookiePicture.TabStop = false;
            // 
            // GameOverScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.playAgainButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.dookiePicture);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.titleLabel);
            this.Name = "GameOverScreen";
            this.Size = new System.Drawing.Size(600, 500);
            ((System.ComponentModel.ISupportInitialize)(this.dookiePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label gameOverLabel;
        private System.Windows.Forms.PictureBox dookiePicture;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button playAgainButton;
    }
}
