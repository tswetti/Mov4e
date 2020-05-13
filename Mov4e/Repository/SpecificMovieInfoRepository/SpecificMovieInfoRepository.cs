using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mov4e.Model;

namespace Mov4e.Repository.SpecificMovieInfoRepository
{
    class SpecificMovieInfoRepository : ISpecificMovieInfoRepository
    {
        public Movie GetMovieById(int id)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                Movie mv = context.Movies.Find(id);
                return mv;
            }
        }

        public string GetGenreById(int id)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                Genre ge = context.Genres.Find(id);
                return ge.name;
            }
        }

        public void InserNewRate(int movieId, int userId, int rate)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                context.Ratings.Add(new Rating() { user_Id = userId, movie_Id = movieId, userRating = rate });
                context.SaveChanges();
            }
        }

        public double? GetRateByMovieId(int movieId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                double? rate = context.Movies.Find(movieId).AVGRating;
                return rate;
            }
        }

        public bool isRateInDB(int userId, int movieId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                bool containsRate = context.Ratings.Any(rt => rt.movie_Id == movieId && rt.user_Id == userId);
                return containsRate;
            }
        }

        public bool isMovieInWatchList(int userId, int movieId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                User currentUser = context.Users.Find(userId);
                bool hasMovieInWatchList = currentUser.movies.Any(m => m.id == movieId);
                return hasMovieInWatchList;
            }
        }

        public void RemoveFromWatchList(int movieId, int userId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                User currentUser = context.Users.Find(userId);
                currentUser.movies.Remove(context.Movies.Find(movieId));
                context.SaveChanges();
            }
        }

        public void AddToWatchList(int movieId, int userId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                User currentUser = context.Users.Find(userId);
                currentUser.movies.Add(context.Movies.Find(movieId));
                context.SaveChanges();
            }
        }

        public List<(int commentId, string name, byte[] picture, string comment)> GetMovieComments(int movieId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                List<(int commentId, string name, byte[] picture, string comment)> commentsAndCommentsInfo = new List<(int commentId, string name, byte[] picture, string comment)>();

                var query = context.Comments.Where(c => c.movie_Id == movieId).
                            Select(c => new
                            {
                                c.id,
                                c.user.userName,
                                c.user.user_info.picture,
                                c.comment1,
                                c.dateOfTheComment
                            }).OrderByDescending(c => c.dateOfTheComment);

                foreach (var el in query)
                {
                    commentsAndCommentsInfo.Add((el.id,el.userName, el.picture, el.comment1));
                }

                return commentsAndCommentsInfo;
            }

        }



        public void SaveComment(int userId, int movieId, string comment)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                context.Comments.Add(new Comment() {
                                     user_Id = userId,
                                     movie_Id = movieId,
                                     comment1 = comment,
                                     dateOfTheComment = DateTime.Now
                                     });
                context.SaveChanges();
            }
        
        }

        public (int commentId,string userName, byte[] profilePic) GetInfoForUserAndCommentIdFromDB(int userId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                Comment LastComment =context.Comments.OrderByDescending(c => c.id).Take(1).Single();
                string username= context.Users.Find(userId).userName;
                byte[] profilePic= context.Users.Find(userId).user_info.picture;

                return (LastComment.id, username,profilePic);
            }
        }

        public void DeleteCommentFromDB(List<int> commentsIds)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                foreach (int el in commentsIds)
                {
                    Comment com = context.Comments.Where(c => c.id==el).Single();
                    context.Comments.Remove(com);
                }

                context.SaveChanges();
            }
        }

        

        public string GetUserNameForCurrentUserFromDB(int userId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                return context.Users.Find(userId).userName;
            }
        }

        public string UserPosition(int userId)
        {
            using(mov4eEntities context = new mov4eEntities())
            {
                return context.UserInfoes.Find(userId).position;
            }
        }

        public void DeleteComentsCounter(int count)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                List<Comment> comms = context.Comments.OrderByDescending(c => c.id).Take(count).ToList();
                foreach (Comment el in comms)
                {
                    context.Comments.Remove(el);
                }
                context.SaveChanges();
            }
        }

        public (int commentId, string name, byte[] picture, string comment) GetLastCommentForTheUser(int movieId, int userId)
        {
            using (mov4eEntities context = new mov4eEntities())
            {
                var query = context.Comments.Where(c => c.movie_Id == movieId && c.user_Id == userId)
                                            .OrderByDescending(c => c.dateOfTheComment)
                                            .First(); 

                return (query.id, query.user.userName, query.user.user_info.picture, query.comment1);
            }
        }
    }
}
