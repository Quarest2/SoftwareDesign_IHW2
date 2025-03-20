using HSE_Bank.Patterns.Facade;

namespace HSE_Bank.Patterns.Command;

public class CreateBankAccountCommand : ICommand
{
    private readonly FinanceFacade _facade;
    private readonly string _name;
    private readonly decimal _initialBalance;
    private readonly int _userId;

    public CreateBankAccountCommand(FinanceFacade facade, string name, decimal initialBalance, int userId)
    {
        _facade = facade;
        _name = name;
        _initialBalance = initialBalance;
        _userId = userId;
    }

    public void Execute()
    {
        _facade.CreateBankAccount(_name, _initialBalance, _userId);
        Console.WriteLine($"Bank account '{_name}' created successfully for user ID {_userId}.");
    }
}