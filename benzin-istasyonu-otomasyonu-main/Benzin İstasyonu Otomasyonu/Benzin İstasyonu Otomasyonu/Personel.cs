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
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
            ShowStaff();
        }
        Funtions Fx = new Funtions();
        private void ShowStaff()
        {
            string Query = "select * from StaffTbl";
            DataSet ds = Fx.ShowData(Query);
            StaffList.DataSource = ds.Tables[0];
        }
        private void Clear()
        {
            StNameTb.Text = "";
            StPasswordTb.Text = "";
            PhoneTb.Text = "";
            textBox2.Text = "";



        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || PhoneTb.Text == "" || StNameTb.Text == "" || StPasswordTb.Text == "" )
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Ip = StNameTb.Text;
                string Adı = StPasswordTb.Text;
                string Sayisi =  PhoneTb.Text;
                string Birim = textBox2.Text;



                try
                {
                    string Query = "insert into StaffTbl values('" + Ip + "','" + Adı + "','" + Sayisi + "', '" + Birim + "')";
                    Fx.SetData(Query, " Aktarıldı");
                    ShowStaff();
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
            
            if (textBox2.Text == "" || PhoneTb.Text == "" || StNameTb.Text == "" || StPasswordTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi!!");
            }
            else
            {
                string Ip = StNameTb.Text;
                string Adı = StPasswordTb.Text;
                string Sayisi = PhoneTb.Text;
                string Birim = textBox2.Text;

                try
                {
                    string Query = "UPDATE StaffTbl SET StName='" + Ip + "',StPass = '" + Adı + "', StPhone = '" + Sayisi + "', StAdd = '" + Birim + "' WHERE StAdd = '" + Birim + "'";
                    Fx.SetData(Query, "Personel Güncellendi");
                    ShowStaff();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void StaffList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            StNameTb.Text = StaffList.SelectedRows[0].Cells[1].Value.ToString();
            StPasswordTb.Text = StaffList.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = StaffList.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = StaffList.SelectedRows[0].Cells[4].Value.ToString();

            if (StNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(StaffList.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa Obj = new AnaSayfa();
            Obj.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (StNameTb.Text == "")
            {
                MessageBox.Show("Lütfen silinecek personel adını girin.");
            }
            else
            {
                string Ip = StNameTb.Text;
                string Adı = StPasswordTb.Text;
                string Birim = textBox2.Text;


                try
                {
                    string Query = "DELETE FROM StaffTbl WHERE StAdd = '" + Birim + "'";
                    Fx.SetData(Query, "Personel Silindi");
                    ShowStaff();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            string query = "SELECT * FROM StaffTbl";
            DataSet ds = Fx.ShowData(query);

            BindingSource staffBindingSource = new BindingSource();
            staffBindingSource.DataSource = ds.Tables[0];

            StaffList.DataSource = staffBindingSource;

            StNameTb.DataBindings.Add("Text", staffBindingSource, "StName");
            StPasswordTb.DataBindings.Add("Text", staffBindingSource, "StPass");
            PhoneTb.DataBindings.Add("Text", staffBindingSource, "StPhone");
            textBox2.DataBindings.Add("Text", staffBindingSource, "StAdd");
        }
    }
}
