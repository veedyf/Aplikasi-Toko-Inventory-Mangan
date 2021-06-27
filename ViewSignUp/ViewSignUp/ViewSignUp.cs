using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ViewSignUp
{
    public partial class ViewSignUp : Form
    {
        Connection con = new Connection();
        string id, username, password;

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "" && txtPassword.Text != "" && txtConfirmPass.Text == txtPassword.Text)
                {
                    con.Open();
                    string query = "INSERT INTO akun (id,username,password) VALUES (NULL,'"+txtUsername.Text+"', '"+txtPassword.Text+"');";
                    DataSet insertData;
                    insertData = con.ExecuteDataSet(query);
                    MessageBox.Show("Sign Up Successful", "Information");
                }
                else if (txtConfirmPass.Text != txtPassword.Text)
                {
                    MessageBox.Show("Confirm password doesn't match", "Information");
                }
                else
                {
                    MessageBox.Show("Username or Password is empty", "Information");
                }
            }
            catch
            {
                MessageBox.Show("Insert Failed", "Information");
            }
        }

        public ViewSignUp()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
            txtConfirmPass.PasswordChar = '*';
        }



    }
}
