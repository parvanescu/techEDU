using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_2018
{
    public partial class Polar : Form
    {
        string email, autor;
        bool log;
        public Polar(string a,string b,bool ok)
        {
            email = a;
            autor = b;
            log = ok;
            
            InitializeComponent();
        }
        string[] animale = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\Animalepolare.txt");
        int c = 3;
        

        private void AnimalePolare_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            label1.Hide();
            button2.Hide();
            richTextBox1.Hide();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(animale[c]) == 12)
            {
                label1.Hide();
                pictureBox1.Hide();
                button2.Hide();
                richTextBox1.Hide();
                c = 3;
                MessageBox.Show("Ai incheiat turul zonei polare");
                button1.Show();
                button3.Show();
            }
            else
            {
                if (Int32.Parse(animale[c]) == 2)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\iepurepolar.jpg");
                if (Int32.Parse(animale[c]) == 3)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\luppolar.jpg");
                if (Int32.Parse(animale[c]) == 4)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\ren.jpg");
                if (Int32.Parse(animale[c]) == 5)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\elan.jpg");
                if (Int32.Parse(animale[c]) == 6)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\urspolar.jpg");
                if (Int32.Parse(animale[c]) == 7)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\foca.jpg");
                if (Int32.Parse(animale[c]) == 8)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\vulpepolara.jpg");
                if (Int32.Parse(animale[c]) == 9)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\pinguinul.jpg");
                if (Int32.Parse(animale[c]) == 10)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\delfinul.jpg");
                if (Int32.Parse(animale[c]) == 11)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\bufnitapolara.jpg");
                label1.Text = animale[c + 1];
                richTextBox1.Text = animale[c + 2];
                c += 3;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZooHub form = new ZooHub(email, autor, log);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            richTextBox1.Show();
            label1.Show();
            button1.Hide();
            button2.Show();
            button3.Hide();
            label1.Text = animale[1];
            richTextBox1.Text = animale[2];
            pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\POLARE\linx.jpg");

        }
    }
}
