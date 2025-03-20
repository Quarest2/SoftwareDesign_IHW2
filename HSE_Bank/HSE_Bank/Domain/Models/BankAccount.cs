namespace HSE_Bank.Domain.Models;

public class BankAccount
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Balance { get; set; }
    
    public int UserId { get; set; }
}