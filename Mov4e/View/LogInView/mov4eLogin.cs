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

        //shows only login, and hides "forgotten password" panel
        private void ShowLoginOnly()
        {
            tableLayoutPanelLoggedOrChangePass.RowStyles[0].Height = 100;
            tableLayoutPanelLoggedOrChangePass.RowStyles[1].Height = 0;
            tableLayoutPanelLoggedOrChangePass.RowStyles[2].Height = 0;
            tableLayoutPanelChangePassInfo.Height = 100;
            tableLayoutPanelChangePassInfo.RowStyles[0].Height = 100;
            tableLayoutPanelChangePassInfo.RowStyles[1].Height = 0;
            tableLayoutPanelChangePassInfo.RowStyles[2].Height = 0;
            checkBoxSave.Height = 40;
            labelForgottenPass.Height = 40;

            tableLayoutPanelLoginContent.RowStyles[0].Height = 20;
            tableLayoutPanelLoginContent.RowStyles[1].Height = 20;
            tableLayoutPanelLoginContent.RowStyles[3].Height = 15;
            tableLayoutPanelLoginContent.RowStyles[5].Height = 15;
            tableLayoutPanelLoginContent.RowStyles[6].Height = 10;
            tableLayoutPanelLoginContent.RowStyles[7].Height = 10;
            tableLayoutPanelLoginContent.RowStyles[8].Height = 20;
            tableLayoutPanelUsername.Height = 40;
            tableLayoutPanelPassword.Height = 40;
            pictureBoxUsername.Height = 40;
            pictureBoxPassword.Height = 40;
            tableLayoutPanelLoginButtons.Height = 41;
            panelPassword.Height = 26;
            checkBoxSave.Visible = true;
        }

        // shows the panel with "forgotten password" and hides the one above it
        private void ShowForgottenPasswordField()
        {
            tableLayoutPanelLoginContent.RowStyles[3].Height = 0;
            tableLayoutPanelLoginContent.RowStyles[5].Height = 0;
            tableLayoutPanelLoginContent.RowStyles[7].Height = 0;
            tableLayoutPanelLoginContent.RowStyles[6].Height = 50;
            tableLayoutPanelLoggedOrChangePass.RowStyles[0].Height = 60;
            tableLayoutPanelLoggedOrChangePass.RowStyles[1].Height = 20;
            tableLayoutPanelLoggedOrChangePass.RowStyles[2].Height = 20;
            tableLayoutPanelChangePassInfo.RowStyles[0].Height = 25;
            tableLayoutPanelChangePassInfo.RowStyles[1].Height = 37;
            tableLayoutPanelChangePassInfo.RowStyles[2].Height = 37;
            tableLayoutPanelForgPassBtns.Height = 35;
            checkBoxSave.Visible = false;
        }

        bool hiddenPass;

        public mov4eLogin()
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            UserName = null;
            Password = null;
            hiddenPass = true;
            _logInPresenter = new LogInPresenter(this);
            ShowLoginOnly();
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
            DialogResult d = MessageBox.Show("Are you sure want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d == DialogResult.OK)
            {
                if (Properties.Settings.Default.Logged!=true)
                {
                    Properties.Settings.Default.LoggedForOneTime = false;
                    Properties.Settings.Default.userPosition = null;
                    Properties.Settings.Default.id = 0;
                    Properties.Settings.Default.Save();
                }
                this.Controls.Clear();
                Environment.Exit(1);
            }
        }

        // the following code changes labels'color according to mouse movement
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
            this.Hide();
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
                MessageBox.Show("You must type something in the boxes first!!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void checkIfEverithingIsFilledInResetToActivateButton()
        {
            if (!string.IsNullOrWhiteSpace(textBoxForgottenPassUsername.Text) && !string.IsNullOrEmpty(textBoxForgottenPassUsername.Text) &&
                !string.IsNullOrWhiteSpace(textBoxForgottenPassEmail.Text) && !string.IsNullOrEmpty(textBoxForgottenPassEmail.Text))
            {
                buttonSendEmail.Enabled = true;
            }
            else
                buttonSendEmail.Enabled = false;
        }


        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void labelForgottenPass_Click(object sender, EventArgs e)
        {
            ShowForgottenPasswordField();
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            ShowLoginOnly();
        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(textBoxForgottenPassUsername.Text) && !string.IsNullOrWhiteSpace(textBoxForgottenPassEmail.Text))
                {
                    DialogResult d = MessageBox.Show("Your password will be changed automaticaly!\n" +
                                                     "Be sure you know your credentials for the email,\n" +
                                                     "because the new password will be sent there!\n\n"+
                                                     "Are you sure you want to continue?",
                                                      "Reset Password", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (d == DialogResult.Yes)
                    {
                        _logInPresenter.ResetPass(textBoxForgottenPassUsername.Text, textBoxForgottenPassEmail.Text);
                        textBoxForgottenPassUsername.Text = null;
                        textBoxForgottenPassEmail.Text = null;
                        MessageBox.Show("You have successfully reset your password!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("You must type something in the boxes first!!", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ErrorMassage(ex.Message);
            }
        }

        private void textBoxForgottenPassUsername_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledInResetToActivateButton();
        }

        private void textBoxForgottenPassEmail_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledInResetToActivateButton();
        }

        private void mov4eLogin_Load(object sender, EventArgs e)
        {

        }

        public void ShowForm()
        {
            this.Show();
        }

        private void pictureBoxShowPass_Click(object sender, EventArgs e)
        {
            // shows password
            if (hiddenPass)
            {
                textBoxPassword.PasswordChar = '\0';
                pictureBoxShowPass.Image= Mov4e.Properties.Resources.show_pass_blue;
                hiddenPass = false;
            }
            // hides password
            else
            {
                textBoxPassword.PasswordChar = '*';
                pictureBoxShowPass.Image = Mov4e.Properties.Resources.show_pass;
                hiddenPass = true;
            }
        }
    }
}
