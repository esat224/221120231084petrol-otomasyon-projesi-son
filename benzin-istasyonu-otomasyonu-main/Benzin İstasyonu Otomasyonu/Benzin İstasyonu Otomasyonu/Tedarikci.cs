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
    public partial class Tedarikci : Form
    {
        public Tedarikci()
        {
            InitializeComponent();
            ShowSuppliers();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        Funtions Fx = new Funtions();
        private void ShowSuppliers()
        {
            string Query = "select * from SupplierTbl";
            DataSet ds = Fx.ShowData(Query);
            SuppliersList.DataSource = ds.Tables[0];
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (AddressTb.Text == "" || PhoneTb.Text == "" || SupNameTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Supplier = SupNameTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                try
                {
                    string Query = "insert into SupplierTbl values('" + Supplier + "','" + Phone + "','" + Address + "')";
                    Fx.SetData(Query, "Tedarikçi Aktarıldı");
                    ShowSuppliers();
                    Clear();
                }
                catch (Exception Ex){
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void Tedarikci_Load(object sender, EventArgs e)
        {
            this.supplierTblTableAdapter.Fill(this.benzinIstasyonuDataSet.SupplierTbl);
            string query = "SELECT * FROM SupplierTbl";
            DataSet ds = Fx.ShowData(query);

            // Veri kaynağını belirleme
            BindingSource suppliersBindingSource = new BindingSource();
            suppliersBindingSource.DataSource = ds.Tables[0];

            // DataGridView kontrolünü veri kaynağına bağlama
            SuppliersList.DataSource = suppliersBindingSource;

            // TextBox ve diğer kontrolleri veri kaynağına bağlama
            SupNameTb.DataBindings.Add("Text", suppliersBindingSource, "SupName");
            PhoneTb.DataBindings.Add("Text", suppliersBindingSource, "SupPhone");
            AddressTb.DataBindings.Add("Text", suppliersBindingSource, "SupAdd");


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (AddressTb.Text == "" || PhoneTb.Text == "" || SupNameTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Supplier = SupNameTb.Text;
                string Phone = PhoneTb.Text;
                string Address = AddressTb.Text;
                try
                {
                    string Query = "UPDATE SupplierTbl SET SupName = '" + Supplier + "',SupPhone = '" + Phone + "', SupAdd = '" + Address + "' WHERE SupName = '" + Supplier + "'";
                    Fx.SetData(Query, "Tedarikçi Güncellendi");
                    ShowSuppliers();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;

        private void SuppliersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SupNameTb.Text = SuppliersList.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = SuppliersList.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = SuppliersList.SelectedRows[0].Cells[3].Value.ToString();
            if(SupNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SuppliersList.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Clear()
        {
            PhoneTb.Text = "";
            Key = 0;
            SupNameTb.Text = "";
            AddressTb.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (SupNameTb.Text == "")
            {
                MessageBox.Show("Lütfen silinecek tedarikçi adını girin.");
            }
            else
            {
                string Supplier = SupNameTb.Text;
                try
                {
                    string Query = "DELETE FROM SupplierTbl WHERE SupName = '" + Supplier + "'";
                    Fx.SetData(Query, "Tedarikçi Silindi");
                    ShowSuppliers();
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
    }
}
