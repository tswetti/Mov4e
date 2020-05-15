using Autofac.Extras.Moq;
using Moq;
using Mov4e.Model;
using Mov4e.Repository.AllMoviesRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4eTests.ServiceTests.AllMoviesServiceTests
{
    class DummyMockedAllMoviesRepository
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie{id=1,title="Titanic",genre=10,pg=0,duration=210,summary="This is the description of the Titanic movie.",year=new DateTime(11,1,1997),picture=new byte[100]},
            new Movie{id=2,title="Terminator",genre=6,pg=12,duration=120,summary="This is the description of the Terminator movie.",year=new DateTime(10,26,1984),picture=new byte[120]},
            new Movie{id=3,title="Star Wars 5",genre=7,pg=0,duration=150,summary="This is the description of the Star Wars 5 movie.",year=new DateTime(4,23,1984),picture=new byte[80]}
        };

        public IAllMoviesRepository _allMoviesRepo;

        public DummyMockedAllMoviesRepository()
        {
            using (var mock = AutoMock.GetStrict())
            {
                /*mock.Mock<IAllMoviesRepository>().Setup(iall_m_repo=>iall_m_repo.GetMovie(It.IsAny<int>()))
                    .Returns((int mov_id)=>movies.Where(m=>m.id==mov_id).Select(mov=>new Tuple<int, byte[]>(m.id, m.picture)));*/

                /*mock.Mock<IAllMoviesRepository>().Setup(iall_m_repo.EditMovie(It.IsAny<int, sting, int, int, Nullable<DateTime>, string, byte[], int>()))
                    .Returns();*/

                _allMoviesRepo = mock.Create<IAllMoviesRepository>();
            }
        }
    }
}
