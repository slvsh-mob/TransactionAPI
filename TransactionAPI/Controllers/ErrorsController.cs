using Microsoft.AspNetCore.Mvc;

namespace TransactionAPI.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}