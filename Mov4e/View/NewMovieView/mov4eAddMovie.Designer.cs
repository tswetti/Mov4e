namespace Mov4e.View.NewMovieView
{
    partial class mov4eAddMovie
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mov4eAddMovie));
            this.topButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.closeLabel = new System.Windows.Forms.Label();
            this.minimizeLabel = new System.Windows.Forms.Label();
            this.maximizeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMN = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMoviePicName = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxMoviePic = new System.Windows.Forms.PictureBox();
            this.labelMovieName = new System.Windows.Forms.Label();
            this.tableLayoutPanelMovie = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMovieDetails = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.buttonChangePic = new System.Windows.Forms.Button();
            this.textBoxSummary = new System.Windows.Forms.TextBox();
            this.labelSummary = new System.Windows.Forms.Label();
            this.labelPDate = new System.Windows.Forms.Label();
            this.labelDuration = new System.Windows.Forms.Label();
            this.textBoxDuration = new System.Windows.Forms.TextBox();
            this.labelPG = new System.Windows.Forms.Label();
            this.labelGenre = new System.Windows.Forms.Label();
            this.datePickerPrDate = new System.Windows.Forms.DateTimePicker();
            this.pgComboBox = new System.Windows.Forms.ComboBox();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.buttonSaveMovie = new System.Windows.Forms.Button();
            this.labelBack = new System.Windows.Forms.Label();
            this.pictureBoxBack = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.toolTipFormats = new System.Windows.Forms.ToolTip(this.components);
            this.topButtonsLayoutPanel.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelMN.SuspendLayout();
            this.tableLayoutPanelMoviePicName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePic)).BeginInit();
            this.tableLayoutPanelMovie.SuspendLayout();
            this.tableLayoutPanelMovieDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // topButtonsLayoutPanel
            // 
            this.topButtonsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topButtonsLayoutPanel.AutoSize = true;
            this.topButtonsLayoutPanel.ColumnCount = 3;
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topButtonsLayoutPanel.Controls.Add(this.closeLabel, 2, 0);
            this.topButtonsLayoutPanel.Controls.Add(this.minimizeLabel, 0, 0);
            this.topButtonsLayoutPanel.Controls.Add(this.maximizeLabel, 1, 0);
            this.topButtonsLayoutPanel.Location = new System.Drawing.Point(1160, 0);
            this.topButtonsLayoutPanel.Name = "topButtonsLayoutPanel";
            this.topButtonsLayoutPanel.RowCount = 1;
            this.topButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.topButtonsLayoutPanel.Size = new System.Drawing.Size(120, 39);
            this.topButtonsLayoutPanel.TabIndex = 4;
            // 
            // closeLabel
            // 
            this.closeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeLabel.AutoSize = true;
            this.closeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeLabel.ForeColor = System.Drawing.Color.White;
            this.closeLabel.Location = new System.Drawing.Point(88, 7);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(23, 25);
            this.closeLabel.TabIndex = 1;
            this.closeLabel.Text = "x";
            this.closeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeLabel.Click += new System.EventHandler(this.closeLabel_Click);
            this.closeLabel.MouseLeave += new System.EventHandler(this.closeLabel_MouseLeave);
            this.closeLabel.MouseHover += new System.EventHandler(this.closeLabel_MouseHover);
            // 
            // minimizeLabel
            // 
            this.minimizeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.minimizeLabel.AutoSize = true;
            this.minimizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minimizeLabel.ForeColor = System.Drawing.Color.White;
            this.minimizeLabel.Location = new System.Drawing.Point(10, 7);
            this.minimizeLabel.Name = "minimizeLabel";
            this.minimizeLabel.Size = new System.Drawing.Size(19, 25);
            this.minimizeLabel.TabIndex = 1;
            this.minimizeLabel.Text = "-";
            this.minimizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.minimizeLabel.Click += new System.EventHandler(this.minimizeLabel_Click);
            this.minimizeLabel.MouseLeave += new System.EventHandler(this.minimizeLabel_MouseLeave);
            this.minimizeLabel.MouseHover += new System.EventHandler(this.minimizeLabel_MouseHover);
            // 
            // maximizeLabel
            // 
            this.maximizeLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.maximizeLabel.AutoSize = true;
            this.maximizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maximizeLabel.ForeColor = System.Drawing.Color.White;
            this.maximizeLabel.Location = new System.Drawing.Point(45, 7);
            this.maximizeLabel.Name = "maximizeLabel";
            this.maximizeLabel.Size = new System.Drawing.Size(27, 25);
            this.maximizeLabel.TabIndex = 2;
            this.maximizeLabel.Text = "⬜";
            this.maximizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.maximizeLabel.Click += new System.EventHandler(this.maximizeLabel_Click);
            this.maximizeLabel.MouseLeave += new System.EventHandler(this.maximizeLabel_MouseLeave);
            this.maximizeLabel.MouseHover += new System.EventHandler(this.maximizeLabel_MouseHover);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMN, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelMovie, 1, 0);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(140, 100);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1000, 650);
            this.tableLayoutPanelMain.TabIndex = 5;
            // 
            // tableLayoutPanelMN
            // 
            this.tableLayoutPanelMN.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMN.ColumnCount = 1;
            this.tableLayoutPanelMN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMN.Controls.Add(this.tableLayoutPanelMoviePicName, 0, 0);
            this.tableLayoutPanelMN.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMN.Name = "tableLayoutPanelMN";
            this.tableLayoutPanelMN.RowCount = 2;
            this.tableLayoutPanelMN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelMN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelMN.Size = new System.Drawing.Size(327, 644);
            this.tableLayoutPanelMN.TabIndex = 9;
            // 
            // tableLayoutPanelMoviePicName
            // 
            this.tableLayoutPanelMoviePicName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMoviePicName.ColumnCount = 1;
            this.tableLayoutPanelMoviePicName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMoviePicName.Controls.Add(this.pictureBoxMoviePic, 0, 0);
            this.tableLayoutPanelMoviePicName.Controls.Add(this.labelMovieName, 0, 1);
            this.tableLayoutPanelMoviePicName.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelMoviePicName.Name = "tableLayoutPanelMoviePicName";
            this.tableLayoutPanelMoviePicName.RowCount = 2;
            this.tableLayoutPanelMoviePicName.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMoviePicName.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelMoviePicName.Size = new System.Drawing.Size(321, 509);
            this.tableLayoutPanelMoviePicName.TabIndex = 7;
            // 
            // pictureBoxMoviePic
            // 
            this.pictureBoxMoviePic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxMoviePic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMoviePic.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxMoviePic.Name = "pictureBoxMoviePic";
            this.pictureBoxMoviePic.Size = new System.Drawing.Size(315, 470);
            this.pictureBoxMoviePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMoviePic.TabIndex = 7;
            this.pictureBoxMoviePic.TabStop = false;
            this.toolTipFormats.SetToolTip(this.pictureBoxMoviePic, "formats: .jpg, .jpeg, .png, .bmp");
            // 
            // labelMovieName
            // 
            this.labelMovieName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelMovieName.AutoSize = true;
            this.labelMovieName.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMovieName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(233)))), ((int)(((byte)(232)))));
            this.labelMovieName.Location = new System.Drawing.Point(68, 476);
            this.labelMovieName.Name = "labelMovieName";
            this.labelMovieName.Size = new System.Drawing.Size(184, 33);
            this.labelMovieName.TabIndex = 8;
            this.labelMovieName.Text = "Movie name";
            this.labelMovieName.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelMovieName.Visible = false;
            // 
            // tableLayoutPanelMovie
            // 
            this.tableLayoutPanelMovie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMovie.ColumnCount = 1;
            this.tableLayoutPanelMovie.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMovie.Controls.Add(this.tableLayoutPanelMovieDetails, 0, 0);
            this.tableLayoutPanelMovie.Location = new System.Drawing.Point(336, 3);
            this.tableLayoutPanelMovie.Name = "tableLayoutPanelMovie";
            this.tableLayoutPanelMovie.RowCount = 1;
            this.tableLayoutPanelMovie.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMovie.Size = new System.Drawing.Size(661, 644);
            this.tableLayoutPanelMovie.TabIndex = 8;
            // 
            // tableLayoutPanelMovieDetails
            // 
            this.tableLayoutPanelMovieDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMovieDetails.ColumnCount = 2;
            this.tableLayoutPanelMovieDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMovieDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxName, 1, 0);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.buttonChangePic, 0, 6);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxSummary, 1, 5);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelSummary, 0, 5);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelPDate, 0, 4);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelDuration, 0, 3);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.textBoxDuration, 1, 3);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelPG, 0, 2);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.labelGenre, 0, 1);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.datePickerPrDate, 1, 4);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.pgComboBox, 1, 2);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.genreComboBox, 1, 1);
            this.tableLayoutPanelMovieDetails.Controls.Add(this.buttonSaveMovie, 1, 7);
            this.tableLayoutPanelMovieDetails.Location = new System.Drawing.Point(3, 65);
            this.tableLayoutPanelMovieDetails.Name = "tableLayoutPanelMovieDetails";
            this.tableLayoutPanelMovieDetails.RowCount = 8;
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.951224F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.951224F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.951224F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.951224F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.951224F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.75612F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.98539F));
            this.tableLayoutPanelMovieDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.502361F));
            this.tableLayoutPanelMovieDetails.Size = new System.Drawing.Size(655, 514);
            this.tableLayoutPanelMovieDetails.TabIndex = 0;
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxName.ForeColor = System.Drawing.Color.Gray;
            this.textBoxName.Location = new System.Drawing.Point(139, 3);
            this.textBoxName.MaxLength = 50;
            this.textBoxName.Multiline = true;
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(661, 34);
            this.textBoxName.TabIndex = 31;
            this.textBoxName.Text = "Type the movie\'s name here...";
            this.textBoxName.Click += new System.EventHandler(this.textBoxName_Click);
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(78, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(55, 20);
            this.labelName.TabIndex = 17;
            this.labelName.Text = "Name:";
            // 
            // buttonChangePic
            // 
            this.buttonChangePic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonChangePic.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePic.Location = new System.Drawing.Point(3, 407);
            this.buttonChangePic.Name = "buttonChangePic";
            this.buttonChangePic.Size = new System.Drawing.Size(130, 27);
            this.buttonChangePic.TabIndex = 29;
            this.buttonChangePic.Text = "Change picture";
            this.buttonChangePic.UseVisualStyleBackColor = true;
            this.buttonChangePic.Click += new System.EventHandler(this.buttonChangePic_Click);
            // 
            // textBoxSummary
            // 
            this.textBoxSummary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.textBoxSummary.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxSummary.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSummary.Location = new System.Drawing.Point(139, 203);
            this.textBoxSummary.MaxLength = 100000;
            this.textBoxSummary.Multiline = true;
            this.textBoxSummary.Name = "textBoxSummary";
            this.textBoxSummary.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSummary.Size = new System.Drawing.Size(516, 198);
            this.textBoxSummary.TabIndex = 26;
            this.textBoxSummary.Text = "Type the movie\'s summary here...";
            this.textBoxSummary.Click += new System.EventHandler(this.textBoxSummary_Click);
            this.textBoxSummary.TextChanged += new System.EventHandler(this.textBoxSummary_TextChanged);
            // 
            // labelSummary
            // 
            this.labelSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSummary.AutoSize = true;
            this.labelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSummary.ForeColor = System.Drawing.Color.White;
            this.labelSummary.Location = new System.Drawing.Point(53, 200);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(80, 20);
            this.labelSummary.TabIndex = 13;
            this.labelSummary.Text = "Summary:";
            // 
            // labelPDate
            // 
            this.labelPDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPDate.AutoSize = true;
            this.labelPDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPDate.ForeColor = System.Drawing.Color.White;
            this.labelPDate.Location = new System.Drawing.Point(18, 160);
            this.labelPDate.Name = "labelPDate";
            this.labelPDate.Size = new System.Drawing.Size(115, 20);
            this.labelPDate.TabIndex = 12;
            this.labelPDate.Text = "Premiere Date:";
            // 
            // labelDuration
            // 
            this.labelDuration.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDuration.AutoSize = true;
            this.labelDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDuration.ForeColor = System.Drawing.Color.White;
            this.labelDuration.Location = new System.Drawing.Point(63, 120);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(70, 20);
            this.labelDuration.TabIndex = 27;
            this.labelDuration.Text = "Duration";
            // 
            // textBoxDuration
            // 
            this.textBoxDuration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.textBoxDuration.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxDuration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDuration.ForeColor = System.Drawing.Color.Gray;
            this.textBoxDuration.Location = new System.Drawing.Point(139, 123);
            this.textBoxDuration.MaxLength = 10;
            this.textBoxDuration.Multiline = true;
            this.textBoxDuration.Name = "textBoxDuration";
            this.textBoxDuration.Size = new System.Drawing.Size(650, 34);
            this.textBoxDuration.TabIndex = 28;
            this.textBoxDuration.Text = "Type the movie\'s duration here...";
            this.toolTipFormats.SetToolTip(this.textBoxDuration, "in minutes; example: 90");
            this.textBoxDuration.Click += new System.EventHandler(this.textBoxDuration_Click);
            // 
            // labelPG
            // 
            this.labelPG.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPG.AutoSize = true;
            this.labelPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPG.ForeColor = System.Drawing.Color.White;
            this.labelPG.Location = new System.Drawing.Point(97, 80);
            this.labelPG.Name = "labelPG";
            this.labelPG.Size = new System.Drawing.Size(36, 20);
            this.labelPG.TabIndex = 11;
            this.labelPG.Text = "PG:";
            // 
            // labelGenre
            // 
            this.labelGenre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGenre.AutoSize = true;
            this.labelGenre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelGenre.ForeColor = System.Drawing.Color.White;
            this.labelGenre.Location = new System.Drawing.Point(75, 40);
            this.labelGenre.Name = "labelGenre";
            this.labelGenre.Size = new System.Drawing.Size(58, 20);
            this.labelGenre.TabIndex = 9;
            this.labelGenre.Text = "Genre:";
            // 
            // datePickerPrDate
            // 
            this.datePickerPrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datePickerPrDate.Location = new System.Drawing.Point(139, 163);
            this.datePickerPrDate.Name = "datePickerPrDate";
            this.datePickerPrDate.Size = new System.Drawing.Size(256, 22);
            this.datePickerPrDate.TabIndex = 32;
            // 
            // pgComboBox
            // 
            this.pgComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pgComboBox.FormattingEnabled = true;
            this.pgComboBox.Location = new System.Drawing.Point(139, 83);
            this.pgComboBox.Name = "pgComboBox";
            this.pgComboBox.Size = new System.Drawing.Size(82, 24);
            this.pgComboBox.TabIndex = 33;
            // 
            // genreComboBox
            // 
            this.genreComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Location = new System.Drawing.Point(139, 43);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(82, 24);
            this.genreComboBox.TabIndex = 34;
            // 
            // buttonSaveMovie
            // 
            this.buttonSaveMovie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSaveMovie.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(233)))), ((int)(((byte)(232)))));
            this.buttonSaveMovie.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveMovie.Location = new System.Drawing.Point(404, 471);
            this.buttonSaveMovie.Name = "buttonSaveMovie";
            this.buttonSaveMovie.Size = new System.Drawing.Size(130, 32);
            this.buttonSaveMovie.TabIndex = 30;
            this.buttonSaveMovie.Text = "Save changes";
            this.buttonSaveMovie.UseVisualStyleBackColor = false;
            this.buttonSaveMovie.Click += new System.EventHandler(this.buttonSaveMovie_Click);
            // 
            // labelBack
            // 
            this.labelBack.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelBack.AutoSize = true;
            this.labelBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelBack.ForeColor = System.Drawing.SystemColors.Control;
            this.labelBack.Location = new System.Drawing.Point(42, 12);
            this.labelBack.Name = "labelBack";
            this.labelBack.Size = new System.Drawing.Size(38, 16);
            this.labelBack.TabIndex = 13;
            this.labelBack.Text = "back";
            // 
            // pictureBoxBack
            // 
            this.pictureBoxBack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxBack.Image = global::Mov4e.Properties.Resources.go_back_white;
            this.pictureBoxBack.Location = new System.Drawing.Point(4, 5);
            this.pictureBoxBack.Name = "pictureBoxBack";
            this.pictureBoxBack.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxBack.TabIndex = 12;
            this.pictureBoxBack.TabStop = false;
            this.pictureBoxBack.Click += new System.EventHandler(this.pictureBoxBack_Click);
            this.pictureBoxBack.MouseLeave += new System.EventHandler(this.pictureBoxBack_MouseLeave);
            this.pictureBoxBack.MouseHover += new System.EventHandler(this.pictureBoxBack_MouseHover);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel3.Controls.Add(this.pictureBoxBack, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelBack, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(90, 40);
            this.tableLayoutPanel3.TabIndex = 16;
            // 
            // mov4eAddMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1280, 788);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.topButtonsLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mov4eAddMovie";
            this.Text = "mov4eAddMovie";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.mov4eAddMovie_Load);
            this.topButtonsLayoutPanel.ResumeLayout(false);
            this.topButtonsLayoutPanel.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMN.ResumeLayout(false);
            this.tableLayoutPanelMoviePicName.ResumeLayout(false);
            this.tableLayoutPanelMoviePicName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoviePic)).EndInit();
            this.tableLayoutPanelMovie.ResumeLayout(false);
            this.tableLayoutPanelMovieDetails.ResumeLayout(false);
            this.tableLayoutPanelMovieDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBack)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topButtonsLayoutPanel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label minimizeLabel;
        private System.Windows.Forms.Label maximizeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMN;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMoviePicName;
        private System.Windows.Forms.PictureBox pictureBoxMoviePic;
        private System.Windows.Forms.Label labelMovieName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMovieDetails;
        private System.Windows.Forms.TextBox textBoxSummary;
        private System.Windows.Forms.Label labelGenre;
        private System.Windows.Forms.Label labelPG;
        private System.Windows.Forms.Label labelPDate;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.TextBox textBoxDuration;
        private System.Windows.Forms.Label labelBack;
        private System.Windows.Forms.PictureBox pictureBoxBack;
        private System.Windows.Forms.Button buttonChangePic;
        private System.Windows.Forms.Button buttonSaveMovie;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DateTimePicker datePickerPrDate;
        private System.Windows.Forms.ComboBox pgComboBox;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.ToolTip toolTipFormats;
    }
}