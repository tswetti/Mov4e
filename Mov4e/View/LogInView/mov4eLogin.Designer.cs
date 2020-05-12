namespace Mov4e.View.LogInView
{
    partial class mov4eLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mov4eLogin));
            this.topButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.closeLabel = new System.Windows.Forms.Label();
            this.minimizeLabel = new System.Windows.Forms.Label();
            this.maximizeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxLogin = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelLoginContent = new System.Windows.Forms.TableLayoutPanel();
            this.labelLogin = new System.Windows.Forms.Label();
            this.tableLayoutPanelUsername = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxUsername = new System.Windows.Forms.PictureBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.tableLayoutPanelPassword = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBoxPassword = new System.Windows.Forms.PictureBox();
            this.checkBoxSave = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanelLoginButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.topButtonsLayoutPanel.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.groupBoxLogin.SuspendLayout();
            this.tableLayoutPanelLoginContent.SuspendLayout();
            this.tableLayoutPanelUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).BeginInit();
            this.tableLayoutPanelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).BeginInit();
            this.tableLayoutPanelLoginButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // topButtonsLayoutPanel
            // 
            this.topButtonsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topButtonsLayoutPanel.ColumnCount = 3;
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.topButtonsLayoutPanel.Controls.Add(this.closeLabel, 2, 0);
            this.topButtonsLayoutPanel.Controls.Add(this.minimizeLabel, 0, 0);
            this.topButtonsLayoutPanel.Controls.Add(this.maximizeLabel, 1, 0);
            this.topButtonsLayoutPanel.Location = new System.Drawing.Point(680, 0);
            this.topButtonsLayoutPanel.Name = "topButtonsLayoutPanel";
            this.topButtonsLayoutPanel.RowCount = 1;
            this.topButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topButtonsLayoutPanel.Size = new System.Drawing.Size(120, 39);
            this.topButtonsLayoutPanel.TabIndex = 1;
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
            this.tableLayoutPanelMain.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelMain.Controls.Add(this.groupBoxLogin, 1, 1);
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(100, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2.5F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(600, 500);
            this.tableLayoutPanelMain.TabIndex = 2;
            // 
            // groupBoxLogin
            // 
            this.groupBoxLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBoxLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBoxLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.groupBoxLogin.Controls.Add(this.tableLayoutPanelLoginContent);
            this.groupBoxLogin.Location = new System.Drawing.Point(100, 15);
            this.groupBoxLogin.Name = "groupBoxLogin";
            this.groupBoxLogin.Size = new System.Drawing.Size(400, 469);
            this.groupBoxLogin.TabIndex = 0;
            this.groupBoxLogin.TabStop = false;
            // 
            // tableLayoutPanelLoginContent
            // 
            this.tableLayoutPanelLoginContent.ColumnCount = 1;
            this.tableLayoutPanelLoginContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLoginContent.Controls.Add(this.labelLogin, 0, 1);
            this.tableLayoutPanelLoginContent.Controls.Add(this.tableLayoutPanelUsername, 0, 3);
            this.tableLayoutPanelLoginContent.Controls.Add(this.tableLayoutPanelPassword, 0, 5);
            this.tableLayoutPanelLoginContent.Controls.Add(this.checkBoxSave, 0, 6);
            this.tableLayoutPanelLoginContent.Controls.Add(this.tableLayoutPanelLoginButtons, 0, 7);
            this.tableLayoutPanelLoginContent.Location = new System.Drawing.Point(39, 12);
            this.tableLayoutPanelLoginContent.Name = "tableLayoutPanelLoginContent";
            this.tableLayoutPanelLoginContent.RowCount = 9;
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanelLoginContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanelLoginContent.Size = new System.Drawing.Size(320, 450);
            this.tableLayoutPanelLoginContent.TabIndex = 2;
            // 
            // labelLogin
            // 
            this.labelLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLogin.AutoSize = true;
            this.labelLogin.Font = new System.Drawing.Font("Broadway", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(233)))), ((int)(((byte)(232)))));
            this.labelLogin.Location = new System.Drawing.Point(35, 80);
            this.labelLogin.Name = "labelLogin";
            this.labelLogin.Size = new System.Drawing.Size(249, 72);
            this.labelLogin.TabIndex = 0;
            this.labelLogin.Text = "LOGIN";
            // 
            // tableLayoutPanelUsername
            // 
            this.tableLayoutPanelUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelUsername.ColumnCount = 2;
            this.tableLayoutPanelUsername.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.16162F));
            this.tableLayoutPanelUsername.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.83839F));
            this.tableLayoutPanelUsername.Controls.Add(this.pictureBoxUsername, 0, 0);
            this.tableLayoutPanelUsername.Controls.Add(this.textBoxUsername, 1, 0);
            this.tableLayoutPanelUsername.Location = new System.Drawing.Point(10, 173);
            this.tableLayoutPanelUsername.Name = "tableLayoutPanelUsername";
            this.tableLayoutPanelUsername.RowCount = 1;
            this.tableLayoutPanelUsername.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelUsername.Size = new System.Drawing.Size(300, 38);
            this.tableLayoutPanelUsername.TabIndex = 1;
            // 
            // pictureBoxUsername
            // 
            this.pictureBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxUsername.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUsername.Image = global::Mov4e.Properties.Resources.username_icon;
            this.pictureBoxUsername.Location = new System.Drawing.Point(9, 4);
            this.pictureBoxUsername.Name = "pictureBoxUsername";
            this.pictureBoxUsername.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxUsername.TabIndex = 6;
            this.pictureBoxUsername.TabStop = false;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUsername.ForeColor = System.Drawing.Color.White;
            this.textBoxUsername.Location = new System.Drawing.Point(59, 6);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(230, 26);
            this.textBoxUsername.TabIndex = 1;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // tableLayoutPanelPassword
            // 
            this.tableLayoutPanelPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelPassword.ColumnCount = 2;
            this.tableLayoutPanelPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelPassword.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.33334F));
            this.tableLayoutPanelPassword.Controls.Add(this.textBoxPassword, 1, 0);
            this.tableLayoutPanelPassword.Controls.Add(this.pictureBoxPassword, 0, 0);
            this.tableLayoutPanelPassword.Location = new System.Drawing.Point(10, 222);
            this.tableLayoutPanelPassword.Name = "tableLayoutPanelPassword";
            this.tableLayoutPanelPassword.RowCount = 1;
            this.tableLayoutPanelPassword.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelPassword.Size = new System.Drawing.Size(300, 38);
            this.tableLayoutPanelPassword.TabIndex = 2;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword.ForeColor = System.Drawing.Color.White;
            this.textBoxPassword.Location = new System.Drawing.Point(60, 6);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(230, 26);
            this.textBoxPassword.TabIndex = 2;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // pictureBoxPassword
            // 
            this.pictureBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxPassword.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPassword.Image = global::Mov4e.Properties.Resources.password_icon;
            this.pictureBoxPassword.Location = new System.Drawing.Point(10, 4);
            this.pictureBoxPassword.Name = "pictureBoxPassword";
            this.pictureBoxPassword.Size = new System.Drawing.Size(30, 30);
            this.pictureBoxPassword.TabIndex = 7;
            this.pictureBoxPassword.TabStop = false;
            // 
            // checkBoxSave
            // 
            this.checkBoxSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxSave.AutoSize = true;
            this.checkBoxSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxSave.Location = new System.Drawing.Point(103, 269);
            this.checkBoxSave.Name = "checkBoxSave";
            this.checkBoxSave.Size = new System.Drawing.Size(114, 17);
            this.checkBoxSave.TabIndex = 4;
            this.checkBoxSave.Text = "Keep me logged in";
            this.checkBoxSave.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelLoginButtons
            // 
            this.tableLayoutPanelLoginButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelLoginButtons.ColumnCount = 2;
            this.tableLayoutPanelLoginButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLoginButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLoginButtons.Controls.Add(this.buttonLogin, 0, 0);
            this.tableLayoutPanelLoginButtons.Controls.Add(this.buttonRegister, 1, 0);
            this.tableLayoutPanelLoginButtons.Location = new System.Drawing.Point(3, 304);
            this.tableLayoutPanelLoginButtons.Name = "tableLayoutPanelLoginButtons";
            this.tableLayoutPanelLoginButtons.RowCount = 1;
            this.tableLayoutPanelLoginButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelLoginButtons.Size = new System.Drawing.Size(314, 63);
            this.tableLayoutPanelLoginButtons.TabIndex = 5;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(233)))), ((int)(((byte)(232)))));
            this.buttonLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonLogin.Enabled = false;
            this.buttonLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonLogin.Location = new System.Drawing.Point(8, 11);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(140, 40);
            this.buttonLogin.TabIndex = 3;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonRegister
            // 
            this.buttonRegister.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRegister.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegister.Location = new System.Drawing.Point(165, 11);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(140, 40);
            this.buttonRegister.TabIndex = 5;
            this.buttonRegister.Text = "Register";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // mov4eLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.topButtonsLayoutPanel);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mov4eLogin";
            this.Text = "mov4eLogin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.topButtonsLayoutPanel.ResumeLayout(false);
            this.topButtonsLayoutPanel.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.groupBoxLogin.ResumeLayout(false);
            this.tableLayoutPanelLoginContent.ResumeLayout(false);
            this.tableLayoutPanelLoginContent.PerformLayout();
            this.tableLayoutPanelUsername.ResumeLayout(false);
            this.tableLayoutPanelUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUsername)).EndInit();
            this.tableLayoutPanelPassword.ResumeLayout(false);
            this.tableLayoutPanelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPassword)).EndInit();
            this.tableLayoutPanelLoginButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel topButtonsLayoutPanel;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label minimizeLabel;
        private System.Windows.Forms.Label maximizeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.GroupBox groupBoxLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLoginContent;
        private System.Windows.Forms.Label labelLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelUsername;
        private System.Windows.Forms.PictureBox pictureBoxUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPassword;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.PictureBox pictureBoxPassword;
        private System.Windows.Forms.CheckBox checkBoxSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLoginButtons;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonRegister;
    }
}