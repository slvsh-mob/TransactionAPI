using TransactionAPI.Contracts.Transactions;
using TransactionAPI.ServiceErrors;
using ErrorOr;

namespace TransactionAPI.Models;

public class Transaction
{
    public Guid OrderID { get; }
    public DateTime Placed { get; }
    public float Total { get; }
    public string Status { get; }
    public string Customer { get; }
    public string Device { get; }
    public DateTime LastModified { get; }

    private Transaction(
        Guid orderID,
        DateTime placed,
        float total,
        string status,
        string customer,
        string device,
        DateTime lastModified
    )
    {
        OrderID = orderID;
        Placed = placed;
        Total = total;
        Status = status;
        Customer = customer;
        Device = device;
        LastModified = lastModified;
    }

    public static ErrorOr<Transaction> Create(
        float total,
        string customer,
        string device,
        Guid? orderID = null)
    {
        List<Error> errors = new();

        //Add incoming information checking here if needed
        //Check if the Total is larger than 0
        if (total is < 0)
        {
            errors.Add(Errors.Transaction.InvalidTotal);
        }

        if (errors.Count > 0)
        {
            return errors;
        }

        return new Transaction(
            orderID ?? Guid.NewGuid(),
            DateTime.UtcNow,
            total,
            "pending",
            customer,
            device,
            DateTime.UtcNow
        );
    }

    public static ErrorOr<Transaction> From(CreateTransactionRequest request)
    {
        return Create(
            request.Total,
            request.Customer,
            request.Device
        );
    }
}