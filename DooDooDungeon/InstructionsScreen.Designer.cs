namespace DooDooDungeon
{
    partial class InstructionsScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsScreen));
            this.titleLabel = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.moveInstructionsLabel = new System.Windows.Forms.Label();
            this.distanceInstructionLabel = new System.Windows.Forms.Label();
            this.dookieLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rollPicture = new System.Windows.Forms.PictureBox();
            this.dookiePicture = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rollPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dookiePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Ravie", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.ForeColor = System.Drawing.Color.Yellow;
            this.titleLabel.Location = new System.Drawing.Point(0, -9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(600, 113);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "Instructions";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            this.menuButton.Font = new System.Drawing.Font("Impact", 17F);
            this.menuButton.Location = new System.Drawing.Point(199, 308);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(208, 45);
            this.menuButton.TabIndex = 4;
            this.menuButton.Text = "I\'m a big kid now";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            this.menuButton.Enter += new System.EventHandler(this.menuButton_Enter);
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.Font = new System.Drawing.Font("Impact", 14F);
            this.instructionsLabel.ForeColor = System.Drawing.Color.White;
            this.instructionsLabel.Location = new System.Drawing.Point(0, 71);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(600, 52);
            this.instructionsLabel.TabIndex = 5;
            this.instructionsLabel.Text = "Mr. Roll must escape the Waste Warrior\r\n who has trapped him in the Doo Doo Dunge" +
    "on\r\n";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // moveInstructionsLabel
            // 
            this.moveInstructionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.moveInstructionsLabel.Font = new System.Drawing.Font("Impact", 14F);
            this.moveInstructionsLabel.ForeColor = System.Drawing.Color.White;
            this.moveInstructionsLabel.Location = new System.Drawing.Point(0, 123);
            this.moveInstructionsLabel.Name = "moveInstructionsLabel";
            this.moveInstructionsLabel.Size = new System.Drawing.Size(600, 92);
            this.moveInstructionsLabel.TabIndex = 6;
            this.moveInstructionsLabel.Text = "Mr. Roll needs to use the WASD keys to \r\nnavigate his way through the Dungeon, \r\n" +
    "the Waste Warrior needs to use the arrow keys to catch Mr. Roll\r\n";
            this.moveInstructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // distanceInstructionLabel
            // 
            this.distanceInstructionLabel.BackColor = System.Drawing.Color.Transparent;
            this.distanceInstructionLabel.Font = new System.Drawing.Font("Impact", 14F);
            this.distanceInstructionLabel.ForeColor = System.Drawing.Color.White;
            this.distanceInstructionLabel.Location = new System.Drawing.Point(0, 188);
            this.distanceInstructionLabel.Name = "distanceInstructionLabel";
            this.distanceInstructionLabel.Size = new System.Drawing.Size(600, 69);
            this.distanceInstructionLabel.TabIndex = 7;
            this.distanceInstructionLabel.Text = "For every one square that Mr. Roll can move, Waste Warrior can move two\r\n";
            this.distanceInstructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dookieLabel
            // 
            this.dookieLabel.AutoSize = true;
            this.dookieLabel.Font = new System.Drawing.Font("Impact", 15F);
            this.dookieLabel.ForeColor = System.Drawing.Color.White;
            this.dookieLabel.Location = new System.Drawing.Point(76, 374);
            this.dookieLabel.Name = "dookieLabel";
            this.dookieLabel.Size = new System.Drawing.Size(129, 25);
            this.dookieLabel.TabIndex = 8;
            this.dookieLabel.Text = "Waste Warrior";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Impact", 15F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(423, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mr. Roll";
            // 
            // rollPicture
            // 
            this.rollPicture.Image = ((System.Drawing.Image)(resources.GetObject("rollPicture.Image")));
            this.rollPicture.Location = new System.Drawing.Point(428, 308);
            this.rollPicture.Name = "rollPicture";
            this.rollPicture.Size = new System.Drawing.Size(68, 63);
            this.rollPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.rollPicture.TabIndex = 3;
            this.rollPicture.TabStop = false;
            // 
            // dookiePicture
            // 
            this.dookiePicture.Image = ((System.Drawing.Image)(resources.GetObject("dookiePicture.Image")));
            this.dookiePicture.Location = new System.Drawing.Point(108, 308);
            this.dookiePicture.Name = "dookiePicture";
            this.dookiePicture.Size = new System.Drawing.Size(68, 63);
            this.dookiePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dookiePicture.TabIndex = 2;
            this.dookiePicture.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 14F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(600, 69);
            this.label2.TabIndex = 10;
            this.label2.Text = "At the start of each level Mr. Roll can place one wall wherever he wants\r\nin orde" +
    "r to help block the Warrior. Use WASD to move the wall, R to rotate,\r\nand SPACE " +
    "to place\r\n\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InstructionsScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dookieLabel);
            this.Controls.Add(this.distanceInstructionLabel);
            this.Controls.Add(this.moveInstructionsLabel);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.rollPicture);
            this.Controls.Add(this.dookiePicture);
            this.Controls.Add(this.titleLabel);
            this.Name = "InstructionsScreen";
            this.Size = new System.Drawing.Size(600, 500);
            ((System.ComponentModel.ISupportInitialize)(this.rollPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dookiePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox dookiePicture;
        private System.Windows.Forms.PictureBox rollPicture;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Label moveInstructionsLabel;
        private System.Windows.Forms.Label distanceInstructionLabel;
        private System.Windows.Forms.Label dookieLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
