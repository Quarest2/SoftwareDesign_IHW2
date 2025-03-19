namespace HSE_Bank.Domain.Models;

public class Operation
{
    public int Id { get; set; }
    public string Type { get; set; } 
    public int BankAccountId { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
}