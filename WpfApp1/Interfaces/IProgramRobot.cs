using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Interfaces
{
    public interface IProgramRobot
    {
        public bool Checking(string p, string o);

        public void RunProgramMovement(ref RobotRunModel r, string p, string o, out int ending);

        public void RunProgramTime(string o);
        public List<string> RunProgramIsert(string o, List<string> l);

        public void RunProgramCounter(string p, int c);
        public void RunProgramChecking(string p);
        public void RunChecking(string p, string o, ref int count);
    }
}
