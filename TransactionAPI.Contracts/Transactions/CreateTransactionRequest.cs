namespace TransactionAPI.Contracts.Transactions;

public record CreateTransactionRequest(
    float Total,
    string Customer,
    string Device
);