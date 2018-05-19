using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace SocialNetwork
{
    public partial class FormRegistration : Form
    {
        private string confirmString;
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = \\Mac\Home\Documents\Visual Studio 2015\Projects\SocialNetwork\SocialNetwork\UsersInfo.mdf; Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;



        public FormRegistration()
        {
            InitializeComponent();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool fieldsFilled()
        {
            bool filled = true;
            if (textName.Text.Length == 0)
                filled = false;
            if (textSurname.Text.Length == 0)
                filled = false;
            if (textMail.Text.Length == 0)
                filled = false;
            if (textPassword.Text.Length == 0)
                filled = false;
            if (textPassword2.Text.Length == 0)
                filled = false;
            if (!filled)
                MessageBox.Show("Fill all fields please!");
            return filled;
        }
        private bool fieldsValid()
        {
         
                bool valid = true;

            if (textName.Text.Length < 2 || textName.Text.Length > 30)
            {
                valid = false;
                MessageBox.Show("Invalid length of name. Fix and try again");
            }
            if (textSurname.Text.Length < 2 || textSurname.Text.Length > 30)
            {
                valid = false;
                MessageBox.Show("Invalid length of surname. Fix and try again");
            }

            if (!IsValidEmail(textMail.Text))
            {
                valid = false;
                MessageBox.Show("Invalid format of e-mail.  Fix and try again");
            }

            if (textPassword.Text.Length < 7 || textPassword.Text.Length > 30)
            {
                valid = false;
                MessageBox.Show("Invalid length of password. Fix and try again");
            }
   
            if (textPassword2.Text != textPassword.Text)
            {
                valid = false;
                MessageBox.Show("Passwords are not equal");
            }
            return valid;
        }

        private  string generateRandomString()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void confirmMail(string mailGetter)
        {
           

            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("semenenya.vitaliy@gmail.com");
                message.To.Add(new MailAddress(mailGetter));
                message.Subject = "CONFIRMATION";
                confirmString = generateRandomString();
                message.Body = "ATTENTION. DONT SHOW IT ANYBODY! WRITE IT IN CORRESPONDING FIELD "+confirmString;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("semenenya.vitaliy@gmail.com", "Semenenyasemenenya1");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                MessageBox.Show("Check you e-mail. We send comfirm code");
            }
            catch (Exception ex)
            {
                MessageBox.Show("err: " + ex.Message);
            }
        }

        private void textName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);//not allow numbers
        }

        private void textSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = char.IsDigit(e.KeyChar);//not allow numbers
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (fieldsFilled())
                if (fieldsValid())
                {
                    confirmMail(textMail.Text);
                    buttonRegister.Enabled = false;
                    textConfirmMail.Visible = true;
                    buttonSignUp.Visible = true;
                    buttonSignUp.Enabled = true;
                }
        }
        private void databaseRegister()
        {
            string name = textName.Text;
            string surname = textSurname.Text;
            string mail = textMail.Text;
            string password = textPassword.Text;
            DateTime dateBirth = dateTimeBirth.Value.Date;
            string sqlFormattedDate = dateBirth.ToString("yyyy-MM-dd");
            string aboutMe = "";
            //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            cn.Open();
            cmd.CommandText = "select * from RegistrationTable where Mail='"+mail+"'";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("This e-mail is already used");
                cn.Close();
            }
            else
            {
                cn.Close();
                cn.Open();
                cmd.CommandText = "insert into RegistrationTable (Mail,Password) values ('"+mail+"','"+password+"')";
                cmd.ExecuteNonQuery();
                cmd.Clone();

                cmd.CommandText = "insert into InfoTable (Name,Surname,Date,Photo,AboutMe) values ('" + name + "','" + surname + "','" + sqlFormattedDate + "','" + aboutMe + "','" + aboutMe+ "')";
                cmd.ExecuteNonQuery();
                cmd.Clone();
                MessageBox.Show("Registration complete");
                cn.Close();

            }

        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            if (confirmString==textConfirmMail.Text)
            {
                databaseRegister();

            }
            else
            {
                MessageBox.Show("Check your e-mail and try again!");
                buttonRegister.Enabled = true;

            }
        }

        private void FormRegistration_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormRegister formReg = new FormRegister();
            this.Hide();
            formReg.Show();
        }
    }
}
