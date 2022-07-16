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
    public partial class FrmKlavye : Form
    {
        public FrmKlavye()
        {
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            FrmKlavyeEkle frm = new FrmKlavyeEkle();
            frm.ShowDialog();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Global.itemList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "İtem Adı";
            dataGridView1.Columns[2].HeaderText = "Miktar";
        }

        private void btnKapat1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmKlavye_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Global.itemList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "İtem Adı";
            dataGridView1.Columns[2].HeaderText = "Miktar";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            Global.itemList.RemoveAt(rowIndex);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = Global.itemList;
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[0].Width = 35;
            dataGridView1.Columns[1].HeaderText = "İtem Adı";
            dataGridView1.Columns[2].HeaderText = "Miktar";
        }
    }
}
