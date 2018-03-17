using Airlines.Program.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Airlines.Program
{
    public class Program
    {
        private ScheduleController _scheduleController;

        public ScheduleController ScheduleController => _scheduleController ??
            (_scheduleController = new ScheduleController());

        public static Program Instance { get; set; }
        public Program()
        {
            _scheduleController = new ScheduleController();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Instance = new Program();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
