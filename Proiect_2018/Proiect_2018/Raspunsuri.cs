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
    public partial class Raspunsuri : Form
    {
        string autor, email,numetest;
        int[] intrebari = new int[11];
        int nota;
        string[] raspuns=new string[20];
        DataTable table = new DataTable();
        public Raspunsuri(string a,string b,int[] v,int c,string d,string[] e)
        {
            autor = a;
            email = b;
            intrebari = v;
            nota = c;
            numetest = d;
            raspuns = e;
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { 
                int a =Int32.Parse( comboBox1.SelectedItem.ToString());
            if (Int32.Parse(raspuns[a]) == 1)
                label8.Text = table.Rows[a]["Raspuns1"].ToString();
            if (Int32.Parse(raspuns[a]) == 2)
                label8.Text = table.Rows[a]["Raspuns2"].ToString();
            if (Int32.Parse(raspuns[a]) == 3)
                label8.Text = table.Rows[a]["Raspuns3"].ToString();
            if (Int32.Parse(raspuns[a]) == 4)
                label8.Text = table.Rows[a]["Raspuns4"].ToString();
            label7.Show();
            label8.Show();
            label10.Show();
            label11.Show();
            label12.Show();
            label6.Show();
            if (Int32.Parse(table.Rows[a]["RaspunsCorect"].ToString()) == 1)
                label10.Text = table.Rows[a]["Raspuns1"].ToString();
            if (Int32.Parse(table.Rows[a]["RaspunsCorect"].ToString()) == 2)
                label10.Text = table.Rows[a]["Raspuns2"].ToString();
            if (Int32.Parse(table.Rows[a]["RaspunsCorect"].ToString()) == 3)
                label10.Text = table.Rows[a]["Raspuns3"].ToString();
            if (Int32.Parse(table.Rows[a]["RaspunsCorect"].ToString()) == 4)
                label10.Text = table.Rows[a]["Raspuns4"].ToString();
            label12.Text = table.Rows[a]["Intrebare"].ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(autor, email);
            form.Show();
            this.Hide();
        }

        private void Raspunsuri_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Raspunsuri_Load(object sender, EventArgs e)
        {
            label11.Hide();
            label12.Hide();
            label7.Hide();
            label8.Hide();
            label10.Hide();
            label6.Hide();
            
            if (nota >= 5)
            {
                label3.Hide();
                label4.Hide();
                label5.Hide();
                label1.Show();
                label2.Show();
                label2.Text = nota.ToString();
            }
            else
            {
                label1.Hide();
                label2.Hide();
                label3.Show();
                label4.Show();
                label5.Show();
                label5.Text = nota.ToString();
            }
            for(int i = 0; i < intrebari.Length; i++)
            {
                if (intrebari[i] == 0)
                    comboBox1.Items.Add(i);
            }

            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry=@"Select * From Teste Where TitluTest = '"+numetest+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);
            sda.Fill(table);

        }
    }
}
