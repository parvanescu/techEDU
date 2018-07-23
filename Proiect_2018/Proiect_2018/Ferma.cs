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
   

    public partial class Ferma : Form
    {
        string email, autor;
        bool log;
        public Ferma(string a,string b,bool c)
        {
            email = a;
            autor = b;
            log = c;
            InitializeComponent();
        }
        string[] a = new string[40];
        int c = 3,imagine=1;
        bool stop = false;
        bool gaina=false, rata = false, vaca = false, oaia = false, capra = false, calul = false, porcul = false, cainele = false, pisica = false;

        private void button4_Click(object sender, EventArgs e)
        {
            ZooHub form = new ZooHub(email, autor, log);
            form.Show();
            this.Hide();

        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            tip.Hide(button3);
        }

        ToolTip tip = new ToolTip();
        private void button3_MouseEnter(object sender, EventArgs e)
        {
            tip.Show("De aici porniti sau opriti prezentarea imaginilor", button3);
        }

       
       

       
  

        private void button3_Click(object sender, EventArgs e)
        {
            if (stop == false)
            {
                timer1.Stop();
                stop = true;
                button3.Text = "Start";
            }else
            { timer1.Start();
                stop = true;
                button3.Text = "Stop";
            }
        }

        private void Ferma_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pisica == true)
            {

                MessageBox.Show("Ai terminat turul fermei");
                label1.Hide();
                button2.Hide();
                richTextBox1.Hide();
                pictureBox1.Hide();
                button1.Show();
                gaina = true;
                timer1.Stop();
                button3.Hide();

            }
            else
            {
                if (gaina == true)
                {
                    gaina = false;
                    rata = true;

                }
                else
                    if (rata == true)
                {
                    rata = false;
                    vaca = true;
                }
                else
                    if (vaca == true)
                {
                    vaca = false;
                    oaia = true;
                }
                else
                    if (oaia == true)
                {
                    oaia = false;
                    capra = true;
                }
                else
                    if (capra == true)
                {
                    capra = false;
                    calul = true;
                }
                else
                    if (calul == true)
                {
                    calul = false;
                    porcul = true;
                }
                else
                    if (porcul == true)
                {
                    porcul = false;
                    cainele = true;
                }
                else
                    if (cainele == true)
                {
                    cainele = false;
                    pisica = true;
                }
                label1.Text = a[c + 1];
                richTextBox1.Text = a[c + 2];
                c += 3;
                imagine = 1;
                timer1.Start();
                button3.Text = "Stop";
                stop = false;
            }

              
        }

        private void Ferma_Load(object sender, EventArgs e)
        {
            a = System.IO.File.ReadAllLines(VariabilaGlobala.resurse + @"\FermaAnimalelor.txt");
            pictureBox1.Hide();
            label1.Hide();
            richTextBox1.Hide();
            button2.Hide();
            button3.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (gaina == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\gaina" + imagine.ToString() + ".jpg");
                   if (rata == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\rata" + imagine.ToString() + ".jpg");
            if (vaca == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\vaca" + imagine.ToString() + ".jpg");
            if (oaia == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\oaia" + imagine.ToString() + ".jpg");
            if (capra == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\capra" + imagine.ToString() + ".jpg");
            if (calul == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\cal" + imagine.ToString() + ".jpg");
            if (porcul == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\porc" + imagine.ToString() + ".jpg");
            if (cainele == true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\caine" + imagine.ToString() + ".jpg");
            if(pisica==true)
                pictureBox1.Image = new Bitmap(VariabilaGlobala.resurse + @"\FERMA\pisica" + imagine.ToString() + ".jpg");
            if (imagine == 3)
                imagine = 1;
            else
                imagine++;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button3.Show();
            label1.Show();
            pictureBox1.Show();
            richTextBox1.Show();
            label1.Text = a[1];
            richTextBox1.Text = a[2];
            timer1.Start();
            gaina = true;
            button1.Hide();
            button2.Show();
            

        }
    }
}
