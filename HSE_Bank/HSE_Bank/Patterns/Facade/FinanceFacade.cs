using HSE_Bank.Domain.Models;
using HSE_Bank.Domain.Services;

namespace HSE_Bank.Patterns.Facade;

public class FinanceFacade
    {
        private readonly BankAccountService _bankAccountService;
        private readonly CategoryService _categoryService;
        private readonly OperationService _operationService;
        private readonly List<User> _users = new();

        public FinanceFacade()
        {
            _bankAccountService = new BankAccountService();
            _categoryService = new CategoryService();
            _operationService = new OperationService();
        }

        public void CreateUser(string username)
        {
            var user = new User { Id = _users.Count + 1, Username = username };
            _users.Add(user);
            Console.WriteLine($"User '{username}' created with ID {user.Id}");
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public void CreateBankAccount(string name, decimal initialBalance, int userId)
        {
            _bankAccountService.CreateAccount(name, initialBalance, userId);
        }

        public void UpdateBankAccount(int accountId, string name, decimal balance)
        {
            _bankAccountService.UpdateAccount(accountId, name, balance);
        }

        public void DeleteBankAccount(int accountId)
        {
            _bankAccountService.DeleteAccount(accountId);
        }

        public void CreateCategory(string type, string name, int userId)
        {
            _categoryService.CreateCategory(type, name, userId);
        }

        public void UpdateCategory(int categoryId, string type, string name)
        {
            _categoryService.UpdateCategory(categoryId, type, name);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryService.DeleteCategory(categoryId);
        }

        public void CreateOperation(string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId, int userId)
        {
            _operationService.CreateOperation(type, bankAccountId, amount, date, description, categoryId, userId);
        }

        public void UpdateOperation(int operationId, string type, decimal amount, DateTime date, string description, int categoryId)
        {
            _operationService.UpdateOperation(operationId, type, amount, date, description, categoryId);
        }

        public void DeleteOperation(int operationId)
        {
            _operationService.DeleteOperation(operationId);
        }

        public List<BankAccount> GetUserBankAccounts(int userId)
        {
            return _bankAccountService.GetAccountsByUser(userId);
        }

        public List<Category> GetUserCategories(int userId)
        {
            return _categoryService.GetCategoriesByUser(userId);
        }

        public List<Operation> GetUserOperations(int userId)
        {
            return _operationService.GetOperationsByUser(userId);
        }
    }