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
            Console.WriteLine("1. Create Bank Account");
            Console.WriteLine("2. Create Category");
            Console.WriteLine("3. Create Operation");
            Console.WriteLine("4. Show Analytics");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateBankAccount();
                    break;
                case "2":
                    CreateCategory();
                    break;
                case "3":
                    CreateOperation();
                    break;
                case "4":
                    ShowAnalytics();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    private void CreateBankAccount()
    {
        Console.Write("Enter account name: ");
        var name = Console.ReadLine();

        Console.Write("Enter initial balance: ");
        if (decimal.TryParse(Console.ReadLine(), out var balance))
        {
            _facade.CreateBankAccount(name, balance);
            Console.WriteLine("Bank account created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid balance. Please enter a valid number.");
        }
    }

    private void CreateCategory()
    {
        Console.Write("Enter category type (Income/Expense): ");
        var type = Console.ReadLine();

        Console.Write("Enter category name: ");
        var name = Console.ReadLine();

        _facade.CreateCategory(type, name);
        Console.WriteLine("Category created successfully!");
    }

    private void CreateOperation()
    {
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

        _facade.CreateOperation(type, bankAccountId, amount, date, description, categoryId);
        Console.WriteLine("Operation created successfully!");
    }

    private void ShowAnalytics()
    {
        Console.WriteLine("\n=== Analytics ===");
        Console.WriteLine("1. Show total balance");
        Console.WriteLine("2. Show operations by category");
        Console.Write("Select an option: ");

        var choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                ShowTotalBalance();
                break;
            case "2":
                ShowOperationsByCategory();
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    private void ShowTotalBalance()
    {
        Console.WriteLine("Total balance: $1000");
    }

    private void ShowOperationsByCategory()
    {
        // Пример: Группировка операций по категориям (заглушка)
        Console.WriteLine("Operations by category:");
        Console.WriteLine("- Category 1: $500");
        Console.WriteLine("- Category 2: $300");
    }
}