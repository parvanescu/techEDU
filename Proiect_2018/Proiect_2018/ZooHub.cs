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
    public partial class ZooHub : Form
    {
        string email, autor;
        bool logged;
        public ZooHub(string a,string b,bool loged)
        {
            autor = b;email = a;
            logged = loged;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button2.Show();
            button5.Show();
            button6.Show();
            button4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AnimaleRomania form = new AnimaleRomania();
            form.Show();
        }

        private void ZooHub_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Cont form1 = new Cont(email, autor);
            if (logged == false)
            {
                form.Show();
                this.Hide();
            }
            if (logged == true)
            {
                form1.Show();
                this.Hide();
                
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Polar form = new Polar(email,autor,logged);
            form.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Ferma form = new Ferma(email, autor, logged);
            form.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Jungla form = new Jungla(email, autor, logged);
            form.Show();
            this.Hide();
        }

       
        

        private void ZooHub_Load(object sender, EventArgs e)
        {
            button2.Hide();
            button5.Hide();
            button6.Hide();
            button4.Hide();
        }
    }
}
