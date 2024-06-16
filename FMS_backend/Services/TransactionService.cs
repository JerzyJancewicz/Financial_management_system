using FMS_backend.Repositories;

namespace FMS_backend.Services
{

    public interface ITransactionService 
    {

    }
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _repository;

        public TransactionService(ITransactionRepository repository)
        {
            _repository = repository;
        }



    }
}
