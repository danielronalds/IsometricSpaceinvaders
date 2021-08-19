
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
            this.GameOverButton = new System.Windows.Forms.Button();
            this.GameOverLbl = new System.Windows.Forms.Label();
            this.StartPnl = new System.Windows.Forms.Panel();
            this.PlayerNameTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StartScreenButton = new System.Windows.Forms.Button();
            this.GameOverPnl.SuspendLayout();
            this.StartPnl.SuspendLayout();
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
            this.GameOverPnl.Location = new System.Drawing.Point(729, 781);
            this.GameOverPnl.Name = "GameOverPnl";
            this.GameOverPnl.Size = new System.Drawing.Size(1090, 760);
            this.GameOverPnl.TabIndex = 1;
            this.GameOverPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.GameOverPnl_Paint);
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
            // StartPnl
            // 
            this.StartPnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.StartPnl.Controls.Add(this.StartScreenButton);
            this.StartPnl.Controls.Add(this.label4);
            this.StartPnl.Controls.Add(this.PlayerNameTxtBox);
            this.StartPnl.Controls.Add(this.label3);
            this.StartPnl.Controls.Add(this.label2);
            this.StartPnl.Controls.Add(this.label1);
            this.StartPnl.Location = new System.Drawing.Point(1096, 0);
            this.StartPnl.Name = "StartPnl";
            this.StartPnl.Size = new System.Drawing.Size(1090, 760);
            this.StartPnl.TabIndex = 1;
            // 
            // PlayerNameTxtBox
            // 
            this.PlayerNameTxtBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.PlayerNameTxtBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PlayerNameTxtBox.Font = new System.Drawing.Font("FFF Forward", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayerNameTxtBox.ForeColor = System.Drawing.Color.White;
            this.PlayerNameTxtBox.Location = new System.Drawing.Point(181, 397);
            this.PlayerNameTxtBox.MaxLength = 16;
            this.PlayerNameTxtBox.Name = "PlayerNameTxtBox";
            this.PlayerNameTxtBox.Size = new System.Drawing.Size(729, 65);
            this.PlayerNameTxtBox.TabIndex = 3;
            this.PlayerNameTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PlayerNameTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PlayerNameTxtBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("FFF Forward", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 725);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "DEVELOPED BY DANIEL RONALDS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("FFF Forward", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(481, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "ISOMETRIC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("FFF Forward", 63.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(995, 149);
            this.label1.TabIndex = 0;
            this.label1.Text = "SPACE INVADERS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("FFF Forward", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(481, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "ENTER NAME";
            // 
            // StartScreenButton
            // 
            this.StartScreenButton.FlatAppearance.BorderSize = 0;
            this.StartScreenButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartScreenButton.Font = new System.Drawing.Font("FFF Forward", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartScreenButton.ForeColor = System.Drawing.Color.White;
            this.StartScreenButton.Location = new System.Drawing.Point(345, 521);
            this.StartScreenButton.Name = "StartScreenButton";
            this.StartScreenButton.Size = new System.Drawing.Size(400, 102);
            this.StartScreenButton.TabIndex = 5;
            this.StartScreenButton.Text = "PLAY";
            this.StartScreenButton.UseVisualStyleBackColor = true;
            this.StartScreenButton.Click += new System.EventHandler(this.PlayGame);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 749);
            this.Controls.Add(this.GameOverPnl);
            this.Controls.Add(this.StartPnl);
            this.Controls.Add(this.GamePanel);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Isometric Space Invaders";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.GameOverPnl.ResumeLayout(false);
            this.GameOverPnl.PerformLayout();
            this.StartPnl.ResumeLayout(false);
            this.StartPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.Timer FrameRefresh;
        private System.Windows.Forms.Panel GameOverPnl;
        private System.Windows.Forms.Button GameOverButton;
        private System.Windows.Forms.Label GameOverLbl;
        private System.Windows.Forms.Panel StartPnl;
        private System.Windows.Forms.TextBox PlayerNameTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button StartScreenButton;
    }
}

