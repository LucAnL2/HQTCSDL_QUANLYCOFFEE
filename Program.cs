using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoCSDL.Forms;
using DemoCSDL.ManagerChildForms;
using DemoCSDL.WorkerChildForms;

namespace DemoCSDL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FWShift());
        }
    }
}
