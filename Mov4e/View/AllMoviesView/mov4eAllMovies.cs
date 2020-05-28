using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.View;
using Mov4e.Validation;
using Mov4e.Presenter.AllMoviesPresenter;
using Mov4e.Exceptions;
using Mov4e.View.ProfileScreenView;
using Mov4e.View.SpecificMovieInfoView;
using System.Globalization;
using Mov4e.View.NewMovieView;

namespace Mov4e.View.AllMoviesView
{
    /// <summary>
    /// The <c>AllMoviesForm</c> class is a view class that communicates with the <c>AllMoviesPresenter</c> class.
    /// </summary>
    /// <inheritdoc cref="Form"/>
    /// <inheritdoc cref="IAllMovies"/>
    public partial class mov4eAllMovies : Form, IScreenView, IAllMovies
    {
        // A private variable that keeps a reference to AllMoviesPresenter via an interface variable.
        private IAllMoviesPresenter all_movies_presenter = new AllMoviesPresenter();

        // A private variable that keeps a reference to a list with movies' ids.
        private List<int> id = new List<int>();

        // A private variable used for saving an user's id.  
        private int user_id = 0;

        // A private variable used for saving an user's position.
        private string user_position = "";

        // Dictinary of int(ids of all movies from the database) and byte[](wrappers of the all movies from the database).
        private Dictionary<int, byte[]> mov;

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

        private void buttonEditMovie_Click(object sender, EventArgs e)
        {
            EditMovie();
        }

        private void buttonDeleteMovie_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonStartSearch_Click(object sender, EventArgs e)
        {
            SearchMovie();
        }

        private void buttonSortNew_Click(object sender, EventArgs e)
        {
            SortByDate();
        }

