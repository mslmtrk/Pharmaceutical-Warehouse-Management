using EczaDepo.CreatedClasses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaDepo
{
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            var serializedStr = File.ReadAllText(Global.path);
            var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());

            dataGridView1.DataSource = customerList[Global.index].Ilaclar;
            lblTutar.Text = customerList[Global.index].Tutar.ToString();

            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].HeaderText = "İlaç Adı";
            dataGridView1.Columns[2].HeaderText = "Miktar";
            dataGridView1.Columns[3].HeaderText = "Açıklama/Muadil";
            dataGridView1.Columns[4].HeaderText = "Birim Fiyat";
            dataGridView1.Columns[5].HeaderText = "Toplam Fiyat";

            lblTeklifSure.Text = customerList[Global.index].TeklifSuresi.ToString() + " gün";

            if (customerList[Global.index].Durum == "Onaylandı")
            {
                rbOnaylandi.Checked = true;
            }
            else if(customerList[Global.index].Durum == "Onaylanmadı")
            {
                rbOnaylanmadı.Checked = true;
            }
            else
            {
                rbSure.Checked = true;
            }
        }

        private void rbOnaylandi_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnaylandi.Checked)
            {
                rbOnaylanmadı.Checked = false;
                rbSure.Checked = false;

                var serializedStr = File.ReadAllText(Global.path);
                var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());

                customerList[Global.index].Durum = "Onaylandı";
                var strResultJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                File.WriteAllText(Global.path, strResultJson);
            }
        }

        private void rbOnaylanmadı_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOnaylanmadı.Checked)
            {
                rbOnaylandi.Checked = false;
                rbSure.Checked = false;

                var serializedStr = File.ReadAllText(Global.path);
                var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());

                customerList[Global.index].Durum = "Onaylanmadı";
                var strResultJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                File.WriteAllText(Global.path, strResultJson);
            }
        }

        private void rbSure_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSure.Checked)
            {
                rbOnaylandi.Checked = false;
                rbOnaylanmadı.Checked = false;

                var serializedStr = File.ReadAllText(Global.path);
                var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());

                customerList[Global.index].Durum = "SuresiDoldu";
                var strResultJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                File.WriteAllText(Global.path, strResultJson);
            }
        }
        
        private void btnTamam_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
