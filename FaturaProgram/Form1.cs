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

namespace FaturaProgram
{
    public partial class Form1 : Form
    {
        SqlConnection conn=new SqlConnection("Data Source=PC105E\\SQLEXPRESS;Initial Catalog=fatura;Integrated Security=True;TrustServerCertificate=True");

        //veribağlanmak için kullanılan bağlantı
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            { 

                //conn.Open();
                string cumle = "select * from musteri";
                SqlDataAdapter adapter = new SqlDataAdapter(cumle,conn);
                DataTable dt=new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource= dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        }
    }
}
