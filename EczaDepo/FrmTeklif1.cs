using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace EczaDepo
{
    public partial class FrmTeklif1 : Form
    {
        public FrmTeklif1()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            FrmExcel frm = new FrmExcel();
            frm.ShowDialog();
        }

        private void btnKlavye_Click(object sender, EventArgs e)
        {
            FrmKlavye frm = new FrmKlavye();
            frm.ShowDialog();
        }

        private void btnTeklifAl_Click(object sender, EventArgs e)
        {
            FrmTeklif2 frm = new FrmTeklif2();
            frm.ShowDialog();
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void içeriğiTemizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("İçeriği temizlemek istediğinizden emin misiniz?", "İçeriği Temizle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Global.itemList.Clear();
                MessageBox.Show("İçerik Temizlendi!");
            }     
        }
        
        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.ShowDialog();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int flag = 1;
        private void yeniTeklifToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            if(flag == 1)
            {
                FrmTeklif1 frm = new FrmTeklif1();
                frm.ShowDialog();
            }
            flag = 1;
        }

        private void FrmTeklif1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("İçerik silinecek, devam edilsin mi?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                flag = 0;
            }
            else
            {
                Global.itemList.Clear();
            }
        }
    }
}
