using TransactionAPI.Contracts.Transactions;
using TransactionAPI.Models;
using TransactionAPI.ServiceErrors;
using TransactionAPI.Services.Transactions;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace TransactionAPI.Controllers;

public class TransactionsController : ApiController
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost]
    public IActionResult CreateTransaction(CreateTransactionRequest request)
    {
        ErrorOr<Transaction> requestToTransactionResult = Transaction.From(request);

        if (requestToTransactionResult.IsError)
        {
            return Problem(requestToTransactionResult.Errors);
        }

        var transaction = requestToTransactionResult.Value;
        ErrorOr<Created> createTransactionResult = _transactionService.CreateTransaction(transaction);

        return createTransactionResult.Match(
            created => CreatedAtGetTransaction(transaction),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTransaction(Guid id)
    {
        ErrorOr<Transaction> getTransactionResult = _transactionService.GetTransaction(id);

        return getTransactionResult.Match(
            transaction => Ok(MapTransactionResponse(transaction)),
            errors => Problem(errors)
        );
    }

    private static TransactionResponse MapTransactionResponse(Transaction transaction)
    {
        return new TransactionResponse(
            transaction.OrderID,
            transaction.Placed,
            transaction.Total,
            transaction.Status,
            transaction.Customer,
            transaction.Device,
            transaction.LastModified
        );
    }

    private CreatedAtActionResult CreatedAtGetTransaction(Transaction transaction)
    {
        return CreatedAtAction(
            actionName: nameof(GetTransaction),
            routeValues: new { id = transaction.OrderID},
            value: MapTransactionResponse(transaction)
        );
    }
}