/*using FMS_backend.Models.BankOperationF;
using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.TransactionF;
using FMS_backend.Models.UserF;
using FMS_backend.Models.Employee;
using FMS_backend.Models.Firm;
using FMS_backend.Models.Admin;
using FMS_backend.Models.ChiefOfFinance;
using System;
using System.Threading.Tasks;
using FMS_backend.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FMS_backend.Data.Seed
{
    public class FmsSeeder
    {
        private readonly FmsDbContext _context;

        public FmsSeeder(FmsDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            SeedUsers();
            SeedFinancialPersons();
            SeedAdmins();
            //SeedChiefOfFinances();
            SeedEmployees();
            SeedBankAccounts();
            SeedBudgets();
            SeedBankAccounts();
            SeedTransactions();
            SeedFinancialOperations();
            SeedFinancialPlans();
            *//*SeedFinancialPredictions();
            SeedFinancialReports();
            SeedBankOperations();
            SeedInvoices();
            SeedReceipts();
            SeedTaxes();
            SeedFirms();*//*
            await _context.SaveChangesAsync(); // Save changes after seeding
        }

        private void SeedUsers()
        {
            _context.Users.AddRange(
                new User { Id = 1, Name = "John", Surname = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789" },
                new User { Id = 2, Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987654321" }
            );
        }
        private void SeedBudgets()
        {
            _context.Budgets.AddRange(
                new Budget { Id = 1, Name = "2024 Budget", ProjectName = "Project X", Balance = 10000.0 },
                new Budget { Id = 2, Name = "2024 Q2 Budget", ProjectName = "Project Y", Balance = 5000.0 }
            );
        }

        private void SeedFinancialPersons()
        {
            _context.FinancialPeople.AddRange(
                new FinancialPerson { Id = 1, NumberOfReports = 5, NumberOfPredictions = 3, Specialization = "Finance", Rank = "Senior", UserId = 1 },
                new FinancialPerson { Id = 2, NumberOfReports = 3, NumberOfPredictions = 2, Specialization = "Accounting", Rank = "Junior", UserId = 2 }
                // Add more financial persons as needed
            );
        }

        private void SeedAdmins()
        {
            _context.Admins.AddRange(
                new Admin { Id = 1, Name = "Admin1", Surname = "Admin1", Email = "admin1@example.com", PhoneNumber = "111111111" }
                // Add more admins as needed
            );
        }

        private void SeedChiefsOfFinance()
        {
            _context.ChiefOfFinance.AddRange(
                new ChiefOfFinance { Id = 1, Name = "Chief1", Surname = "Finance", Email = "chief1@example.com", PhoneNumber = "222222222" }
                // Add more chiefs of finance as needed
            );
        }

        private void SeedEmployees()
        {
            _context.Employees.AddRange(
                new Employee { Id = 1, Name = "Employee1", Surname = "EmployeeSur", Nickname = "Emplo"}
                // Add more employees as needed
            );
        }

        private void SeedBankAccounts()
        {
            _context.BankAccounts.AddRange(
                new BankAccount { Id = 1, BankName = "Bank A", AccountNumber = "ABC123", BudgetId = 1 },
                new BankAccount { Id = 2, BankName = "Bank B", AccountNumber = "XYZ789", BudgetId = 2 }
            );
        }

        private void SeedTransactions()
        {
            _context.Transactions.AddRange(
                new Transaction { OperationDate = DateTime.Now.AddDays(-5), Amount = 100.0, UserId = 1, BudgetId = 1 },
                new Transaction { OperationDate = DateTime.Now.AddDays(-3), Amount = 250.0, UserId = 2, BudgetId = 2 }
            );
        }

        private void SeedFinancialOperations()
        {
            _context.FinancialOperations.AddRange(
                new FinancialOperation { Id = 1, Name = "Financial Operation 1", DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(30), Income = 5000.0 }
                // Add more financial operations as needed
            );
        }

        private void SeedFinancialPlans()
        {
            _context.FinancialPlans.AddRange(
                new FinancialPlan { Id = 1, Name = "Financial Plan 1", DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(30), Income = 10000.0, RiskValue = 20, PotentialIncome = 12000.0, IsRealised = true, ChiefOfFinanceId = 1 }
            );
        }

        // Implement methods for seeding other entities: FinancialPredictions, FinancialReports, BankOperations, Invoices, Receipts, Taxes, Firms, etc.
    }
}
*/