namespace Kutuphane
{
    partial class OduncVermeForm
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
            this.lstKitaplar = new System.Windows.Forms.ListBox();
            this.lstUyeler = new System.Windows.Forms.ListBox();
            this.dtpOduncAlmaTarihi = new System.Windows.Forms.DateTimePicker();
            this.dtpIadeTarihi = new System.Windows.Forms.DateTimePicker();
            this.btnOduncVer = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstKitaplar
            // 
            this.lstKitaplar.FormattingEnabled = true;
            this.lstKitaplar.Location = new System.Drawing.Point(12, 29);
            this.lstKitaplar.Name = "lstKitaplar";
            this.lstKitaplar.Size = new System.Drawing.Size(200, 160);
            this.lstKitaplar.TabIndex = 0;
            // 
            // lstUyeler
            // 
            this.lstUyeler.FormattingEnabled = true;
            this.lstUyeler.Location = new System.Drawing.Point(218, 29);
            this.lstUyeler.Name = "lstUyeler";
            this.lstUyeler.Size = new System.Drawing.Size(200, 160);
            this.lstUyeler.TabIndex = 1;
            // 
            // dtpOduncAlmaTarihi
            // 
            this.dtpOduncAlmaTarihi.Location = new System.Drawing.Point(12, 220);
            this.dtpOduncAlmaTarihi.Name = "dtpOduncAlmaTarihi";
            this.dtpOduncAlmaTarihi.Size = new System.Drawing.Size(200, 20);
            this.dtpOduncAlmaTarihi.TabIndex = 2;
            // 
            // dtpIadeTarihi
            // 
            this.dtpIadeTarihi.Location = new System.Drawing.Point(218, 220);
            this.dtpIadeTarihi.Name = "dtpIadeTarihi";
            this.dtpIadeTarihi.Size = new System.Drawing.Size(200, 20);
            this.dtpIadeTarihi.TabIndex = 3;
            // 
            // btnOduncVer
            // 
            this.btnOduncVer.Location = new System.Drawing.Point(12, 260);
            this.btnOduncVer.Name = "btnOduncVer";
            this.btnOduncVer.Size = new System.Drawing.Size(200, 30);
            this.btnOduncVer.TabIndex = 4;
            this.btnOduncVer.Text = "Ödünç Ver";
            this.btnOduncVer.UseVisualStyleBackColor = true;
            this.btnOduncVer.Click += new System.EventHandler(this.btnOduncVer_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(218, 260);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(200, 30);
            this.btnIptal.TabIndex = 5;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kitaplar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Üyeler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ödünç Alma Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "İade Tarihi";
            // 
            // OduncVermeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnOduncVer);
            this.Controls.Add(this.dtpIadeTarihi);
            this.Controls.Add(this.dtpOduncAlmaTarihi);
            this.Controls.Add(this.lstUyeler);
            this.Controls.Add(this.lstKitaplar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OduncVermeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ödünç Verme";
            this.Load += new System.EventHandler(this.OduncVermeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ListBox lstKitaplar;
        private System.Windows.Forms.ListBox lstUyeler;
        private System.Windows.Forms.DateTimePicker dtpOduncAlmaTarihi;
        private System.Windows.Forms.DateTimePicker dtpIadeTarihi;
        private System.Windows.Forms.Button btnOduncVer;
        private System.Windows.Forms.Button btnIptal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
} 