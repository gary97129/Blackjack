using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalTest40941118
{
    public partial class Form1 : Form
    {

        System.Net.WebClient WC = new System.Net.WebClient();
        Random rnd = new Random();
        List<string> cards = new List<string> { "" };
        int po1 = 1;
        int po2 = 1;
        double n;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void setpb(int x=0,int y=0)
        {
            string[] f = { "spade", "heart", "diamond", "club" };
            n = rnd.Next(13) + 1;
            PictureBox pb = new PictureBox();
            pb.Location = new Point(50*x, 25+y);
            pb.Size = new Size(100, 200);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            string card = "";
            while (cards.Contains(card))
            {
                card = $"https://goclass.github.io/poker/{n}_of_{f[rnd.Next(4)]}s.png";
            }
            MemoryStream Ms = new MemoryStream(WC.DownloadData(card));
            pb.Image = Image.FromStream(Ms);
            Controls.Add(pb);
            pb.BringToFront();
            if (n > 10)
            {
                n = 0.5;
            }
            cards.Add(card);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToDouble(label1.Text) < 20)
            {
                setpb(po1);
                po1 += 1;
                label1.Text = (Convert.ToDouble(label1.Text) + n).ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToDouble(label2.Text) < 20)
            {
                setpb(po2,220);
                po2 += 1;
                label2.Text = (Convert.ToDouble(label2.Text) + n).ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            label2.Text = "0";
            for(int i = 0; i < Controls.Count; i++)
            {
                if(Controls[i] is PictureBox)
                {
                    Controls.Remove(Controls[i]);
                    i -= 1;
                }
            }
            po1 = 1;
            po2 = 1;
            cards.Clear();
            cards.Add("");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(Convert.ToDouble(label1.Text) == Convert.ToDouble(label2.Text) || (Convert.ToDouble(label1.Text)>20 && Convert.ToDouble(label2.Text) > 20))
            {
                MessageBox.Show("雙方平手");
            }
            else if((Convert.ToDouble(label1.Text) > Convert.ToDouble(label2.Text) && Convert.ToDouble(label1.Text) <= 20) || Convert.ToDouble(label2.Text) > 20)
            {
                MessageBox.Show("A方獲勝");
            }
            else if ((Convert.ToDouble(label1.Text) < Convert.ToDouble(label2.Text) & Convert.ToDouble(label2.Text) <= 20) || Convert.ToDouble(label1.Text) > 20)
            {
                MessageBox.Show("B方獲勝");
            }
        }
    }
}
