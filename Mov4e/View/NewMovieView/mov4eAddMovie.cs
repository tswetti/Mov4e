using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.View.AllMoviesView;
using Mov4e.Presenter.AllMoviesPresenter;
using Mov4e.Presenter.NewMoviePresenter;
using Mov4e.Validation;
using Mov4e.Model;


namespace Mov4e.View.NewMovieView
{
    /// <summary>
    /// The <c>NewMovieFrm</c> class is a view class that communicates with the <c>NewMoviePresenter</c> class.
    /// </summary>
    /// <inheritdoc cref="Form"/>
    /// <inheritdoc cref="INewMovie"/>
    public partial class mov4eAddMovie : Form,INewMovie
    {
        // A private variable that keeps the filename of the wrapper of the movie.
        private string fileName = null;

        // A private variable that keeps a refernce to the NewMoviePresenter via an interface variable.
        private INewMoviePresenter mp;

        // A private variable that keeps a reference to the AllMoviesPresenter via an interface variable.
        private IAllMoviesPresenter amp;

        // A private variable that keeps a reference to the AllMoviesForm.
        private mov4eAllMovies allM;

        // A private variable that conserve a certain movie's id.
        private int id = 0;

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

        public mov4eAddMovie()
        {
            InitializeComponent();
            InitializeForm();
        }

        /// <summary>
        /// A one arguments constructor for the <c>NewMovieForm</c> class.
        /// </summary>
        /// <param name="allMovies">This is the AllMoviesForm argument.</param>
        public mov4eAddMovie(mov4eAllMovies allMovies)
        {
            this.allM = allMovies;
            InitializeComponent();
            this.allM.Visible = false;
            InitializeForm();
        }

        /// <summary>
        /// A two arguments constructor for the <c>NewMovieForm</c> class.
        /// </summary>
        /// <param name="movie_id">The id of the movie.</param>
        /// <param name="allMovies">The AllMoviesForm argument.</param>
        public mov4eAddMovie(int movie_id, mov4eAllMovies allMovies)
        {
            this.allM = allMovies;
            this.allM.Visible = false;
            InitializeComponent();
            InitializeForm();
            amp = new AllMoviesPresenter();
            Tuple<Movie, string> movie = amp.GetMovie(movie_id);
            textBoxName.Text = movie.Item1.title;
            labelMovieName.Text = movie.Item1.title;
            genreComboBox.SelectedValue = movie.Item1.genre;
            pgComboBox.SelectedValue = (int)movie.Item1.pg;
            datePickerPrDate.Text = movie.Item1.year.ToString();
            textBoxSummary.Text = movie.Item1.summary;
            pictureBoxMoviePic.Image = (Bitmap)((new ImageConverter()).ConvertFrom((byte[])movie.Item1.picture));
            textBoxDuration.Text = movie.Item1.duration.ToString();
            id = movie_id;
        }

        // This method converts image to byte[].
        private byte[] ConvertImageToBinary(Image img)
        {
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(img, typeof(byte[]));
            return xByte;
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

        private void pictureBoxBack_Click(object sender, EventArgs e)
        {
            this.Close();
            allM.Visible = true;
        }

        private void pictureBoxBack_MouseHover(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_blue;
        }

        private void pictureBoxBack_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxBack.Image = Mov4e.Properties.Resources.go_back_white;
        }

