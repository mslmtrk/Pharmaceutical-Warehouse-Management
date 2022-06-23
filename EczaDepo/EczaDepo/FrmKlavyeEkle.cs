using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaDepo
{
    public partial class FrmKlavyeEkle : Form
    {
        public FrmKlavyeEkle()
        {
            InitializeComponent();
        }

        public JObject SearchItem(string ad)
        {
            JObject jObject = new JObject();
            jObject["ItemName"] = ad;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/catalog/SearhItem", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
        }

        private void btnKapat2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if (cmbAd.Text.Trim() == "" || txtMiktar.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun!");
            }
            else
            {
                int miktar = Convert.ToInt32(txtMiktar.Text.Trim());
                if (miktar == 0)
                {
                    MessageBox.Show("Miktar 0 olamaz!");
                }
                else
                {
                    string ad = cmbAd.Text.Trim();
                    int result = Global.itemList.FindIndex(x => x.AdString == ad);
                    if (result > -1)
                    {
                        Global.itemList[result].MiktarInt += miktar;
                    }
                    else
                    {
                        Global.itemList.Add(new Item(Global.itemList.Count + 1, ad, miktar));
                    }
                    cmbAd.Text = "";
                    txtMiktar.Clear();
                    lblDurum.Text = "";
                    System.Threading.Thread.Sleep(100);
                    lblDurum.Text = "Başarıyla Eklendi.";
                }
            }

        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void FrmKlavyeEkle_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            var a = SearchItem("a");
            foreach (var i in a["Items"])
            {
                list.Add(i["Name"].ToString());
            }
            
            cmbAd.DataSource = list;
            cmbAd.Text = "";
        }

    }
}
