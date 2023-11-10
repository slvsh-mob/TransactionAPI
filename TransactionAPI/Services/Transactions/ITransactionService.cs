using TransactionAPI.Models;
using ErrorOr;

namespace TransactionAPI.Services.Transactions;

public interface ITransactionService
{
    ErrorOr<Created> CreateTransaction(Transaction transaction);
    ErrorOr<Transaction> GetTransaction(Guid orderID);
}