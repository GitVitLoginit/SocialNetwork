using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class Profile : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = \\Mac\Home\Documents\Visual Studio 2015\Projects\SocialNetwork\SocialNetwork\UsersInfo.mdf; Integrated Security = True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        profInfo myProfile = new profInfo();

        private class profInfo
        {
            public string name;
            public string surname;
            public string mail;
            public string password;
            public string aboutMe;
            public string photo;
            public int Id;
            public DateTime dateBirth;
            public List<int> friends = new List<int>();




        }

        public Profile(string _mail, int _id)
        {

            string mail = _mail;
            InitializeComponent();
            dataBaseInitialization(mail, _id);


        }

        private void dataBaseInitialization(string mail, int _id) //get info from database
        {

            cmd.Connection = cn;
            int id = 0;
            if (mail.Length != 0)
            {
                cn.Open();
                cmd.CommandText = "select Id from RegistrationTable where Mail='" + mail + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    if (dr.HasRows)
                    {
                        id = Int32.Parse(dr[0].ToString());
                        //   MessageBox.Show(id.ToString());
                        id--;
                        myProfile.Id = id;
                    }
                cn.Close();
            }
            else
            {
                myProfile.Id = _id;
                id = _id;
                buttonEdit.Visible = false;
                buttonLook.Visible = false;
                buttonStartChat.Visible = false;
                buttonAdd.Visible= false;
                buttonDelete.Visible= false; 

            }

            cn.Open();

            cmd.CommandText = "select Name from InfoTable where Id='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    myProfile.name = (dr[0].ToString());
                }
            cn.Close();

            cn.Open();
            cmd.CommandText = "select Surname from InfoTable where Id='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    myProfile.surname = (dr[0].ToString());
                }
            cn.Close();

            cn.Open();
            cmd.CommandText = "select Date from InfoTable where Id='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    //  MessageBox.Show((dr[0].ToString()));
                    myProfile.dateBirth = Convert.ToDateTime(dr[0].ToString());

                    //   MessageBox.Show(profInfo.dateBirth.Day.ToString());

                }
            cn.Close();

            cn.Open();
            cmd.CommandText = "select Photo from InfoTable where Id='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    myProfile.photo = (dr[0].ToString());
                }
            cn.Close();




            cn.Open();
            cmd.CommandText = "select AboutMe from InfoTable where Id='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    myProfile.aboutMe = (dr[0].ToString());
                }
            cn.Close();
          /*  cn.Open();
            cmd.CommandText = "select UserId1 from FriendshipTable where UserId2='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.Read())
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        myProfile.friends.Add(int.Parse(dr[0].ToString()));

                    }
                }
            cn.Close();*/
            cn.Open();
            cmd.CommandText = "select UserId2 from FriendshipTable where UserId1='" + id + "'";
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //  MessageBox.Show("s");
                    myProfile.friends.Add(int.Parse(dr[0].ToString()));
                }
            }
            cn.Close();
            formInitialization();
        }



        private void formInitialization()
        {
            string friendName = "";
            string friendSurname = "";
            string friendPhoto = "";
            string birth;
            textName.Text = myProfile.name;
            textSurname.Text = myProfile.surname;
            textAboutMe.Text = myProfile.aboutMe;
            //    MessageBox.Show(myProfile.friends.Count.ToString());
            tryOpenPhoto();
            birth = "Родился: " + myProfile.dateBirth.Day.ToString() + "." + myProfile.dateBirth.Month.ToString() + "." + myProfile.dateBirth.Year.ToString() + "";
            textBirthDate.Text = birth;
            for (int i = 0; i < myProfile.friends.Count; i++)
            {
                cn.Open();
                cmd.CommandText = "select * from InfoTable where Id='" + myProfile.friends[i] + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    if (dr.HasRows)
                    {
                        friendName = (dr[1].ToString());
                        friendSurname = (dr[2].ToString());
                        friendPhoto = (dr[4].ToString());
                    }
                cn.Close();
                listFriends.Items.Add(friendSurname + "  " + friendName);
            }

        }



        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangePhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Open Image";
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    var fileName = dlg.FileName;
                    string newFileName = myProfile.Id.ToString() + Path.GetExtension(fileName);

                    //  pictureMain.Image = null;
                    //  File.Delete(@"C:\images\"+ newFileName);

                    //   pictureMain.InitialImage = null;
                    // File.Delete(@"C:\images\" + newFileName);
                    if (pictureMain.Image != null)
                    {
                        pictureMain.Image.Dispose();
                        pictureMain.Image = null;
                    }


                    System.IO.File.Copy(fileName, Path.Combine(@"C:\images\", newFileName), true);



                    //PictureBox P = new PictureBox();

                    // Create a new Bitmap object from the picture file on disk,
                    // and assign that to the PictureBox.Image property
                    labelNoPhoto.Visible = false;
                    pictureMain.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureMain.Image = new Bitmap(dlg.FileName);
                }
            }
        }
        private void tryOpenPhoto()
        {
            //  var fileName = dlg.FileName;
            bool res = false;
            string newFileName = @"C:\images\" + myProfile.Id.ToString();// + Path.GetExtension(fileName);
                                                                         //  MessageBox.Show(newFileName);

            labelNoPhoto.Visible = false;
            pictureMain.SizeMode = PictureBoxSizeMode.StretchImage;
            if (!res && File.Exists(newFileName + ".jpg"))
            {
                res = true;
                newFileName = newFileName + ".jpg";
                File.Delete(newFileName + ".jpg");


            }
            if (!res && File.Exists(newFileName + ".png"))
            {
                res = true;
                newFileName = newFileName + ".png";
                File.Delete(newFileName + ".png");

            }
            if (!res && File.Exists(newFileName + ".jpeg"))
            {
                res = true;
                newFileName = newFileName + ".jpeg";
                File.Delete(newFileName + ".jpeg");

            }

            if (res)
            {

                pictureMain.Image = new Bitmap(newFileName);
                // using (pictureMain.Image = new Bitmap(newFileName))
                {
                    // Do some stuff
                } // automatically does the .Dispose call as if it was in a finally block

                labelNoPhoto.Visible = false;



            }



        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            buttonEdit.Enabled = false;
            buttonChangePhoto.Visible = true;
            buttonSaveChanges.Visible = true;
            textAboutMe.ReadOnly = false;
            textName.ReadOnly = false;
            textSurname.ReadOnly = false;
        }

        private void buttonSaveChanges_Click(object sender, EventArgs e)
        {
            buttonEdit.Enabled = true;
            buttonChangePhoto.Visible = false;
            buttonSaveChanges.Visible = false;
            textAboutMe.ReadOnly = true;
            textName.ReadOnly = true;
            textSurname.ReadOnly = true;
            savingChanges();
        }
        private void savingChanges()
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
            if (valid)
            {
                string name = textName.Text;
                string surname = textSurname.Text;
                string aboutMe = textAboutMe.Text;
                cn.Open();
                cmd.CommandText = "update InfoTable set Name='" + name + "',Surname='" + surname + "',AboutMe='" + aboutMe + "' where Id='" + myProfile.Id + "'";
                dr = cmd.ExecuteReader();
                cn.Close();

            }
        }

        private void buttonLook_Click(object sender, EventArgs e)
        {
            int chosedElem;
            int friendId;
           // string typeChosedElem;
            if (listFriends.SelectedIndex == -1)
            {
                MessageBox.Show("Choose friend");
            }
            else
            {
                chosedElem = listFriends.SelectedIndex;
                friendId = myProfile.friends[chosedElem];
                Profile formFriend = new Profile("", friendId);
                formFriend.Show();

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int chosedElem;
            int friendId;
            // string typeChosedElem;
            if (listFriends.SelectedIndex == -1)
            {
                MessageBox.Show("Choose friend");
            }
            else
            {
                chosedElem = listFriends.SelectedIndex;
                friendId = myProfile.friends[chosedElem];
                cn.Open();
                cmd.CommandText = "delete from  FriendshipTable where UserId1='" + myProfile.Id + "' and UserId2='"+ friendId + "' ";
                cmd.ExecuteNonQuery();
                cn.Close();
                listFriends.Items.RemoveAt(chosedElem);
                myProfile.friends.RemoveAt(chosedElem);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            int newFrienId;
            bool userFound = false;
            string friendName = "";
            string friendSurname = "";
            string friendPhoto = "";
            if (textNewFriendId.Text.Length!=0)
            {
                newFrienId =int.Parse(textNewFriendId.Text);
                cn.Open();
                cmd.CommandText = "select * from InfoTable where Id='" + newFrienId + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    if (dr.HasRows)
                    {


                        userFound = true;
                    }
             
                cn.Close();


                cn.Open();
                cmd.CommandText = "select * from InfoTable where Id='" + newFrienId + "'";
                dr = cmd.ExecuteReader();
                if (dr.Read())
                    if (dr.HasRows)
                    {
                        userFound = true;
                    }
                cn.Close();
                if (userFound)
                {
                    cn.Open();
                    cmd.CommandText = "insert into FriendshipTable (UserId1,UserId2) values ('" + myProfile.Id + "','" + newFrienId + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    cn.Close();
                    MessageBox.Show("New friend added!");

                    cn.Open();
                    cmd.CommandText = "select UserId2 from FriendshipTable where UserId1='" + myProfile.Id + "'";
                    myProfile.friends.Clear();
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            //  MessageBox.Show("s");
                            myProfile.friends.Add(int.Parse(dr[0].ToString()));
                        }
                    }
                    cn.Close();
                    listFriends.Items.Clear();
                    for (int i = 0; i < myProfile.friends.Count; i++)
                    {
                        cn.Open();
                        cmd.CommandText = "select * from InfoTable where Id='" + myProfile.friends[i] + "'";
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                            if (dr.HasRows)
                            {
                                friendName = (dr[1].ToString());
                                friendSurname = (dr[2].ToString());
                                friendPhoto = (dr[4].ToString());
                            }
                        cn.Close();
                        
                        listFriends.Items.Add(friendSurname + "  " + friendName);
                    }
                }
                else
                    MessageBox.Show("Check friend ID please!");

            }
        }

        private void textNewFriendId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonStartChat_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
