using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.IO;

namespace CertificateKeyGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread()]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.FirstChanceException += CurrentDomain_FirstChanceException;
            Application.Run(new MainForm());
        }

        private static void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            File.AppendAllText("FirstChanceException.log.txt", e.Exception.ToString());
        }
    }
}
