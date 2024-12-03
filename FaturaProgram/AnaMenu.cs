using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaProgram
{
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 yeni=new Form1();
            yeni.MdiParent = this;
            yeni.Show();
        }

        private void ekleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Urunler urn = new Urunler();
            urn.MdiParent = this;
            urn.Show();
        }

        private void ekleToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Satis sts= new Satis();
            sts.MdiParent = this;
            sts.Show();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult  soru=MessageBox.Show("Uygulamadan Çıkamk İstiyor musunuz?","Dikkat",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(soru==DialogResult.Yes)
            {
                Application.Exit();
            }
           
        }
    }
}
