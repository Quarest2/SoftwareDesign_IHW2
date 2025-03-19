using HSE_Bank.Patterns.Command;
using HSE_Bank.Patterns.Facade;

namespace HSE_Bank.App;

internal static class Program
{
    static void Main(string[] args)
    {
        var facade = new FinanceFacade();
        var menu = new ConsoleMenu(facade);

        menu.ShowMenu();
    }
}