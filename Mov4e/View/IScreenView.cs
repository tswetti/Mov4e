using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov4e.View
{
    public  interface IScreenView
    {
        void ShowForm();

        /// <summary>
        /// This method displays MessageBox with the error
        /// </summary>
        /// <param name="msg"></param>
        void ErrorMessage(string msg);
    }
}
