using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mov4e
{
    public partial class mov4eProfileSettings : Form
    {
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
        }

        public mov4eProfileSettings()
        {
            InitializeComponent();

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

            labels=new List<Label>() {labelEmail, labelRepNewPassword, labelUsername, labelFirstName, labelLastName,labelBirthYear};
            buttons=new List<Button> {buttonChangeEmail, buttonChangePassword, buttonChangeUsername, buttonChangeFName,
            buttonChangeLName,buttonChangeBYear };
            panels=new List<Panel> {panelHrEmail, panelHrPassword, panelHrUsername, panelHrFName,
            panelHrLName};
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
            this.Close();
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
            mov4eProfile m = new mov4eProfile();
            m.FormClosed += (s, args) => this.Close();
            m.ShowDialog();
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

        }

        private void textBoxEmailChanged_Click(object sender, EventArgs e)
        {
           
            ClearAllSettingsColors();
            ChangeSettingsColors(labelEmail, buttonChangeEmail, panelHrEmail, neonBlue);
        }

        private void textBoxNewPasswordRepeat_TextChanged(object sender, EventArgs e)
        { 
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

        private void textBoxOldPassword_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBoxOldPassword_Click(object sender, EventArgs e)
        {          
            labelOldPassword.ForeColor = neonBlue;
        }

        private void textBoxNewPassword_Click(object sender, EventArgs e)
        {          
            labelNewPassword.ForeColor = neonBlue;
        }

        private void textBoxNewPasswordRepeat_Click(object sender, EventArgs e)
        {          
            ChangeSettingsColors(labelRepNewPassword, buttonChangePassword, panelHrPassword, neonBlue);
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
    }
}
