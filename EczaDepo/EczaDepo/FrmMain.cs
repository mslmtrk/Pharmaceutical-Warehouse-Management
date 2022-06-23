using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using EczaDepo.CreatedClasses;

namespace EczaDepo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void Authorize()
        {
            JObject jObject = new JObject();
            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Basic {Base64Encode("bexfa:bexfa")}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/auth/token", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            Global.token = (string)responseData["AccessToken"];
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            //Authorize();

            //var serializedStr = File.ReadAllText(Global.path);
            //var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings());

            //for(int i =0; i<customerList.Count; i++)
            //{
            //    DateTime tarih = Convert.ToDateTime(customerList[i].Tarih);
            //    DateTime guncelTarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //    int gecenSure = (int)(guncelTarih - tarih).TotalDays;
            //    int sure = customerList[i].TeklifSuresi;

            //    if (gecenSure >= sure && customerList[i].Durum != "SuresiDoldu" && customerList[i].Durum != "Onaylandı")
            //    {
            //        customerList[i].Durum = "SuresiDoldu";
            //        var strResultJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
            //        File.WriteAllText(Global.path, strResultJson);
            //        MessageBox.Show(customerList[i].Alici + " teklifinin süresi doldu!", "Teklif Süresi Doldu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnTeklif_Click(object sender, EventArgs e)
        {
            FrmCari frmCari = new FrmCari();
            frmCari.ShowDialog();

            //if (Global.flag == 1)
            //{
                FrmTeklif1 frm = new FrmTeklif1();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            //}
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            FrmAyarlar frm = new FrmAyarlar();
            frm.ShowDialog();
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRaporlar frm = new FrmRaporlar();
            frm.ShowDialog();
        }
    }
}
