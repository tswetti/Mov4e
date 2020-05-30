using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.Presenter.SpecificMovieInfoPresenter;
using Mov4e.Validation;

namespace Mov4e.View.SpecificMovieInfoView
{
    public partial class mov4eMovie : Form, ISpecificMovieView
    {
        public int movieId { get; set; }
        public int userId { get; set; }
        public string movieTitle { get; set; }
        public byte[] moviePicture { get; set; }
        public string movieGenre { get; set; }
        public Nullable<int> moviePG { get; set; }
        public string moviePrimeDate { get; set; }
        public double? movieAVGRate { get; set; }
        public string movieSummary { get; set; }
        public string userPosition { get; set; }
        public int duration { get; set; }
        public int userRate { get; set; }
        public List<(int commentId, string name, byte[] picture, string comment)> comments { get; set; }

        private HashSet<int> commentIds = new HashSet<int>();
        private ISpecificMovieInfoPresenter _specificMoviePresenter;
        IScreenView _screnToGoback;


        //Events///////
        public event EventHandler<SpecificMovieEventArgs> MovieDeletedFromWatchList;
        public event EventHandler<SpecificMovieEventArgs> MovieAddedToWatchList;
        SpecificMovieEventArgs spEventArgs;

        protected virtual void OnMovieDeletedFromWatchList(SpecificMovieEventArgs e)
        {
            if (MovieDeletedFromWatchList != null)
                MovieDeletedFromWatchList.Invoke(this, e);
        }

        protected virtual void OnMovieAddedToWatchList(SpecificMovieEventArgs e)
        {
            if (MovieDeletedFromWatchList != null)
                MovieAddedToWatchList.Invoke(this, e);
        }

        public void ErrorMessage(string msg)
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

        private static void ChangeStarColorYellow(int n, List<PictureBox> list)
        {
            for (int i = 0; i < n; i++)
            {
                list[i].Image = Mov4e.Properties.Resources.star_yellow;
            }
        }

        private static void ClearAllStars(List<PictureBox> pb)
        {
            for (int i = 0; i < 5; i++)
            {
                pb[i].Image = Mov4e.Properties.Resources.star_white;
            }
        }

        // a list of starts for the rating
        List<PictureBox> stars = new List<PictureBox>();
        // is used to show how many characters in the comments are written
        int charactersCount;
        int maxCharacters;
        // is used to change guide text in comments
        bool commentFirstClick;

        public mov4eMovie(int movieId, int userId, IScreenView screen)
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            // hides the panel that appears when the user rates movie
            tableLayoutPanelRating.RowStyles[1].Height = 66;
            tableLayoutPanelRating.RowStyles[2].Height = 0;
            this.tableLayoutPanelRating.RowStyles[3].Height = 0;
            labelAlreadyRated.Visible = false;

            // hides "remove from watchlist" and shows "add to watchlist"
            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 100;
            buttonAddToWatchlist.Height = buttonAddComment.Height;
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 0;
            buttonRemoveFWatchlist.Visible = false;

            textBoxAddComment.Text = "Type your comment here...";
            commentFirstClick = true;
            // setting up the comment textbox
            charactersCount = textBoxAddComment.Text.Length;
            maxCharacters = textBoxAddComment.MaxLength;
            labelCharactersLeft.Text = "0/" + maxCharacters;

            stars.Add(pictureBoxStar1);
            stars.Add(pictureBoxStar2);
            stars.Add(pictureBoxStar3);
            stars.Add(pictureBoxStar4);
            stars.Add(pictureBoxStar5);

            this.ActiveControl = labelTitle;

            _screnToGoback = screen;
            this.userId = userId;
            this.movieId = movieId;
            _specificMoviePresenter = new SpecificMovieInfoPresenter(this);
            _specificMoviePresenter.GetUserPosition();
            _specificMoviePresenter.GetInfoForMovie(movieId);
            _specificMoviePresenter.SetCommentsForTheMovie();
            spEventArgs = new SpecificMovieEventArgs() { movieId = this.movieId };
            this.InitializeMovieInfo();
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

        // the following code changes labels' colors according to the mouse movement
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

        // the following code changes stars to default when user's mouse leaves
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

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            _screnToGoback.ShowForm();
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

        private void buttonAddComment_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateSpecificMovie.isCommentOK(textBoxAddComment.Text);
                comments.Reverse();
                _specificMoviePresenter.AddCommentInDB(textBoxAddComment.Text);
                comments.Add(_specificMoviePresenter.GetLastComment());

                if (!commentIds.Contains(comments.Last().commentId))
                {
                    commentIds.Add(comments.Last().commentId);
                }
                else
                    throw new Exception();

                comments.Reverse();

                commentBoxAllComments.AddComment(comments.First());

                commentBoxMyComments.AddComment(comments.First());

