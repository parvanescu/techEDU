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
    public partial class Creeare_lectie : Form
    {
        string email,autor;
        int c=0;
        public Creeare_lectie(string a,string b)
        {
            autor = b;
            email = a;
            InitializeComponent();
        }
        int x, y ;
        
        //aduaga coloana
        private void Column_add_Click(object sender, EventArgs e)
        { 
            tableLayoutPanel1.ColumnCount++;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,50F));
            if (tableLayoutPanel1.ColumnCount == 2)
                Column_delete.Enabled = true;
        }
        //sterge rand
        private void Row_delete_Click(object sender, EventArgs e)
        {  if (tableLayoutPanel1.RowCount == 2)
                Row_delete.Enabled = false;

            tableLayoutPanel1.RowCount--;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
        }
        //sterge coloana
        private void Column_delete_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.ColumnCount == 2)
                Column_delete.Enabled = false;
           
                tableLayoutPanel1.ColumnCount--;
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            
        }
        //tolltip
        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.textBox1, "Scrie numărul coloanei unde vrei să faci modificarea");
        }
        //tooltip
        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            ToolTip tip = new ToolTip();
            tip.SetToolTip(this.textBox2, "Scrie numărul liniei unde vrei să faci modificarea");
        }

        
        //Adaugare text in celula
        private void button6_Click(object sender, EventArgs e)
        {
            c++;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Introduceti coordonatele celulei!!");
            else
            {   
                x = Int32.Parse(textBox1.Text); y = Int32.Parse(textBox2.Text);
                tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(x-1, y-1));
                RichTextBox tb = new RichTextBox();
                tb.Dock = DockStyle.Fill;
                tb.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                tableLayoutPanel1.Controls.Add(tb, x-1, y-1);
                
            }
          
        }
        //Adaugare imagine in celula
        private void button7_Click(object sender, EventArgs e)
        {
            c++;
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Introduceti coordonatele celulei!!");
            else
            {
                x = Int32.Parse(textBox1.Text); y = Int32.Parse(textBox2.Text);
                

                PictureBox pB = new PictureBox();
               
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    
                    tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(x - 1, y - 1));
                    tableLayoutPanel1.Controls.Add(pB, x - 1, y - 1);
                    tableLayoutPanel1.GetControlFromPosition(x - 1, y - 1).Dock = DockStyle.Fill;
                    tableLayoutPanel1.GetControlFromPosition(x - 1, y - 1).BackgroundImageLayout = ImageLayout.Stretch;
                    string path = ofd.FileName;
                    tableLayoutPanel1.GetControlFromPosition(x - 1, y - 1).BackgroundImage =new Bitmap(path);
                }
                

            }

        }
        //Stergerea unui control dintr-o celula
        private void button1_Click_1(object sender, EventArgs e)
        {
            x = Int32.Parse(textBox1.Text);
            y = Int32.Parse(textBox2.Text);
            tableLayoutPanel1.Controls.Remove(tableLayoutPanel1.GetControlFromPosition(x-1, y-1));
        }
        //Adaugarea unui rand
        private void Row_add_Click(object sender, EventArgs e)
        {
            if (tableLayoutPanel1.RowCount == 2)
                Row_delete.Enabled = true;
            tableLayoutPanel1.RowCount++;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent,50F));
            
        }
        //Iesire in meniu
        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            Cont form = new Cont(email, autor);
            this.Hide();
            form.Show();
        }

        private void Creeare_lectie_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //Salvare lectie
        private void button8_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath;

           
           
            if (textBox3.Text == "" || textBox4.Text == "")
                MessageBox.Show("Completati numele sau regiunea proiectului");
            if (textBox4.Text.IndexOf(',') != -1)
                MessageBox.Show("Nu puteti folosii virgula pentru a scrie subiectul lectiei");
            if (c == 0)
                MessageBox.Show("Nu puteti face o lectie goala");
            else
            {
                SqlConnection con = new SqlConnection(VariabilaGlobala.constring);
                con.Open();
                string querry = @"SELECT * FROM Lectii WHERE Titlul= '" + textBox3.Text + "' ";
                SqlCommand com = new SqlCommand(querry, con);
                SqlDataReader reader = com.ExecuteReader();
                if (reader.HasRows == true)
                    MessageBox.Show("Titlul lectiei exista,schimbati-l");
                else
                {
                    path = path.Substring(0, path.Length - 10) + @"\Lectii\" + textBox3.Text + ".bmp";


                    //Ss la imagine
                    Control ctrl = tableLayoutPanel1;

                    Rectangle rect = new Rectangle(tableLayoutPanel1.Location.X, tableLayoutPanel1.Location.Y, tableLayoutPanel1.Width, tableLayoutPanel1.Height);
                    Rectangle rectangle = ctrl.RectangleToScreen(rect);
                    Point point = PointToScreen(ctrl.Location);
                    Point point2 = new Point(0, 0);

                    Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);
                    Graphics g = Graphics.FromImage(bmp);
                    g.CopyFromScreen(point, point2, bmp.Size);
                    bmp.Save(path);

                    //Introducere in baza de date
                    MessageBox.Show("Lectie creeata cu succes");
                    reader.Close();
                    string querry2 = @"INSERT INTO Lectii VALUES ( '" + autor + "' , '" + email + "' , '" + DateTime.Now + "' , '" + textBox3.Text + "' , '" + textBox4.Text + "' ) ";
                    SqlCommand com2 = new SqlCommand(querry2, con);
                    com2.ExecuteNonQuery();
                    con.Close();
                    Cont form = new Cont(email, autor);
                    this.Hide();
                    form.Show();
                }


            }

        }

        private void Creeare_lectie_Load(object sender, EventArgs e)
        {
          

        }
    }
}
