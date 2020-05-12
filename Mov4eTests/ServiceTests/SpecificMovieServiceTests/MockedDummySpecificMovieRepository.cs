using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Autofac.Extras.Moq;
using Mov4e.Repository.SpecificMovieInfoRepository;

namespace Mov4eTests.ServiceTests.SpecificMovieServiceTests
{
    class MockedDummySpecificMovieRepository
    {
       
        public bool error = false;
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

        public Movie currentMovie = new Movie()
        {
            title="Transformers",
            id=1,
            pg=1,
            genre=1,
            duration=130,
            AVGRating=5       
        };

        (int commentId, string userName, byte[] profilePic) commentIdAndUser = (1, "asddds", new byte[4]);

        public ISpecificMovieInfoRepository _specificMovieInfoRepository;

        public MockedDummySpecificMovieRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetMovieById(It.IsAny<int>()))
                                            .Returns(currentMovie);

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetGenreById(It.IsAny<int>()))
                                            .Returns(()=>
                                                        {
                                                            if (error == true)
                                                            {
                                                                throw new Exception();
                                                            }
                                                            else
                                                                return "Drama";
                                                        }
                                                     );


                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.InserNewRate(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                                                          .Callback((int movieid,int id, int rate) => this.currentMovie.AVGRating = rate);
                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetRateByMovieId(It.IsAny<int>()))
                                            .Returns(5);

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.isRateInDB(It.IsAny<int>(), It.IsAny<int>()))
                                            .Returns(()=>
                                                    {
                                                        if (error == true)
                                                        {
                                                            return false;
                                                        }
                                                        else
                                                            return true;
                                                    });

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.isMovieInWatchList(It.IsAny<int>(), It.IsAny<int>()))
                                            .Returns(() =>
                                            {
                                                if (error == true)
                                                {
                                                    return false;
                                                }
                                                else
                                                    return true;
                                            });

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.RemoveFromWatchList(It.IsAny<int>(), It.IsAny<int>()))
                                                         .Callback((int movieid, int userid)  => watchlist.Remove(movieid));

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.AddToWatchList(It.IsAny<int>(), It.IsAny<int>()))
                                                         .Callback(() => watchlist.Add(4, new byte[32]));

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetMovieComments(It.IsAny<int>()))
                                                         .Returns(comments);

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.SaveComment(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()))
                                                         .Callback(() => comments.Add((5, "pesho", new byte[1], "sddsfdfsdsf")));

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.DeleteCommentFromDB(It.IsAny<List<int>>()))
                                                          .Callback(() => comments.Remove(comments.Last()));

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetUserNameForCurrentUserFromDB(It.IsAny<int>()))
                                                         .Returns("Peshko");

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetUserNameForCurrentUserFromDB(It.IsAny<int>()))
                                                         .Returns("Peshko");

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.UserPosition(It.IsAny<int>()))
                                                         .Returns("admin");

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.DeleteComentsCounter(It.IsAny<int>()));

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetLastCommentForTheUser(It.IsAny<int>(), It.IsAny<int>()))
                                                         .Returns(comments.Last());

                mock.Mock<ISpecificMovieInfoRepository>().Setup(im => im.GetInfoForUserAndCommentIdFromDB(It.IsAny<int>()))
                                                                         .Returns(commentIdAndUser);

                _specificMovieInfoRepository = mock.Create<ISpecificMovieInfoRepository>();
            }
        }

    }
}
