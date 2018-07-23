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
    public partial class Vizualizare_lectii : Form
    {
        string email, autor;
        bool ok;
        public Vizualizare_lectii(string a,string b,bool c)
        {
            email = a;
            autor = b;
            ok=c;
            InitializeComponent();
        }

        private void Vizualizare_lectii_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            string querry = @"SELECT * FROM Lectii";
            con.Open();
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Titlul"].ToString()+','+reader["Regiune"].ToString());
            }
            con.Close();
            reader.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string selectie = comboBox1.SelectedItem.ToString(), path = Application.StartupPath,titlu,regiune;
            string[] doi = selectie.Split(',');
            titlu = doi[0];
            regiune = doi[1];
            path = path.Substring(0, path.Length - 10)+@"\Lectii\"+titlu+".bmp";
            pictureBox1.Image = new Bitmap(path);
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            string querry = @"Select * From Lectii WHERE Titlul = '"+titlu+"' and Regiune = '"+regiune+"' ";
            con.Open();
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add("Proiect creat de : " + reader["Autor"].ToString());
                listBox1.Items.Add("La data de : " + reader["Data"].ToString());
                listBox1.Items.Add("Adresa de email : " + reader["Email"].ToString());
            }
            con.Close();
            reader.Close();
        }

        private void Vizualizare_lectii_FormClosed(object sender, FormClosedEventArgs e)
        {
            comboBox1.Items.Clear();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        { Form1 form = new Form1();
            Cont form2 = new Cont(email, autor);
            if (ok == false)
            {
                form.Show();
            }
            else
                form2.Show();
            this.Hide();

        }
    }
}
