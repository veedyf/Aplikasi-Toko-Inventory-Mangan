using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KPL2
{
    public partial class ViewProfile : Form
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
        public ViewProfile() //Metode ketika aplikasi dijalankan
        {
            InitializeComponent();
            if (Server == null)
            {
                throw new ArgumentNullException(nameof(Server));
            }
            Contract.EndContractBlock();

            string Constring = ConfigurationManager.AppSettings.Get("Key0");
            string Pertama = "SELECT MAX(jumlah) from barang";
            MySqlConnection Con = new MySqlConnection(Constring);
            MySqlCommand Cmd = new MySqlCommand(Pertama, Con);
            MySqlDataReader Read;

            try
            {
                Con.Open();
                Read = Cmd.ExecuteReader();
                while (Read.Read())
                {
                    int maxId = Convert.ToInt32(Cmd.ExecuteScalar());
                    label5.Text = maxId.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            string Kedua = "SELECT MIN(jumlah) from barang";
            MySqlConnection Con2 = new MySqlConnection(Constring);
            MySqlCommand Cmd2 = new MySqlCommand(Kedua, Con2);
            MySqlDataReader Read2;

            try
            {
                Con.Open();
                Read2 = Cmd.ExecuteReader();
                while (Read2.Read())
                {
                    int maxId = Convert.ToInt32(Cmd.ExecuteScalar());
                    label6.Text = maxId.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            string Ketiga = "SELECT MAX(harga) from barang";
            MySqlConnection Con3 = new MySqlConnection(Constring);
            MySqlCommand Cmd3 = new MySqlCommand(Ketiga, Con3);
            MySqlDataReader Read3;

            try
            {
                Con3.Open();
                Read3 = Cmd3.ExecuteReader();
                while (Read3.Read())
                {
                    int maxId = Convert.ToInt32(Cmd.ExecuteScalar());
                    label7.Text = maxId.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            string Keempat = "SELECT MIN(harga) from barang";
            MySqlConnection Con4 = new MySqlConnection(Constring);
            MySqlCommand Cmd4 = new MySqlCommand(Keempat, Con4);
            MySqlDataReader Read4;

            try
            {
                Con4.Open();
                Read4 = Cmd4.ExecuteReader();
                while (Read4.Read())
                {
                    int maxId = Convert.ToInt32(Cmd.ExecuteScalar());
                    label8.Text = maxId.ToString();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            

            
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e) //Metode untuk tombol Homepage
        {
            ViewHomepage Fm1 = new ViewHomepage();
            Fm1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
