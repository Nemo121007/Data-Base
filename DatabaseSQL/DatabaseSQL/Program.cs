// Гашков С.П. 22205 25.04.2023
using System.Windows.Forms;

namespace DatabaseSQL
{
    //ssh -L 1433:192.168.112.103:1433 -N -T gashkov@kappa.cs.petrsu.ru
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //var s = Connection.Start();

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());

            //WriteReport.WriteReportWorker();

        }
    }
}