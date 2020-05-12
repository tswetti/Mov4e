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
    public partial class mov4eMovie : Form
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

        private static void ChangeStarColorYellow(int n, List<PictureBox> list)
        {
            for (int i=0;i<n;i++)
            {
                list[i].Image = Mov4e.Properties.Resources.star_yellow;
            }
        }

        private static void ClearAllStars(List<PictureBox> pb)
        {
            for (int i=0;i<5;i++)
            {
                pb[i].Image = Mov4e.Properties.Resources.star_white;
            }
        }

        /*private static void ChangeTextBoxSize(TextBox tb)
        {
            Size size = TextRenderer.MeasureText(tb.Text, tb.Font);
            tb.Width = size.Width;
            tb.Height = size.Height;
        }*/

        List<PictureBox> stars = new List<PictureBox>();
        //bool addingComment;

        public mov4eMovie()
        {
            InitializeComponent();
            //addingComment = false;

            /*this.tableLayoutPanelComments.RowStyles[0].Height = 0;
            textBoxAddComment.Visible = false;
            tabControlComments.Height = 750;*/

            tableLayoutPanelRating.RowStyles[2].Height = 0;
            tableLayoutPanelRating.RowStyles[1].Height = 66;
            labelAlreadyRated.Visible = false;

            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 100;
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 0;
            buttonRemoveFWatchlist.Visible = false;
            buttonAddToWatchlist.Height = 27;

            stars.Add(pictureBoxStar1);
            stars.Add(pictureBoxStar2);
            stars.Add(pictureBoxStar3);
            stars.Add(pictureBoxStar4);
            stars.Add(pictureBoxStar5);
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

        private void pictureBoxStar1_MouseHover(object sender, EventArgs e)
        {
            ChangeStarColorYellow(1, stars);
        }

        private void pictureBoxStar2_MouseHover(object sender, EventArgs e)
        {
            ChangeStarColorYellow(2, stars);
        }

        private void pictureBoxStar3_MouseHover(object sender, EventArgs e)
        {
            ChangeStarColorYellow(3, stars);
        }

        private void pictureBoxStar4_MouseHover(object sender, EventArgs e)
        {
            ChangeStarColorYellow(4, stars);
        }

        private void pictureBoxStar5_MouseHover(object sender, EventArgs e)
        {
            ChangeStarColorYellow(5, stars);
        }

        private void pictureBoxStar1_MouseLeave(object sender, EventArgs e)
        {
            ClearAllStars(stars);
        }

        private void pictureBoxStar2_MouseLeave(object sender, EventArgs e)
        {
            ClearAllStars(stars);
        }

        private void pictureBoxStar3_MouseLeave(object sender, EventArgs e)
        {
            ClearAllStars(stars);
        }

        private void pictureBoxStar4_MouseLeave(object sender, EventArgs e)
        {
            ClearAllStars(stars);
        }

        private void pictureBoxStar5_MouseLeave(object sender, EventArgs e)
        {
            ClearAllStars(stars);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eAddMovie m = new mov4eAddMovie();
            m.FormClosed += (s, args) => this.Close();
            m.ShowDialog();
        }

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eAllMovies m = new mov4eAllMovies();
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

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            /*if (addingComment)
            {
                this.tableLayoutPanelComments.RowStyles[0].Height = 0;
                textBoxAddComment.Visible = false;
                tabControlComments.Visible = true;
                tabControlComments.Height = 750;
                buttonAddComment.Text = "Add comment";
                buttonAddComment.BackColor = Color.White;
                addingComment = false;
            }
            else
            {
                this.tableLayoutPanelComments.RowStyles[1].Height = 0;
                tabControlComments.Visible = false;
                textBoxAddComment.Visible = true;
                textBoxAddComment.Height = 200;
                buttonAddComment.Text = "Submit comment";
                buttonAddComment.BackColor = Color.FromArgb(8, 233, 232);
                addingComment = true;
            }*/
        }

        private void buttonAddToWatchlist_Click(object sender, EventArgs e)
        {
            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 0;
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 100;
            buttonRemoveFWatchlist.Visible = true;
            buttonRemoveFWatchlist.Height = 30;
        }

        private void buttonRemoveFWatchlist_Click(object sender, EventArgs e)
        {
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 0;
            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 100;
            buttonAddToWatchlist.Visible = true;
            buttonRemoveFWatchlist.Visible = false;
            buttonAddToWatchlist.Height = 30;
        }

        private void textBoxAddComment_Click(object sender, EventArgs e)
        {
            if (textBoxAddComment.Text=="Type your comment here...")
            {
                textBoxAddComment.Text = null;
            }
        }
    }
}
