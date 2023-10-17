using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.DTO
{
    public class AnswersDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsRight { get; set; }
        public int IdT { get; set; }
    }
}
