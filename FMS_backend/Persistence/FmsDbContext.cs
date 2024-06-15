using FMS_backend.Models.BankOperationF;
using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.FirmF;
using FMS_backend.Models.TransactionF;
using FMS_backend.Models.TransactionF.Types;
using FMS_backend.Models.UserF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FMS_backend.Persistence
{
    public class FmsDbContext : DbContext
    {

        public FmsDbContext(DbContextOptions<FmsDbContext> options) : base(options) { }

        public DbSet<Firm> Firms { get; set; }

        public DbSet<BankOperation> BankOperations { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Tax> Taxes { get; set; }

        public DbSet<FinancialPlan> FinancialPlans { get; set; }
        public DbSet<FinancialPrediction> FinancialPredictions { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<FinancialPerson> FinancialPeople { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ChiefOfFinance> ChiefOfFinance { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<ContactDetails> ContactDetails { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            FirmMb(modelBuilder);
            BankOperationMb(modelBuilder);
            FinancialOperationMb(modelBuilder);
            UserMb(modelBuilder);
            TransactionMb(modelBuilder);
        }

        private void FirmMb(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Firm>()
                .HasDiscriminator<TypeOfCustomer>("TypeOfCustomer")
                .HasValue<Firm>(TypeOfCustomer.CLIENT)
                .HasValue<Firm>(TypeOfCustomer.DELIVERER);

            modelBuilder.Entity<Firm>(entity =>
            {
                entity.HasKey(f => f.Id);

                entity.HasMany(f => f.Receipts)
                    .WithOne(r => r.Firm)
                    .HasForeignKey(r => r.FirmId);

                entity.Property(f => f.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(f => f.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(f => f.NIP)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasIndex(f => f.NIP)
                    .IsUnique();

                entity.Property(f => f.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(f => f.Type)
                    .IsRequired()
                    .HasConversion<string>()
                    .IsRequired();
            });
        }

        private void BankOperationMb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankOperation>(entity =>
            {
                entity.ToTable("BankOperation");
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.FinancialPerson)
                    .WithMany(f => f.BankOperations)
                    .HasForeignKey(e => e.FinancialPersonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.Property(e => e.NetAmount)
                    .IsRequired();

                entity.Property(e => e.GrossAmount)
                    .IsRequired();

                entity.Property(e => e.Date)
                    .IsRequired();

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasBaseType<BankOperation>();
                entity.ToTable("Receipt");

                entity.HasOne(r => r.Invoice)
                    .WithMany(i => i.Receipts)
                    .HasForeignKey(r => r.InvoiceId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(r => r.Taxes)
                    .WithMany(t => t.Receipts);

                entity.HasOne(r => r.Firm)
                    .WithMany(f => f.Receipts)
                    .HasForeignKey(r => r.FirmId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(r => r.Employee)
                    .WithMany(e => e.Receipts)
                    .HasForeignKey(r => r.EmployeeId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                entity.Property(r => r.Type)
                    .HasConversion<string>()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tax>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Receipts)
                    .WithMany(r => r.Taxes);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rate)
                    .IsRequired();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasBaseType<BankOperation>();
                entity.ToTable("Invoice");

                entity.HasMany(I => I.Receipts)
                    .WithOne(r => r.Invoice)
                    .HasForeignKey(r => r.InvoiceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.Property(I => I.Seller)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(I => I.Buyer)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasMany(e => e.Receipts)
                    .WithOne(r => r.Employee)
                    .HasForeignKey(r => r.EmployeeId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.HasOne(e => e.ContactDetails)
                    .WithOne(ct => ct.Employee)
                    .HasForeignKey<ContactDetails>(cd => cd.EmployeeId)
                    .IsRequired();
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(pn => pn.ContactDetails)
                    .WithMany(cd => cd.PhoneNumbers)
                    .HasForeignKey(pn => pn.ContactDetailsId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                entity.Property(pn => pn.Number)
                    .HasMaxLength(12)
                    .IsRequired();
            });

            modelBuilder.Entity<ContactDetails>(entity =>
            {
            entity.HasKey(e => e.Id);

            entity.HasMany(cd => cd.PhoneNumbers)
                .WithOne(cn => cn.ContactDetails)
                .HasForeignKey(cd => cd.ContactDetailsId)
                .IsRequired();

            entity.HasOne(ct => ct.Employee)
                .WithOne(pn => pn.ContactDetails)
                .HasForeignKey<Employee>(em => em.ContactDetailsId)
                .IsRequired();
            });
        }
        private void FinancialOperationMb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinancialPlan>(entity =>
            {
                entity.ToTable("FinancialPlan");
                entity.HasKey(fp => fp.Id);

                entity.HasOne(fp => fp.ChiefOfFinance)
                    .WithMany(ch => ch.FinancialPlans)
                    .HasForeignKey(fp => fp.ChiefOfFinanceId)
                    .IsRequired();

                entity.ConfigureFinancialOperation();

                entity.Property(fp => fp.RiskValue)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(fp => fp.PotentialIncome)
                    .IsRequired();

                entity.Property(fp => fp.IsRealised)
                    .IsRequired();               
            });

            modelBuilder.Entity<FinancialPrediction>(entity =>
            {
                entity.ToTable("FinancialPrediction");
                entity.HasKey(fp => fp.Id);

                entity.HasOne(fp => fp.FinancialPerson)
                    .WithMany(fpe => fpe.FinancialPredictions)
                    .HasForeignKey(fp => fp.FinancialPersonId)
                    .IsRequired();

                entity.ConfigureFinancialOperation();

                entity.Property(fp => fp.Profit)
                    .IsRequired();
            });

            modelBuilder.Entity<FinancialReport>(entity =>
            {
                entity.ToTable("FinancialReport");
                entity.HasKey(fr => fr.Id);

                entity.HasOne(fr => fr.FinancialPerson)
                      .WithMany(fp => fp.FinancialReports)
                      .HasForeignKey(fr => fr.FinancialPersonId)
                      .IsRequired();

                entity.ConfigureFinancialOperation();

                entity.Property(fr => fr.Turnover)
                      .IsRequired();
            });
        }

        private void UserMb(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(u => u.Id);

                entity.HasMany(u => u.Transactions)
                      .WithOne(tr => tr.User)
                      .HasForeignKey(tr => tr.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.ConfigureUser();
            });

            modelBuilder.Entity<FinancialPerson>(entity =>
            {
                entity.ToTable("FinancialPerson");

                entity.HasMany(fp => fp.BankOperations)
                    .WithOne(bo => bo.FinancialPerson)
                    .HasForeignKey(bo => bo.FinancialPersonId);

                entity.HasMany(fp => fp.FinancialPredictions)
                    .WithOne(fp => fp.FinancialPerson)
                    .HasForeignKey(fp => fp.FinancialPersonId);

                entity.HasMany(fp => fp.FinancialReports)
                    .WithOne(fr => fr.FinancialPerson)
                    .HasForeignKey(fr => fr.FinancialPersonId);

                entity.ConfigureUser();

                entity.Property(fp => fp.FinancialPersonRoles)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(r => Enum.Parse<SpecializationType>(r)).ToList())
                    .IsRequired();

                entity.Property(fp => fp.Specialization)
                    .HasMaxLength(50);
                entity.Property(fp => fp.Rank)
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<ChiefOfFinance>(entity =>
            {
                entity.ToTable("ChiefOfFinance");

                entity.HasMany(chof => chof.FinancialPlans)
                    .WithOne(fp => fp.ChiefOfFinance)
                    .HasForeignKey(fp => fp.ChiefOfFinanceId);

                entity.ConfigureUser();

                entity.Property(e => e.DateOfEmployment)
                    .IsRequired();

                entity.Property(e => e.FinancialScore)
                    .IsRequired();

            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.ConfigureUser();
            });
        }

        private void TransactionMb(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");
                entity.HasKey(t => new { t.BudgetId, t.UserId });

                entity.Property(t => t.BudgetId)
                    .IsRequired()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

                entity.Property(t => t.UserId)
                    .IsRequired()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);

                entity.HasOne(t => t.Budget)
                    .WithMany(b => b.Transactions)
                    .HasForeignKey(t => t.BudgetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(t => t.User)
                    .WithMany(u => u.Transactions)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.Property(t => t.OperationDate)
                    .IsRequired();

                entity.Property(t => t.Amount)
                    .IsRequired();

                entity.Property(t => t.TransactionTypes)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(t => Enum.Parse<TransactionType>(t)).ToList())
                    .IsRequired();

                entity.Property(t => t.StatusTypes)
                    .HasConversion(
                        v => string.Join(',', v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                            .Select(s => Enum.Parse<StatusType>(s)).ToList())
                    .IsRequired();
            });

            modelBuilder.Entity<Budget>(entity =>
            {
                entity.ToTable("Budget");
                entity.HasKey(b => b.Id);

                entity.HasMany(b => b.Transactions)
                      .WithOne(t => t.Budget)
                      .OnDelete(DeleteBehavior.Cascade)
                      .HasForeignKey(t => t.BudgetId);

                entity.HasMany(b => b.BankAccounts)
                      .WithOne(ba => ba.Budget)
                      .HasForeignKey(ba => ba.BudgetId)
                      .OnDelete(DeleteBehavior.Cascade)
                      .IsRequired();

                entity.Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(b => b.ProjectName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(b => b.Balance)
                    .IsRequired();

                entity.Property(b => b.Description)
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<BankAccount>(entity =>
            {
                entity.ToTable("BankAccount");
                entity.HasKey(ba => ba.AccountNumber);

                entity.HasOne(ba => ba.Budget)
                    .WithMany(b => b.BankAccounts)
                    .HasForeignKey(ba => ba.BudgetId)
                    .IsRequired();

                entity.Property(ba => ba.BankName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(ba => ba.Balance)
                    .IsRequired();

                entity.Property(ba => ba.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
