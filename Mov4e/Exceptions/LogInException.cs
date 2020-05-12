using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.Exceptions
{
    public class LogInException :Exception
    {
        public LogInException()
        {
        }

        public LogInException(string msg)
            : base(msg)
        {
        }
    }
}
