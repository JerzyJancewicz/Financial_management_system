using FMS_backend.DTOs;
using FMS_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FMS_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FmsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public FmsController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBudgets()
        {
            var budgets = await _budgetService.GetAllBudgets();
            if (budgets.IsNullOrEmpty()) 
            {
                return NotFound();
            }
            return Ok(budgets);
        }

        [HttpGet("budget/{Id}")]
        public async Task<IActionResult> GetBudget(int Id)
        {
            var budget = await _budgetService.GetBudgetById(Id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        [HttpGet("transaction/{Id}")]
        public async Task<IActionResult> GetTransaction(int Id)
        {
            var transaction = await _budgetService.GetTransactionById(Id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost("addTransaction/{userId}/{budgetId}")]
        public async Task<IActionResult> CreateTransaction(TransactionDto transaction, int userId, int budgetId)
        {
            if (transaction == null) 
            {
                return BadRequest();
            }
            if (transaction.Amount < 0) 
            {
                return BadRequest("Amount can not be below 0");
            }
            await _budgetService.AddTransaction(transaction, userId, budgetId);
            return Created("", "");
        }
    }
}
