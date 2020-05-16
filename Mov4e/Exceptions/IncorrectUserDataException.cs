using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Exceptions
{
    [Serializable]
    public class IncorrectUserDataException:Exception
    {
        public IncorrectUserDataException()
        {

        }

        public IncorrectUserDataException(string msg)
           : base(msg)
        {
        }

    }
}
