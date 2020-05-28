namespace Mov4e.View.AllMoviesView
{
    partial class mov4eAllMovies
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // mov4eAllMovies
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "mov4eAllMovies";
            this.Load += new System.EventHandler(this.mov4eAllMovies_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topButtonsLayoutPanel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label minimizeLabel;
        private System.Windows.Forms.Label maximizeLabel;
        private System.Windows.Forms.ListView listViewMovies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovies;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelActionsWMovie;
        private System.Windows.Forms.Button buttonViewInfo;
        private System.Windows.Forms.Button buttonAddMovie;
        private System.Windows.Forms.Button buttonDeleteMovie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMoviesMenu;
        private System.Windows.Forms.PictureBox pictureBoxSearchIcon;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.PictureBox pictureBoxFilter;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.Button buttonStartSearch;
        private System.Windows.Forms.PictureBox pictureBoxSort;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSortFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFilter;
        private System.Windows.Forms.Label labelFilterPG;
        private System.Windows.Forms.Label labelFilterDuration;
        private System.Windows.Forms.Label labelFilterGenre;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonClearFilters;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSort;
        private System.Windows.Forms.Button buttonSortOld;
        private System.Windows.Forms.Button buttonSortNew;
        private System.Windows.Forms.Button buttonSortZA;
        private System.Windows.Forms.Label labelSortTitle;
        private System.Windows.Forms.Label labelSortDate;
        private System.Windows.Forms.Button buttonSortAZ;
        private System.Windows.Forms.Button buttonEditMovie;
        private System.Windows.Forms.ImageList imageListMovies;
        private System.Windows.Forms.GroupBox groupBoxGenreFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelFGenre;
        private System.Windows.Forms.RadioButton radioButtonFantasy;
        private System.Windows.Forms.RadioButton radioButtonComedy;
        private System.Windows.Forms.RadioButton radioButtonDrama;
        private System.Windows.Forms.RadioButton radioButtonAdventure;
        private System.Windows.Forms.RadioButton radioButtonRomance;
        private System.Windows.Forms.RadioButton radioButtonSeries;
        private System.Windows.Forms.RadioButton radioButtonHistorical;
        private System.Windows.Forms.RadioButton radioButtonAction;
        private System.Windows.Forms.RadioButton radioButtonBiographical;
        private System.Windows.Forms.RadioButton radioButtonScifi;
        private System.Windows.Forms.RadioButton radioButtonThriller;
        private System.Windows.Forms.RadioButton radioButtonSoapOpera;
        private System.Windows.Forms.RadioButton radioButtonHorror;
        private System.Windows.Forms.GroupBox groupBoxDurationFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.RadioButton radioButtonMoreT3;
        private System.Windows.Forms.RadioButton radioButtonBetween2A3;
        private System.Windows.Forms.RadioButton radioButtonBetween1A2;
        private System.Windows.Forms.RadioButton radioButtonLessT1Hour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.RadioButton radioButtonPG18;
        private System.Windows.Forms.RadioButton radioButtonPG16;
        private System.Windows.Forms.RadioButton radioButtonPG14;
        private System.Windows.Forms.RadioButton radioButtonPG12;
        private System.Windows.Forms.RadioButton radioButtonNoPG;
    }
}