using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.Validation;
using Mov4e.Presenter.ProfileScreenPresenter;

namespace Mov4e.View.ProfileScreenView
{
    public partial class mov4eProfileSettings : Form,Imov4eProfileSettings
    {
        IProfileScreen _profileScreen;
        ISettingsPresenter _imov4EProfileSettingsPresenter;

        public void ErrorMassage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private static void TopLabelsMouseHover(Label label)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Hand;
            label.BackColor = Color.FromArgb(8, 233, 232);
            label.ForeColor = Color.Black;
        }

        private static void TopLabelsMouseLeave(Label label)
        {
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
            label.BackColor = Color.FromArgb(0, 15, 40);
            label.ForeColor = Color.White;
        }

        private static void ChangeSettingsColors(Label l, Button b, Panel p, Color c)
        {
            l.ForeColor = c;
            b.BackColor = c;
            p.BackColor = c;
        }

        Color neonBlue;
        Color white;
        List<Label> labels;
        List<Button> buttons;
        List<Panel> panels;

        private void ClearAllSettingsColors()
        {
            for (int i = 0; i < labels.Count-1; i++)
            {
                ChangeSettingsColors(labels[i], buttons[i], panels[i], white);
            }
            labelOldPassword.ForeColor = white;
            labelNewPassword.ForeColor = white;
            labelRepNewPassword.ForeColor = white;
        }

        public mov4eProfileSettings(IProfileScreen _profileSc)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            _profileScreen = _profileSc;
            this._imov4EProfileSettingsPresenter = new SettingsPresenter(_profileScreen);
            textBoxOldPassword.PasswordChar = '*';
            textBoxNewPassword.PasswordChar = '*';
            textBoxNewPasswordRepeat.PasswordChar = '*';
            this.comboBoxBYearChanged.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxGenderChanged.DropDownStyle = ComboBoxStyle.DropDownList;
            System.Object[] yearsObject = new System.Object[71];
            for (int i = 0; i < 71; i++)
            {
                yearsObject[i] = i + 1950;
            }
            comboBoxBYearChanged.Items.AddRange(yearsObject);
            comboBoxGenderChanged.Items.Add("Male");
            comboBoxGenderChanged.Items.Add("Female");

            neonBlue = Color.FromArgb(8, 233, 232);
            white = Color.White;

            labels=new List<Label>() {labelEmail, labelRepNewPassword, labelUsername, labelFirstName, labelLastName,labelBirthYear,labelGender};
            buttons=new List<Button> {buttonChangeEmail, buttonChangePassword, buttonChangeUsername, buttonChangeFName,
            buttonChangeLName,buttonChangeBYear,buttonChangeGender };
            panels=new List<Panel> {panelHrEmail, panelHrPassword, panelHrUsername, panelHrFName,
            panelHrLName,panelHrGender,panelHrBYear};