        private void buttonSortAZ_Click(object sender, EventArgs e)
        {
            SortByTitle();
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            List<int> filters = CheckSelectdFilters();
            int g = filters[0];
            int d = filters[1];
            int pg = filters[2];

            if ((checkBoxFantasy.Checked || checkBoxThriller.Checked || checkBoxAction.Checked || checkBoxRomance.Checked || checkBoxDrama.Checked || checkBoxHorror.Checked
                || checkBoxSciFi.Checked || checkBoxHistorical.Checked || checkBoxAdventure.Checked || checkBoxComedy.Checked || checkBoxSoapOpera.Checked || checkBoxBiographical.Checked
                || checkBoxSeries.Checked) && (checkBoxLessT1.Checked || checkBoxBetween12.Checked || checkBoxBetween23.Checked || checkBoxMoreT3.Checked) &&
                (checkBoxNoPG.Checked || checkBox12Y.Checked || checkBox14Y.Checked || checkBox16Y.Checked || checkBox18Y.Checked))
            {
                // Filters the movies by genre, duration and parental guidance.
                FilterMovies(g, d, pg);
            }
            else if ((checkBoxFantasy.Checked || checkBoxThriller.Checked || checkBoxAction.Checked || checkBoxRomance.Checked || checkBoxDrama.Checked || checkBoxHorror.Checked || checkBoxSciFi.Checked
                 || checkBoxHistorical.Checked || checkBoxAdventure.Checked || checkBoxComedy.Checked || checkBoxSoapOpera.Checked || checkBoxBiographical.Checked || checkBoxSeries.Checked)
                 && (checkBoxLessT1.Checked || checkBoxBetween12.Checked || checkBoxBetween23.Checked || checkBoxMoreT3.Checked) && (checkBoxNoPG.Checked == false && checkBox12Y.Checked
                 == false && checkBox14Y.Checked == false && checkBox16Y.Checked == false && checkBox18Y.Checked == false))
            {
                // Filters the movies by genre and duration.
                FilterMoviesByGenresAndDuration(g, d);
            }
            else if ((checkBoxFantasy.Checked || checkBoxThriller.Checked || checkBoxAction.Checked || checkBoxRomance.Checked || checkBoxDrama.Checked || checkBoxHorror.Checked
                 || checkBoxSciFi.Checked || checkBoxHistorical.Checked || checkBoxAdventure.Checked || checkBoxComedy.Checked || checkBoxSoapOpera.Checked || checkBoxBiographical.Checked
                 || checkBoxSeries.Checked) && (checkBoxLessT1.Checked == false && checkBoxBetween12.Checked == false && checkBoxBetween23.Checked == false
                 && checkBoxMoreT3.Checked == false) && (checkBoxNoPG.Checked || checkBox12Y.Checked || checkBox14Y.Checked ||
                 checkBox16Y.Checked || checkBox18Y.Checked))
            {
                // Filters the movies by genre and parental guidance.
                FilterMoviesByGenresAndPG(g, pg);
            }
            else if ((checkBoxFantasy.Checked == false && checkBoxThriller.Checked == false && checkBoxAction.Checked == false && checkBoxRomance.Checked == false
                 && checkBoxDrama.Checked == false && checkBoxHorror.Checked == false && checkBoxSciFi.Checked == false && checkBoxHistorical.Checked == false
                 && checkBoxAdventure.Checked == false && checkBoxComedy.Checked == false && checkBoxSoapOpera.Checked == false && checkBoxBiographical.Checked == false
                 && checkBoxSeries.Checked == false) && (checkBoxLessT1.Checked || checkBoxBetween12.Checked || checkBoxBetween23.Checked || checkBoxMoreT3.Checked) &&
                 (checkBoxNoPG.Checked == false && checkBox12Y.Checked == false && checkBox14Y.Checked == false
                 && checkBox16Y.Checked == false && checkBox18Y.Checked == false))
            {
                // Filters the movies by duration.
                FilterMoviesByDuration(d);
            }
            else if ((checkBoxFantasy.Checked || checkBoxThriller.Checked || checkBoxAction.Checked || checkBoxRomance.Checked || checkBoxDrama.Checked || checkBoxHorror.Checked
                || checkBoxSciFi.Checked || checkBoxHistorical.Checked || checkBoxAdventure.Checked || checkBoxComedy.Checked || checkBoxSoapOpera.Checked || checkBoxBiographical.Checked
                || checkBoxSeries.Checked) && (checkBoxLessT1.Checked == false && checkBoxBetween12.Checked == false && checkBoxBetween23.Checked == false
                && checkBoxMoreT3.Checked == false) && (checkBoxNoPG.Checked == false && checkBox12Y.Checked == false
                && checkBox14Y.Checked == false && checkBox16Y.Checked == false && checkBox18Y.Checked == false))
            {
                // Filters the movies by genre.
                FilterMoviesByGenres(g);
            }
            else if ((checkBoxFantasy.Checked == false && checkBoxThriller.Checked == false && checkBoxAction.Checked == false && checkBoxRomance.Checked == false
                && checkBoxDrama.Checked == false && checkBoxHorror.Checked == false && checkBoxSciFi.Checked == false && checkBoxHistorical.Checked == false
                && checkBoxAdventure.Checked == false && checkBoxComedy.Checked == false && checkBoxSoapOpera.Checked == false && checkBoxBiographical.Checked == false
                && checkBoxSeries.Checked == false) && (checkBoxLessT1.Checked == false && checkBoxBetween12.Checked == false && checkBoxBetween23.Checked == false
                && checkBoxMoreT3.Checked == false) && (checkBoxNoPG.Checked || checkBox12Y.Checked || checkBox14Y.Checked || checkBox16Y.Checked || checkBox18Y.Checked))
            {
                // Filters the movies by parental guidance.
                FilterMoviesByPG(pg);
            }
            else if ((checkBoxFantasy.Checked == false && checkBoxThriller.Checked == false && checkBoxAction.Checked == false && checkBoxRomance.Checked == false
                && checkBoxDrama.Checked == false && checkBoxHorror.Checked == false && checkBoxSciFi.Checked == false && checkBoxHistorical.Checked == false
                && checkBoxAdventure.Checked == false && checkBoxComedy.Checked == false && checkBoxSoapOpera.Checked == false && checkBoxBiographical.Checked == false
                && checkBoxSeries.Checked == false) && (checkBoxLessT1.Checked || checkBoxBetween12.Checked || checkBoxBetween23.Checked || checkBoxMoreT3.Checked) &&
                (checkBoxNoPG.Checked || checkBox12Y.Checked || checkBox14Y.Checked || checkBox16Y.Checked || checkBox18Y.Checked))
            {
                // Filters the movies by duration and parental guidance.
                FilterMoviesByDurationAndPG(d, pg);
            }
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            listViewMovies.Items.Clear();
            Dictionary<int, byte[]> moviesList = all_movies_presenter.SetMovieInformation();
            InitializeMoviesList(moviesList);

            checkBoxFantasy.Checked = false;
            checkBoxThriller.Checked = false;
            checkBoxAction.Checked = false;
            checkBoxRomance.Checked = false;
            checkBoxDrama.Checked = false;
            checkBoxHorror.Checked = false;
            checkBoxSciFi.Checked = false;
            checkBoxHistorical.Checked = false;
            checkBoxAdventure.Checked = false;
            checkBoxComedy.Checked = false;
            checkBoxSoapOpera.Checked = false;
            checkBoxBiographical.Checked = false;
            checkBoxSeries.Checked = false;

            checkBoxLessT1.Checked = false;
            checkBoxBetween12.Checked = false;
            checkBoxBetween12.Checked = false;
            checkBoxMoreT3.Checked = false;

            checkBoxNoPG.Checked = false;
            checkBox12Y.Checked = false;
            checkBox14Y.Checked = false;
            checkBox16Y.Checked = false;
            checkBox18Y.Checked = false;
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSearch.Focused == true && !string.IsNullOrEmpty(textBoxSearch.Text) && !string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                pictureBoxSearchIcon.Image = Mov4e.Properties.Resources.search_blue;
            }
            else
                pictureBoxSearchIcon.Image = Mov4e.Properties.Resources.search_white;
        }

