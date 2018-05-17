using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialNetwork
{
    public partial class FormRegistration : Form
    {
        public FormRegistration()
        {
            InitializeComponent();
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
            return filled;
        }
        private bool fieldsValid()
        {
            bool valid = true;
            if (textName.Text.Length < 2)
                valid = false;
            if (textSurname.Text.Length < 2)
                valid = false;

            if (textMail.Text.Length == 0)
                valid = false;

            if (textPassword.Text.Length == 0)
                valid = false;


            if (textPassword2.Text != textPassword.Text)
                valid = false;
            return valid;
        }

    }
}
