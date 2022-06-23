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
using Newtonsoft.Json.Linq;
using DGVPrinterHelper;
using System.Drawing.Drawing2D;
using EczaDepo.CreatedClasses;
using Newtonsoft.Json;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp;

namespace EczaDepo
{
    public partial class FrmTeklif2 : Form
    {
        public FrmTeklif2()
        {
            InitializeComponent();
        }

        public JObject ItemDetail(int itemId)
        {
            JObject jObject = new JObject();
            jObject["ItemID"] = itemId;
            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/catalog/ItemDetail", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
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

        public JObject SearchItemEquivalent(string equivalentCode)
        {
            JObject jObject = new JObject();
            jObject["EquivalentCode"] = equivalentCode;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/catalog/SearhItem", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
        }

        public JObject SearchVendor(string name, string taxNumber)
        {
            JObject jObject = new JObject();
            jObject["Name"] = name;
            jObject["TaxNumber"] = taxNumber;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/purchasing/SearhVendor", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
        }

        public JObject SearchCustomer(string name, string taxNumber)
        {
            JObject jObject = new JObject();
            jObject["Name"] = name;
            jObject["TaxNumber"] = taxNumber;

            var content = new StringContent(jObject.ToString(), Encoding.UTF8, "application/json");
            Global.client.DefaultRequestHeaders.Clear();
            Global.client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Global.token}");

            var response = Global.client.PostAsync("http://172.34.1.12:1307/api/sales/SearhCustomer", content).GetAwaiter().GetResult();
            var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var responseData = JObject.Parse(responseString);

            return responseData;
        }

        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        List<Ilac1> ilacList1 = new List<Ilac1>();
        
