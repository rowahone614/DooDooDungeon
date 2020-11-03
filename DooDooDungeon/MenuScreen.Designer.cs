namespace DooDooDungeon
{
    partial class MenuScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
            this.titleLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.instructionsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.rollPicture = new System.Windows.Forms.PictureBox();
            this.dookiePicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rollPicture)).BeginInit();
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
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Doo Doo Dungeon";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playButton
            // 
            this.playButton.Font = new System.Drawing.Font("Impact", 17F);
            this.playButton.Location = new System.Drawing.Point(194, 176);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(208, 45);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Get Fartin\'";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            this.playButton.Enter += new System.EventHandler(this.playButton_Enter);
            // 
            // instructionsButton
            // 
            this.instructionsButton.Font = new System.Drawing.Font("Impact", 17F);
            this.instructionsButton.Location = new System.Drawing.Point(194, 227);
            this.instructionsButton.Name = "instructionsButton";
            this.instructionsButton.Size = new System.Drawing.Size(208, 45);
            this.instructionsButton.TabIndex = 2;
            this.instructionsButton.Text = "Potty Training";
            this.instructionsButton.UseVisualStyleBackColor = true;
            this.instructionsButton.Click += new System.EventHandler(this.instructionsButton_Click);
            this.instructionsButton.Enter += new System.EventHandler(this.instructionsButton_Enter);
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Impact", 17F);
            this.exitButton.Location = new System.Drawing.Point(194, 278);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(208, 45);
            this.exitButton.TabIndex = 3;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            this.exitButton.Enter += new System.EventHandler(this.exitButton_Enter);
            // 
            // rollPicture
            // 
            this.rollPicture.BackColor = System.Drawing.Color.Transparent;
            this.rollPicture.Image = ((System.Drawing.Image)(resources.GetObject("rollPicture.Image")));
            this.rollPicture.Location = new System.Drawing.Point(430, 186);
            this.rollPicture.Name = "rollPicture";
            this.rollPicture.Size = new System.Drawing.Size(158, 160);
            this.rollPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rollPicture.TabIndex = 5;
            this.rollPicture.TabStop = false;
            // 
            // dookiePicture
            // 
            this.dookiePicture.BackColor = System.Drawing.Color.Transparent;
            this.dookiePicture.Image = ((System.Drawing.Image)(resources.GetObject("dookiePicture.Image")));
            this.dookiePicture.Location = new System.Drawing.Point(16, 176);
            this.dookiePicture.Name = "dookiePicture";
            this.dookiePicture.Size = new System.Drawing.Size(158, 160);
            this.dookiePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dookiePicture.TabIndex = 4;
            this.dookiePicture.TabStop = false;
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.rollPicture);
            this.Controls.Add(this.dookiePicture);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.instructionsButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.titleLabel);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(600, 600);
            ((System.ComponentModel.ISupportInitialize)(this.rollPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dookiePicture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button instructionsButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.PictureBox dookiePicture;
        private System.Windows.Forms.PictureBox rollPicture;
    }
}
