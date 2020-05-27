using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Service.SpecificMovieService;
using Mov4e.Model;


namespace Mov4eTests.PresenterTests.SpecificMoviePresenterTests
{
    class MockedDummySpecificMovieService
    {
        public ISpecificMovieInfoService _specificMovieService;

       
        public Movie _movie = new Movie()
        {
          title = "Transformers",
          id = 1,
          year = DateTime.Now,
          summary = "asdasdasd",
          picture = new byte[10],
          pg = 16,
          AVGRating = 6,
          genre = 3
        };
        
        public bool error = false;

        public List<int> rates = new List<int>() { 1, 2, 3 };

        public List<(int commentId, string name, byte[] picture, string comment)> comments = new List<(int commentId, string name, byte[] picture, string comment)>()
        {
            (1, "Peter", new byte[1], "sdfsd"),
            (2, "Niki", new byte[2], "xcvcxcv")
        };

        public Dictionary<int, byte[]> watchlist = new Dictionary<int, byte[]>()
        {
            {1,new byte[10] },
            {2,new byte[11] },
            {3,new byte[12] }
        };

        public MockedDummySpecificMovieService()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.GetMovieFromDBAndSetItInModel(It.IsAny<int>()))
                                                      .Callback(() =>
                                                      {
                                                          if (error == true)
                                                          {
                                                              throw new Exception();
                                                          }
                                                      });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.SetMovieInfo())
                                                      .Returns(() =>
                                                      {
                                                          if (error == false)
                                                          {
                                                              return (_movie.title, _movie.picture,
                                                                      _movie.genre.ToString(),
                                                                      _movie.pg, _movie.year.ToString(),
                                                                      _movie.summary, _movie.AVGRating,_movie.duration);
                                                          }
                                                          else
                                                              throw new Exception();
                                                      });
                

        
                                                               
                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.AddRate(It.IsAny<int>(), It.IsAny<int>()))
                                                       .Callback((int id, int rate) =>
                                                       {
                                                           if (error == false)
                                                           {
                                                               rates.Add(rate);
                                                           }
                                                           else
                                                               throw new Exception();
                                                       }                                                      
                                                       );

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.SetUpdatedRateInModel())
                                                      .Callback(() =>
                                                      {
                                                          if (error == false)
                                                          {
                                                              _movie.AVGRating = 10;
                                                          }
                                                          else
                                                              throw new Exception();
                                                      });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.CheckIfUserRated(It.IsAny<int>()))
                                                       .Returns(() =>
                                                       {
                                                           if (error==false)
                                                           {
                                                               return true;
                                                               
                                                           }
                                                           else
                                                           {
                                                               throw new Exception();
                                                           }
                                                       });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.CheckIfUserHasMovieInWatchList(It.IsAny<int>()))
                                                       .Returns(() =>
                                                       {
                                                           if (error == false)
                                                           {
                                                               return true;

                                                           }
                                                           else
                                                           {
                                                               throw new Exception();
                                                           }
                                                       });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.MovieRemover(It.IsAny<int>()))
                                                       .Callback(() =>
                                                       {
                                                           if (error == false)
                                                           {
                                                               watchlist.Remove(3);
                                                           }
                                                           else
                                                           {
                                                               throw new Exception();
                                                           }
                                                       });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.MovieAdder(It.IsAny<int>()))
                                                       .Callback(() =>
                                                       {
                                                           if (error == false)
                                                           {
                                                               watchlist.Add(5,new byte[10]);
                                                           }
                                                           else
                                                           {
                                                               throw new Exception();
                                                           }
                                                       });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.GetCommentsFromDB())
                                                      .Returns(()=>
                                                      {
                                                          if (error == false)
                                                          {
                                                              return this.comments;
                                                          }
                                                          else
                                                          {
                                                              throw new Exception();
                                                          }
                                                      });
                                                           

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.SaveComentInDB(It.IsAny<int>(), It.IsAny<string>()))
                                                      .Callback((int id,string comment) =>
                                                      {
                                                          if (error == false)
                                                          {
                                                              comments.Add((4, "Peter", new byte[1], comment));
                                                          }
                                                          else
                                                          {
                                                              throw new Exception();
                                                          }
                                                      });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.DeleteComment(It.IsAny<List<int>>()))
                                                      .Callback(() =>
                                                      {
                                                          if (error == false)
                                                          {
                                                              comments.Remove(comments.Last());
                                                          }
                                                          else
                                                          {
                                                              throw new Exception();
                                                          }
                                                      });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.GetCurrentUserUserName(It.IsAny<int>()))
                                                     .Returns(() =>
                                                     {
                                                         if (error == false)
                                                         {
                                                             return "Zak"; 
                                                         }
                                                         else
                                                         {
                                                             throw new Exception();
                                                         }
                                                     });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.UserPositon(It.IsAny<int>()))
                                                    .Returns(() =>
                                                    {
                                                        if (error == false)
                                                        {
                                                            return "admin";
                                                        }
                                                        else
                                                        {
                                                            throw new Exception();
                                                        }
                                                    });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.GetLastComment(It.IsAny<int>()))
                                                    .Returns(() =>
                                                    {
                                                        if (error == false)
                                                        {
                                                            return comments.Last();
                                                        }
                                                        else
                                                        {
                                                            throw new Exception();
                                                        }
                                                    });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.GetUserRate(It.IsAny<int>()))
                                                    .Returns(() =>
                                                    {
                                                        if (error == false)
                                                        {
                                                            return 3;
                                                        }
                                                        else
                                                        {
                                                            throw new Exception();
                                                        }
                                                    });

                mock.Mock<ISpecificMovieInfoService>().Setup(Ispec => Ispec.DeleteUserRate(It.IsAny<int>()))
                                                   .Callback(() =>
                                                   {
                                                       if (error == false)
                                                       {
                                                           _movie.AVGRating = 4.5;
                                                       }
                                                       else
                                                       {
                                                           throw new Exception();
                                                       }
                                                   });

                _specificMovieService = mock.Create<ISpecificMovieInfoService>();
            }
        }
    }
}
