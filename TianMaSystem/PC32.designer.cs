namespace BSC_System
{
    partial class PC32
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
            this.TxtCKDH = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtCKDH
            // 
            this.TxtCKDH.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtCKDH.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TxtCKDH.Location = new System.Drawing.Point(0, 0);
            this.TxtCKDH.Multiline = true;
            this.TxtCKDH.Name = "TxtCKDH";
            this.TxtCKDH.Size = new System.Drawing.Size(258, 46);
            this.TxtCKDH.TabIndex = 0;
            this.TxtCKDH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCKDH.WordWrap = false;
            this.TxtCKDH.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCKDH_KeyPress);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(0, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 45);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PC32
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(258, 91);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtCKDH);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PC32";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "出库单号-PC32";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PC32_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtCKDH;
        private System.Windows.Forms.Button button1;



    }
}