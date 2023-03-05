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
using System.Net.Mail;
namespace Repository.Repository
{
    public enum CustomerStatus
    {
        AVAILABLE = 1,
        DISABLE = 2,
    }
    public enum RoleId
    {
        Admin = 1,
        Customer = 2,
    }
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly BookSellingContext _context;

        public AccountRepository(BookSellingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Account?> FindAccountByEmail(String email)
        {
            var account = new Account();
            try
            {
                account = await _context.Accounts.Include(a => a.Customer).FirstOrDefaultAsync(a => a.Email == email);
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return account;
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

        public async Task<(IEnumerable<Account> accounts, int totalPages)> SearchAccountsWithPagination(string orderBy, string status, int page, int pageSize, string query)
        {
            var accounts = new List<Account>();
            int totalPages = 0;
            try
            {
                accounts = await _context.Accounts
                            .Include(a => a.Customer)                        
                            .Where((a => a.Email.Contains(query) 
                            || a.Customer.Name.Contains(query) 
                            && a.RoleId != (int)RoleId.Admin))                          
                            .ToListAsync();
                totalPages = accounts.Count();
                
            }
            catch (Exception)
            {
                throw new Exception();
            }
            return (PaginatedList<Account>.Create(accounts.AsQueryable(), page, pageSize), totalPages);
        }
        public int CountData()
        {
            return _context.Accounts.Include(a => a.Customer).Where(a => a.Customer!.Status != (int)CustomerStatus.DISABLE).Count();
        }
        public async Task SendConfirmationMail()
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress("glacier.hostel@gmail.com");
                message.To.Add(new MailAddress("buiminhkhoa2706@gmail.com"));
                message.Subject = "Your email subject";
                message.Body = "Your email message body";
                message.Priority = MailPriority.High;
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new System.Net.NetworkCredential("glacier.hostel@gmail.com", "iimtervacdxzaxsj");
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<Account> SignIn(Account account)
        {

            Account returnAccount = new Account();
            try
            {

                var existingAccount = await _context.Accounts.Include(a => a.Customer).SingleOrDefaultAsync(a => a.Email == account.Email);
                if (existingAccount != null && Bcrypt.Verify(account.Password, existingAccount.Password))
                {      
                        returnAccount.Email = existingAccount.Email;
                        returnAccount.Password = existingAccount.Password;
                        returnAccount.RoleId = existingAccount.RoleId;
                        returnAccount.Customer = existingAccount.Customer;
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
            try
            {
                account.RoleId = (int)RoleId.Customer;
                account.Password = Bcrypt.HashPassword(account.Password);
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateException ex)
            {
                var innerException = ex.InnerException;
                Console.WriteLine(innerException);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DisableAccount(int accountId)
        {
            try
            {
                var account = await _context.Accounts.Include(a => a.Customer).SingleOrDefaultAsync(a => a.AccountId == accountId);
                if(account != null)
                {
                    account.Customer!.Status = (int)CustomerStatus.DISABLE;
                }
                _context.Update(account);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        public async Task<Customer> UpdateAccount(Customer updatedCustomer)
        {

            try
            {
                updatedCustomer.Status =(int) CustomerStatus.AVAILABLE;
                //account = await FindAccountByEmail(email);
                _context.Customers.Entry(updatedCustomer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                Console.WriteLine("Success");
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return updatedCustomer;
        }
    }
}
