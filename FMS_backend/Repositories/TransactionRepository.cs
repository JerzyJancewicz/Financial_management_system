using FMS_backend.Persistence;

namespace FMS_backend.Repositories
{
    public interface ITransactionRepository 
    {

    }
    public class TransactionRepository : ITransactionRepository
    {
        private readonly FmsDbContext _context;

        public TransactionRepository(FmsDbContext context)
        {
            _context = context;
        }


    }
}
