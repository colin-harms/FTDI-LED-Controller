namespace FTDI_Led_Controller
{
    partial class MainForm
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
            this.RotatingColorBtn = new System.Windows.Forms.Button();
            this.MouseFollowBtn = new System.Windows.Forms.Button();
            this.StaticColorBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RotatingColorBtn
            // 
            this.RotatingColorBtn.Location = new System.Drawing.Point(12, 12);
            this.RotatingColorBtn.Name = "RotatingColorBtn";
            this.RotatingColorBtn.Size = new System.Drawing.Size(260, 23);
            this.RotatingColorBtn.TabIndex = 0;
            this.RotatingColorBtn.Text = "Rotating Color";
            this.RotatingColorBtn.UseVisualStyleBackColor = true;
            this.RotatingColorBtn.Click += new System.EventHandler(this.rotatingColorBtn_Click);
            // 
            // MouseFollowBtn
            // 
            this.MouseFollowBtn.Location = new System.Drawing.Point(12, 42);
            this.MouseFollowBtn.Name = "MouseFollowBtn";
            this.MouseFollowBtn.Size = new System.Drawing.Size(260, 23);
            this.MouseFollowBtn.TabIndex = 1;
            this.MouseFollowBtn.Text = "Mouse Follow";
            this.MouseFollowBtn.UseVisualStyleBackColor = true;
            this.MouseFollowBtn.Click += new System.EventHandler(this.mouseFollowBtn_Click);
            // 
            // StaticColorBtn
            // 
            this.StaticColorBtn.Location = new System.Drawing.Point(12, 72);
            this.StaticColorBtn.Name = "StaticColorBtn";
            this.StaticColorBtn.Size = new System.Drawing.Size(260, 23);
            this.StaticColorBtn.TabIndex = 2;
            this.StaticColorBtn.Text = "Static Color";
            this.StaticColorBtn.UseVisualStyleBackColor = true;
            this.StaticColorBtn.Click += new System.EventHandler(this.staticColorBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.StaticColorBtn);
            this.Controls.Add(this.MouseFollowBtn);
            this.Controls.Add(this.RotatingColorBtn);
            this.Name = "MainForm";
            this.Text = "LED Control";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RotatingColorBtn;
        private System.Windows.Forms.Button MouseFollowBtn;
        private System.Windows.Forms.Button StaticColorBtn;
    }
}

