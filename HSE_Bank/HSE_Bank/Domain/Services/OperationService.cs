using HSE_Bank.Domain.Models;

namespace HSE_Bank.Domain.Services;

public class OperationService
    {
        private readonly List<Operation> _operations = new();

        public void CreateOperation(string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId, int userId)
        {
            var operation = new Operation
            {
                Id = _operations.Count + 1,
                Type = type,
                BankAccountId = bankAccountId,
                Amount = amount,
                Date = date,
                Description = description,
                CategoryId = categoryId,
                UserId = userId
            };
            _operations.Add(operation);
            Console.WriteLine($"Created operation: {operation.Type} of {operation.Amount} on {operation.Date}");
        }

        public void UpdateOperation(int operationId, string type, decimal amount, DateTime date, string description, int categoryId)
        {
            var operation = _operations.FirstOrDefault(o => o.Id == operationId);
            if (operation != null)
            {
                operation.Type = type;
                operation.Amount = amount;
                operation.Date = date;
                operation.Description = description;
                operation.CategoryId = categoryId;
                Console.WriteLine($"Updated operation: {operation.Type} of {operation.Amount} on {operation.Date}");
            }
            else
            {
                Console.WriteLine("Operation not found.");
            }
        }

        public void DeleteOperation(int operationId)
        {
            var operation = _operations.FirstOrDefault(o => o.Id == operationId);
            if (operation != null)
            {
                _operations.Remove(operation);
                Console.WriteLine($"Deleted operation: {operation.Type} of {operation.Amount} on {operation.Date}");
            }
            else
            {
                Console.WriteLine("Operation not found.");
            }
        }

        public List<Operation> GetOperationsByUser(int userId)
        {
            return _operations.Where(o => o.UserId == userId).ToList();
        }
    }