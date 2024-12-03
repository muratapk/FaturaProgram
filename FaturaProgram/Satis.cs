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
    public partial class Satis : Form
    {
        public Satis()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=fatura;Integrated Security=True;TrustServerCertificate=True");
        private void Satis_Load(object sender, EventArgs e)
        {
            doldur();
            musteridoldur();
            urundoldur();
        }
        private void doldur()
        {
            string sorgu = "Select * from siparisler";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void musteridoldur()
        {
            string sorgu = "Select * from musteri";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ad";
            comboBox1.ValueMember = "Id";
        }

        private void urundoldur()
        {
            string sorgu = "Select * from urunler";
            SqlDataAdapter da = new SqlDataAdapter(sorgu, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "urunAd";
            comboBox2.ValueMember = "urunId";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu = "insert into siparisler (musteriId,urunId,adet,tarih,aciklama) values(@musteriId,@urunId,@adet,@tarih,@aciklama) ";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@musteriId", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@urunId", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@adet", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@aciklama", textBox1.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi");
                doldur();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridView1.CurrentRow.Index;
            comboBox1.SelectedValue = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.Rows[satir].Cells[2].Value.ToString();
            numericUpDown1.Value = Convert.ToDecimal(dataGridView1.Rows[satir].Cells[3].Value.ToString());
            dateTimePicker1.Value =Convert.ToDateTime(dataGridView1.Rows[satir].Cells[4].Value.ToString());
            textBox1.Text = dataGridView1.Rows[satir].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult cevap=MessageBox.Show("Kayıt Silinsin mi?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(cevap==DialogResult.Yes)
                {
                    conn.Open();
                    string sorgu = "Delete from siparisler where siparisId=@Id  ";
                    SqlCommand cmd = new SqlCommand(sorgu, conn);
                    cmd.Parameters.Clear();
                   
                    cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Eklendi");
                    doldur();
                    conn.Close();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string sorgu = "update siparisler set musteriId=@musteriId,urunId=@urunId,adet=@adet,tarih=@tarih,aciklama=@aciklama where siparisId=@Id ";
                SqlCommand cmd = new SqlCommand(sorgu, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@musteriId", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@urunId", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@adet", numericUpDown1.Value);
                cmd.Parameters.AddWithValue("@tarih", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("@aciklama", textBox1.Text);
                cmd.Parameters.AddWithValue("@Id", textBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Eklendi");
                doldur();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata Oluştu" + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Visible = true;
            textBox3.Text = "Aranacak Müşteri Adını Girin";
           
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }
    }
}
