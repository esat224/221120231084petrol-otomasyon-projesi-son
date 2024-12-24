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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GetFinance();
            GetCount();
            CountMachines();
            CountSuppliers();
            CountStaff();
            Kasa();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AnaSayfa Obj = new AnaSayfa();
            Obj.Show();
            this.Hide();
        }

        Funtions Fx = new Funtions();

        private void CountSuppliers()
        {
            string Query = "select count(*) from SupplierTbl";
            Fx.GetData(Query, SupLbl);
        }
        private void CountMachines()
        {
            string Query = "select count(*) from MachineTbl";
            Fx.GetData(Query, MachineLbl);
        }
        private void CountStaff()
        {
            string Query = "select count(*) from StaffTbl";
            Fx.GetData(Query, Stafflbl);
        }



        private void GetFinance()
        {
            string Query = "select sum(FPrice) from FuelTbl";
            Fx.GetData(Query, FinanceLbl);
            FinanceLbl.Text = FinanceLbl.Text + " TL";

        }

         private void GetCount()
        {
            string Query = "select sum(Price) from BillingTbl";
            Fx.GetData(Query, CountLbl);
            

        }
        private void Kasa()
        {
            string Query = "select sum(FPrice) from FuelTbl";
            Fx.GetData(Query, FinanceLbl);
            string query = "select sum(Price) from BillingTbl";
            Fx.GetData(query, CountLbl);

            int a, b, c;
            a = Convert.ToInt32(CountLbl.Text);
            b = Convert.ToInt32(FinanceLbl.Text);
            c = a - b;
            KasaLbl.Text = c.ToString();
        }
      



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MachineLbl_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
