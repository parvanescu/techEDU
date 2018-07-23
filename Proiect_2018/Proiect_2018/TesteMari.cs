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
    public partial class TesteMari : Form
    {
        string email, autor;
        public TesteMari(string a,string b)
        {
            email = a;
            autor = b;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email, autor);
            form.Show();
            this.Hide();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Show();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry = @"Select * FROM ViewTest WHERE Titlu = '"+comboBox1.SelectedItem.ToString()+"' ";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                richTextBox2.Text = reader["Info"].ToString();
            }
            con.Close();
            reader.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Testare form = new Testare(email,autor,comboBox1.SelectedItem.ToString());
            form.Show();
            this.Hide();
        }

        private void TesteMari_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TesteMari_Load(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry = @"Select * From ViewTest";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Titlu"].ToString());
            }
        }
    }
}
