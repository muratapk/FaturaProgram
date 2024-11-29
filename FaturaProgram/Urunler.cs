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
    public partial class Urunler : Form
    {
        public Urunler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=fatura;Integrated Security=True;TrustServerCertificate=True");
        private void Urunler_Load(object sender, EventArgs e)
        {
            doldur();
        }
        private void doldur()
        {
            string sorgu = "Select * from urunler";
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu:" + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu = "insert into urunler (urunAd,urunFiyat,stok,ozellik) values (@urunAd,@urunFiyat,@stok,@ozellik)";
                //sql ekleme sorgu cümlesi
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@urunAd", textBox1.Text);
                cmd.Parameters.AddWithValue("@urunFiyat",Convert.ToDecimal(textBox3.Text));
                cmd.Parameters.AddWithValue("@stok",Convert.ToInt32(numericUpDown1.Text));
                cmd.Parameters.AddWithValue("@ozellik", textBox2.Text);
                cmd.ExecuteNonQuery();
                //sorgu cmd cümlesini çalıştır
                MessageBox.Show("Kayıt Eklendi");
                conn.Close();
                doldur();
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
            textBox4.Text= dataGridView1.Rows[satir].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString();
           numericUpDown1.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[4].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu = "Delete from urunler where urunId=@Id";
                //sql silme sorgu cümlesi
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Id", textBox4.Text);
                cmd.ExecuteNonQuery();
                //sorgu cmd cümlesini çalıştır
                MessageBox.Show("Kayıt Silindi");
                conn.Close();
                doldur();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu = "update urunler set urunAd=@urunAd,urunFiyat=@urunFiyat,stok=@stok,ozellik=@ozellik where urunId=@Id";
                //sql ekleme sorgu cümlesi
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@urunAd", textBox1.Text);
                cmd.Parameters.AddWithValue("@urunFiyat", Convert.ToDecimal(textBox3.Text));
                cmd.Parameters.AddWithValue("@stok", Convert.ToInt32(numericUpDown1.Text));
                cmd.Parameters.AddWithValue("@ozellik", textBox2.Text);
                cmd.Parameters.AddWithValue("@Id", textBox4.Text);
                cmd.ExecuteNonQuery();
                //sorgu cmd cümlesini çalıştır
                MessageBox.Show("Kayıt Eklendi");
                conn.Close();
                doldur();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen Ürün Adı Giriniz");
                textBox5.Focus();
                textBox5.BackColor = Color.Beige;
            }
            else
            {
                string sorgu = "Select * from musteri where ad like '%" + textBox5.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}
