/*
 * Login Form Done by Paul Teixeira
 * This allows users to enter username and password and gain access to the database editing tool
 * 
 * Enter key on password fires login event.
 * TO do:
 * -Move server side hashing done by sql to client side done in .net
 * -Sanitize inputs for safty from SQL injection
 * */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelExperts
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void QuitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (LoginDB.Login(UsernameTxt.Text, PasswordTxt.Text)) //logged in was returned true
            {
                this.Hide(); //hide login
                frmMain MainMenu = new frmMain(); //start new form
                MainMenu.ShowDialog();
                this.Close(); //when dialog returns control to login form, close imediatly
            }
            else
            {
                MessageBox.Show("Username or password were incorrect.");
                PasswordTxt.SelectAll();
                PasswordTxt.Focus();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("You must re attach Travel Experts Database to the new one in your github folder. \n \n Login: Admin \n Password:pass");
        }
    }
}
