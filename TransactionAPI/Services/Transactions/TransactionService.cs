using TransactionAPI.Models;
using TransactionAPI.ServiceErrors;
using ErrorOr;

namespace TransactionAPI.Services.Transactions;

public class TransactionService : ITransactionService
{
    //Currently stores in system memory, need to look at persisting data here to database
    private static readonly Dictionary<Guid, Transaction> _transactions = new();

    public ErrorOr<Created> CreateTransaction(Transaction transaction)
    {
        _transactions.Add(transaction.OrderID, transaction);

        return Result.Created;
    }

    public ErrorOr<Transaction> GetTransaction(Guid orderID)
    {
        if (_transactions.TryGetValue(orderID, out var transaction))
        {
            return transaction;
        }

        return Errors.Transaction.NotFound;
    }
}