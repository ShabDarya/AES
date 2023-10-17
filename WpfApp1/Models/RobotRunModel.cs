using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class RobotRunModel
    {
        public float ArmUp { get; set; } = 0f;
        public float ArmRound { get; set; } = 0f;
        public float ElbowForward { get; set; } = 0f;
        public float HandRound { get; set; } = 0f;
        public float FingerL { get; set; } = 0f;
        public float FingerR { get; set; } = 0f;
        public float HandDownUp { get; set; } = 0f;
        public int Scene { get; set; } = 0;
    }
}
