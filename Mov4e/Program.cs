using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mov4e.View.LogInView;
using Mov4e.View.AllMoviesView;

namespace Mov4e
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            if (Properties.Settings.Default.Logged == true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mov4eAllMovies(Properties.Settings.Default.id, Properties.Settings.Default.userPosition));
            }
            if(Properties.Settings.Default.LoggedForOneTime==true)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mov4eAllMovies(Properties.Settings.Default.id, Properties.Settings.Default.userPosition));
            }
            else 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new mov4eLogin());
            }

        }
    }
}
