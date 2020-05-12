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
    public partial class mov4eAllMovies : Form
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

        bool sortOpened;
        bool filterOpened;

        public mov4eAllMovies()
        {
            InitializeComponent();
            this.tableLayoutPanelMovies.RowStyles[1].Height = 0;
            this.tableLayoutPanelMovies.RowStyles[2].Height = 80;
            listViewMovies.Height = 570;
            sortOpened = false;
            filterOpened = false;
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBoxSearch_Click(object sender, EventArgs e)
        {
            pictureBoxSearchIcon.Image = Mov4e.Properties.Resources.search_blue;
            pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_white;
            pictureBoxSort.Image = Mov4e.Properties.Resources.sort_white;
        }

        private void buttonStartSearch_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eProfile mp = new mov4eProfile();
            mp.FormClosed += (s, args) => this.Close();
            mp.ShowDialog();
        }

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eAddMovie m = new mov4eAddMovie();
            m.FormClosed += (s, args) => this.Close();
            m.ShowDialog();
        }

        private void listViewMovies_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBoxFilter_Click(object sender, EventArgs e)
        {
            pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_blue;
            pictureBoxSearchIcon.Image = Mov4e.Properties.Resources.search_white;
            pictureBoxSort.Image = Mov4e.Properties.Resources.sort_white;
            if (filterOpened)
            {
                if (sortOpened)
                {
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 10;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 100;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 0;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 70;
                    pictureBoxSort.Image = Mov4e.Properties.Resources.sort_blue;
                }
                else
                {
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 0;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 80;
                }
                filterOpened = false;
                pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_white;
            }
            else
            {
                if (sortOpened)
                {
                    
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 35;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 45;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 15;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 85;
                    pictureBoxSort.Image = Mov4e.Properties.Resources.sort_blue;

                }
                else
                {
                   
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 35;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 0;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 100;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 55;
                }
                filterOpened = true;
            }
        }

        private void pictureBoxSort_Click(object sender, EventArgs e)
        {
            pictureBoxSort.Image = Mov4e.Properties.Resources.sort_blue;
            pictureBoxSearchIcon.Image = Mov4e.Properties.Resources.search_white;
            pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_white;
            if (sortOpened)
            {
                if (filterOpened)
                {

                    this.tableLayoutPanelMovies.RowStyles[1].Height = 32;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 0;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 100;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 55;
                    pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_blue;
                }
                else
                {
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 0;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 80;
                }
                sortOpened = false;
                pictureBoxSort.Image = Mov4e.Properties.Resources.sort_white;
            }
            else
            {
                if (filterOpened == false)
                {
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 10;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 100;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 0;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 70;
                }
                else
                {
                    this.tableLayoutPanelMovies.RowStyles[1].Height = 35;
                    this.tableLayoutPanelMovies.RowStyles[2].Height = 45;
                    this.tableLayoutPanelSortFilter.RowStyles[0].Height = 15;
                    this.tableLayoutPanelSortFilter.RowStyles[1].Height = 85;
                    pictureBoxFilter.Image = Mov4e.Properties.Resources.filter_blue;
                }
                sortOpened = true;
            }
        }

        private void buttonViewInfo_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eMovie mm = new mov4eMovie();
            mm.FormClosed += (s, args) => this.Close();
            mm.ShowDialog();
        }

        private void tableLayoutPanelFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
