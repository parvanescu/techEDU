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
    public partial class AnimaleRomania : Form
    {
        int contor_animale=3,contor_reptile=3,contor_pasari=3;
        
        public AnimaleRomania()
        {
            InitializeComponent();
        }
        string[] a = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\\MamifereRomania.txt");
        string[] b = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\\ReptileRomania.txt");
        string[] c = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\\PasariRomania.txt");
        bool mamifere = false, reptile = false, pasari = false;
        //Buton mamifere
        private void button1_Click(object sender, EventArgs e)
        {   
            label1.Show();
            richTextBox1.Show();
            pictureBox1.Show();
            button2.Hide();
            button3.Hide();
            button1.Hide();
            button4.Show();
                label1.Text = a[1];
                richTextBox1.Text = a[2];
            
            Bitmap bitmap = new Bitmap(VariabilaGlobala.resurse + @"\\Animale\\arici.jpg");
            pictureBox1.Image = bitmap;
            mamifere = true;
           
        }

        private void AnimaleRomania_Load(object sender, EventArgs e)
        {
            label1.Hide();
            richTextBox1.Hide();
            pictureBox1.Hide();
            button4.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Show();
            richTextBox1.Show();
            pictureBox1.Show();
            button2.Hide();
            button3.Hide();
            button1.Hide();
            button4.Show();
            label1.Text = c[1];
            richTextBox1.Text = c[2];

            Bitmap bitmap = new Bitmap(VariabilaGlobala.resurse + @"\\Pasari\\barza.jpg");
            pictureBox1.Image = bitmap;
            pasari = true;
        }

        private void AnimaleRomania_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mamifere == true)
            {
                if (Int32.Parse(a[contor_animale]) == 10)
                {
                    MessageBox.Show("Ai vazut toate mamiferele");
                    richTextBox1.Hide();
                    label1.Hide();
                    pictureBox1.Hide();
                    button4.Hide();
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    mamifere = false;
                }
                else
                {
                    label1.Text = a[contor_animale + 1];
                    richTextBox1.Text = a[contor_animale + 2];
                    if (Int32.Parse(a[contor_animale]) == 2)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\capra.jpg");
                    if (Int32.Parse(a[contor_animale]) == 3)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\Caprioara.jpg");
                    if (Int32.Parse(a[contor_animale]) == 4)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\iepure.jpg");
                    if (Int32.Parse(a[contor_animale]) == 5)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\lup.jpg");
                    if (Int32.Parse(a[contor_animale]) == 6)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\mistret.jpg");
                    if (Int32.Parse(a[contor_animale]) == 7)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\ursbrun.jpg");
                    if (Int32.Parse(a[contor_animale]) == 8)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\veverita.jpg");
                    if (Int32.Parse(a[contor_animale]) == 9)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Animale\\vulpe.jpg");


                    contor_animale += 3;
                }
            }
            if (reptile == true)
            {
                if (Int32.Parse(b[contor_reptile]) == 7)
                {
                    MessageBox.Show("Ai vazut toate reptilele");
                    richTextBox1.Hide();
                    label1.Hide();
                    pictureBox1.Hide();
                    button4.Hide();
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    reptile = false;
                }
                else
                {
                    label1.Text = b[contor_reptile + 1];
                    richTextBox1.Text = b[contor_reptile + 2];
                    if (Int32.Parse(b[contor_reptile]) == 2)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Reptile\\soparla.jpg");
                    if (Int32.Parse(b[contor_reptile]) == 3)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Reptile\\sarpealun.jpg");
                    if (Int32.Parse(b[contor_reptile]) == 4)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Reptile\\sarpeapa.jpg");
                    if (Int32.Parse(b[contor_reptile]) == 5)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Reptile\\viperacorn.jpg");
                    if (Int32.Parse(b[contor_reptile]) == 6)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Reptile\\sarperau.jpg");
                    contor_reptile += 3;
                }
            }
            if (pasari == true)
            {
                if (Int32.Parse(c[contor_pasari]) == 13)
                {
                    MessageBox.Show("Ai vazut toate pasarile");
                    richTextBox1.Hide();
                    label1.Hide();
                    pictureBox1.Hide();
                    button4.Hide();
                    button1.Show();
                    button2.Show();
                    button3.Show();
                    pasari=false;
                }
                else
                {
                    label1.Text = c[contor_pasari + 1];
                    richTextBox1.Text = c[contor_pasari + 2];
                    if (Int32.Parse(c[contor_pasari]) == 2)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\cinteza.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 3)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\ciocanitoareaneagra.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 4)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\cocosdemunte.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 5)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\corb.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 6)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\cotofana.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 7)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\cucul.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 8)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\dropia.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 9)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\fazan.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 10)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\gugustiuc.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 11)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\pitigoi.jpg");
                    if (Int32.Parse(c[contor_pasari]) == 12)
                        pictureBox1.Image = Bitmap.FromFile(VariabilaGlobala.resurse + @"\\Pasari\\prepelita.jpg");
                    contor_pasari += 3;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Show();
            richTextBox1.Show();
            pictureBox1.Show();
            button2.Hide();
            button3.Hide();
            button1.Hide();
            button4.Show();
            label1.Text = b[1];
            richTextBox1.Text = b[2];

            Bitmap bitmap = new Bitmap(VariabilaGlobala.resurse + @"\\Reptile\\testoasa.jpg");
            pictureBox1.Image = bitmap;
            reptile = true;
        }
    }
}
