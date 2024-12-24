using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzin_İstasyonu_Otomasyonu
{
    public partial class Yakıt : Form
    {

        public Yakıt()
        {
            InitializeComponent();
            GetFuel();
            ShowFuels();
        }

        Funtions Fx = new Funtions();
        private void GetFuel()
        {
            string Query = "select * from SupplierTbl";
            string Col = "Supid";
            Fx.FillCombo(Query, Col, SupidCb);
        }
        private void ShowFuels()
        {
            string Query = "select * from FuelTbl";
            DataSet ds = Fx.ShowData(Query);
            FuelList.DataSource = ds.Tables[0];
        }

        private void Clear()
        {
            FNameTb.Text = "";
            PriceTb.Text = "";
            SupidCb.SelectedIndex =-1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FNameTb.Text == "" || SupidCb.SelectedIndex == -1 || PriceTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Name = FNameTb.Text;
                string Price = PriceTb.Text;
                string Supplier = SupidCb.SelectedValue.ToString();
                try
                {
                    string Query = "insert into FuelTbl values('" + Name + "'," + Price + ",'" + Supplier + "')";
                    Fx.SetData(Query, "Yakıt Aktarıldı");
                    ShowFuels();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FNameTb.Text == "" || SupidCb.SelectedIndex == -1 || PriceTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Name = FNameTb.Text;
                string Price = PriceTb.Text;
                string Supplier = SupidCb.SelectedValue.ToString();
                try
                {
                    string Query = "UPDATE FuelTbl SET FName = '" + Name + "', FPrice = '" + Price + "', FSupplier = '" + Supplier + "' WHERE FName = '" + Name + "'";
                    Fx.SetData(Query, "Yakıt Güncellendi");
                    ShowFuels();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void FuelList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FNameTb.Text = FuelList.SelectedRows[0].Cells[1].Value.ToString();
            PriceTb.Text = FuelList.SelectedRows[0].Cells[2].Value.ToString();
            SupidCb.SelectedValue = FuelList.SelectedRows[0].Cells[3].Value.ToString();

            if (FNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(FuelList.SelectedRows[0].Cells[0].Value.ToString());
            }

          
            SaveBtn.Text = "Güncelle";
        
    }

        private void button2_Click(object sender, EventArgs e)
        {

            if (FNameTb.Text == "")
            {
                MessageBox.Show("Lütfen silinecek yakıt adını girin.");
            }
            else
            {
                string Name = FNameTb.Text;
                try
                {
                    string Query = "DELETE FROM FuelTbl WHERE FName = '" + Name + "'";
                    Fx.SetData(Query, "Yakıt Silindi");
                    ShowFuels();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        BindingSource fuelBindingSource = new BindingSource();

        private void Yakıt_Load(object sender, EventArgs e)
        {
            this.fuelTblTableAdapter.Fill(this.benzinIstasyonuDataSet1.FuelTbl);
            string Query = "select * from FuelTbl";
            DataSet ds = Fx.ShowData(Query);

            fuelBindingSource.DataSource = ds.Tables[0];
            FuelList.DataSource = fuelBindingSource;

            FNameTb.DataBindings.Add("Text", fuelBindingSource, "FName");
            PriceTb.DataBindings.Add("Text", fuelBindingSource, "FPrice");
            SupidCb.DataBindings.Add("SelectedValue", fuelBindingSource, "FSupplier");

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa Obj = new AnaSayfa();
            Obj.Show();
            this.Hide();
        }
       

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
