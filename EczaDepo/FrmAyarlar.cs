using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaDepo
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            txtKurumAdi.Text = Properties.Settings.Default.kurumAdi;
            txtNot.Text = Properties.Settings.Default.teklifNot;
            pictureBox1.ImageLocation = Properties.Settings.Default.imageLocation;
        }
        
        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "PNG files(*.png)|*.png| jpg files(*.jpg)|*.jpg| All Files(*.*)|*.*";

                if(dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pictureBox1.ImageLocation = dialog.FileName;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Bir hata oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.kurumAdi = txtKurumAdi.Text;
            Properties.Settings.Default.teklifNot = txtNot.Text;
            Properties.Settings.Default.imageLocation = pictureBox1.ImageLocation;
            Properties.Settings.Default.Save();

            lblSonuc.Text = "";
            System.Threading.Thread.Sleep(100);
            lblSonuc.Text = "Kaydedildi.";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
