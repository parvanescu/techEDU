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
    public partial class TestePostate : Form
    {
        string email, autor;
        public TestePostate(string a,string b)
        {
            email = a;
            autor = b;
            InitializeComponent();
        }
        DataTable table2 = new DataTable();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            table2.Clear();
            dataGridView1.Show();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry = @"SELECT * FROM Teste WHERE TitluTest = '" + comboBox1.SelectedItem.ToString() + "' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);
            sda.Fill(table2);
            
            dataGridView1.DataSource = table2;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
                dataGridView1.Columns[i].ReadOnly = true;
            dataGridView1.Columns["IdIntrebare"].Visible = false;
            
            
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
                MessageBox.Show("Selectati textul pe care doriti sa il stergeti");
            else
            {
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                con.Open();
                string querry = @"Delete From Teste Where TitluTest = '" + comboBox1.SelectedItem.ToString() + "' ";
                string querry2 = @"Delete From ViewTest where Titlu = '" + comboBox1.SelectedItem.ToString() + "' ";
                SqlCommand com = new SqlCommand(querry, con);
                SqlCommand com2 = new SqlCommand(querry2, con);
                com2.ExecuteNonQuery();
                com.ExecuteNonQuery();
                comboBox1.Items.RemoveAt(comboBox1.SelectedIndex);
               
               
                dataGridView1.Hide();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email,autor);
            form.Show();
            this.Hide();
            comboBox1.Items.Clear();
            
            dataGridView1.Columns.Clear();

        }

        private void TestePostate_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void TestePostate_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry = @"SELECT * FROM ViewTest WHERE Email = '" + email + " ' ";
            SqlCommand com = new SqlCommand(querry, con);
            SqlDataReader reader = com.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Titlu"].ToString());
            }
            dataGridView1.Hide();
            con.Close();
           
            
        }
    }
}
