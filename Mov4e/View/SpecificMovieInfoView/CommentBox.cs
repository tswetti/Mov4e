using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mov4e.View.SpecificMovieInfoView
{
    public partial class CommentBox : Panel
    {
        public string currentUserName; //this intiger is used to place tags on each elemtnt

        private List<GroupBox> gComments = new List<GroupBox>();
        private Button showMoreBtn = new Button();
        private Label noComments = new Label();
        private Label endOfComments = new Label();

        public bool enableCheckBoxes = false;
        public int startY = 0;
        public int commentsCounter = 0;
        public int allComentsCounter = 0;

        public List<(int commentId, string name, byte[] picture, string comment)> commentList = new List<(int commentId, string name, byte[] picture, string comment)>();
        public List<int> checkedCommentsList = new List<int>();

        public CommentBox()
        {
            InitializeComponent();
            this.SetLabels();
        }

        private void SetLabels()
        {
            this.Controls.Add(showMoreBtn);
            this.Controls.Add(noComments);
            this.Controls.Add(endOfComments);

            //show more properties
            showMoreBtn.Visible = false;
            showMoreBtn.Text = "Show More";
            showMoreBtn.Click += ShowMore_Click;

            //endOfComments of the comments properties
            endOfComments.Visible = false;
            endOfComments.Text = "There are no more comments!";
            endOfComments.Width = TextRenderer.MeasureText(endOfComments.Text, endOfComments.Font).Width;

            //noComments label properties
            noComments.Visible = true;
            noComments.Text = "There are no comments for this movie!";
            noComments.Width = TextRenderer.MeasureText(noComments.Text, noComments.Font).Width;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            showMoreBtn.Left = (this.ClientSize.Width - showMoreBtn.Width) / 2;
            endOfComments.Left = (this.ClientSize.Width - endOfComments.Width) / 2;
            noComments.Left = (this.ClientSize.Width - noComments.Width) / 2;
        }

        private void CheckPositions()
        {
            
            if (allComentsCounter > 5 && commentsCounter != allComentsCounter)
            {
                //zashto ne bacjka
                showMoreBtn.Visible = true;
                showMoreBtn.Top = gComments.Last().Bottom + 10;
                endOfComments.Visible = false;
                noComments.Visible = false;
            }
            if ((commentsCounter == allComentsCounter || allComentsCounter <= 5) && gComments.Count > 0)
            {
                endOfComments.Visible = true;
                noComments.Visible = false;
                showMoreBtn.Visible = false;
                endOfComments.Top = gComments.Last().Bottom + 10;
            }
            if (allComentsCounter == 0 && commentsCounter == 0)
            {
                this.AutoScrollPosition = new Point(0, 0);
                noComments.Visible = true;
                showMoreBtn.Visible = false;
                endOfComments.Visible = false;
            }

        }

        private void MakeComment(int commId, string userName, byte[] profilePic, string comment, int Y)
        {
            GroupBox gComment = new GroupBox();
            PictureBox profilePicture = new PictureBox();
            Label userNamelbl = new Label();
            Label commentlbl = new Label();

            profilePicture.Size = new Size(40, 40);
            profilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            profilePicture.Image = (Bitmap)((new ImageConverter()).ConvertFrom(profilePic));
            profilePicture.Top = 0;

            commentlbl.Top = profilePicture.Top + profilePicture.Height + 3;
            commentlbl.Text = comment;
            commentlbl.Height = TextRenderer.MeasureText(commentlbl.Text, commentlbl.Font).Height;
            commentlbl.Width = TextRenderer.MeasureText(commentlbl.Text, commentlbl.Font).Width;
            commentlbl.Left = 5;

            userNamelbl.Text = userName;
            userNamelbl.Font = new Font(Label.DefaultFont, FontStyle.Bold);
            userNamelbl.Height = TextRenderer.MeasureText(userNamelbl.Text, commentlbl.Font).Height;
            userNamelbl.Top = profilePicture.Height - userNamelbl.Height;
            userNamelbl.Left = profilePicture.Width + 5;

            gComment.Height = profilePicture.Height + commentlbl.Height + 10;
            gComment.Width = this.Width - 20;

            gComment.Controls.Add(profilePicture);
            gComment.Controls.Add(userNamelbl);
            gComment.Controls.Add(commentlbl);

            if (enableCheckBoxes == true)
            {
                CheckBox commentChb = new CheckBox();
                commentChb.Height = 20;
                commentChb.Width = 20;
                commentChb.Left = gComment.Width - commentChb.Width - 20;
                commentChb.Top = (gComment.Height - commentChb.Height) / 2;
                gComment.Controls.Add(commentChb);
            }

            gComment.Location = new Point(0, Y);
            gComment.Dock = DockStyle.None;
            gComment.Tag = commId;
            gComments.Add(gComment);
            this.Controls.Add(gComment);
            commentsCounter++;
        }

        public void SetComments(int howMuchToTake)
        {

            this.VerticalScroll.Value = 0;
         
            if (commentsCounter != allComentsCounter)
            {
                foreach (var el in commentList.Skip(commentsCounter).Take(howMuchToTake))
                {
                    MakeComment(el.commentId, el.name, el.picture, el.comment, startY);
                    if (gComments.Count > 0)
                    {
                        startY = gComments.Last().Bottom;
                    }
                }
            }
            this.CheckPositions();
        }

        public void AddComment((int commentId, string userName, byte[] profilePic, string comment) com)
        {
            commentList.Reverse();
            commentList.Add(com);
            commentList.Reverse();
            this.AutoScrollPosition = new Point(0, 0);
            gComments.Reverse();
            MakeComment(com.commentId, com.userName, com.profilePic, com.comment, 0);
            gComments.Reverse();
            allComentsCounter++;

            if (gComments.Count() > 5)
            {
                this.Controls.Remove(gComments.Last());
                gComments.Remove(gComments.Last());
                commentsCounter--;
            }

            for (int i = gComments.Count - 1; i > 0; i--)
            {
                gComments.ElementAt(i).Top += gComments.First().Height;
            }

            this.CheckPositions();

        }

        public void ShowMore_Click(object sender, EventArgs e)
        {
            //ne e mnogo ok no raboti
            this.VerticalScroll.Value = 0;
            startY = gComments.Last().Bottom;
            this.SetComments(5);
            this.CheckPositions();
        }

        public void AddCommentsForDeleteInList()
        {
            foreach (GroupBox el in gComments)
            {
                CheckBox chB = el.Controls.OfType<CheckBox>().Single();
                if (chB.Checked == true)
                {
                    checkedCommentsList.Add(Convert.ToInt32(el.Tag));
                }
            }
        }

        public void AddAllCommentsForDelete()
        {
            foreach (var el in commentList)
            {
                if (el.name == currentUserName)
                {
                    checkedCommentsList.Add(el.commentId);
                }
            }
        }

        //tozi metod se izpolzwa za mahane na kometari ot commentBox controla ili po tochno ot da maha grupboxove
        private void DeleteFromGCommentsList(int comIndex)
        {
            if (gComments.Count > 0)
            {
                int index = 0;
                GroupBox gbForRemove = gComments.Where(g => Convert.ToInt32(g.Tag).Equals(comIndex)).Single();
                index = gComments.IndexOf(gbForRemove);
                this.Controls.Remove(gbForRemove);
                gComments.Remove(gbForRemove);
                foreach (GroupBox gb2 in gComments.Skip(index).Take(gComments.Count))
                {
                    gb2.Top -= gbForRemove.Height;
                }
            }
        }

        private void PushCommentsAfterDelete()
        {
            this.VerticalScroll.Value = 0;
            if (allComentsCounter > 0)
            {
                if (gComments.Count > 0)
                {
                    startY = gComments.Last().Bottom;
                }              
                else
                {
                    this.VerticalScroll.Value = 0;
                    showMoreBtn.Top = 0;
                    startY = 0;
                }
                this.SetComments(checkedCommentsList.Count);
            }
        }

        public void DeleteCommentsFromControl()
        {
           
            foreach (var el in checkedCommentsList)
            {
                allComentsCounter--;
                commentsCounter--;
                
                             
                (int commentId, string name, byte[] picture, string comment) p = commentList.Where(c => c.commentId == el).Single();
                commentList.Remove(p);
                DeleteFromGCommentsList(el);              
            }
            if (commentsCounter<0)
            {
                commentsCounter = 0;
            }

            PushCommentsAfterDelete();
            checkedCommentsList.Clear();
            this.CheckPositions();
        }

        public void Reset()
        {
            //ne vsichki
            foreach (var el in gComments)
            {
                this.Controls.Remove(el);
            }
            enableCheckBoxes = false;
            startY = 0;
            commentsCounter = 0;
            allComentsCounter = 0;
            gComments.Clear();
            commentList.Clear();
            checkedCommentsList.Clear();
            showMoreBtn.Visible = false;
            noComments.Visible = true;
            endOfComments.Visible = false;
         }
       
    }
}
