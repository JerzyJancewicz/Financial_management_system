using FMS_backend.Models.FirmF;
using FMS_backend.Models.UserF;

namespace FMS_backend.Models.BankOperationF
{
    public class Receipt : BankOperation
    {
        public List<Types> TransactionTypes { get; set; } = new List<Types>();
        public Invoice Invoice { get; set; } = new Invoice();
        public HashSet<Tax> Taxes { get; set; } = new HashSet<Tax>();
        public Firm Firm { get; set; } = new Firm();
        public Employee Employee { get; set; }= new Employee();
    }
}
