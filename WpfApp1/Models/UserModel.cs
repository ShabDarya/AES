using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class UserModel
    {
        public string Login { get; set; } = null!;
        public int Role { get; set; }
        public string Password { get; set; } = null!;
    }
}
