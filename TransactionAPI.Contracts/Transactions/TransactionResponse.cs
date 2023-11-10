namespace TransactionAPI.Contracts.Transactions;

public record TransactionResponse(
    Guid OrderID,
    DateTime Placed,
    float Amount,
    string Status,
    string Customer,
    string Device,
    DateTime LastModified
);