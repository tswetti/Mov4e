using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.Presenter.LogInPresenter;

namespace Mov4e.View.LogInView
{
    public partial class mov4eLogin : Form,ILogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool Stay { get; set; }

        public void HideScreen()
        {
            this.Hide();
        }

        public void ErrorMassage(string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ILogInPresenter _logInPresenter;

        private static void TopLabelsMouseHover(Label label)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
            label.BackColor = Color.FromArgb(8,233,232);
            label.ForeColor = Color.Black;
        }

        private static void TopLabelsMouseLeave(Label label)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            label.BackColor = Color.FromArgb(0, 15, 40);
            label.ForeColor = Color.White;
        }

        public mov4eLogin()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            UserName = null;
            Password = null;
            _logInPresenter = new LogInPresenter(this);
        }

        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void maximizeLabel_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void closeLabel_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are You sure Want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                this.Controls.Clear();
                Environment.Exit(1);
            }
        }

        private void minimizeLabel_MouseHover(object sender, EventArgs e)
        {
            TopLabelsMouseHover(minimizeLabel);
        }

        private void maximizeLabel_MouseHover(object sender, EventArgs e)
        {
            TopLabelsMouseHover(maximizeLabel);
        }

        private void closeLabel_MouseHover(object sender, EventArgs e)
        {
            closeLabel.BackColor = Color.Red;
        }

        private void minimizeLabel_MouseLeave(object sender, EventArgs e)
        {
            TopLabelsMouseLeave(minimizeLabel);
        }

        private void maximizeLabel_MouseLeave(object sender, EventArgs e)
        {
            TopLabelsMouseLeave(maximizeLabel);
        }

        private void closeLabel_MouseLeave(object sender, EventArgs e)
        {
            TopLabelsMouseLeave(closeLabel);
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterView.mov4eRegistration r = new RegisterView.mov4eRegistration(this);
            this.Visible = false;
            r.ShowDialog();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxUsername.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                this.UserName = textBoxUsername.Text;
                this.Password = textBoxPassword.Text;
                if (checkBoxSave.Checked == true)
                {
                    this.Stay = true;
                }
                else
                    this.Stay = false;
                _logInPresenter.LogUser();
                if (Properties.Settings.Default.Logged == true || Properties.Settings.Default.LoggedForOneTime == true)
                {
                    Application.Restart();
                }
            }

            else
            {
                MessageBox.Show("You must write something in the boxes first!!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkIfEverithingIsFilledToActivateButton()
        {
            if (!string.IsNullOrWhiteSpace(textBoxUsername.Text) && !string.IsNullOrEmpty(textBoxUsername.Text) &&
                !string.IsNullOrWhiteSpace(textBoxPassword.Text) && !string.IsNullOrEmpty(textBoxPassword.Text))
            {
              buttonLogin.Enabled = true; 
            }
            else
                buttonLogin.Enabled = false;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }
    }
}
