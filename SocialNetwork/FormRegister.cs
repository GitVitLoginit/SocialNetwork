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

namespace SocialNetwork
{
    public partial class FormRegister : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = \\Mac\Home\Documents\Visual Studio 2015\Projects\SocialNetwork\SocialNetwork\UsersInfo.mdf; Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;

        public FormRegister()
        {
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            FormRegistration formReg = new FormRegistration();
            this.Hide();
            formReg.Show();
        }

        

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            string mail = textLogin.Text;
            string password = textPassword.Text;
            if (mail.Length != 0 && password.Length != 0)
            {
                cn.Open();
                cmd.CommandText = "select * from RegistrationTable where Mail='" + mail + "' and Password='" + password + "'";
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        MessageBox.Show("Login is succesfully completed!");
                        cn.Close();
                        Profile formReg = new Profile(mail,0);

                        this.Hide();
                        formReg.Show();
                    }

                }
                else
                {
                    MessageBox.Show("Check your e-mail/password please or log up!");
                    cn.Close();
                }
            }
            else
            {
                cn.Close();
                MessageBox.Show("Your e-mail/password is empty");
            }
        }

        private void FormRegister_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }
    }
}
