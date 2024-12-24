using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzin_İstasyonu_Otomasyonu
{
    public partial class Hesap : Form
    {
        public Hesap()
        {
            InitializeComponent();
            GetMachine();
            GetFuel();
            ShowBilling();
        }

        Funtions Fx = new Funtions();


        private void GetMachine()
        {
            string Query = "select * from MachineTbl";
            string Col = "MId";
            Fx.FillCombo(Query, Col, MachineCb);
        }
        private void GetFuel()
        {
            string Query = "select * from FuelTbl";
            string Col = "Fid";
            Fx.FillCombo(Query, Col, FuelCb);
        }
      

        private void ShowBilling()
        {
            string Query = "select * from BillingTbl";
            DataSet ds = Fx.ShowData(Query);
            BillList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            MachineCb.SelectedIndex = -1;
            FuelCb.SelectedIndex = -1;
            QtyTb.Text = "";
            PriceTb.Text = "";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa Obj = new AnaSayfa();
            Obj.Show();
            this.Hide(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MachineCb.SelectedIndex == -1 || FuelCb.SelectedIndex == -1 || QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Machine = MachineCb.SelectedValue.ToString();
                string Fuel = FuelCb.SelectedValue.ToString();
                string Qty = QtyTb.Text;
                string Price = PriceTb.Text;
                try
                {
                    string Query = "insert into BillingTbl values('" + Machine + "','" + Fuel + "'," + Qty + "," + Price + ")";
                    Fx.SetData(Query, "Hesap Aktarıldı");
                    ShowBilling();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MachineCb.SelectedIndex == -1 || FuelCb.SelectedIndex == -1 || QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Machine = MachineCb.SelectedValue.ToString();
                string Fuel = FuelCb.SelectedValue.ToString();
                string Qty = QtyTb.Text;
                string Price = PriceTb.Text;
                try
                {
                    string Query = "UPDATE BillingTbl SET Machine = '" + Machine + "' ,Fuel = '" + Fuel + "', Quantity = " + Qty + ", Price = " + Price + " WHERE Machine = '" + Machine + "'";
                    Fx.SetData(Query, "Hesap Güncellendi");
                    ShowBilling();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MachineCb.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen silinecek faturanın makinesini seçin.");
            }
            else
            {
                string Machine = MachineCb.SelectedValue.ToString();
                try
                {
                    string Query = "DELETE FROM BillingTbl WHERE Machine = '" + Machine + "'";
                    Fx.SetData(Query, "Hesap Silindi");
                    ShowBilling();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void BillList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MachineCb.SelectedValue = BillList.SelectedRows[0].Cells[1].Value.ToString();
            FuelCb.SelectedValue = BillList.SelectedRows[0].Cells[2].Value.ToString();
            QtyTb.Text = BillList.SelectedRows[0].Cells[3].Value.ToString();
            PriceTb.Text = BillList.SelectedRows[0].Cells[4].Value.ToString();


            if (QtyTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BillList.SelectedRows[0].Cells[0].Value.ToString());
            }


        }   

        private void Hesap_Load(object sender, EventArgs e)
        {
            // Bill tablosundan verileri çekme
            string query = "SELECT * FROM BillingTbl";
            DataSet ds = Fx.ShowData(query);

            // Veri kaynağını belirleme
            BindingSource billBindingSource = new BindingSource();
            billBindingSource.DataSource = ds.Tables[0];

            // DataGridView kontrolünü veri kaynağına bağlama
            BillList.DataSource = billBindingSource;

            // ComboBox ve TextBox kontrollerini veri kaynağına bağlama
            MachineCb.DataBindings.Add("SelectedValue", billBindingSource, "Machine");
            FuelCb.DataBindings.Add("SelectedValue", billBindingSource, "Fuel");
            QtyTb.DataBindings.Add("Text", billBindingSource, "Quantity");
            PriceTb.DataBindings.Add("Text", billBindingSource, "Price");

            // Key değerini atama
            if (QtyTb.Text == "")
            {
                Key = 0;
            }
            else
            {
            }


        }
    }
}