        private void buttonChangePic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog fd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    fileName = fd.FileName;
                    pictureBoxMoviePic.Image = Image.FromFile(fileName);
                }
            }
        }

        private void mov4eAddMovie_Load(object sender, EventArgs e)
        {

        }

        private void buttonSaveMovie_Click(object sender, EventArgs e)
        {
            mp = new NewMoviePresenter(this);
            if (id == 0)
            {
                addNewMovie();
            }
            else
            {
                updateMovie();
            }
        }

        // This method initializes the form.
        private void InitializeForm()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Fantasy");
            comboSource.Add(2, "Thriller");
            comboSource.Add(3, "Action");
            comboSource.Add(4, "Romance");
            comboSource.Add(5, "Drama");
            comboSource.Add(6, "Horror");
            comboSource.Add(7, "Sci-Fi");
            comboSource.Add(8, "Historical");
            comboSource.Add(9, "Adventurous");
            comboSource.Add(10, "Comedy");
            comboSource.Add(11, "Soap opera");
            comboSource.Add(12, "Biographical");
            comboSource.Add(13, "Series");
            genreComboBox.DataSource = new BindingSource(comboSource, null);
            genreComboBox.DisplayMember = "Value";
            genreComboBox.ValueMember = "Key";

            Dictionary<int, string> comboSource1 = new Dictionary<int, string>();
            comboSource1.Add(0, "-");
            comboSource1.Add(12, "12");
            comboSource1.Add(14, "14");
            comboSource1.Add(16, "16");
            comboSource1.Add(18, "18");
            pgComboBox.DataSource = new BindingSource(comboSource1, null);
            pgComboBox.DisplayMember = "Value";
            pgComboBox.ValueMember = "Key";
        }

        /// <summary>
        /// This is a property of the movie's title.
        /// </summary>
        /// <value>This property sets/gets string values for the title.</value>
        public string title
        {
            get => textBoxName.Text;
            set => textBoxName.Text = value;
        }

        /// <summary>
        /// This is a property of the movie's parental guidness.
        /// </summary>
        /// <value>This property sets/gets Nullable int values for the parental guidness.</value>
        public Nullable<int> pg
        {
            get => ((KeyValuePair<int, string>)pgComboBox.SelectedItem).Key;
            set => pgComboBox.SelectedItem = value;
        }

        /// <summary>
        /// This is a property of the movie's genre.
        /// </summary>
        /// <value>This property sets/gets int values for the genre.</value>
        public int genre
        {
            get => ((KeyValuePair<int, string>)genreComboBox.SelectedItem).Key;
            set => genreComboBox.SelectedItem = value;
        }

        /// <summary>
        /// This is a property of the movie's prime date.
        /// </summary>
        /// <value>This property sets/gets Nullable DateTime values for the wrapper.</value>
        public Nullable<System.DateTime> date
        {
            get => datePickerPrDate.Value;
            set => datePickerPrDate.Value = new DateTime();
        }

        /// <summary>
        /// This is a property of the movie's summary.
        /// </summary>
        /// <value>This property sets/gets string values for the summary.</value>
        public string summary
        {
            get => textBoxSummary.Text;
            set => textBoxSummary.Text = value;
        }

        /// <summary>
        /// This is a property of the movie's wrapper.
        /// </summary>
        /// <value>This property sets/gets byte[] values for the wrapper.</value>
        public byte[] picture
        {
            get => ConvertImageToBinary(pictureBoxMoviePic.Image);
            set => picture = ConvertImageToBinary(pictureBoxMoviePic.Image);
        }
        public int duration
        {
            get => int.Parse(textBoxDuration.Text);
            set => textBoxDuration.Text = value.ToString();
        }

        /// <summary>
        /// The <c>addNewMovie()</c> method executets the ValidateNewMovie() method of the <c>MovieVlidation</c> class.
        /// </summary>
        public void addNewMovie()
        {
            MovieValidation.ValidateNewMovie(title, genre, pg, date, summary, picture, duration);
            allM.UpdateMovies(mp.LastMovieId(), (byte[])(new ImageConverter()).ConvertTo(pictureBoxMoviePic.Image, typeof(byte[])));
        }

        /// <summary>
        /// The <c>updateMovie()</c> method executets the ValidateMovieUpdate() method of the <c>MovieVlidation</c> class.
        /// </summary>
        public void updateMovie()
        {
            MovieValidation.ValidateMovieUpdate(id, title, genre, pg, date, summary, picture, duration);
        }
    }
}
