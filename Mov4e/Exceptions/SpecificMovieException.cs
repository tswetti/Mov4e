using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Exceptions
{
    public class SpecificMovieException:Exception
    {
        public SpecificMovieException()
        {
        }

        public SpecificMovieException(string msg)
            : base(msg)
        {
        }
    }
}
