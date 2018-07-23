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
    public partial class Lectii_postate2 : Form
    {
        string email,autor;
        public Lectii_postate2(string a,string b)
        {
            email = a;
            autor = b;
            
            InitializeComponent();
        }
         
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            pictureBox1.Show();
            string numelectie,data="";
            numelectie = comboBox1.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            string querry = @"SELECT * FROM Lectii WHERE Titlul = '" + numelectie + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                data = reader["Data"].ToString();
            }
            con.Close();
            label3.Text = data.ToString();
            string path = Application.StartupPath;
            path = path.Substring(0, path.Length - 10) + @"\Lectii\" + numelectie + ".bmp";
            pictureBox1.Image = new Bitmap(path);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titlu = comboBox1.SelectedItem.ToString();
            comboBox1.Items.Remove(comboBox1.SelectedItem);
            pictureBox1.Hide();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            string querry = @"DELETE  FROM Lectii WHERE Titlul = '" + titlu + "' ";
            con.Open();
            SqlCommand com = new SqlCommand(querry, con);
            com.ExecuteNonQuery();
            MessageBox.Show("Lectie stearsa!");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email, autor);
            form.Show();
            this.Hide();
        }

        private void Lectii_postate2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Lectii_postate2_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            string querry = @"SELECT * FROM Lectii WHERE Email = '"+email+"' ";
            con.Open();
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Titlul"].ToString());
            }
            con.Close();
            reader.Close();
            
        }

    }
}
