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
    public partial class Testare : Form
    {
        string email,autor,numetest="";
        int c = 0, nota = 0;
        DataTable table = new DataTable();
        int[] intrebari = new int[10];
        string[] raspuns= new string[20];
        
        private void button1_Click(object sender, EventArgs e)
        {
            button3.Hide();
            timer1.Start();
            button1.Hide();
            button2.Show();
            richTextBox1.Show();
            SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
            con.Open();
            string querry=@"SELECT * From Teste WHERE TitluTest = '"+numetest+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(querry, con);
            sda.Fill(table);
            dataGridView1.DataSource = table;
            richTextBox1.Text = dataGridView1["Intrebare", 0].Value.ToString();
            
            if(Int32.Parse(dataGridView1["TipIntrebare",0].Value.ToString()) == 1)
            {
                groupBox1.Show();
                radioButton1.Text = dataGridView1["Raspuns1", 0].Value.ToString();
                radioButton2.Text = dataGridView1["Raspuns2", 0].Value.ToString();
                radioButton3.Text = dataGridView1["Raspuns3", 0].Value.ToString();
                radioButton4.Text = dataGridView1["Raspuns4", 0].Value.ToString();
            }else
                if(Int32.Parse(dataGridView1["TipIntrebare", 0].Value.ToString()) == 2)
            {
                groupBox2.Show();
            }
            else
                if(Int32.Parse(dataGridView1["TipIntrebare", 0].Value.ToString()) == 3)
            {
                groupBox3.Show();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int min = Int32.Parse(label1.Text);
            int sec = Int32.Parse(label3.Text);
            if (sec == 0)
            {
                min--;
                sec = 60;
            }
            else
                sec--;
            if (min == 0)
            {
                timer1.Stop();
                button2.Hide();
                button3.Show();
                button2.Text = "Urmatoarea intrebare";
                richTextBox1.Hide();
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                con.Open();
                string querry=@"INSERT INTO Note VALUES ( '"+email+"' , '"+nota+"' )";
                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            label1.Text = min.ToString();
            label3.Text = sec.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email, autor);
            form.Show();
            this.Hide();
        }

        private void Testare_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        { //Verfiicare raspunsuri
            
            if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 1)
            { if (radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked==false && radioButton4.Checked==false)
                    MessageBox.Show("Raspunde la intrebare inainte sa treci la urmatoarea");
                else
                {
                    bool ok1 = false, ok2 = false, ok3 = false, ok4 = false, ok = true;
                    int aux = Int32.Parse(dataGridView1["RaspunsCorect", c].Value.ToString());
                    int i = 0;


                    //Raspunsuri corecte

                    if (aux == 1)
                        ok1 = true;
                    if (aux == 2)
                        ok2 = true;
                    if (aux == 3)
                        ok3 = true;
                    if (aux == 4)
                        ok4 = true;


                    //Vf raspuns
                    if (ok1 == true && radioButton1.Checked == false)
                        ok = false;
                    if (ok1 == false && radioButton1.Checked == true)
                        ok = false;
                    if (ok2 == true && radioButton2.Checked == false)
                        ok = false;
                    if (ok2 == false && radioButton2.Checked == true)
                        ok = false;
                    if (ok3 == true && radioButton3.Checked == false)
                        ok = false;
                    if (ok3 == false && radioButton3.Checked == true)
                        ok = false;
                    if (ok4 == true && radioButton4.Checked == false)
                        ok = false;
                    if (ok4 == false && radioButton4.Checked == true)
                        ok = false;

                    if (ok == true)
                    {
                        nota++;
                        intrebari[c] = 1;
                    }
                    else
                    {
                        intrebari[c] = 0;
                        if (radioButton1.Checked == true)
                            raspuns[c] = "1";
                        if (radioButton2.Checked == true)
                            raspuns[c] = "2";
                        if (radioButton3.Checked == true)
                            raspuns[c] = "3";
                        if (radioButton4.Checked == true)
                            raspuns[c] = "4";
                    }
                }
            }
            else
                if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 2)
            {if (textBox1.Text.Trim() == "")
                    MessageBox.Show("Completeaza raspunsul");
                else
                {
                    if (textBox1.Text == dataGridView1["RaspunsCorect", c].Value.ToString())
                    {
                        nota++;
                        intrebari[c] = 1;
                    }
                    else
                    {
                        intrebari[c] = 0;
                        raspuns[c] = textBox1.Text;
                    }
                }
            }
            else
                if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 3)
            {  if (radioButton5.Checked == false && radioButton6.Checked == false)
                    MessageBox.Show("Completeaza raspunsul");
                else
                {
                    bool ok = true;
                    if (radioButton5.Checked == true && Int32.Parse(dataGridView1["RaspunsCorect", c].Value.ToString()) == 0)
                        ok = false;
                    if (radioButton6.Checked == true && Int32.Parse(dataGridView1["RaspunsCorect", c].Value.ToString()) == 1)
                        ok = false;

                    if (ok == true)
                    {
                        nota++;
                        intrebari[c] = 1;
                    }
                    else
                    {
                        intrebari[c] = 0;
                        if (radioButton5.Checked == true)
                            raspuns[c] = "1";
                        if (radioButton6.Checked == true)
                            raspuns[c] = "0";
                    }
                }
            }
            //Terminare test
            if (c == 8)
            {
                button2.Text = "Finalizare test";
            }

            if (c == 9)
            { button2.Hide();
                button2.Text = "Urmatoarea intrebare";
                richTextBox1.Hide();
                timer1.Stop();
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                con.Open();
                string querry = @"INSERT INTO Note VALUES ( '" + email + "' , " + nota + " , '"+numetest+"' )";
                SqlCommand com = new SqlCommand(querry, con);
                com.ExecuteNonQuery();
                con.Close();
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
                button3.Show();
                Raspunsuri form = new Raspunsuri(email, autor,intrebari,nota,numetest,raspuns);
                form.Show();
                this.Hide();
                MessageBox.Show("Test terminat");

            }
            else
            {
                //Pregatire urmatoarea intrebare
                c++;
                richTextBox1.Text = dataGridView1["Intrebare", c].Value.ToString();
                if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 1)
                {
                    groupBox2.Hide();
                    groupBox3.Hide();
                    groupBox1.Show();
                    radioButton1.Text = dataGridView1["Raspuns1", c].Value.ToString();
                    radioButton2.Text = dataGridView1["Raspuns2", c].Value.ToString();
                    radioButton3.Text = dataGridView1["Raspuns3", c].Value.ToString();
                    radioButton4.Text = dataGridView1["Raspuns4", c].Value.ToString();
                }
                if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 2)
                { groupBox2.Show();
                    groupBox1.Hide();
                    groupBox3.Hide();

                }

                if (Int32.Parse(dataGridView1["TipIntrebare", c].Value.ToString()) == 3)
                {
                    groupBox3.Show();
                    groupBox1.Hide();
                    groupBox2.Hide();
                }
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
               

                
            }
        }

        public Testare(string a,string b,string c)
        {
            email = a;autor = b;
            numetest = c;
            InitializeComponent();
        }

        private void Testare_Load(object sender, EventArgs e)
        {
            richTextBox1.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            label1.Text = "10";
            label3.Text = "0";
            c = 0;
            button2.Hide();
            for (int i = 0; i < raspuns.Length; i++)
                raspuns[i] = "";
        }
    }
}
