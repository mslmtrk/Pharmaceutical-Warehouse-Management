using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using EczaDepo.CreatedClasses;

namespace EczaDepo
{
    public partial class FrmRaporlar : Form
    {
        public FrmRaporlar()
        {
            InitializeComponent();
        }

        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            List<Rapor> raporlar = new List<Rapor>();

            var serializedStr = File.ReadAllText(Global.path);
            if (serializedStr != "")
            {
                var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());
                for (int i = 0; i < customerList.Count; i++)
                {
                    raporlar.Add(new Rapor(Convert.ToInt32(customerList[i].Id), customerList[i].Alici, customerList[i].Durum, customerList[i].Tarih));
                }
            }
            dataGridView1.DataSource = raporlar;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "Alıcı";
            dataGridView1.Columns[2].HeaderText = "Durum";
            dataGridView1.Columns[3].HeaderText = "Tarih";
        }

        private void btnTeklif_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                Global.index = dataGridView1.CurrentCell.RowIndex;
                FrmRapor frm = new FrmRapor();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bir Teklif Seçilmedi!");
            }
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
