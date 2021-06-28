using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Collections.Specialized;
using System.Diagnostics.Contracts;

namespace KPL2
{
    public partial class ViewHomepage : Form
    {
        MySqlConnection Con = new MySqlConnection();
        MySqlCommand Cmd = new MySqlCommand();
        MySqlDataReader Rd;
        String Query;
        DataSet Ds = new DataSet();
        String Server = ConfigurationManager.AppSettings.Get("Key3");
        String Username = ConfigurationManager.AppSettings.Get("Key4");
        String Password = ConfigurationManager.AppSettings.Get("Key5");
        String Database = ConfigurationManager.AppSettings.Get("Key6");
        public ViewHomepage() //Metode apabila file berjalan
        {
          
            InitializeComponent();
            if (Server == null)
            {
                throw new ArgumentNullException(nameof(Server));
            }
            Contract.EndContractBlock();
        }

        public void Fill_Listbox() //Metode untuk mengisi listbox 
        {
            string Constring = ConfigurationManager.AppSettings.Get("Key0");
            string Query = ConfigurationManager.AppSettings.Get("Key1");
            MySqlConnection Con = new MySqlConnection(Constring);
            MySqlCommand Cmd = new MySqlCommand(Query, Con);
            MySqlDataReader Read;
            try
            {
                Con.Open();
                Read = Cmd.ExecuteReader();

                while (Read.Read())
                {
                    String Name = Read.GetString("nama");
                    listBox1.Items.Add(Name);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) //Metode ketika form terbuka
        {
           
            Fill_Listbox();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e) //Metode untuk tombol ubah
        {
            int Index = listBox1.SelectedIndex;
            Index++;
            Con.ConnectionString = "server=" + Server + ";" + "user id=" + Username
                                   + ";" + "password=" + Password + ";" + "database="
                                   + Database;
            Con.Open();
            try
            {

                Cmd.Connection = Con;

                Query = ConfigurationManager.AppSettings.Get("Key7") +
                    Index + ConfigurationManager.AppSettings.Get("Key8") + listBox1.GetItemText(listBox1.SelectedItem)
                    + "'";

                Cmd = new MySqlCommand(Query, Con);
                Rd = Cmd.ExecuteReader();
                Con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    

        static void Main() //Metode utama
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ViewHomepage());
            
        }

       

        private void button1_Click(object sender, EventArgs e) //Metode untuk tombol tambah
        {
            
            Con.ConnectionString = "server=" + Server + ";" + "user id=" + Username
                                    + ";" + "password=" + Password + ";" + "database="
                                    + Database;

            try
            {
                Con.Open();
                Query = ConfigurationManager.AppSettings.Get("Key9")
                        + "values('" + textBox1.Text + "', '" + textBox2.Text + "', '"
                        + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')";
                Cmd = new MySqlCommand(Query, Con);
                Rd = Cmd.ExecuteReader();
                Con.Close();
                listBox1.Items.Add(textBox2.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
            
        }
       
        private void button2_Click(object sender, EventArgs e) //Metode untuk tombol index
        {
            Con.ConnectionString = "server=" + Server + ";" + "user id=" + Username
                                    + ";" + "password=" + Password + ";" + "database="
                                    + Database;
            Con.Open();
            try
            {
                
                Cmd.Connection = Con;

                Query = ConfigurationManager.AppSettings.Get("Key7") +
                    textBox1.Text + "',nama='" + textBox2.Text +
                    "',harga='" + textBox3.Text + "',jumlah='" + textBox4.Text +
                    "',jenis='" + textBox5.Text + ConfigurationManager.AppSettings.Get("Key10") +
                    textBox1.Text + "'";

                Cmd = new MySqlCommand(Query, Con);
                Rd = Cmd.ExecuteReader();
                Con.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) //Metode ketika listbox ditekan
        {
            int Index = listBox1.SelectedIndex;
            Index++;
            string Constring = ConfigurationManager.AppSettings.Get("Key0");
            string Query = ConfigurationManager.AppSettings.Get("Key11")
                                + Index + "' ;";
            
            MySqlConnection Con = new MySqlConnection(Constring);
            MySqlCommand Cmd = new MySqlCommand(Query, Con);
            MySqlDataReader Read;

            try
            {
                Con.Open();
                Read = Cmd.ExecuteReader();

                while (Read.Read())
                {
                    string Kode2 = Read.GetString("kode");
                    string Nama2 = Read.GetString("nama");
                    string Harga2 = Read.GetInt32("harga").ToString();
                    string Jumlah2 = Read.GetInt32("jumlah").ToString();
                    string Jenis = Read.GetString("jenis");

                    textBox1.Text = Kode2;
                    textBox2.Text = Nama2;
                    textBox3.Text = Harga2;
                    textBox4.Text = Jumlah2;
                    textBox5.Text = Jenis;
                } 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                }

        private void button3_Click(object sender, EventArgs e) //Metode untuk tombol hapus
        {
            Con.ConnectionString = "server=" + Server + ";" + "user id=" + Username
                                    + ";" + "password=" + Password + ";" + "database="
                                    + Database;
            Con.Open();
            try
            {

                Cmd.Connection = Con;

                Query = ConfigurationManager.AppSettings.Get("Key12") +
                    textBox1.Text + "'";

                Cmd = new MySqlCommand(Query, Con);
                Rd = Cmd.ExecuteReader();
                Con.Close();
                listBox1.Items.Remove(textBox2.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e) //Metode untuk tombol profile
        {
            ViewProfile Fm2 = new ViewProfile();
            Fm2.Show();
            this.Hide();
        }
    }
    
}
