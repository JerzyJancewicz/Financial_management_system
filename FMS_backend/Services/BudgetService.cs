using AutoMapper;
using FMS_backend.DTOs;
using FMS_backend.Models.TransactionF;
using FMS_backend.Repositories;

namespace FMS_backend.Services
{
    public interface IBudgetService
    {
        public Task<List<BudgetDto>> GetAllBudgets();
        public Task<BudgetDto> GetBudgetById(int id);
        public Task<TransactionDto> GetTransactionById(int id);
        public Task AddTransaction(TransactionDto transaction, int userId, int budgetId);
    }
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _repository;
        private readonly IMapper _mapper;

        public BudgetService(IBudgetRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task AddTransaction(TransactionDto transaction, int userId, int budgetId)
        {
            var dto = _mapper.Map<Transaction>(transaction);
            await _repository.AddTransaction(dto, userId, budgetId);
        }

        public async Task<List<BudgetDto>> GetAllBudgets()
        {
            var budgets = await _repository.GetAllBudgets();
            var dtos = _mapper.Map<List<BudgetDto>>(budgets);
            return dtos;
        }

        public async Task<BudgetDto> GetBudgetById(int id)
        {
            var budget = await _repository.GetBudget(id);
            var dto = _mapper.Map<BudgetDto> (budget);
            return dto;
        }

        public async Task<TransactionDto> GetTransactionById(int id)
        {
            var transaction = await _repository.GetTransaction(id);
            var dto = _mapper.Map<TransactionDto>(transaction);
            return dto;
        }
    }
}