                textBoxAddComment.Text = "";
            }
            catch (Exception)
            {
                MessageBox.Show("You have inserted too many comments!\n" +
                                "This is considered as spam! Current window will be closed.\n" +
                                "You should open the window again",
                                "Spam", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                _screnToGoback.ShowForm();
            }

            this.ActiveControl = labelTitle;
        }

        private void buttonAddToWatchlist_Click(object sender, EventArgs e)
        {
            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 0;
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 100;
            buttonRemoveFWatchlist.Visible = true;
            buttonAddToWatchlist.Visible = false;
            buttonRemoveFWatchlist.Height = buttonAddComment.Height;

            try
            {
                Validation.ValidateSpecificMovie.isThereAnythingToRemoveOrAddFromWatchList(this.movieId);
                buttonRemoveFWatchlist.Height = buttonAddComment.Height;

                Validation.ValidateSpecificMovie.isThereAnUser(this.userId);
                _specificMoviePresenter.AddMovieINWatchList();
                OnMovieAddedToWatchList(spEventArgs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonRemoveFWatchlist_Click(object sender, EventArgs e)
        {
            tableLayoutPanelWatchlistActions.RowStyles[1].Height = 0;
            tableLayoutPanelWatchlistActions.RowStyles[0].Height = 100;
            buttonAddToWatchlist.Visible = true;
            buttonRemoveFWatchlist.Visible = false;
            buttonAddToWatchlist.Height = buttonAddComment.Height;

            try
            {
                Validation.ValidateSpecificMovie.isThereAnythingToRemoveOrAddFromWatchList(this.movieId);
                OnMovieDeletedFromWatchList(spEventArgs);
                buttonAddToWatchlist.Height = buttonAddComment.Height;
                Validation.ValidateSpecificMovie.isThereAnUser(this.userId);
                _specificMoviePresenter.DeleteMovieFromWatchList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxAddComment_Click(object sender, EventArgs e)
        {
            if (commentFirstClick==true)
            {
                textBoxAddComment.Text = null;
            }
            commentFirstClick = false;
        }

        private void mov4eMovie_Load(object sender, EventArgs e)
        {

        }

        private void Rate_Click(object sender, EventArgs e)
        {
            PictureBox rate = (PictureBox)sender;
            try
            {
                Validation.ValidateSpecificMovie.isRateOk(int.Parse(rate.Tag.ToString()));
                _specificMoviePresenter.RateMovie(int.Parse(rate.Tag.ToString()));
                tableLayoutPanelStars.Visible = false;
                userRate = int.Parse(rate.Tag.ToString());
                labelAlreadyRated.Text += " " + userRate + "!";
                labelMovieAverageRating.Text = movieAVGRate.ToString();
                this.tableLayoutPanelRating.RowStyles[0].Height = 15;
                this.tableLayoutPanelRating.RowStyles[1].Height = 0;
                this.tableLayoutPanelRating.RowStyles[2].Height = 60;
                this.tableLayoutPanelRating.RowStyles[3].Height = 25;
                buttonChangeRating.Height = 35;
                labelAlreadyRated.Visible = true;
                MessageBox.Show("Thanks for rating this movie!","Rated",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void InitializeMovieInfo()
        {
            labelTitle.Text = movieTitle;
            pictureBoxMoviePicture.Image = (Bitmap)((new ImageConverter()).ConvertFrom(moviePicture));
            labelMovieGenre.Text = movieGenre;
            labelMovieDuration.Text = duration.ToString()+" mins";

            if (moviePG==null || moviePG==0)
            {
                labelMoviePG.Text = "-";
            }
            else
            labelMoviePG.Text = moviePG.ToString();

            labelMoviePremiereDate.Text = moviePrimeDate;
            labelMovieAverageRating.Text = movieAVGRate.ToString();

            if (movieSummary.Length>textBoxMovieSummary.Text.Length)
            {
                textBoxMovieSummary.ScrollBars = ScrollBars.Vertical;
            }
            textBoxMovieSummary.Text = movieSummary;

            // shows already rated panel 
            if (_specificMoviePresenter.UserAlreadyRated())
            {
                _specificMoviePresenter.SetUserRate();
                tableLayoutPanelStars.Visible = false;
                labelAlreadyRated.Text += " " + userRate + "!";
                this.tableLayoutPanelRating.RowStyles[0].Height = 15;
                this.tableLayoutPanelRating.RowStyles[1].Height = 0;
                this.tableLayoutPanelRating.RowStyles[2].Height = 60;
                this.tableLayoutPanelRating.RowStyles[3].Height = 25;
                buttonChangeRating.Height = 35;
                labelAlreadyRated.Visible = true;
            }
            // shows "remove from watchlist" and hides "add to watchlist"
            if (_specificMoviePresenter.UserHasMovieInWatchList())
            {
                tableLayoutPanelWatchlistActions.RowStyles[0].Height = 0;
                tableLayoutPanelWatchlistActions.RowStyles[1].Height = 100;
                buttonAddToWatchlist.Visible = false;
                buttonRemoveFWatchlist.Visible = true;
            }
            else
            {
                tableLayoutPanelWatchlistActions.RowStyles[0].Height = 100;
                tableLayoutPanelWatchlistActions.RowStyles[1].Height = 0;
                buttonAddToWatchlist.Visible = true;
                buttonRemoveFWatchlist.Visible = false;
            }

            this.IntializeComments();
            foreach (var el in comments)
            {
                commentIds.Add(el.commentId);
            }
        }

        private void initalizeMyComments()
        {
            commentBoxMyComments.enableCheckBoxes = true;
            commentBoxMyComments.currentUserName = _specificMoviePresenter.GetUserName();
            if (comments.Count > 0)
            {
                commentBoxMyComments.commentList = comments.Where(c => c.name == commentBoxMyComments.currentUserName).ToList();
                commentBoxMyComments.allComentsCounter = commentBoxMyComments.commentList.Count();
                commentBoxMyComments.SetComments(5);
            }
        }

        private void initializeAllComments()
        {
            if (userPosition == "admin")
            {
                commentBoxAllComments.enableCheckBoxes = true;
                buttonDelSelectFromAllComments.Enabled = true;
                buttonDelSelectFromAllComments.Visible = true;
            }
            commentBoxAllComments.currentUserName = _specificMoviePresenter.GetUserName();
            if (comments.Count > 0)
            {
                commentBoxAllComments.allComentsCounter = comments.Count;
                foreach (var el in comments)
                {
                    commentBoxAllComments.commentList.Add(el);
                }

                commentBoxAllComments.SetComments(5);
            }
        }

        private void IntializeComments()
        {
            this.initalizeMyComments();
            this.initializeAllComments();
        }

        public void deleteCommentsFromDB(List<int> comms)
        {
            try
            {
            foreach (int el in comms)
            {
                (int commentId, string name, byte[] picture, string comment) p = comments.Where(c => c.commentId == el).Single();
                this.comments.Remove(p);
            }
            _specificMoviePresenter.DeleteComments(comms);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void deleteCommentsFromCommentBoxes(CommentBox one, CommentBox two)
        {
            try
            {
                DialogResult d = MessageBox.Show("Are you sure want to delete this/these comment/s?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    two.AddCommentsForDeleteInList();
                    ValidateSpecificMovie.isThereCommentToRemove(two.checkedCommentsList);
                    this.deleteCommentsFromDB(two.checkedCommentsList);

                    two.DeleteCommentsFromControl();
                    two.checkedCommentsList.Clear();

                    if (two == commentBoxAllComments)
                    {
                        commentBoxMyComments.Reset();
                        initalizeMyComments();
                    }
                    else
                    {
                        commentBoxAllComments.Reset();
                        initializeAllComments();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxAddComment_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBoxAddComment.Text) && !string.IsNullOrWhiteSpace(textBoxAddComment.Text)))
            {
                buttonAddComment.Enabled = true;
            }
            else
                buttonAddComment.Enabled = false;

            foreach (string line in textBoxAddComment.Lines)
            {
                if (line.Length >= 90)
                {
                    textBoxAddComment.Undo();
                }
            }

            textBoxAddComment.ClearUndo();

            charactersCount=textBoxAddComment.Text.Length;
            labelCharactersLeft.Text = charactersCount + "/" + maxCharacters;
        }

        private void buttonDelSelectFromAllComments_Click(object sender, EventArgs e)
        {
            this.deleteCommentsFromCommentBoxes(commentBoxMyComments, commentBoxAllComments);
        }

        private void buttonDelAllMyComments_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult d = MessageBox.Show("Are you sure want to delete all comments?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (d == DialogResult.OK)
                {
                    commentBoxAllComments.AddAllCommentsForDelete();
                    commentBoxMyComments.AddAllCommentsForDelete();
                    this.deleteCommentsFromDB(commentBoxMyComments.checkedCommentsList);
                    commentBoxAllComments.DeleteCommentsFromControl();
                    commentBoxMyComments.DeleteCommentsFromControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void buttonDelSelectComments_Click(object sender, EventArgs e)
        {
            this.deleteCommentsFromCommentBoxes(commentBoxAllComments, commentBoxMyComments);
        }

        public void ShowForm()
        {
            this.Show();
        }

        private void buttonChangeRating_Click(object sender, EventArgs e)
        {

            DialogResult d = MessageBox.Show("Your current rate will be deleted after pressing OK!\nAre you sure you want to continue?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (d==DialogResult.OK)
            {
                tableLayoutPanelRating.RowStyles[1].Height = 66;
                tableLayoutPanelRating.RowStyles[2].Height = 0;
                this.tableLayoutPanelRating.RowStyles[3].Height = 0;
                tableLayoutPanelStars.Visible = true;
                labelAlreadyRated.Visible = false;
                _specificMoviePresenter.DeleteRate();
                labelAlreadyRated.Text = "You have already rated for this movie! Your rating: ";
                labelMovieAverageRating.Text = movieAVGRate.ToString();
            }           
        }
    }
}