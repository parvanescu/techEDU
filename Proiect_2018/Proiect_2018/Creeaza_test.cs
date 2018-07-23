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
    public partial class Creeaza_test : Form
    {
        int c;
        string email, autor,intrebare;
        public Creeaza_test(string a,string b)
        {
            email = a;
            autor = b;
            InitializeComponent();
        }
       
        int tip;
        string  raspuns1, raspuns2, raspuns3, raspuns4,raspunscorect;
        DataTable table = new DataTable();
        //Creeare test
        private void button2_Click(object sender, EventArgs e)
        {

            
            tip = 0;
            //Grila
            int variabila;
            if (radioButton1.Checked==true)
            {
                if (Int32.TryParse(textBox5.Text, out variabila) == false)
                    MessageBox.Show("Introduceti un numar intre 1 si 4");
                else
                    if(variabila<1 || variabila>4)
                    MessageBox.Show("Rezultatul introdus nu e corect introduceti un numar intre 1 si 4 cu referinta la numarul rezultatului corect");
                else
                {
                        tip = 1;
                        raspuns1 = textBox1.Text;
                        raspuns2 = textBox2.Text;
                        raspuns3 = textBox3.Text;
                        raspuns4 = textBox4.Text;
                        raspunscorect = textBox5.Text;
                    }
                }
                
               
               //Raspuns text
                if (radioButton2.Checked == true)
            { 
                tip = 2;
                raspunscorect = textBox6.Text;

            }
               else
               //Adevarat fals
                if (radioButton3.Checked == true)
            {
                tip = 3;
                if (radioButton4.Checked == true)
                    raspunscorect = "1";
                else
                    if (radioButton5.Checked == true)
                    raspunscorect = "0";
            }

            //Adaugarea in tabel
            if (richTextBox1.Text.Trim() == "")
                MessageBox.Show("Introduce intrebarea");
            else
                if (tip == 0 || raspunscorect == "")
                MessageBox.Show("Termina de completat intrebarea");
            else
            {

                intrebare = richTextBox2.Text;
                DataRow row = table.NewRow();
                row[0] = tip;
                row[1] = intrebare;
                row[2] = raspuns1;
                row[3] = raspuns2;
                row[4] = raspuns3;
                row[5] = raspuns4;
                row[6] = raspunscorect;
                table.Rows.InsertAt(row, c);
                

                //pregatire pt urmatoarea intrebare
                richTextBox2.Clear();
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                c++;
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Hide();
            }
            if(c==10)
            {
                radioButton2.Hide();
                radioButton1.Hide();
                radioButton3.Hide();
                button2.Hide();
                label3.Hide();
                label9.Show();
                textBox7.Show();
                button2.Hide();
                button3.Show();
                button4.Show();
                label2.Text="Descriere Test";
                
            }
            if (c == 9)
            {
                button2.Text = "Finalizare test";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {  
            dataGridView1.DataSource = table;
            if (textBox7.Text == "")
                MessageBox.Show("Completati titlul lectiei");
            if (textBox7.Text.Length > 49)
                MessageBox.Show("Titlul este prea lung");
            else
            {
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                string querry = @"SELECT * FROM Teste WHERE TitluTest = '" + textBox7.Text + "' ";
                con.Open();
                SqlCommand com = new SqlCommand(querry, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows == true)
                    MessageBox.Show("Titlul exista deja,schimbati-l");
                else
                {
                    reader.Close();
                    for (int k = 0; k < c; k++)
                    {
                        string querry2 = @"INSERT INTO Teste VALUES ( " + dataGridView1[0, k].Value + " , '" + dataGridView1[1, k].Value + "' , '" + dataGridView1[2, k].Value + "' , '" + dataGridView1[3, k].Value + "' , '" + dataGridView1[4, k].Value + "' , '" + dataGridView1[5, k].Value + "' , '" + dataGridView1[6, k].Value + "' , '" + textBox7.Text + "' ) ";
                        SqlCommand com2 = new SqlCommand(querry2, con);
                        com2.ExecuteNonQuery();
                        
                    }
                    string querry3 = @"INSERT INTO ViewTest VALUES ( '" + textBox7.Text + "' , '" + email + "' , '"+richTextBox2.Text+"' )";
                    SqlCommand com3 = new SqlCommand(querry3, con);
                    com3.ExecuteNonQuery();
                    MessageBox.Show("Test creeat cu succes");
                    Cont form = new Cont(email, autor);
                    form.Show();
                    this.Hide();
                    con.Close();
                    button2.Text = "Urmatoarea intrebare";

                }


            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = table;
            comboBox1.Show();
            button7.Show();
            richTextBox3.Show();
            label10.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Cont form = new Cont(email, autor);
            form.Show();
            this.Hide();
        }

        private void Creeaza_test_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox3.Text = table.Rows[comboBox1.SelectedIndex]["Intrebare"].ToString();
            int a = Int32.Parse(table.Rows[comboBox1.SelectedIndex]["TipIntrebare"].ToString());
            if (a == 1) 
            {
                groupBox2.Hide();
                groupBox3.Hide();
                groupBox1.Show();
                
                textBox1.Text = table.Rows[comboBox1.SelectedIndex]["Raspuns1"].ToString();
                textBox2.Text = table.Rows[comboBox1.SelectedIndex]["Raspuns2"].ToString();
                textBox3.Text = table.Rows[comboBox1.SelectedIndex]["Raspuns3"].ToString();
                textBox4.Text = table.Rows[comboBox1.SelectedIndex]["Raspuns4"].ToString();
                textBox5.Text = table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"].ToString();

            }
            if (a == 2)
            {
               
                textBox6.Text = table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"].ToString();
                groupBox3.Hide();
                groupBox1.Hide();
                groupBox2.Show();

            }
            if (a == 3)
            {
                groupBox1.Hide();
                groupBox2.Hide();
                groupBox3.Show();
                if (Int32.Parse(table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"].ToString()) == 1)
                    radioButton4.Checked = true;
                else
                    radioButton5.Checked = true;
                groupBox3.Show();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 1)
            {
                MessageBox.Show("Raspunsul poate fii de maximum o cifra");
                textBox5.Text = textBox5.Text.Substring(0,1);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(table.Rows[comboBox1.SelectedIndex]["TipIntrebare"].ToString()) == 1)
            {
                int variabila;
                tip = 0;
                //Grila

                if (Int32.TryParse(textBox5.Text, out variabila) == false)
                    MessageBox.Show("Introduceti un numar intre 1 si 4");
                else
                {
                    if (variabila < 1 || variabila > 4)
                        MessageBox.Show("Rezultatul introdus nu e corect introduceti un numar intre 1 si 4 cu referinta la numarul rezultatului corect");
                    else
                    {

                        if (richTextBox3.Text == "" || richTextBox3.Text.Trim() == "")
                            MessageBox.Show("Completati intrebarea");
                        else
                        {
                            table.Rows[comboBox1.SelectedIndex]["Intrebare"] = richTextBox3.Text;
                            table.Rows[comboBox1.SelectedIndex]["Raspuns1"] = textBox1.Text;
                            table.Rows[comboBox1.SelectedIndex]["Raspuns2"] = textBox2.Text;
                            table.Rows[comboBox1.SelectedIndex]["Raspuns3"] = textBox3.Text;
                            table.Rows[comboBox1.SelectedIndex]["Raspuns4"] = textBox4.Text;
                            table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"] = textBox5.Text;
                            dataGridView1.DataSource = table;
                        }
                    }
                }
                }
            


                    if (Int32.Parse(table.Rows[comboBox1.SelectedIndex]["TipIntrebare"].ToString()) == 2)
                {
                    if (richTextBox3.Text == "" || richTextBox3.Text.Trim() == "")
                        MessageBox.Show("Completati intrebarea");
                    else
                    if (textBox6.Text == "" || textBox6.Text.Trim() == "")
                        MessageBox.Show("Completati raspunsul");
                    else
                    {
                        table.Rows[comboBox1.SelectedIndex]["Intrebare"] = richTextBox3.Text;
                        table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"] = textBox6.Text;
                        dataGridView1.DataSource = table;
                    }
                }


                    if (Int32.Parse(table.Rows[comboBox1.SelectedIndex]["TipIntrebare"].ToString()) == 3)
                    if (richTextBox3.Text == "" || richTextBox3.Text.Trim() == "")
                        MessageBox.Show("Completati intrebarea");
                    else
                    {
                        table.Rows[comboBox1.SelectedIndex]["Intrebare"] = richTextBox3.Text;
                        if (radioButton4.Checked == true)
                            table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"] = 1;
                        else
                            table.Rows[comboBox1.SelectedIndex]["RaspunsCorect"] = 0;
                        dataGridView1.DataSource = table;


                    }

            
            }

        private void Creeaza_test_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            c = 0;
            label2.Hide();
            richTextBox2.Hide();
            button1.Text = "Incepe creearea";
            button2.Hide();
            label3.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            button3.Hide();
            button4.Hide();
            textBox7.Hide();
            label9.Hide();
            label2.Text = "Scrie intrebarea";
            comboBox1.Hide();
            button7.Hide();
            richTextBox3.Hide();
            label10.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox1.Show();
                groupBox2.Hide();
                groupBox3.Hide();
            }
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip(); 
            tip.SetToolTip(textBox5, "Scrie numarul intrebarii corecte ex.3 (pentru care a 3-a intrebare este corecta)");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox2.Show();
                groupBox1.Hide();
                groupBox3.Hide();
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                groupBox3.Show();
                groupBox1.Hide();
                groupBox2.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                richTextBox1.Hide();
                label1.Hide();
                label2.Show();
                richTextBox2.Show();
                button1.Hide();
                button2.Show();
                label3.Show();
                radioButton1.Show();
                radioButton2.Show();
                radioButton3.Show();
               
                table.Columns.Add("TipIntrebare", typeof(int));
                table.Columns.Add("Intrebare", typeof(string));
                table.Columns.Add("Raspuns1", typeof(string));
                table.Columns.Add("Raspuns2", typeof(string));
                table.Columns.Add("Raspuns3", typeof(string));
                table.Columns.Add("Raspuns4", typeof(string));
                table.Columns.Add("RaspunsCorect", typeof(string));

            
        }
    }
}
