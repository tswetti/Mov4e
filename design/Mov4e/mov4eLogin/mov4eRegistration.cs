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
    public partial class mov4eRegistration : Form
    {
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

        public mov4eRegistration()
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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eLogin ml = new mov4eLogin();
            ml.FormClosed += (s, args) => this.Close();
            ml.ShowDialog();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eLogin ml = new mov4eLogin();
            ml.FormClosed += (s, args) => this.Close();
            ml.ShowDialog();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

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
        }

        private void radioButtonFemale_CheckedChanged(object sender, EventArgs e)
        {
            pictureBoxFemale.Image = Mov4e.Properties.Resources.female_symbol_blue;
            pictureBoxMale.Image = Mov4e.Properties.Resources.male_symbol;
            ChangeColorsOnClickWhite(labelUsername, labelFirstName, labelLastName,
                labelEmail, panelHr1, panelHr2, panelHr3, panelHr4);
            labelPassword.ForeColor = Color.White;
            panelHr5.BackColor = Color.White;
        }
    }
}
