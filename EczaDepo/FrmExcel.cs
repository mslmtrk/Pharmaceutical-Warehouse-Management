using ExcelDataReader;
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
    public partial class FrmExcel : Form
    {
        public FrmExcel()
        {
            InitializeComponent();
        }

        private void FrmExcel_Load(object sender, EventArgs e)
        {

        }

        DataTableCollection tableCollection;
        DataTable dt;
        int flag = 0;

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter= "Excel Workbook|*.xlsx|Excel 97-2003 Workbook|*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using(var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using(IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });

                            tableCollection = result.Tables;
                            cmbSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cmbSheet.Items.Add(table.TableName);

                        }
                    }
                }
            }
            flag = 1;
        }

        private void cmbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = tableCollection[cmbSheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;

            string columnName = "İlaç Adı";
            string columnName2 = "Miktar";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][columnName].ToString() == "" || dt.Rows[i][columnName2].ToString() == "") continue;

                string ad = dt.Rows[i][columnName].ToString();
                int miktar = Convert.ToInt32(dt.Rows[i][columnName2]);

                int result = Global.itemList.FindIndex(x => x.AdString == ad);
                if (result > -1)
                {
                    Global.itemList[result].MiktarInt += miktar;
                }
                else
                {
                    Global.itemList.Add(new Item(Global.itemList.Count + 1, ad, miktar));
                }
            }
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            if(dt == null && flag == 1)
            {
                MessageBox.Show("Lütfen Sayfayı Seçin!");
            }
            else
            {
                this.Close();
            }
            
        }
    }
}
