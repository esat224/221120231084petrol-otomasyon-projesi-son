using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Benzin_İstasyonu_Otomasyonu
{
    internal class Funtions
    {
        protected SqlConnection getConnection()
        {
            SqlConnection Con = new SqlConnection();
            Con.ConnectionString = "Data Source=127.0.0.1\\SQLEXPRESS;Initial Catalog=benzinistasyonu;Integrated Security=True";
            return Con;
        }
        //dashbord
        public void GetData(string Query, Label Lbl)
        {
            SqlConnection Con = getConnection();
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);   
            Lbl.Text = dt.Rows[0][0].ToString();
        }

        //combobox doldurma
        public void FillCombo(string Query, string Col, ComboBox Cb)
        {
            SqlConnection Con = getConnection();
            Con.Open();
            SqlCommand cmd = new SqlCommand(Query,Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add(Col, typeof(int));
            dt.Load(Rdr);
            Cb.ValueMember = Col;
            Cb.DataSource = dt;
            Con.Close();


        }

        //database görüntüleme
        public DataSet ShowData(string Query)
        {
            SqlConnection Con = getConnection();
            SqlCommand cmd = new SqlCommand(); 
            cmd.Connection = Con;
            cmd.CommandText = Query;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds; 
        }

       

        //database insert etme
        public void SetData(string Query,string Msg)
        {
        SqlConnection Con = getConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = Con;
        Con.Open();
        cmd.CommandText = Query;
        cmd.ExecuteNonQuery();
        Con.Close();

        MessageBox.Show(Msg,"Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Information);


        
        }

        public List<double> data;
        public List<string> PLables;
        public void GetCharData()
        {
            SqlConnection Con = getConnection();
            SqlCommand cmd = new SqlCommand("select FPrice from FuelLbl", Con);
            SqlCommand cmd1 = new SqlCommand("Select FName from FuelTbl", Con);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda.Fill(dt);
            sda.Fill(dt);
            data = new List<double>();
            PLables = new List<string>();

            foreach(DataRow dr in dt.Rows)
            {
                data.Add(Convert.ToDouble(dr["FPrice"].ToString()));

            }
            foreach(DataRow dr in dt1.Rows)
            {
                PLables.Add(Convert.ToString(dr["FName"].ToString()));
            }

        }

    }
}
