using FMS_backend.Models.FirmF;
using FMS_backend.Models.UserF;

namespace FMS_backend.Models.BankOperationF
{
    public class Receipt : BankOperation
    {
        public Types Type { get; set; }

        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public HashSet<Tax> Taxes { get; set; }

        public string FirmId { get; set; } = string.Empty;
        public Firm Firm { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
