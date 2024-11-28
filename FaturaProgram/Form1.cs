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
            //insert into musteri (ad,vno,adres,tel) values (text1.text
            string sorgu = "insert into musteri(ad,vno,adres,tel) values (@ad,@vno,@adres,@tel)";
            try
            {
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@vno", textBox2.Text);
                cmd.Parameters.AddWithValue("@adres",textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklenmiştir");
            }
            catch (Exception ex)
            {

                throw;
            }
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
