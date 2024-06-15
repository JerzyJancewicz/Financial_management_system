using FMS_backend.Models.FirmF;
using FMS_backend.Models.UserF;

namespace FMS_backend.Models.BankOperationF
{
    public class Receipt : BankOperation
    {
        public Types Type { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; } = new Invoice();

        public HashSet<Tax> Taxes { get; set; } = new HashSet<Tax>();

        public int FirmId { get; set; }
        public Firm Firm { get; set; } = new Firm();

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }= new Employee();
    }
}
