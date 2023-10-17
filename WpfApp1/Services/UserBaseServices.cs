using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Interfaces;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class UserBaseServices : IUserBaseService
    {
        public Task AddAsync(UserModel item)
        {
            throw new NotImplementedException();
        }

        public Task AddRangeAsync(ICollection<UserModel> item)
        {
            throw new NotImplementedException();
        }

        public IQueryable<UserModel> GetEntityQuery()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserModel>> RemoveRangeAsync(Func<UserModel, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
