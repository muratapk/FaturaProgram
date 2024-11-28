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
                conn.Open();
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@vno", textBox2.Text);
                cmd.Parameters.AddWithValue("@adres",textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklenmiştir");
                doldur();
                conn.Close();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
       private  void doldur()
        {
            string cumle = "select * from musteri";
            SqlDataAdapter adapter = new SqlDataAdapter(cumle, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridView1.CurrentRow.Index;
            textBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[satir].Cells[4].Value.ToString();
            txtId.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string cumle = "Update musteri set ad=@ad, vno=@vno,adres=@adres,tel=@tel where Id=@Id";
                SqlCommand cmd = new SqlCommand(cumle, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                cmd.Parameters.AddWithValue("@vno", textBox2.Text);
                cmd.Parameters.AddWithValue("@adres", textBox3.Text);
                cmd.Parameters.AddWithValue("@tel", textBox4.Text);
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Güncellendi");
                doldur();
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Bu Kaydı Silmek İstiyor musunuz", "Kayıt Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.Yes == cevap) 
            {
                conn.Open();
                string cumle = "Delete from musteri where Id=@Id";
                SqlCommand cmd = new SqlCommand(cumle, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", txtId.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi");
                doldur();
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from musteri where ad like '%" + textBox5.Text +"%'";
            SqlDataAdapter da=new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from musteri where vno like '%" + textBox5.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from musteri where adres like '%" + textBox5.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            string sorgu = "Select * from musteri where tel like '%" + textBox5.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