            this.ActiveControl = null;
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
                if (Properties.Settings.Default.Logged != true)
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

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            _profileScreen.ShowForm();
            this.Close();
        }

        private void pictureBoxBack_MouseHover(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_blue;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_white;
        }

        private void textBoxEmailChanged_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxEmailChanged.Text) && !string.IsNullOrWhiteSpace(textBoxEmailChanged.Text))
            {
                buttonChangeEmail.Enabled = true;
            }
            else
                buttonChangeEmail.Enabled = false;
        }

        private void textBoxEmailChanged_Click(object sender, EventArgs e)
        {
           
            ClearAllSettingsColors();
            ChangeSettingsColors(labelEmail, buttonChangeEmail, panelHrEmail, neonBlue);
        }

        private void textBoxNewPasswordRepeat_TextChanged(object sender, EventArgs e)
        {
            this.activatePasswordChangeButton();
        }

        private void textBoxUsernameChanged_Click(object sender, EventArgs e)
        {          
            ClearAllSettingsColors();
            ChangeSettingsColors(labelUsername, buttonChangeUsername, panelHrUsername, neonBlue);
        }

        private void textBoxFNameChanged_Click(object sender, EventArgs e)
        {
           
            ClearAllSettingsColors();
            ChangeSettingsColors(labelFirstName, buttonChangeFName, panelHrFName, neonBlue);
        }

        private void textBoxLNameChanged_Click(object sender, EventArgs e)
        {
            ClearAllSettingsColors();
            ChangeSettingsColors(labelLastName, buttonChangeLName, panelHrLName, neonBlue);
        }


        private void textBoxOldPassword_Click(object sender, EventArgs e)
        {
            ClearAllSettingsColors();
            labelOldPassword.ForeColor = neonBlue;
        }

        private void textBoxNewPassword_Click(object sender, EventArgs e)
        {
            ClearAllSettingsColors();
            labelNewPassword.ForeColor = neonBlue;
        }

        private void textBoxNewPasswordRepeat_Click(object sender, EventArgs e)
        {
            //ChangeSettingsColors(labelRepNewPassword, buttonChangePassword, panelHrPassword, neonBlue);
            ClearAllSettingsColors();
            labelRepNewPassword.ForeColor = neonBlue;
        }

        private void comboBoxBYearChanged_Click(object sender, EventArgs e)
        {
            ClearAllSettingsColors();
            labelBirthYear.ForeColor = neonBlue;
            buttonChangeBYear.BackColor = neonBlue;
        }

        private void comboBoxGenderChanged_Click(object sender, EventArgs e)
        {
            ClearAllSettingsColors();
            labelGender.ForeColor = neonBlue;
            buttonChangeGender.BackColor = neonBlue;
        }

        private void mov4eProfileSettings_Load(object sender, EventArgs e)
        {

        }

        private void buttonChangeEmail_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.isEMailCorrect(textBoxEmailChanged.Text);
                _imov4EProfileSettingsPresenter.ChangeEmail(textBoxEmailChanged.Text);
                if (_profileScreen.Email.Equals(textBoxEmailChanged.Text))
                {
                    textBoxEmailChanged.Text = null;
                    MessageBox.Show("You have successfully changed your E-mail!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonChangeBYear_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.isAgeValid(int.Parse(comboBoxBYearChanged.Text));
                _imov4EProfileSettingsPresenter.ChangeAge(int.Parse(comboBoxBYearChanged.Text));
                if (_profileScreen.Age.Equals(int.Parse(comboBoxBYearChanged.Text)))
                {
                    comboBoxBYearChanged.Text = null;
                    MessageBox.Show("You have successfully changed your birth-year", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonChangeGender_Click(object sender, EventArgs e)
        {
            try
            {                
                if (comboBoxGenderChanged.Text == "Male")
                {
                    ValidateProfile.isGenderValid(comboBoxGenderChanged.Text.First().ToString());
                    _imov4EProfileSettingsPresenter.ChangeGender("M");
                    if (_profileScreen.Gender.Equals(comboBoxGenderChanged.Text.First().ToString()))
                    {
                        comboBoxGenderChanged.Text =null;
                        MessageBox.Show("You have successfully changed your gender!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    
                }
                else
                 if (comboBoxGenderChanged.Text == "Female")
                 {
                    ValidateProfile.isGenderValid(comboBoxGenderChanged.Text.First().ToString());
                    _imov4EProfileSettingsPresenter.ChangeGender("F");
                    if (_profileScreen.Gender.Equals(comboBoxGenderChanged.Text.First().ToString()))
                    {
                        comboBoxGenderChanged.Text = null;
                        MessageBox.Show("You have successfully changed your gender!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                 }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //ima izklyuchenie
        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.areNewPassAndRepeatedSame(textBoxNewPassword.Text, textBoxNewPasswordRepeat.Text);
                ValidateProfile.isPasswordCorrect(textBoxNewPassword.Text);
                _imov4EProfileSettingsPresenter.ChangePassword(textBoxOldPassword.Text, textBoxNewPassword.Text, textBoxNewPasswordRepeat.Text);
                textBoxNewPasswordRepeat.Text=null;
                textBoxNewPassword.Text = null;
                textBoxOldPassword.Text = null;
                MessageBox.Show("You have successfully changed your password", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonChangeUsername_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.isUserNameValid(textBoxUsernameChanged.Text);
                _imov4EProfileSettingsPresenter.ChangeUserName(textBoxUsernameChanged.Text);
                if (_profileScreen.UserName.Equals(textBoxUsernameChanged.Text))
                {
                    textBoxUsernameChanged.Text = null;
                    MessageBox.Show("You have successfully changed your username", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonChangeFName_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.isFirstNameCorrect(textBoxFNameChanged.Text);
                _imov4EProfileSettingsPresenter.ChangeFirstName(textBoxFNameChanged.Text);
                if (_profileScreen.FirstName.Equals(textBoxFNameChanged.Text))
                {
                    textBoxFNameChanged.Text =null;
                    MessageBox.Show("You have successfully changed your firstname!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonChangeLName_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateProfile.isLastNameCorrect(textBoxLNameChanged.Text);
                _imov4EProfileSettingsPresenter.ChangeLastName(textBoxLNameChanged.Text);
                if (_profileScreen.LastName.Equals(textBoxLNameChanged.Text))
                {
                    textBoxLNameChanged.Text = null;
                    MessageBox.Show("You have successfully changed your lastname!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void comboBoxBYearChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxBYearChanged.Text) && !string.IsNullOrWhiteSpace(comboBoxBYearChanged.Text))
            {
                buttonChangeBYear.Enabled = true;
            }
            else
                buttonChangeBYear.Enabled = false;
        }

        private void textBoxUsernameChanged_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxUsernameChanged.Text) && !string.IsNullOrWhiteSpace(textBoxUsernameChanged.Text))
            {
                buttonChangeUsername.Enabled = true;
            }
            else
                buttonChangeUsername.Enabled = false;
        }

        private void textBoxFNameChanged_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxFNameChanged.Text) && !string.IsNullOrWhiteSpace(textBoxFNameChanged.Text))
            {
                buttonChangeFName.Enabled = true;
            }
            else
                buttonChangeFName.Enabled = false;
        }

        private void textBoxLNameChanged_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxLNameChanged.Text) && !string.IsNullOrWhiteSpace(textBoxLNameChanged.Text))
            {
                buttonChangeLName.Enabled = true;
            }
            else
                buttonChangeLName.Enabled = false;
        }

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {
            this.activatePasswordChangeButton();
        }

        private void textBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            this.activatePasswordChangeButton();
        }

        private void comboBoxGenderChanged_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBoxGenderChanged.Text) && !string.IsNullOrWhiteSpace(comboBoxGenderChanged.Text))
            {
                buttonChangeGender.Enabled = true;
            }
            else
                buttonChangeGender.Enabled = false;
        }

        private void activatePasswordChangeButton()
        {
            if (!string.IsNullOrEmpty(textBoxNewPassword.Text) && !string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                if (!string.IsNullOrEmpty(textBoxOldPassword.Text) && !string.IsNullOrWhiteSpace(textBoxOldPassword.Text))
                {
                    if (!string.IsNullOrEmpty(textBoxNewPasswordRepeat.Text) && !string.IsNullOrWhiteSpace(textBoxNewPasswordRepeat.Text))
                    {
                        buttonChangePassword.Enabled = true;
                    }
                }
            }
            else
                buttonChangePassword.Enabled = false;
        }

        public void ShowForm()
        {
            this.Show();
        }
    }
}
