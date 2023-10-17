using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Interfaces
{
    public interface IUserBaseService : IBaseRepository<UserModel>
    {
    }
}
