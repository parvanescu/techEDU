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
    public partial class Cont : Form
    {
        string email,autor;
        public Cont(string a,string b)
        {
            email = a;
            autor = b;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vizualizare_lectii form = new Vizualizare_lectii(email,autor,true);
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Creeare_lectie form = new Creeare_lectie(email,autor);
                form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Lectii_postate2 form = new Lectii_postate2(email,autor);
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Creeaza_test form = new Creeaza_test(email, autor);
            form.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TestePostate form = new TestePostate(email, autor);
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TesteMari form = new TesteMari(email, autor);
            form.Show();
            this.Hide();
        }

        private void Cont_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Vezi_note form = new Vezi_note(email, autor);
            form.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ZooHub form = new ZooHub(email, autor, true);
            form.Show();
            this.Hide();
        }

        private void Cont_Load(object sender, EventArgs e)
        {

        }
    }
}
