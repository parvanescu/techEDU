using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect_2018
{
    public partial class Form1 : Form
    {
        int c = 0;
        bool auto ;
        public Form1()
        {
            InitializeComponent();
        }
        // Buton Inainte
      
        private void button3_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                if (c == 0)
                    pictureBox1.Image = Properties.Resources.Harta_Romaniei;
                if (c == 1)
                    pictureBox1.Image = Properties.Resources.descărcare__1_;
                if (c == 2)
                    pictureBox1.Image = Properties.Resources.descărcare;
                if (c == 3)
                    pictureBox1.Image = Properties.Resources.images;
                if (c == 4)
                {
                    pictureBox1.Image = Properties.Resources._100deAni;
                    c = 0;
                }
                else
                    c++;
            }
        }




        //Incarcarea Formului
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            string path = Application.StartupPath;
            path = path.Substring(0, path.Length - 10);
            string connectionstring= @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = " +path+ @"\Educational.mdf; Integrated Security = True";
            
            VariabilaGlobala.constring = connectionstring;
            button1.Enabled = false;
            button3.Enabled = false;
            button2.Text = "Manual";
            c = 0;
            timer1.Start();
            auto = true;

            VariabilaGlobala.resurse = path + @"\Resources";
            VariabilaGlobala.reg = false;
        }
       



        //Tickul De la timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (c == 0)
                pictureBox1.Image = Properties.Resources._100deAni;
            if (c == 1)
                pictureBox1.Image = Properties.Resources.Harta_Romaniei;
            if (c == 2)
            pictureBox1.Image = Properties.Resources.descărcare__1_;
            if (c == 3)
                pictureBox1.Image = Properties.Resources.descărcare;
            if (c == 4)
            {
                pictureBox1.Image = Properties.Resources.images;
                c = 0;
            } else
            c++;
        }






        //Buton auto/manual
        private void button2_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                if (auto == true)
                {
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button2.Text = "Auto";
                    timer1.Stop();
                    auto = false;
                }
                else
                {
                    button1.Enabled = false;
                    button3.Enabled = false;
                    button2.Text = "Manual";
                    timer1.Start();
                    auto = true;
                }
            }
        }


        //BUton inapoi
        private void button1_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                if (c == 1)
                    pictureBox1.Image = Properties.Resources._100deAni;
                if (c == 2)
                    pictureBox1.Image = Properties.Resources.Harta_Romaniei;
                if (c == 3)
                    pictureBox1.Image = Properties.Resources.descărcare__1_;
                if (c == 4)
                    pictureBox1.Image = Properties.Resources.descărcare;
                if (c == 0)
                {
                    pictureBox1.Image = Properties.Resources.images;
                    c = 4;
                }
                else c--;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                Vizualizare_lectii form = new Vizualizare_lectii(" ", " ", false);
                form.Show();
                this.Hide();
            }
        }
        //Deschide form inregistrare
        private void button6_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                
                Inregistrare form = new Inregistrare();
                
                form.Show();
            }
        }


        //buton logare
        private void button5_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true) {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                string email = textBox1.Text, autor = "";


                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);

                con.Open();
                string querry = @"Select * From TabelUtilizatori Where Email = '" + textBox1.Text + "' and Parola = '" + textBox2.Text + "' ";
                SqlCommand com = new SqlCommand(querry, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows == true)
                {
                    while (reader.Read())
                        autor = reader["Nume"].ToString();
                    Cont form = new Cont(email, autor);
                    MessageBox.Show("Autentificare reusita");
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Verifica Parola sau Emailul");
                    if (checkBox1.Checked == false)
                        textBox1.Clear();
                    textBox2.Clear();
                }
                con.Close();
                reader.Close();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (VariabilaGlobala.reg == true)
            {
                MessageBox.Show("Inchide prima data fereastra de inregistrare.");
            }
            else
            {
                ZooHub form = new ZooHub("guest", "guest", false);
                form.Show();
                this.Hide();
            }
        }
    }
}
