
namespace IsometricSpaceinvaders
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
            this.GamePanel = new System.Windows.Forms.Panel();
            this.FrameRefresh = new System.Windows.Forms.Timer(this.components);
            this.GameOverPnl = new System.Windows.Forms.Panel();
            this.GameOverLbl = new System.Windows.Forms.Label();
            this.GameOverButton = new System.Windows.Forms.Button();
            this.GameOverPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // GamePanel
            // 
            this.GamePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.GamePanel.Location = new System.Drawing.Point(0, 0);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(1090, 760);
            this.GamePanel.TabIndex = 0;
            this.GamePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.GamePanel_Paint);
            // 
            // FrameRefresh
            // 
            this.FrameRefresh.Enabled = true;
            this.FrameRefresh.Interval = 16;
            this.FrameRefresh.Tick += new System.EventHandler(this.FrameRefresh_Tick);
            // 
            // GameOverPnl
            // 
            this.GameOverPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.GameOverPnl.Controls.Add(this.GameOverButton);
            this.GameOverPnl.Controls.Add(this.GameOverLbl);
            this.GameOverPnl.Location = new System.Drawing.Point(1096, 0);
            this.GameOverPnl.Name = "GameOverPnl";
            this.GameOverPnl.Size = new System.Drawing.Size(1090, 760);
            this.GameOverPnl.TabIndex = 1;
            this.GameOverPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOverPnl_Paint);
            // 
            // GameOverLbl
            // 
            this.GameOverLbl.AutoSize = true;
            this.GameOverLbl.Font = new System.Drawing.Font("FFF Forward", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverLbl.ForeColor = System.Drawing.Color.White;
            this.GameOverLbl.Location = new System.Drawing.Point(278, 9);
            this.GameOverLbl.Name = "GameOverLbl";
            this.GameOverLbl.Size = new System.Drawing.Size(535, 112);
            this.GameOverLbl.TabIndex = 0;
            this.GameOverLbl.Text = "GAME OVER";
            // 
            // GameOverButton
            // 
            this.GameOverButton.Enabled = false;
            this.GameOverButton.FlatAppearance.BorderSize = 0;
            this.GameOverButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GameOverButton.Font = new System.Drawing.Font("FFF Forward", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOverButton.ForeColor = System.Drawing.Color.White;
            this.GameOverButton.Location = new System.Drawing.Point(305, 658);
            this.GameOverButton.Name = "GameOverButton";
            this.GameOverButton.Size = new System.Drawing.Size(480, 85);
            this.GameOverButton.TabIndex = 1;
            this.GameOverButton.Text = "PLAY AGAIN";
            this.GameOverButton.UseVisualStyleBackColor = true;
            this.GameOverButton.Click += new System.EventHandler(this.PlayGame);
            this.GameOverButton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.GameOverButton.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2165, 1421);
            this.Controls.Add(this.GameOverPnl);
            this.Controls.Add(this.GamePanel);
            this.Name = "Form1";
            this.Text = "Isometric Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.GameOverPnl.ResumeLayout(false);
            this.GameOverPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Timer FrameRefresh;
        private System.Windows.Forms.Panel GameOverPnl;
        private System.Windows.Forms.Button GameOverButton;
        private System.Windows.Forms.Label GameOverLbl;
    }
}

