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
    public partial class Inregistrare : Form
    {
        public Inregistrare()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string nume,  email, parola, cparola;
            nume = textBox1.Text;
            email = textBox2.Text;
            parola = textBox3.Text;
            cparola = textBox4.Text;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Completati toate campurile");
            else
                if (parola != cparola)
                label5.Show();
            else
                if (parola.Length < 6)
                MessageBox.Show("Parola trebuie sa aiba mai mult de 6 caractere");
            else
            if (textBox2.Text.IndexOf('@') == -1)
                MessageBox.Show("Verificati daca a-ti introdus emailul corect");
            else
            if (checkBox1.Checked == false)
                MessageBox.Show("Bifati campul nu sunt robot");
            else
            {
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                string querry = @"SELECT * FROM TabelUtilizatori WHERE Email = '" + email + "' ";
                con.Open();
                SqlCommand com = new SqlCommand(querry, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows == true)
                    MessageBox.Show("Emailul exista deja");
                else
                {
                    reader.Close();
                    string querry2 = @"INSERT INTO TabelUtilizatori VALUES( '" + nume + "' , '" + email + "' , '" + parola + "'  ) ";
                    SqlCommand com2 = new SqlCommand(querry2, con);
                    com2.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();

                    MessageBox.Show("Inregistrare reusita");

                    VariabilaGlobala.reg = false;
                    this.Hide();
                }
                con.Close();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            VariabilaGlobala.reg = false;
            
            this.Hide();
            
            
        }

        private void Inregistrare_Load(object sender, EventArgs e)
        {
            label5.Hide();
            VariabilaGlobala.reg = true;
            
        }

        private void Inregistrare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
