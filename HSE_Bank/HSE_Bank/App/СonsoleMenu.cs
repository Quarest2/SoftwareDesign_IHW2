using HSE_Bank.Patterns.Facade;

namespace HSE_Bank.App;

using System;

public class ConsoleMenu
    {
        private readonly FinanceFacade _facade;

        public ConsoleMenu(FinanceFacade facade)
        {
            _facade = facade;
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Finance App ===");
                Console.WriteLine("1. Create User");
                Console.WriteLine("2. Create Bank Account");
                Console.WriteLine("3. Edit Bank Account");
                Console.WriteLine("4. Delete Bank Account");
                Console.WriteLine("5. Create Category");
                Console.WriteLine("6. Edit Category");
                Console.WriteLine("7. Delete Category");
                Console.WriteLine("8. Create Operation");
                Console.WriteLine("9. Edit Operation");
                Console.WriteLine("10. Delete Operation");
                Console.WriteLine("11. Show User Data");
                Console.WriteLine("12. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateUser();
                        break;
                    case "2":
                        CreateBankAccount();
                        break;
                    case "3":
                        EditBankAccount();
                        break;
                    case "4":
                        DeleteBankAccount();
                        break;
                    case "5":
                        CreateCategory();
                        break;
                    case "6":
                        EditCategory();
                        break;
                    case "7":
                        DeleteCategory();
                        break;
                    case "8":
                        CreateOperation();
                        break;
                    case "9":
                        EditOperation();
                        break;
                    case "10":
                        DeleteOperation();
                        break;
                    case "11":
                        ShowUserData();
                        break;
                    case "12":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private void CreateUser()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();

            _facade.CreateUser(username);
        }

        private void CreateBankAccount()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter account name: ");
            var name = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            if (decimal.TryParse(Console.ReadLine(), out var balance))
            {
                _facade.CreateBankAccount(name, balance, user.Id);
                Console.WriteLine("Bank account created successfully!");
            }
            else
            {
                Console.WriteLine("Invalid balance. Please enter a valid number.");
            }
        }

        private void EditBankAccount()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out var accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            Console.Write("Enter new account name: ");
            var name = Console.ReadLine();

            Console.Write("Enter new balance: ");
            if (!decimal.TryParse(Console.ReadLine(), out var balance))
            {
                Console.WriteLine("Invalid balance.");
                return;
            }

            _facade.UpdateBankAccount(accountId, name, balance);
        }

        private void DeleteBankAccount()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter account ID: ");
            if (!int.TryParse(Console.ReadLine(), out var accountId))
            {
                Console.WriteLine("Invalid account ID.");
                return;
            }

            _facade.DeleteBankAccount(accountId);
        }

        private void CreateCategory()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter category type (Income/Expense): ");
            var type = Console.ReadLine();

            Console.Write("Enter category name: ");
            var name = Console.ReadLine();

            _facade.CreateCategory(type, name, user.Id);
            Console.WriteLine("Category created successfully!");
        }

        private void EditCategory()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            Console.Write("Enter new category type (Income/Expense): ");
            var type = Console.ReadLine();

            Console.Write("Enter new category name: ");
            var name = Console.ReadLine();

            _facade.UpdateCategory(categoryId, type, name);
        }

        private void DeleteCategory()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            _facade.DeleteCategory(categoryId);
        }

        private void CreateOperation()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter operation type (Income/Expense): ");
            var type = Console.ReadLine();

            Console.Write("Enter bank account ID: ");
            if (!int.TryParse(Console.ReadLine(), out var bankAccountId))
            {
                Console.WriteLine("Invalid bank account ID.");
                return;
            }

            Console.Write("Enter amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Console.Write("Enter date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var date))
            {
                Console.WriteLine("Invalid date.");
                return;
            }

            Console.Write("Enter description (optional): ");
            var description = Console.ReadLine();

            Console.Write("Enter category ID: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            _facade.CreateOperation(type, bankAccountId, amount, date, description, categoryId, user.Id);
            Console.WriteLine("Operation created successfully!");
        }

        private void EditOperation()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter operation ID: ");
            if (!int.TryParse(Console.ReadLine(), out var operationId))
            {
                Console.WriteLine("Invalid operation ID.");
                return;
            }

            Console.Write("Enter new operation type (Income/Expense): ");
            var type = Console.ReadLine();

            Console.Write("Enter new amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out var amount))
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Console.Write("Enter new date (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out var date))
            {
                Console.WriteLine("Invalid date.");
                return;
            }

            Console.Write("Enter new description (optional): ");
            var description = Console.ReadLine();

            Console.Write("Enter new category ID: ");
            if (!int.TryParse(Console.ReadLine(), out var categoryId))
            {
                Console.WriteLine("Invalid category ID.");
                return;
            }

            _facade.UpdateOperation(operationId, type, amount, date, description, categoryId);
        }

        private void DeleteOperation()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.Write("Enter operation ID: ");
            if (!int.TryParse(Console.ReadLine(), out var operationId))
            {
                Console.WriteLine("Invalid operation ID.");
                return;
            }

            _facade.DeleteOperation(operationId);
        }

        private void ShowUserData()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            var user = _facade.GetUserByUsername(username);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                return;
            }

            Console.WriteLine($"\n=== Data for user '{username}' ===");

            var accounts = _facade.GetUserBankAccounts(user.Id);
            Console.WriteLine("\nBank Accounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"- ID: {account.Id}, Name: {account.Name}, Balance: {account.Balance}");
            }

            var categories = _facade.GetUserCategories(user.Id);
            Console.WriteLine("\nCategories:");
            foreach (var category in categories)
            {
                Console.WriteLine($"- ID: {category.Id}, Name: {category.Name}, Type: {category.Type}");
            }

            var operations = _facade.GetUserOperations(user.Id);
            Console.WriteLine("\nOperations:");
            foreach (var operation in operations)
            {
                Console.WriteLine($"- ID: {operation.Id}, Type: {operation.Type}, Amount: {operation.Amount}, Date: {operation.Date}, Description: {operation.Description}");
            }
        }
    }