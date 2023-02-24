using Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.Interfaces
{
    public interface IAccountRepository
    {
        Task SignUp(Account account);
        Task<Account> SignIn(Account account);
        Task<IEnumerable<Account>> GetAllAccounts();
    }
}
