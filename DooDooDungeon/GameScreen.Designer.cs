namespace DooDooDungeon
{
    partial class GameScreen
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.turnLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // turnLabel
            // 
            this.turnLabel.BackColor = System.Drawing.Color.Transparent;
            this.turnLabel.Font = new System.Drawing.Font("Impact", 20F);
            this.turnLabel.ForeColor = System.Drawing.Color.Black;
            this.turnLabel.Location = new System.Drawing.Point(0, 15);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(600, 101);
            this.turnLabel.TabIndex = 0;
            this.turnLabel.Text = "Roll\'s Turn";
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // levelLabel
            // 
            this.levelLabel.BackColor = System.Drawing.Color.DimGray;
            this.levelLabel.Font = new System.Drawing.Font("Impact", 20F);
            this.levelLabel.ForeColor = System.Drawing.Color.Maroon;
            this.levelLabel.Location = new System.Drawing.Point(225, 116);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(150, 34);
            this.levelLabel.TabIndex = 1;
            this.levelLabel.Text = "Level 1";
            this.levelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DooDooDungeon.Properties.Resources._2020_11_16__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.turnLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(600, 500);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label levelLabel;
    }
}
