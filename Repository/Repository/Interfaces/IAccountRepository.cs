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
        Task SendConfirmationMail();
        Task<Account?> FindAccountByEmail(String email);
        Task<(IEnumerable<Account> accounts, int totalPages)> SearchAccountsWithPagination(String orderBy, int page, int pageSize, String query);
        Task DisableAccount(int accountId);
        Task<Customer> UpdateAccount(Customer customer);
        int CountData();
        

    }
}
