using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
    public class ProtocolDTO
    {
        public string? Login { get; set; }
        public bool ReadyTest { get; set; }
        public bool ReadyPr { get; set; }
        public int IdPractica { get; set; }
        public int IdProtocol { get; set; }
    }
}
