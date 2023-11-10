using ErrorOr;

namespace TransactionAPI.ServiceErrors;
public static class Errors
{
    public static class Transaction
    {
        public static Error NotFound => Error.NotFound(
            code: "Transaction.NotFound",
            description: "Given Transaction ID Not Found"
        );

        public static Error InvalidTotal => Error.Validation(
            code: "Transaction.InvalidTotal",
            description: "The total value of the transaction needs to be larger than 0 dollars."
        );
    }
}