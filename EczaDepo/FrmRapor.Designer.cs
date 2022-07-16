
namespace EczaDepo
{
    partial class FrmRapor
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTutar = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTamam = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbSure = new System.Windows.Forms.RadioButton();
            this.rbOnaylanmadı = new System.Windows.Forms.RadioButton();
            this.rbOnaylandi = new System.Windows.Forms.RadioButton();
            this.lblTeklifSure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(4, 17);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(579, 288);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(482, 313);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tutar: ";
            // 
            // lblTutar
            // 
            this.lblTutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTutar.AutoSize = true;
            this.lblTutar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTutar.Location = new System.Drawing.Point(532, 313);
            this.lblTutar.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(54, 20);
            this.lblTutar.TabIndex = 2;
            this.lblTutar.Text = "Tutar: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.lblTutar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(588, 342);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnTamam
            // 
            this.btnTamam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTamam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTamam.Location = new System.Drawing.Point(495, 364);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(98, 29);
            this.btnTamam.TabIndex = 4;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.UseVisualStyleBackColor = true;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblTeklifSure);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rbSure);
            this.groupBox2.Controls.Add(this.rbOnaylanmadı);
            this.groupBox2.Controls.Add(this.rbOnaylandi);
            this.groupBox2.Location = new System.Drawing.Point(9, 357);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(472, 38);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Durum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(267, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Teklif Süresi:";
            // 
            // rbSure
            // 
            this.rbSure.AutoSize = true;
            this.rbSure.Location = new System.Drawing.Point(167, 16);
            this.rbSure.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbSure.Name = "rbSure";
            this.rbSure.Size = new System.Drawing.Size(85, 17);
            this.rbSure.TabIndex = 3;
            this.rbSure.Text = "Süresi Doldu";
            this.rbSure.UseVisualStyleBackColor = true;
            this.rbSure.CheckedChanged += new System.EventHandler(this.rbSure_CheckedChanged);
            // 
            // rbOnaylanmadı
            // 
            this.rbOnaylanmadı.AutoSize = true;
            this.rbOnaylanmadı.Location = new System.Drawing.Point(79, 16);
            this.rbOnaylanmadı.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbOnaylanmadı.Name = "rbOnaylanmadı";
            this.rbOnaylanmadı.Size = new System.Drawing.Size(86, 17);
            this.rbOnaylanmadı.TabIndex = 1;
            this.rbOnaylanmadı.Text = "Onaylanmadı";
            this.rbOnaylanmadı.UseVisualStyleBackColor = true;
            this.rbOnaylanmadı.CheckedChanged += new System.EventHandler(this.rbOnaylanmadı_CheckedChanged);
            // 
            // rbOnaylandi
            // 
            this.rbOnaylandi.AutoSize = true;
            this.rbOnaylandi.Location = new System.Drawing.Point(4, 16);
            this.rbOnaylandi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbOnaylandi.Name = "rbOnaylandi";
            this.rbOnaylandi.Size = new System.Drawing.Size(72, 17);
            this.rbOnaylandi.TabIndex = 0;
            this.rbOnaylandi.Text = "Onaylandı";
            this.rbOnaylandi.UseVisualStyleBackColor = true;
            this.rbOnaylandi.CheckedChanged += new System.EventHandler(this.rbOnaylandi_CheckedChanged);
            // 
            // lblTeklifSure
            // 
            this.lblTeklifSure.AutoSize = true;
            this.lblTeklifSure.Location = new System.Drawing.Point(334, 18);
            this.lblTeklifSure.Name = "lblTeklifSure";
            this.lblTeklifSure.Size = new System.Drawing.Size(16, 13);
            this.lblTeklifSure.TabIndex = 5;
            this.lblTeklifSure.Text = "...";
            // 
            // FrmRapor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmRapor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor";
            this.Load += new System.EventHandler(this.FrmRapor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTutar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTamam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbSure;
        private System.Windows.Forms.RadioButton rbOnaylanmadı;
        private System.Windows.Forms.RadioButton rbOnaylandi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTeklifSure;
    }
}