using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.DTO;

namespace WpfApp1
{
    public static class SettingsMovements
    {
        public static string? Login { get; set; }
        public static RobotDTO SelectR { get; set; }

        public static bool openCommand { get; set; } = false;
        public static List<string> CommandsList { get; set; }

        public static int Scene { get; set; }
        public static double Pertcent { get; set; }
    }
}