        private void FrmTeklif_Load(object sender, EventArgs e)
        {
            Global.ilacList.Clear();
            float totalPrice = 0;
            float totalPurchasingPrice = 0;

            for (int i = 0; i < Global.itemList.Count; i++)
            {
                var item = SearchItem(Global.itemList[i].AdString);
                var quantity = Global.itemList[i].MiktarInt;
                var message = item["Message"].ToString();
                if (message[0] == '0') //ürün bulunmadıysa
                {
                    //Global.ilacList.Add(new Ilac(i + 1, Global.itemList[i].AdString, quantity, "Bulunamadı", 0, 0));
                    continue;
                }

                var itemId = (int)item["Items"][0]["ID"];
                var itemDetail = ItemDetail(itemId);
                var itemStockQuantity = (int)itemDetail["Item"]["StockQuantity"];

                if (itemStockQuantity >= quantity) //stock varsa
                {
                    var name = itemDetail["Item"]["Name"].ToString();
                    var birimFiyat = (float)itemDetail["Item"]["SalesPrice"];
                    var PurchasingPrice = float.Parse(itemDetail["Item"]["PurchasingPrice"].ToString());

                    Global.ilacList.Add(new Ilac(i + 1, name, quantity, "Orijinal", birimFiyat, birimFiyat * quantity));
                    ilacList1.Add(new Ilac1(i + 1, name, quantity, "Orijinal", PurchasingPrice, birimFiyat, birimFiyat * quantity));
                    totalPrice += birimFiyat * quantity;
                    totalPurchasingPrice += PurchasingPrice * quantity;
                }
                else//stock yoksa muadillerine bakar
                {
                    var equivalentCode = itemDetail["Item"]["EquivalentCode"].ToString();

                    if (equivalentCode == "#")//muadil yok
                    {
                        //Global.ilacList.Add(new Ilac(i + 1, itemDetail["Item"]["Name"].ToString(), quantity, "Stokta yok", 0, 0));
                        continue;
                    }
                    var equivalents = SearchItemEquivalent(equivalentCode);
                    var message2 = equivalents["Message"].ToString();

                    if (message2[0] == '0')//muadil yok
                    {
                        //Global.ilacList.Add(new Ilac(i + 1, itemDetail["Item"]["Name"].ToString(), quantity, "Stokta yok", 0, 0));
                        continue;
                    }
                    int flag = 0;

                    foreach (var x in equivalents["Items"])//muadillerin stockları
                    {
                        var equivalentItemDetail = ItemDetail((int)x["ID"]);
                        if ((int)equivalentItemDetail["Item"]["StockQuantity"] >= quantity)
                        {
                            var name = x["Name"].ToString();
                            var birimFiyat = (float)x["SalesPrice"];
                            var PurchasingPrice = float.Parse(equivalentItemDetail["Item"]["PurchasingPrice"].ToString());

                            Global.ilacList.Add(new Ilac(i + 1, itemDetail["Item"]["Name"].ToString(), quantity, name, birimFiyat, birimFiyat * quantity));
                            ilacList1.Add(new Ilac1(i + 1, itemDetail["Item"]["Name"].ToString(), quantity, name, PurchasingPrice, birimFiyat, birimFiyat * quantity));
                            totalPrice += birimFiyat * quantity;
                            totalPurchasingPrice += PurchasingPrice * quantity;
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 0)
                    {
                        //Global.ilacList.Add(new Ilac(i + 1, itemDetail["Item"]["Name"].ToString(), quantity, "Stokta yok", 0, 0));
                    }
                }
            }

            dataGridView1.DataSource = ilacList1;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "İlaç Adı";
            dataGridView1.Columns[2].HeaderText = "Miktar";
            dataGridView1.Columns[3].HeaderText = "Açıklama/Muadil";
            dataGridView1.Columns[4].HeaderText = "Alış Fiyatı";
            dataGridView1.Columns[5].HeaderText = "Birim Fiyat";
            dataGridView1.Columns[6].HeaderText = "Toplam Fiyat";

            pictureBox1.ImageLocation = Properties.Settings.Default.imageLocation;
            lblSirket.Text = Properties.Settings.Default.kurumAdi;
            lblTarih.Text = DateTime.Now.ToShortDateString();
            lblTutar.Text = totalPrice.ToString();
            lblNot.Text = Properties.Settings.Default.teklifNot;

            float karOrani = (totalPrice - totalPurchasingPrice) / totalPurchasingPrice * 100;
            if (float.IsNaN(karOrani))
            {
                lblKar.Text = "%" + 0.ToString();
            }
            else
            {
                lblKar.Text = "%" + String.Format("{0:0.00}", karOrani);
            }

            var customer = SearchCustomer(Global.cariName, Global.cariTaxNumber);
            lblName.Text = Global.cariName;
            string adres = customer["Items"][0]["Address"]["Body"].ToString() + " " + customer["Items"][0]["Address"]["CountyName"].ToString()+ "/" + customer["Items"][0]["Address"]["CityName"].ToString();
            lblAdres.Text = adres;
            lblVergiNumarasi.Text = Global.cariTaxNumber.ToString();
            lblHesapKodu.Text = customer["Items"][0]["AccountCode"].ToString();

        }

        public static DataTable ToDataTable<Ilac>(IList<Ilac> data)
        {
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(Ilac));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (Ilac item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            table.Columns[0].ColumnName = "ID";
            table.Columns[1].ColumnName = "AD";
            table.Columns[2].ColumnName = "MIKTAR";
            table.Columns[3].ColumnName = "AÇIKLAMA/MUADIL";
            table.Columns[4].ColumnName = "BIRIM FIYAT";
            table.Columns[5].ColumnName = "TOPLAM FIYAT";

            return table;
        }

        void ExportDataTableToPdf(DataTable dtTable, string strPdfPath, string strHeader)
        {
            FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontHead = new iTextSharp.text.Font(bfnHead, 16, 1, BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fontHead));
            document.Add(prgHeading);

            Paragraph prgSub = new Paragraph();
            BaseFont btnSub = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontSub = new iTextSharp.text.Font(btnSub, 8, 2, BaseColor.GRAY);
            prgSub.Alignment = Element.ALIGN_RIGHT;
            prgSub.Add(new Chunk("Sayın, " + lblName.Text, fontSub));
            prgSub.Add(new Chunk("\n" + lblAdres.Text, fontSub));
            prgSub.Add(new Chunk("\nVergi Numarası: " + lblVergiNumarasi.Text, fontSub));
            prgSub.Add(new Chunk("\nHesap Kodu: " + lblHesapKodu.Text, fontSub));
            prgSub.Add(new Chunk("\nTarih: " + DateTime.Now.ToShortDateString(), fontSub));      
            document.Add(prgSub);

            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, Left)));//***
            document.Add(p);

            document.Add(new Chunk("\n", fontHead));

            PdfPTable table = new PdfPTable(dtTable.Columns.Count);

            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fontColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, BaseColor.WHITE);
            for(int i = 0; i < dtTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = BaseColor.GRAY;
                cell.AddElement(new Chunk(dtTable.Columns[i].ColumnName.ToUpper(), fontColumnHeader));
                table.AddCell(cell);
            }

            for (int i = 0; i < dtTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtTable.Columns.Count; j++)
                {
                    table.AddCell(dtTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        private void btnYazdır_Click(object sender, EventArgs e)
        {
            if(txtSure.Text == "")
            {
                MessageBox.Show("Lütfen Teklif Süresini girin!");
            }
            else
            {
                //DGVPrinter printer = new DGVPrinter();

                //System.Drawing.Image img = System.Drawing.Image.FromFile(pictureBox1.ImageLocation);
                //Bitmap b = new Bitmap(img);
                //System.Drawing.Image i = resizeImage(b, new Size(70, 70));

                //DGVPrinter.ImbeddedImage img1 = new DGVPrinter.ImbeddedImage();
                //img1.theImage = i; img1.ImageX = 3; img1.ImageY = 3;
                //img1.ImageAlignment = DGVPrinter.Alignment.Right;
                //img1.ImageLocation = DGVPrinter.Location.Header;
                //printer.ImbeddedImageList.Add(img1);

                //printer.TitleSpacing = 30;
                //printer.Title = "Teklif";
                //printer.SubTitleSpacing = 15;
                //printer.SubTitle = string.Format("Cari: {0} \n Tarih: {1}", lblName.Text, DateTime.Now.Date.ToString("dd/MM/yyyy"));
                //printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                //printer.PageNumbers = true;
                //printer.PageNumberAlignment = StringAlignment.Near;
                //printer.PageNumberInHeader = false;
                //printer.PorportionalColumns = true;
                //printer.HeaderCellAlignment = StringAlignment.Near;
                //printer.Footer = "Teklif Tutarı: " + lblTutar.Text;
                //printer.FooterAlignment = StringAlignment.Far;
                //printer.FooterSpacing = 15;
                //printer.FooterPrint = DGVPrinter.PrintLocation.LastOnly;
                //printer.FooterPrint = DGVPrinter.PrintLocation.LastOnly;
                //printer.PageText = lblNot.Text + "\n\nPage ";
                //printer.PrintDataGridView(dataGridView1);

                var serializedStr = File.ReadAllText(Global.path);
                var customerList = JsonConvert.DeserializeObject<List<Customer>>(serializedStr, new JsonSerializerSettings()) ?? new List<Customer>();

                customerList.Add(new Customer(customerList.Count + 1, lblName.Text, lblTarih.Text, Convert.ToInt32(txtSure.Text), "Onaylanmadı", float.Parse(lblTutar.Text), Global.ilacList));
                var strResultJson = JsonConvert.SerializeObject(customerList, Formatting.Indented);
                File.WriteAllText(Global.path, strResultJson);

                DataTable dt = ToDataTable(Global.ilacList);

                ExportDataTableToPdf(dt, @"C:/EczaDepo/deneme.pdf", "TEKLIF");

            }
        }

        private void txtSure_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
