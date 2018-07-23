using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
namespace Proiect_2018
{
    public partial class Jungla : Form
    {
        string email, autor;
        bool log;
        public Jungla(string a,string b,bool c)
        {
            email = a;
            autor = b;
            log = c;
            InitializeComponent();
        }
        string[] a = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\InfoJungla.txt");
        int c = 3;
        bool primu = true,pornit=false;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            pictureBox1.Show();
            richTextBox1.Show();
            label1.Text = a[1];
            richTextBox1.Text = a[2];
            pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\tigru.jpg");
            button2.Show();
            label1.Show();
            button3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(a[c]) == 16)
            { pictureBox1.Hide();
                label1.Hide();
                button2.Hide();
                richTextBox1.Hide();
                MessageBox.Show("Ai terminat turul");
                button1.Show();
                primu = true;
                button3.Hide();
            }
            else
            {
                button3.BackgroundImage = Properties.Resources.start;
                player.Stop();
                pornit = false;
                primu = false;
                label1.Text = a[c + 1];
                richTextBox1.Text = a[c + 2];
                if (Int32.Parse(a[c]) == 2)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\jaguar.jpg");
                if (Int32.Parse(a[c]) == 3)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\cazuar.jpg");
                if (Int32.Parse(a[c]) == 4)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\marmoset.jpg");
                if (Int32.Parse(a[c]) == 5)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\siamang.jpg");
                if (Int32.Parse(a[c]) == 6)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\ursmalaezian.jpg");
                if (Int32.Parse(a[c]) == 7)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\anaconda.jpg");
                if (Int32.Parse(a[c]) == 8)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\gorila.jpg");
                if (Int32.Parse(a[c]) == 9)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\elefant.jpg");
                if (Int32.Parse(a[c]) == 10)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\tatu.jpg");
                if (Int32.Parse(a[c]) == 11)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\furnicar.jpg");
                if (Int32.Parse(a[c]) == 12)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\hipopotam.jpg");
                if (Int32.Parse(a[c]) == 13)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\mamba.jpg");
                if (Int32.Parse(a[c]) == 14)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\crocodil.jpg");
                if (Int32.Parse(a[c]) == 15)
                    pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\IMAGINIJUNGLA\papagal.jpg");
                c += 3;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (pornit == false)
            {
                button3.BackgroundImage = Properties.Resources.stop;
               
                if (primu == false)
                {
                    player = new System.Media.SoundPlayer(VariabilaGlobala.resurse + @"\SuneteJungla\" + a[c - 3] + ".wav");

                }
                else
                {
                    player = new System.Media.SoundPlayer(VariabilaGlobala.resurse + @"\SuneteJungla\1.wav");
                }
                player.Play();
                pornit = true;
            }
            else
            { pornit = false;
                player.Stop();
                button3.BackgroundImage = Properties.Resources.start;
            }
           
        }

        private void Jungla_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Jungla_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            richTextBox1.Hide();
            button2.Hide();
            label1.Hide();
            button3.Hide();
        }
    }
}