        private void listViewMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMovies.SelectedItems.Count == 0)
            {
                buttonViewInfo.Enabled = false;
                buttonDeleteMovie.Enabled = false;
                buttonEditMovie.Enabled = false;
            }
            else
            {
                buttonViewInfo.Enabled = true;
                buttonDeleteMovie.Enabled = true;
                buttonEditMovie.Enabled = true;
            }
        }

        private void buttonDeleteMovie_Click(object sender, EventArgs e)
        {
            DeleteMovie();
        }

        private void tableLayoutPanelMovies_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonSortZA_Click(object sender, EventArgs e)
        {
            Dictionary<int, byte[]> movies = all_movies_presenter.SortMoviesByTitle();
            Dictionary<int, byte[]> reversedMovies = new Dictionary<int, byte[]>();
            var reverse = movies.Reverse();
            foreach (var item in reverse)
            {
                reversedMovies.Add(item.Key, item.Value);
            }
            listViewMovies.Items.Clear();
            InitializeMoviesList(reversedMovies);
        }

        private void buttonSortOld_Click(object sender, EventArgs e)
        {
            Dictionary<int, byte[]> mov = all_movies_presenter.SortByDate();
            listViewMovies.Items.Clear();
            InitializeMoviesList(mov);
        }

        bool sortOpened;
        bool filterOpened;

        /// <summary>
        /// A three arguments constructor for the <c>AllMoviesForm</c> class.
        /// </summary>
        /// <param name="mov">This is the list of movies from the database.</param>
        /// <param name="uid">This is the user's id.</param>
        /// <param name="upos">This is the user's position.</param>
        public mov4eAllMovies(int uid, string upos)
        {
            InitializeComponent();
            this.tableLayoutPanelMovies.RowStyles[1].Height = 0;
            this.tableLayoutPanelMovies.RowStyles[2].Height = 80;
            listViewMovies.Height = 570;
            sortOpened = false;
            filterOpened = false;

            user_id = uid;
            user_position = upos;
            mov = all_movies_presenter.SetMovieInformation();
            var autoComlete = new AutoCompleteStringCollection();
            List<string> strs = new List<string>();
            strs = all_movies_presenter.GetMovieTitles();
            autoComlete.AddRange(strs.ToArray());

            listViewMovies.Items.Clear();
            textBoxSearch.AutoCompleteCustomSource = autoComlete;

            try
            {
                if (user_position == "admin")
                {
                    SetUpAdminProfile(uid, upos, mov);

                }
                else
                {

                    if (user_position == "normal")
                    {
                        SetUpNormalProfile(uid, upos, mov);
                    }
                    else
                    {
                        MessageBox.Show("In the application sprang up an error! " +
                            "Please, check errors.txt file for more information!",
                            "User Position Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        this.Close();
                        throw new NoSuchUserPositionException();
                    }
                }
            }
            catch (NoSuchUserPositionException ex)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                    + " There is no person on this kind of position" + "\n"
                    + ex.ToString());
            }
        }

        public mov4eAllMovies(IAllMoviesPresenter mp)
        {
            this.all_movies_presenter = mp;
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

        private void pictureBoxProfile_Click(object sender, EventArgs e)
        {
            mov4eProfile _profileScreen = new mov4eProfile(this.user_id, this);
            //this.close trqbwa da e ppc
            this.Hide();
            _profileScreen.ShowDialog();
        }

        private void buttonAddMovie_Click(object sender, EventArgs e)
        {
            mov4eAddMovie _newMovie = new mov4eAddMovie(this);
            this.Hide();
            _newMovie.ShowDialog();
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
            GetMovie();          
        }     

        private void mov4eAllMovies_Load(object sender, EventArgs e)
        {

        }

        // This method makes initial settings for the administrator profile.
        private void SetUpAdminProfile(int uid, string upos, Dictionary<int, byte[]> mov)
        {
            buttonAddMovie.Visible = true;
            buttonDeleteMovie.Visible = true;
            buttonEditMovie.Visible =true;
            buttonAddMovie.Enabled = true;
            buttonDeleteMovie.Enabled = true;
            buttonEditMovie.Enabled = true;

            try
            {
                if (mov.Count > 0)
                {
                    InitializeMoviesList(mov);

                }
                else
                {
                    if (mov.Count == 0)
                    {
                        MessageBox.Show("There are no movies to be shown!", "Show Movies Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("There are no movies to be shown! Something went wrong! " +
                            "Please, check errors.txt file for more information!", "Show Movies Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        throw new InvalidItemsNumberException();
                    }
                }
            }
            catch (InvalidItemsNumberException ex)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                    + " The number of the movies is less than zero!" + "\n"
                    + ex.ToString() + "\n");
            }
        }

        // This methods makes initial settings for a normal profile.
        private void SetUpNormalProfile(int uid, string upos, Dictionary<int, byte[]> mov)
        {
            try
            {
                if (mov.Count > 0)
                {
                    InitializeMoviesList(mov);
                    buttonAddMovie.Visible = false;
                    buttonDeleteMovie.Visible = false;
                    buttonEditMovie.Visible = false;
                    buttonAddMovie.Enabled = false;
                    buttonDeleteMovie.Enabled = false;
                    buttonEditMovie.Enabled = false;
                }
                else
                {
                    if (mov.Count == 0)
                    {
                        MessageBox.Show("There are no movies to be shown!", "Show Movies Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("There are no movies to be shown! Something went wrong! " +
                            "Please, check errors.txt file for more information!", "Show Movies Information",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        throw new InvalidItemsNumberException();
                    }
                }
            }
            catch (InvalidItemsNumberException ex)
            {
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                    + " The number of the movies is less than zero!" + "\n"
                    + ex.ToString() + "\n");
            }
        }

        // This method checks whether any filter is checked and set values for the genre, 
        //duration and parental guidance filters.
        private List<int> CheckSelectdFilters()
        {
            int d = 0;
            int pg = 0;
            int g = 0;

            if (checkBoxFantasy.Checked)
            {
                g = 1;
            }
            else if (checkBoxThriller.Checked)
            {
                g = 2;
            }
            else if (checkBoxAction.Checked)
            {
                g = 3;
            }
            else if (checkBoxRomance.Checked)
            {
                g = 4;
            }
            else if (checkBoxDrama.Checked)
            {
                g = 5;
            }
            else if (checkBoxHorror.Checked)
            {
                g = 6;
            }
            else if (checkBoxSciFi.Checked)
            {
                g = 7;
            }
            else if (checkBoxHistorical.Checked)
            {
                g = 8;
            }
            else if (checkBoxAdventure.Checked)
            {
                g = 9;
            }
            else if (checkBoxComedy.Checked)
            {
                g = 10;
            }
            else if (checkBoxSoapOpera.Checked)
            {
                g = 11;
            }
            else if (checkBoxBiographical.Checked)
            {
                g = 12;
            }
            else if (checkBoxSeries.Checked)
            {
                g = 13;
            }

            if (checkBoxLessT1.Checked)
            {
                d = 1;
            }
            else if (checkBoxBetween12.Checked)
            {
                d = 2;
            }
            else if (checkBoxBetween23.Checked)
            {
                d = 3;
            }
            else if (checkBoxMoreT3.Checked)
            {
                d = 4;
            }

            if (checkBoxNoPG.Checked)
            {
                pg = 0;
            }
            else if (checkBox12Y.Checked)
            {
                pg = 12;
            }
            else if (checkBox14Y.Checked)
            {
                pg = 14;
            }
            else if (checkBox16Y.Checked)
            {
                pg = 16;
            }
            else if (checkBox18Y.Checked)
            {
                pg = 18;
            }

            return new List<int> { g, d, pg };
        }

        /// <summary>
        /// This is a property of the searchbox.
        /// </summary>
        /// <value>This property sets/gets string values for the searchbox.</value>
        public string Search
        {
            get => textBoxSearch.Text;
            set => textBoxSearch.Text = value;
        }

        /// <summary>
        /// The <c>GetMovie()</c> method fills the <c>MovieInformation</c> form with data for a certain movie.
        /// </summary>
        /// <exception cref="Mov4e.Exceptions.InvalidItemsSelectionException">Thrown when the count of the 
        /// secected items is invalid (less than zero).</exception>
        /// <exception cref="System.Exception">Throw when something else in the application becomes broken.</exception>
        /// <remarks>When some of the exceptions is thrown this methods writes the error 
        /// in the errors.txt file.</remarks>
        public void GetMovie()
        {
            try
            {
                if (listViewMovies.SelectedItems.Count > 0)
                {
                    for (int lcount = 0; lcount < listViewMovies.Items.Count; lcount++)
                    {
                        if (listViewMovies.Items[lcount].Selected == true)
                        {
                            int var2 = lcount;
                            Dictionary<int, byte[]> m = all_movies_presenter.GetMoviesByTitle(new List<string> { listViewMovies.Items[lcount].Text });
                            int p = 0;
                            foreach (var item in m)
                            {
                                p = item.Key;
                            }
                            mov4eMovie mi = new mov4eMovie(p, this.user_id, this);
                            this.Hide();
                            mi.ShowDialog();                           
                            break;
                        }
                    }
                }
                else
                {
                    if (listViewMovies.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("Before you try to view movie's information, you should select at least one of them!",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Before you try to view movie's information, you should select a valid movie!",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                            + " You don't select a movie to view information about!" + "\n"
                            + new InvalidItemsSelectionException().ToString());
                        throw new InvalidItemsSelectionException();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There sprang up an error! Please, check errors.txt file for more information!",
                    "Get Movie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                            + " GET MOVIE ERROR:" + "\n" + ex.ToString());
            }
        }



        /// <summary>
        /// The <c>DeleteMovie()</c> method asks the user whether they want to delete this movie. If the answer is yes 
        /// and the id of the selected movie is valid, the application executes the presentér's method, which executes 
        /// the service's method, which executes the repository's method, responsible of deleting a certain movie.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when something in the application went wrong.</exception>
        /// <remarks>When the exception is thrown this method writes the error in the errors.txt file.</remarks>
        public void DeleteMovie()
        {
            DialogResult res = MessageBox.Show("Are you sure you want to delete this movie?",
                "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.Yes)
            {
                try
                {
                    if (listViewMovies.SelectedItems.Count > 0)
                    {
                        for (int lcount = 0; lcount <= listViewMovies.Items.Count - 1; lcount++)
                        {
                            if (listViewMovies.Items[lcount].Selected == true)
                            {
                                int var2 = lcount;
                                Dictionary<int, byte[]> m = all_movies_presenter.GetMoviesByTitle(new List<string> { listViewMovies.Items[lcount].Text });
                                int p = 0;
                                foreach (var item in m)
                                {
                                    p = item.Key;
                                }
                                all_movies_presenter.DeleteMovie(p);
                                MessageBox.Show("Movie: " + listViewMovies.Items[var2].Text + " was successfully deleted!");
                                break;
                            }
                        }
                    }

                    listViewMovies.Items.Clear();
                    Dictionary<int, byte[]> moviesList = all_movies_presenter.SetMovieInformation();
                    InitializeMoviesList(moviesList);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("In the application sprang up an error! Please, check errors.txt file for more information!",
                   "Delete Movie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                                + " DELETE MOVIE ERROR:" + "\n" + ex.ToString());
                }
            }
        }

        /// <summary>
        /// The <c>InitializeMoviesList()</c> method receives information from 
        /// the presenter and fills the listview in the form. 
        /// </summary>
        public void InitializeMoviesList(Dictionary<int, byte[]> movs)
        {

            if (movs != null)
            {
                foreach (var pair in movs)
                {
                    imageListMovies.Images.Add(pair.Key.ToString(), ((Bitmap)((new ImageConverter()).ConvertFrom(pair.Value))));
                    ListViewItem item = new ListViewItem(all_movies_presenter.SetMovieTitle(pair.Key));
                    item.ImageKey = pair.Key.ToString();
                    listViewMovies.Items.Add(item);
                    listViewMovies.Tag = pair.Key;
                    id.Add(pair.Key);
                }
                listViewMovies.LargeImageList = imageListMovies;
            }
            else
            {
                //exception
            }
        }

        /// <summary>
        /// The <c>SearchMovie()</c> method receives all movies' titles as a list from the presenter and compares each 
        /// title from the presenter's list with the text in the searchbox. If any title from the list is equal to or
        /// contains the searchbox's text, this movie's title is added to another list of titles which later are send to
        /// the presenter, to the service and finally to the repository in order to return these movies as dictionary of 
        /// ids and wrapper of certain movies.
        /// </summary>
        public void SearchMovie()
        {
            List<string> words = all_movies_presenter.GetMovieTitles();
            List<string> movies = new List<string>();
            CultureInfo culture = new CultureInfo("es-ES", false);
            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Equals(textBoxSearch.Text, StringComparison.InvariantCultureIgnoreCase)
                    || culture.CompareInfo.IndexOf(words[i], textBoxSearch.Text, CompareOptions.IgnoreCase) >= 0)
                {
                    movies.Add(words[i]);
                }
            }

            listViewMovies.Clear();
            Dictionary<int, byte[]> moviesList = all_movies_presenter.GetMoviesByTitle(movies);
            InitializeMoviesList(moviesList);

            if (moviesList.Count == 0)
            {
                MessageBox.Show("Hmm...You may have something different in mind?", "Not Found Movie",
                MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        /// <summary>
        /// The <c>SortByTitle()</c> method is the sorting by ttle view's method.
        /// </summary>
        public void SortByTitle()
        {
            Dictionary<int, byte[]> mov = all_movies_presenter.SortMoviesByTitle();
            listViewMovies.Items.Clear();
            InitializeMoviesList(mov);
        }

        /// <summary>
        /// The <c>SortByDate()</c> method is the sorting by primier date view's method.
        /// </summary>
        public void SortByDate()
        {
            Dictionary<int, byte[]> movies = all_movies_presenter.SortByDate();
            Dictionary<int, byte[]> reversedMovies = new Dictionary<int, byte[]>();
            var reverse = movies.Reverse();
            foreach (var item in reverse)
            {
                reversedMovies.Add(item.Key, item.Value);
            }
            listViewMovies.Items.Clear();
            InitializeMoviesList(reversedMovies);
        }

        /// <summary>
        /// The <c>FilterMovies()</c> method is the filtering by genre, duration and parental guidance view's method.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidnce - one of the filtering params.</param>
        public void FilterMovies(int g, int d, int pg)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                g = filters[0];
                d = filters[1];
                pg = filters[2];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = FilteringValidation.ValidateFilterMovies(g, d, pg);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByGenresAndDuration()</c> method is the filtering by genre and duration view's method.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        public void FilterMoviesByGenresAndDuration(int g, int d)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                g = filters[0];
                d = filters[1];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByGenresAndDuration(g, d);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByGenresAndPG()</c> method is the filtering by genre and parental guidance view's method.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidnce - one of the filtering params.</param>
        public void FilterMoviesByGenresAndPG(int g, int pg)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                g = filters[0];
                pg = filters[2];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByGenresAndPG(g, pg);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByDurationAndPG()</c> method is the filtering 
        /// by duration and parental guidance view's method.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        /// <param name="pg">This is the parental guidnce - one of the filtering params.</param>
        public void FilterMoviesByDurationAndPG(int d, int pg)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                d = filters[1];
                pg = filters[2];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByDurationAndPG(d, pg);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByGenres()</c> method is the filtering by genre view's method.
        /// </summary>
        /// <param name="g">This is the genre - one of the filtering params.</param>
        public void FilterMoviesByGenres(int g)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                g = filters[0];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByGenres(g);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByDuration()</c> method is the filtering by duration view's method.
        /// </summary>
        /// <param name="d">This is the duration - one of the filtering params.</param>
        public void FilterMoviesByDuration(int d)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                d = filters[1];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByDuration(d);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>FilterMoviesByPG()</c> method is the filtering by parental guidance view's method.
        /// </summary>
        /// <param name="pg">This is the parental guidnce - one of the filtering params.</param>
        public void FilterMoviesByPG(int pg)
        {
            try
            {
                List<int> filters = CheckSelectdFilters();
                pg = filters[2];

                listViewMovies.Items.Clear();
                Dictionary<int, byte[]> movies = all_movies_presenter.FilterMoviesByPG(pg);
                InitializeMoviesList(movies);
            }
            catch (InvalidFilteringParamsException ex)
            {
                MessageBox.Show("Please select any filter before start filtering the movies!",
                    "Filtering Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Logger.Logger.WriteToLogFile(DateTime.Now + ex.ToString());
            }
        }

        void IScreenView.ShowForm()
        {
            this.Show();
        }

        private void AllMoviesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LoggedForOneTime = false;
            Properties.Settings.Default.Save();
        }

        public void UpdateMovies(int movieId, byte[] moviePic)
        {
            mov.Add(movieId, moviePic);

            if (listViewMovies.Items.Count < mov.Count)
            {
                imageListMovies.Images.Add(mov.Last().Key.ToString(), ((Bitmap)((new ImageConverter()).ConvertFrom(mov.Last().Value))));
                ListViewItem item = new ListViewItem(all_movies_presenter.SetMovieTitle(mov.Last().Key));
                item.ImageKey = mov.Last().Key.ToString();
                listViewMovies.Items.Add(item);
                listViewMovies.Tag = mov.Last().Key;
                id.Add(mov.Last().Key);
            }
        }

        /// <summary>
        /// The <c>EditMovie()</c> method sends the data from the form to the presenter if it is valid.
        /// </summary>
        /// <exception cref="System.Exception">Thrown when something fails in the application.</exception>
        /// <remarks>When the exception is thrown this method writes the error in the errors.txt file.</remarks>
        public void EditMovie()
        {
            this.Hide();
            try
            {
                if (listViewMovies.SelectedItems.Count > 0)
                {
                    for (int lcount = 0; lcount <= listViewMovies.Items.Count - 1; lcount++)
                    {
                        if (listViewMovies.Items[lcount].Selected == true)
                        {
                            int var2 = lcount;
                            Dictionary<int, byte[]> m = all_movies_presenter.GetMoviesByTitle(new List<string> { listViewMovies.Items[lcount].Text });
                            int p = 0;
                            foreach (var item in m)
                            {
                                p = item.Key;
                            }
                            mov4eAddMovie me = new mov4eAddMovie(all_movies_presenter.GetMovie(p).Item1.id, this);
                            me.ShowDialog();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("In the application sprang up an error! Please, check errors.txt file for more information!",
                   "Edit Movie Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Logger.WriteToLogFile(DateTime.Now.ToString()
                            + " EDIT MOVIE ERROR:" + "\n" + ex.ToString());
            }
        }

        /// <summary>
        /// The <c>ErrorMessage()</c> method is an overrided method from the <c>IScreenView</c> interface class, 
        /// which shows in a message box an occured error.
        /// </summary>
        /// <param name="msg">This string param is the messge which will be shown in a message box when something in the application go worng.</param>
        public void ErrorMassage(string msg)
        {
            MessageBox.Show(msg,"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
