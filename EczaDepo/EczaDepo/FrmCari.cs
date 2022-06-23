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
    public partial class FrmCari : Form
    {
        public FrmCari()
        {
            InitializeComponent();
        }

        public JObject SearchVendor(string name)
        {
            JObject jObject = new JObject();
            jObject["Name"] = name;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/purchasing/SearhVendor", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
        }

        public JObject SearchCustomer(string name)
        {
            JObject jObject = new JObject();
            jObject["Name"] = name;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/sales/SearhCustomer", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);



            
            return responseData;
        }

        List<string> list = new List<string>();
        List<string> list2 = new List<string>();

        private void FrmCari_Load(object sender, EventArgs e)
        {
            var a = SearchCustomer("a");
            var a1 = SearchVendor("a");

            foreach (var i in a["Items"])
            {
                list.Add(i["Name"].ToString());
            }

            foreach (var i in a1["Items"])
            {
                list.Add(i["Name"].ToString());
            }

            cmbName.DataSource = list;
        }
        
        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            list2.Clear();
            var a = SearchCustomer(cmbName.Text);
            var a1= SearchVendor(cmbName.Text);

            foreach (var i in a["Items"])
            {
                list2.Add(i["TaxNumber"].ToString());
            }

            foreach (var i in a1["Items"])
            {
                list2.Add(i["TaxNumber"].ToString());
            }

            cmbTaxNumber.DataSource = null;
            cmbTaxNumber.DataSource = list2;
            cmbTaxNumber.Refresh();
        }

        private void btnDevamEt_Click(object sender, EventArgs e)
        {
            if (cmbName.Text.Trim() == "" || cmbTaxNumber.Text.Trim() == "")
            {
                MessageBox.Show("Lütfen gerekli alanları doldurun!");
            }
            else
            {
                string name = cmbName.Text.Trim();
                string taxNumber = cmbTaxNumber.Text.Trim();
                int result = list.FindIndex(x => x == name);
                int result2 = list2.FindIndex(x => x == taxNumber);

                if (result < 0)
                {
                    MessageBox.Show("Geçersiz isim girildi!");
                }
                else
                {
                    if(result2 < 0)
                    {
                        MessageBox.Show("Geçersiz vergi numarası girildi!");
                    }
                    else
                    {
                        Global.cariName = cmbName.Text;
                        Global.cariTaxNumber = cmbTaxNumber.Text;
                        Global.flag = 1;
                        this.Close();
                    }
                }
            }
            
        }

        private void FrmCari_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
