using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string firstname = txtFirstName.Text;
            string lastname = txtLastName.Text;
            bool isCorrect = false;
            if (email.Contains("@"))
            {
                if (Utilities.UserList.Count == 0)
                {
                    isCorrect = true;
                    User us = new User(email, password, firstname, lastname);
                    Utilities.UserList.Add(us);
                    MessageBox.Show("User yaradildi");
                    txtEmail.Text = "";
                    txtFirstName.Text = "";
                    txtLastName.Text = "";
                    txtPassword.Text = "";
                }
                else
                {
                    foreach (var u in Utilities.UserList)
                    {
                        if (u.Email != email)
                        {
                            User us = new User(email, password, firstname, lastname);
                            Utilities.UserList.Add(us);
                            isCorrect = true;
                            MessageBox.Show("User yaradildi");
                            txtEmail.Text = "";
                            txtFirstName.Text = "";
                            txtLastName.Text = "";
                            txtPassword.Text = "";
                            break;
                        }
                    }
                    if (!isCorrect)
                    {
                        MessageBox.Show("email artiq movcuddur");
                    }
                }
            }
            else
            {
                MessageBox.Show("@ isharesinden istifade etmemisiniz");
            }
        }
    }
}
