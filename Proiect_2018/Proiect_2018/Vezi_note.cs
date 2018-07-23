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
    public partial class Vezi_note : Form
    {
        string email, autor;
        public Vezi_note(string a,string b)
        {
            email = a;
            autor = b;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email,autor);
            form.Show();
            this.Hide();

        }

        private void Vezi_note_Load(object sender, EventArgs e)
        { int c = 0;
            dataGridView1.Hide();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry=@"Select * From Note WHERE Email = '"+email+"' ";
            DataTable table = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);
            sda.Fill(table);
            dataGridView1.DataSource = table;
            for(int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                chart1.Series["Note"].Points.AddXY(dataGridView1[3, i].Value.ToString(), dataGridView1[2, i].Value.ToString());
            }
        }
    }
}
