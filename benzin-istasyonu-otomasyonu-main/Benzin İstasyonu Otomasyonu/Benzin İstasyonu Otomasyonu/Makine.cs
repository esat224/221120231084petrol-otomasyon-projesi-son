using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Benzin_İstasyonu_Otomasyonu
{
    public partial class Makine : Form
    {
        public Makine()
        {
            InitializeComponent();
            GetFuel();
            ShowMachines();
        }
        int Key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FuelCb.Text = MachineList.SelectedRows[0].Cells[1].Value.ToString();
            CompCb.Text = MachineList.SelectedRows[0].Cells[2].Value.ToString();
            DescTb.Text = MachineList.SelectedRows[0].Cells[3].Value.ToString();
            if (DescTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MachineList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        Funtions Fx = new Funtions();
        private void GetFuel()
        {
            string Query = "select * from FuelTbl";
            string Col = "Fid";
            Fx.FillCombo(Query, Col, FuelCb);
        }
        private void ShowMachines()
        {
            string Query = "select * from MachineTbl";
            DataSet ds = Fx.ShowData(Query);
            MachineList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            DescTb.Text = "";
            CompCb.SelectedIndex = -1;
            FuelCb.SelectedIndex = -1;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (FuelCb.SelectedIndex == -1 || CompCb.SelectedIndex == -1 || DescTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Fuel = FuelCb.SelectedIndex.ToString();
                string Company = CompCb.SelectedIndex.ToString();
                string Description = DescTb.Text;
                try
                {
                    string Query = "insert into MachineTbl values(" + Fuel + "," + Company + ",'" + Description + "')";
                    Fx.SetData(Query, "Makine Aktarıldı");
                    ShowMachines();
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

           
            if (FuelCb.SelectedIndex == -1 || CompCb.SelectedIndex == -1 || DescTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Fuel = FuelCb.SelectedIndex.ToString();
                string Company = CompCb.SelectedIndex.ToString();
                string Description = DescTb.Text;
                try
                {
                    string Query = "UPDATE MachineTbl SET Fuel = '" + Fuel + "', Company = " + Company + ", Description = '" + Description + "' WHERE Fuel = " + Fuel;
                    Fx.SetData(Query, "Makine Güncellendi");
                    ShowMachines();
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
            if (FuelCb.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen silinecek makinenin yakıtını seçin.");
            }
            else
            {
                string Fuel = FuelCb.SelectedIndex.ToString();
                try
                {
                    string Query = "DELETE FROM MachineTbl WHERE Fuel = " + Fuel;
                    Fx.SetData(Query, "Makine Silindi");
                    ShowMachines();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa Obj = new AnaSayfa();
            Obj.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Makine_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM MachineTbl";
            DataSet ds = Fx.ShowData(query);

            // Veri kaynağını belirleme
            BindingSource machineBindingSource = new BindingSource();
            machineBindingSource.DataSource = ds.Tables[0];

            // DataGridView kontrolünü veri kaynağına bağlama
            MachineList.DataSource = machineBindingSource;

            // TextBox ve diğer kontrolleri veri kaynağına bağlama
            FuelCb.DataBindings.Add("Text", machineBindingSource, "Fuel");
            CompCb.DataBindings.Add("Text", machineBindingSource, "Company");
            DescTb.DataBindings.Add("Text", machineBindingSource, "Description");

            // Key değerini atama
            if (DescTb.Text == "")
            {
                Key = 0;
            }
            else
            {
            }
        }
    }
}
