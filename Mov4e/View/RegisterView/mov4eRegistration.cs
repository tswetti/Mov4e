using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.View.LogInView;
using Mov4e.Presenter.RegisterPresenter;
using Mov4e.Validation;

namespace Mov4e.View.RegisterView
{
    public partial class mov4eRegistration : Form,IRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        private LogInView.ILogIn mainForm;
        private IRegisterPresenter rp;

        public void ErrorMassage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

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

        private static void ChangeColorsOnClickBlue(Label label, Panel panel)
        {
            label.ForeColor = Color.FromArgb(8, 233, 232);
            panel.BackColor = Color.FromArgb(8, 233, 232);
        }

        private static void ChangeColorsOnClickWhite(Label l1, Label l2, Label l3,
            Label l4, Panel p1, Panel p2, Panel p3, Panel p4)
        {
            Label[] labels = new Label[] { l1, l2, l3, l4 };
            foreach (Label l in labels)
            {
                l.ForeColor = Color.White;
            }
            Panel[] panels = new Panel[] { p1, p2, p3, p4 };
            foreach (Panel p in panels)
            {
                p.BackColor = Color.White;
            }
        }

        public mov4eRegistration(ILogIn mainform)
        {
            InitializeComponent();
            textBoxPassword.PasswordChar = '*';
            this.comboBoxAge.DropDownStyle = ComboBoxStyle.DropDownList;
            System.Object[] ageObject = new System.Object[71];
            for (int i = 0; i < 71; i++)
            {
                ageObject[i] = i+1950;
            }
            comboBoxAge.Items.AddRange(ageObject);

            FirstName = null;
            LastName = null;
            UserName = null;
            Password = null;
            Email = null;
            Gender = null;
            Age = 0;
            rp = new RegisterPresenter(this);
            mainForm = mainform;
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainForm.ShowForm();
            this.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateRegister.isUserNameValid(textBoxUsername.Text);
                UserName = textBoxUsername.Text;

                ValidateRegister.areFirstAndLastNameValid(textBoxFirstName.Text, textBoxFirstName.Text);
                FirstName = textBoxFirstName.Text;
                LastName = textBoxLastName.Text;

                ValidateRegister.isPasswordCorrect(textBoxPassword.Text);
                Password = textBoxPassword.Text;

                ValidateRegister.isEMailCorrect(textBoxEmail.Text);
                Email = textBoxEmail.Text;

                if (radioButtonMale.Checked == true)
                {
                    Gender = "M";
                    ValidateRegister.isGenderValid(Gender);
                }
                if (radioButtonFemale.Checked == true)
                {
                    Gender = "F";
                    ValidateRegister.isGenderValid(Gender);
                }

                ValidateRegister.isAgeValid(int.Parse(comboBoxAge.Text));
                Age = int.Parse(comboBoxAge.Text);

                if (rp.RegisterUser())
                {
                    this.Hide();
                    mainForm.ShowForm();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxUsername_Click(object sender, EventArgs e)
        {
            ChangeColorsOnClickBlue(labelUsername, panelHr1);
            ChangeColorsOnClickWhite(labelFirstName, labelLastName, labelEmail, labelPassword,
            panelHr2, panelHr3, panelHr4, panelHr5);
        }

        private void textBoxFirstName_Click(object sender, EventArgs e)
        {
            ChangeColorsOnClickBlue(labelFirstName, panelHr2);
            ChangeColorsOnClickWhite(labelUsername, labelLastName, labelEmail, labelPassword,
            panelHr1, panelHr3, panelHr4, panelHr5);
        }

        private void textBoxLastName_Click(object sender, EventArgs e)
        {
            ChangeColorsOnClickBlue(labelLastName, panelHr3);
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelEmail, labelPassword,
            panelHr1, panelHr2, panelHr4, panelHr5);
        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {
            ChangeColorsOnClickBlue(labelEmail, panelHr4);
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelLastName, labelPassword,
            panelHr1, panelHr2, panelHr3, panelHr5);
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            ChangeColorsOnClickBlue(labelPassword, panelHr5);
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelLastName, labelEmail,
            panelHr1, panelHr2, panelHr3, panelHr4);
        }

        private void radioButtonMale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxMale.Image = Mov4e.Properties.Resources.male_symbol_blue;
            pictureBoxFemale.Image = Mov4e.Properties.Resources.female_symbol;
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelLastName,
                labelEmail, panelHr1, panelHr2, panelHr3, panelHr4);
            labelPassword.ForeColor = Color.White;
            panelHr5.BackColor = Color.White;
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxFemale.Image = Mov4e.Properties.Resources.female_symbol_blue;
            pictureBoxMale.Image = Mov4e.Properties.Resources.male_symbol;
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelLastName,
                labelEmail, panelHr1, panelHr2, panelHr3, panelHr4);
            labelPassword.ForeColor = Color.White;
            panelHr5.BackColor = Color.White;
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void mov4eRegistration_Load(object sender, EventArgs e)
        {

        }

        private void checkIfEverithingIsFilledToActivateButton()
        {
            if (!string.IsNullOrEmpty(textBoxUsername.Text) && !string.IsNullOrWhiteSpace(textBoxUsername.Text)
                && (!string.IsNullOrEmpty(textBoxFirstName.Text) && !string.IsNullOrWhiteSpace(textBoxFirstName.Text))
                && (!string.IsNullOrEmpty(textBoxLastName.Text) && !string.IsNullOrWhiteSpace(textBoxLastName.Text))
                && (!string.IsNullOrEmpty(textBoxEmail.Text) && !string.IsNullOrWhiteSpace(textBoxEmail.Text))
                && (!string.IsNullOrEmpty(textBoxPassword.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text))
                && tableLayoutPanelGenderAndYear.Controls.OfType<RadioButton>().Any(t => t.Checked == true)
                && !(string.IsNullOrEmpty(this.comboBoxAge.Text) && string.IsNullOrWhiteSpace(this.comboBoxAge.Text)))
            {
                buttonRegister.Enabled = true;
            }
            else
                buttonRegister.Enabled = false;
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        private void comboBoxAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.checkIfEverithingIsFilledToActivateButton();
        }

        public void ShowForm()
        {
            this.Show();
        }
    }
}
