using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.Presenter.ProfileScreenPresenter;
using Mov4e.View.SpecificMovieInfoView;
using Mov4e.Validation;

namespace Mov4e.View.ProfileScreenView
{
    public partial class mov4eProfile : Form,IProfileScreen
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public byte[] Picture { get; set; }
        public int Age { get; set; }
        public Dictionary<int, byte[]> watchList { get; set; }

        //interface
        AllMoviesView.IAllMovies mainForm;

        public void ErrorMassage(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void IScreenView.ShowForm()
        {
            this.Show();
            listViewWatchlist.SelectedItems.Clear();
        }

        private IProfileScreenPresenter _profileScreenPresenter;

        private void AddMovieToWatchList(object sender, SpecificMovieEventArgs e)
        {
            _profileScreenPresenter.UpdateWatchListWhenMovieAdded(this.id);
            imageListWatchlist.Images.Add(e.movieId.ToString(), ((Bitmap)((new ImageConverter()).ConvertFrom(watchList[e.movieId]))));
            ListViewItem item = new ListViewItem(_profileScreenPresenter.SetMovieTitelInView(e.movieId));
            item.ImageKey = e.movieId.ToString();
            item.Name = e.movieId.ToString();
            listViewWatchlist.Items.Add(item);
            listViewWatchlist.Refresh();
        }

        //nowo
        private void DeleteMovieHandler(object sender, SpecificMovieEventArgs e)
        {
            watchList.Remove(e.movieId);
            imageListWatchlist.Images.RemoveByKey(e.movieId.ToString());
            listViewWatchlist.Items.RemoveByKey(e.movieId.ToString());
            _profileScreenPresenter.DeleteMovieFromwatchList(e.movieId);
            listViewWatchlist.Refresh();
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

        public mov4eProfile(int id, AllMoviesView.IAllMovies mainMov)
        {
            InitializeComponent();
            _profileScreenPresenter = new ProfileScreenPresenter(this);
            this.id = id;
            _profileScreenPresenter.SetUserInformation(id);
            mainForm = mainMov;
            initializeWatchList();
        }

        //Initilize the watchlist Setes information fro Db in the control
        public void initializeWatchList()
        {
            foreach (var pair in watchList)
            {
                imageListWatchlist.Images.Add(pair.Key.ToString(), ((Bitmap)((new ImageConverter()).ConvertFrom(pair.Value))));
                ListViewItem item = new ListViewItem(_profileScreenPresenter.SetMovieTitelInView(pair.Key));
                item.ImageKey = pair.Key.ToString();
                item.Name = pair.Key.ToString();
                listViewWatchlist.Items.Add(item);
            }

            listViewWatchlist.LargeImageList = imageListWatchlist;
        }


        
        private void SetInformation()
        {
            labelUsername.Text = UserName;
            labelUserFName.Text = FirstName;
            labelUserLName.Text = LastName;
            labelUserEmail.Text = Email;

            if (Gender == "M")
            {
                labelUserGender.Text = "Male";
            }
            else
                labelUserGender.Text = "Female";

            labelUserAge.Text =(DateTime.Now.Year- Age).ToString();
            pictureBoxProfilePicture.Image = (Bitmap)((new ImageConverter()).ConvertFrom(Picture));
            if (!Picture.SequenceEqual((byte[])(new ImageConverter()).ConvertTo(Properties.Resources.Default_profile_pic, typeof(byte[]))))
            {
               contextMenuStripEditPicture.Items[2].Enabled = true;
            }
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
                Properties.Settings.Default.LoggedForOneTime = false;
                Properties.Settings.Default.Save();
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
            /*TopLabelsMouseHover(closeLabel);*/
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
            mainForm.ShowForm();
            this.Close();
        }

        private void buttonLogOffProfile_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.id = 0;
            Properties.Settings.Default.Logged = false;
            Properties.Settings.Default.LoggedForOneTime = false;
            Properties.Settings.Default.userPosition = null;
            Properties.Settings.Default.Save();
            Application.Restart();
        }

        private void buttonProfileSettings_Click(object sender, EventArgs e)
        {
            this.Hide();
            mov4eProfileSettings _settings= new mov4eProfileSettings(this);
            _settings.Show();
        }

        private void pictureBoxBack_MouseHover(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_blue;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_white;
        }

        private void pictureBoxProfilePicture_Click(object sender, EventArgs e)
        {
            contextMenuStripEditPicture.Show(pictureBoxProfilePicture, 0, pictureBoxProfilePicture.Height);
        }

        private void buttonLogOffProfile_MouseHover(object sender, EventArgs e)
        {
            buttonLogOffProfile.BackColor = Color.Red;
        }

        private void buttonLogOffProfile_MouseLeave(object sender, EventArgs e)
        {
            buttonLogOffProfile.BackColor = Color.White;
        }

        private void mov4eProfile_Load(object sender, EventArgs e)
        {
            this.SetInformation();
        }

        private void buttonRemoveFW_Click(object sender, EventArgs e)
        {
            if (listViewWatchlist.SelectedItems.Count > 0)
            {
                _profileScreenPresenter.DeleteMovieFromwatchList(int.Parse(listViewWatchlist.SelectedItems[0].ImageKey));
                imageListWatchlist.Images.RemoveByKey(listViewWatchlist.SelectedItems[0].ImageKey);
                listViewWatchlist.Items.Remove(listViewWatchlist.SelectedItems[0]);
                listViewWatchlist.Refresh();
            }
            else
            {
                MessageBox.Show("Before you try to remove, you should select a movie!",
                              "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonViewInformation_Click(object sender, EventArgs e)
        {
            if (listViewWatchlist.SelectedItems.Count > 0)
            {
                this.Hide();
                ISpecificMovieView _specificMovieInfo = new mov4eMovie(int.Parse(listViewWatchlist.SelectedItems[0].ImageKey), this.id, this);
                //nowo
                _specificMovieInfo.MovieDeletedFromWatchList += DeleteMovieHandler;
                _specificMovieInfo.MovieAddedToWatchList += AddMovieToWatchList;
                _specificMovieInfo.ShowForm();
            }
            else
            {
                MessageBox.Show("Before you try to view movie's information, you should select a movie!",
                                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void listViewWatchlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewWatchlist.SelectedItems.Count == 0)
            {
                buttonRemoveFW.Enabled = false;
                buttonViewInformation.Enabled = false;
            }
            else
            {
                buttonRemoveFW.Enabled = true;
                buttonViewInformation.Enabled = true;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxProfilePicture.Image = Image.FromFile(open.FileName);
                    _profileScreenPresenter.ChangeProfilePicture((byte[])(new ImageConverter()).ConvertTo(pictureBoxProfilePicture.Image, typeof(byte[])));
                    contextMenuStripEditPicture.Items[2].Enabled = true;
                }
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pictureBoxProfilePicture.Image = Properties.Resources.Default_profile_pic;
            _profileScreenPresenter.ChangeProfilePicture((byte[])(new ImageConverter()).ConvertTo(Properties.Resources.Default_profile_pic, typeof(byte[])));
            contextMenuStripEditPicture.Items[2].Enabled = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            contextMenuStripEditPicture.Close();
        }

        public void UpdateEmail()
        {
            this.labelUserEmail.Text =Email;
        }

        public void UpdateBirthYear()
        {
            this.labelUserAge.Text = (DateTime.Now.Year - Age).ToString();

        }

        public void UpdateGender()
        {
            if (Gender == "M")
            {
                labelUserGender.Text = "Male";
            }
            else
                labelUserGender.Text = "Female";
        }

        public void UpdateUserName()
        {
            this.labelUsername.Text = UserName;
        }

        public void UpdateFirstNmae()
        {
            this.labelUserFName.Text = FirstName;
        }

        public void UpdateLastNmae()
        {
            this.labelUserLName.Text = LastName;
        }
    }
}
