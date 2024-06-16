using FMS_backend.Models.TransactionF;
using FMS_backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FMS_backend.Repositories
{
    public interface IBudgetRepository
    {
        public Task<List<Budget>> GetAllBudgets();
        public Task<Budget?> GetBudget(int id);
        public Task<Transaction?> GetTransaction(int id);
        public Task AddTransaction(Transaction transaction, int userId, int budgetId);
    }
    public class BudgetRepository : IBudgetRepository
    {
        private readonly FmsDbContext _context;

        public BudgetRepository(FmsDbContext context)
        {
            _context = context;
        }

        public async Task AddTransaction(Transaction transaction, int userId, int budgetId)
        {
            if (transaction != null) 
            {
                transaction.OperationDate = DateTime.UtcNow;
                transaction.BudgetId = budgetId;
                transaction.UserId = userId;
                await _context.Transactions.AddAsync(transaction);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Budget>> GetAllBudgets()
        {
            var budgets = await _context.Budgets.ToListAsync();
            foreach (var budget in budgets)
            {
                var bu = await _context.Transactions.Where(e => e.BudgetId == budget.Id).ToListAsync();
                budget.Transactions = new HashSet<Transaction>(bu);

                var ba = await _context.BankAccounts.Where(e => e.BudgetId == budget.Id).ToListAsync();
                budget.BankAccounts = new HashSet<BankAccount>(ba);
            }
            return budgets;
        }

        public async Task<Budget?> GetBudget(int id)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(e => e.Id == id);
            if (budget != null) 
            {
                var bu = await _context.Transactions.Where(e => e.BudgetId == budget.Id).ToListAsync();
                var ba = await _context.BankAccounts.Where(e => e.BudgetId == budget.Id).ToListAsync();
            }
            return budget;
        }

        public async Task<Transaction?> GetTransaction(int id)
        {
            var transaction = await _context.Transactions.FirstOrDefaultAsync(e => e.Id == id);
            if (transaction != null)
            {
                var user = await _context.Users.FirstOrDefaultAsync(e => e.Id == transaction.UserId);

                if (user != null)
                transaction.User = user;
            }
            return transaction;
        }
    }
}
