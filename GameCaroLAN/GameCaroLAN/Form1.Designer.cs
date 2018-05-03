namespace GameCaroLAN
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
            this.panelChessBoad = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLan = new System.Windows.Forms.Button();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.pictureBoxMark = new System.Windows.Forms.PictureBox();
            this.progressBarCoolDown = new System.Windows.Forms.ProgressBar();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tmCoolDown = new System.Windows.Forms.Timer(this.components);
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelChessBoad
            // 
            this.panelChessBoad.BackColor = System.Drawing.SystemColors.Control;
            this.panelChessBoad.Location = new System.Drawing.Point(1, 1);
            this.panelChessBoad.Name = "panelChessBoad";
            this.panelChessBoad.Size = new System.Drawing.Size(579, 452);
            this.panelChessBoad.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.Controls.Add(this.label1);
            this.panel.Controls.Add(this.buttonLan);
            this.panel.Controls.Add(this.textBoxIP);
            this.panel.Controls.Add(this.pictureBoxMark);
            this.panel.Controls.Add(this.progressBarCoolDown);
            this.panel.Controls.Add(this.textBoxName);
            this.panel.Location = new System.Drawing.Point(582, 189);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(241, 264);
            this.panel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 In a line to win";
            // 
            // buttonLan
            // 
            this.buttonLan.Location = new System.Drawing.Point(3, 169);
            this.buttonLan.Name = "buttonLan";
            this.buttonLan.Size = new System.Drawing.Size(235, 42);
            this.buttonLan.TabIndex = 4;
            this.buttonLan.Text = "LAN";
            this.buttonLan.UseVisualStyleBackColor = true;
            this.buttonLan.Click += new System.EventHandler(this.buttonLan_Click);
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(3, 124);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(146, 20);
            this.textBoxIP.TabIndex = 3;
            // 
            // pictureBoxMark
            // 
            this.pictureBoxMark.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxMark.Location = new System.Drawing.Point(155, 13);
            this.pictureBoxMark.Name = "pictureBoxMark";
            this.pictureBoxMark.Size = new System.Drawing.Size(83, 131);
            this.pictureBoxMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMark.TabIndex = 2;
            this.pictureBoxMark.TabStop = false;
            // 
            // progressBarCoolDown
            // 
            this.progressBarCoolDown.Location = new System.Drawing.Point(3, 56);
            this.progressBarCoolDown.Name = "progressBarCoolDown";
            this.progressBarCoolDown.Size = new System.Drawing.Size(146, 29);
            this.progressBarCoolDown.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(3, 13);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(146, 20);
            this.textBoxName.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::GameCaroLAN.Properties.Resources.GameAvatar;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(241, 175);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(582, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 175);
            this.panel1.TabIndex = 2;
            // 
            // tmCoolDown
            // 
            this.tmCoolDown.Tick += new System.EventHandler(this.tmCoolDown_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 456);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.panelChessBoad);
            this.Name = "Form1";
            this.Text = "GameCaro";
            this.Shown += new System.EventHandler(this.Form1_Show);
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelChessBoad;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonLan;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.PictureBox pictureBoxMark;
        private System.Windows.Forms.ProgressBar progressBarCoolDown;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmCoolDown;
    }
}

