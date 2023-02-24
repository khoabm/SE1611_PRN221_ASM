using Microsoft.EntityFrameworkCore;
using Repository.Entities;
using Repository.Infrastructure;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bcrypt = BCrypt.Net.BCrypt;
namespace Repository.Repository
{
    enum CustomerStatus
    {
        AVAILABLE = 1,
        DISABLE = 2,
    }
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly BookSellingContext _context;
        public AccountRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            var accounts = new List<Account>();
            try
            {
                accounts = await _context.Accounts.Include(a => a.Customer).ToListAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return accounts;
        }

        public async Task<Account> SignIn(Account account)
        {
            Console.WriteLine("Called");
            Account returnAccount = new Account();
            try
            {

                var existingAccount = await _context.Accounts.Include(a => a.Customer).SingleOrDefaultAsync(a => a.Email == account.Email);
                if (existingAccount != null && Bcrypt.Verify(account.Password, existingAccount.Password))
                {
                    if (existingAccount.Customer!.Status != (int)CustomerStatus.AVAILABLE)
                    {

                    }
                    else
                    {
                        Console.WriteLine("hehe");
                        returnAccount.Email = account.Email;
                        returnAccount.Password = account.Password;
                        returnAccount.RoleId = account.RoleId;
                        returnAccount.Customer = existingAccount.Customer;
                    }

                }
                else
                {
                    // Login failed
                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return returnAccount;
        }

        public async Task SignUp(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
