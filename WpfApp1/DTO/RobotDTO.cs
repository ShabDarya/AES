using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
    public class RobotDTO
    {
        public int Id { get; set; }
        public double G { get; set; }
        public int N { get; set; }
        public double P { get; set; }
        public double Delta { get; set; }
        public int W_s { get; set; }
        public int W_m { get; set; }
        public int R_c { get; set; }
        public int R_s { get; set; }
        public int R_p { get; set; }
        public int L_v { get; set; }
        public int L_h { get; set; }
        public string? Mechanism { get; set; }
        public string? Name { get; set; }

    }
}
