﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class SettingsPage : Form
    {
        int returnform;
        string email;
        public SettingsPage(int recievedform, string email)
        {
            InitializeComponent();
            returnform = recievedform;
            this.email = email;
            Image myimage = new Bitmap(MySQLFunctions.getProfileImage(email));
            pictureBox1.BackgroundImage = myimage;
            user_button.Text = MySQLFunctions.getName(email);
            ChangePasswordPanel.Visible = false;
            LogoutPanel.Visible = false;
        }
        public SettingsPage()
        {
            InitializeComponent();
            ChangePasswordPanel.Visible = false;
            LogoutPanel.Visible = false;
        }
        private void Return_Click(object sender, EventArgs e)
        {
            switch (returnform)
            {
                case 0:
                    this.Hide();
                    HomePage a = new HomePage(email);
                    a.ShowDialog();
                    this.Close();
                    break;
                case 1:
                    this.Hide();
                    AccountPage b = new AccountPage(email);
                    b.ShowDialog();
                    this.Close();
                    break;
                default:
                    this.Hide();
                    HomePage c = new HomePage(email);
                    c.ShowDialog();
                    this.Close();
                    break;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            HomePage a = new HomePage(email);
            a.ShowDialog();
            this.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            WelcomePage d = new WelcomePage();
            d.ShowDialog();
            this.Close();
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text.Length == 0)
            {
                invalid.Visible = true;
            }else if (!passwordTextBox.Text.Equals(retypeTextBox.Text))
            {
                pwDoesNotMatch.Visible = true;
            }
            else
            {
                //Change password
                MySQLFunctions.changePassword(email, passwordTextBox.Text);
                MessageBox.Show("Password has been changed!");
            }
        }

        private void retypeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!passwordTextBox.Text.Equals(retypeTextBox.Text))
            {
                pwDoesNotMatch.Visible = true;
            }
            else
            {
                pwDoesNotMatch.Visible = false;
            }
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            if(passwordTextBox.Text.Length == 0)
            {
                invalid.Visible = true;
            }
            else
            {
                invalid.Visible = false;
            }
        }

        private void pwDoesNotMatch_Click(object sender, EventArgs e)
        {

        }

        private void user_button_Click(object sender, EventArgs e)
        {

        }

        private void ChangeLogoutOpener_Click(object sender, EventArgs e)
        {
            LogoutPanel.Visible = true;
        }

        private void ChangePasswordOpener_Click(object sender, EventArgs e)
        {
            if(!LogoutPanel.Visible)
            ChangePasswordPanel.Visible = true;
        }

        private void CancellogoutButton_Click(object sender, EventArgs e)
        {
            if(!ChangePasswordPanel.Visible)
            LogoutPanel.Visible = false;
        }

        private void PasswordCancel_Click(object sender, EventArgs e)
        {
            ChangePasswordPanel.Visible = false;
        }
    }
}
