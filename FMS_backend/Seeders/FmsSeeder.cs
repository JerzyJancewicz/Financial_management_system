using FMS_backend.Models.BankOperationF;
using FMS_backend.Models.FinancialOperationF;
using FMS_backend.Models.TransactionF;
using FMS_backend.Models.UserF;
using System;
using System.Threading.Tasks;
using FMS_backend.Persistence;
using Microsoft.EntityFrameworkCore;
using FMS_backend.Models.FirmF;

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
            SeedAdmins();

            SeedChiefsOfFinance();
            SeedEmployees();
            SeedFinancialPerson();

            SeedBudgets();
            SeedBankAccounts();
            SeedTransactions();
            SeedFinancialPlans();
            SeedFinancialPredictions();
            SeedFinancialReports();

            SeedBankOperations();
            SeedInvoices();
            SeedTaxes();
            SeedFirms();

            await _context.SaveChangesAsync();
        }

        private void SeedUsers()
        {
            if (!_context.Users.Any())
            {
                _context.Users.AddRange(
                    new User {Name = "John", Surname = "Doe", Email = "john.doe@example.com", PhoneNumber = "123456789" },
                    new User {Name = "Jane", Surname = "Smith", Email = "jane.smith@example.com", PhoneNumber = "987654321" }
                );
                _context.SaveChanges();
            }
        }
        private void SeedBudgets()
        {
            if (!_context.Budgets.Any())
            {
                var budgets = new List<Budget>
                {
                    new Budget { Name = "2024 Budget", ProjectName = "Project X", Balance = 10000.0 },
                    new Budget { Name = "2024 Q2 Budget", ProjectName = "Project Y", Balance = 5000.0, Description = "Example description for budget id 2" }
                };

                _context.Budgets.AddRange(budgets);
                _context.SaveChanges();
            }
        }

        private void SeedBankAccounts()
        {
            if (!_context.BankAccounts.Any())
            {
                var bankAccounts = new List<BankAccount>
                {
                    new BankAccount { BankName = "Bank A", AccountNumber = "ABC123", BudgetId = 1 },
                    new BankAccount { BankName = "Bank B", AccountNumber = "XYZ789", BudgetId = 2 }
                };

                _context.BankAccounts.AddRange(bankAccounts);
                _context.SaveChanges();
            }
        }

        private void SeedTransactions()
        {
            if (!_context.Transactions.Any())
            {
                var transactions = new List<Transaction>
                {
                    new Transaction { OperationDate = DateTime.Now.AddDays(-5), Amount = 100.0, UserId = 1, BudgetId = 1, TransactionType = Models.TransactionF.Types.TransactionType.OUTCOME, StatusType = Models.TransactionF.Types.StatusType.INPROGRESS },
                    new Transaction { OperationDate = DateTime.Now.AddDays(-3), Amount = 250.25, UserId = 1, BudgetId = 1, TransactionType = Models.TransactionF.Types.TransactionType.INCOME, StatusType = Models.TransactionF.Types.StatusType.WORKINGVERSION },
                    new Transaction { OperationDate = DateTime.Now.AddDays(-3), Amount = 250.0, UserId = 2, BudgetId = 2, TransactionType = Models.TransactionF.Types.TransactionType.INCOME, StatusType = Models.TransactionF.Types.StatusType.WORKINGVERSION }
                };

                _context.Transactions.AddRange(transactions);
                _context.SaveChanges();
            }
        }


        private void SeedAdmins()
        {
            if (!_context.Admins.Any())
            {
                _context.Admins.AddRange(
                    new Admin {Name = "Admin1", Surname = "Admin1", Email = "admin1@example.com", PhoneNumber = "111111111" }
                );
                _context.SaveChanges();
            }
        }

        private void SeedChiefsOfFinance()
        {
            if (!_context.ChiefOfFinance.Any())
            {
                _context.ChiefOfFinance.AddRange(
                    new ChiefOfFinance {Name = "Chief1", Surname = "Finance", Email = "chief1@example.com", PhoneNumber = "222222222" },
                    new ChiefOfFinance {Name = "Chief2", Surname = "Chiefsur2", Email = "chief1@example.com", PhoneNumber = "333333333" }
                );
                _context.SaveChanges();
            }
        }

        private void SeedFinancialPerson() 
        {
            if (!_context.FinancialPeople.Any())
            {
                _context.FinancialPeople.AddRange(
                    new FinancialPerson {Name = "FPersonName1", Surname = "FPersonSurname1", PhoneNumber = "123123123", Email = "example@example.com", NickName = "Example", Specialization = "Taxes", Rank = "Junior specialist", FinancialPersonRoles = new List<SpecializationType> { SpecializationType.ACCOUNTANT } },
                    new FinancialPerson {Name = "FPersonName2", Surname = "FPersonSurname2", PhoneNumber = "123123124", Email = "exampl2e@example.com", NickName = "Example", Specialization = "Taxes", Rank = "Junior specialist", NumberOfPredictions = 0, NumberOfReports = 0, FinancialPersonRoles = new List<SpecializationType> { SpecializationType.ACCOUNTANT, SpecializationType.FINANCIAL_SPECIALIST } }
                );
                _context.SaveChanges();
            }
        }

        private void SeedEmployees()
        {
            if (!_context.Employees.Any())
            {
                _context.Employees.AddRange(
                    new Employee {Name = "Employee1", Surname = "EmployeeSur", Nickname = "Emplo"},
                    new Employee { Name = "Employee2", Surname = "EmployeeSur2", Nickname = "Emplo2" }

                );
                _context.SaveChanges();
            }
        }

        public void SeedFinancialPlans()
        {
            if (!_context.FinancialPlans.Any())
            {
                var chiefOfFinanceIds = _context.ChiefOfFinance.Select(c => c.Id).ToList();

                var financialPlans = new[]
                {
                new FinancialPlan
                {
                    Name = "Plan A",
                    DateFrom = new DateTime(2024, 1, 1),
                    DateTo = new DateTime(2024, 12, 31),
                    Income = 100000,
                    RiskValue = 10,
                    IsRealised = false,
                    ChiefOfFinanceId = chiefOfFinanceIds.FirstOrDefault(),
                },
                new FinancialPlan
                {
                    Name = "Plan B",
                    DateFrom = new DateTime(2024, 6, 1),
                    DateTo = new DateTime(2024, 12, 31),
                    Income = 200000,
                    RiskValue = 20,
                    IsRealised = true,
                    ChiefOfFinanceId = chiefOfFinanceIds.LastOrDefault(),
                }
            };

                _context.FinancialPlans.AddRange(financialPlans);
                _context.SaveChanges();
            }
        }

        public void SeedFinancialPredictions()
        {
            if (!_context.FinancialPredictions.Any())
            {
                var financialPeople = _context.FinancialPeople.Select(c => c.Id).ToList();

                var financialPredictions = new[]
                {
                new FinancialPrediction
                {
                    Name = "Prediction A",
                    DateFrom = new DateTime(2024, 1, 1),
                    DateTo = new DateTime(2024, 12, 31),
                    Income = 150000,
                    Profit = 50000,
                    FinancialPersonId = financialPeople.FirstOrDefault(),
                },
                new FinancialPrediction
                {
                    Name = "Prediction B",
                    DateFrom = new DateTime(2024, 3, 1),
                    DateTo = new DateTime(2024, 9, 30),
                    Income = 120000,
                    Profit = 40000,
                    FinancialPersonId = financialPeople.LastOrDefault(),
                }
            };

                _context.FinancialPredictions.AddRange(financialPredictions);
                _context.SaveChanges();
            }
        }

        public void SeedFinancialReports()
        {
            if (!_context.FinancialReports.Any())
            {
                var financialPeople = _context.FinancialPeople.Select(c => c.Id).ToList();

                var financialReports = new[]
                {
                new FinancialReport
                {
                    Name = "Report A",
                    DateFrom = new DateTime(2024, 1, 1),
                    DateTo = new DateTime(2024, 12, 31),
                    Income = 180000,
                    Turnover = 220000,
                    FinancialPersonId = financialPeople.FirstOrDefault(),
                },
                new FinancialReport
                {
                    Name = "Report B",
                    DateFrom = new DateTime(2024, 5, 1),
                    DateTo = new DateTime(2024, 11, 30),
                    Income = 140000,
                    Turnover = 170000,
                    FinancialPersonId = financialPeople.LastOrDefault(),
                }
            };

                _context.FinancialReports.AddRange(financialReports);
                _context.SaveChanges();
            }
        }

        public void SeedFirms()
        {
            if (!_context.Firms.Any())
            {
                var firms = new[]
                {
                new Firm
                {
                    Name = "ABC Corp",
                    Address = "123 Main St",
                    NIP = "1234567890",
                    PhoneNumber = "555-1234",
                    Type = TypeOfCustomer.CLIENT,
                    DateOfRegistration = new DateTime(2020, 1, 15),
                    Discount = 0
                },
                new Firm
                {
                    Name = "XYZ Ltd",
                    Address = "456 Elm St",
                    NIP = "098765432",
                    PhoneNumber = "555-5678",
                    Type = TypeOfCustomer.DELIVERER,
                    DateOfDelivery = new DateTime(2023, 5, 20)
                },
            };

                foreach (var firm in firms)
                {
                    if (firm.Type == TypeOfCustomer.CLIENT)
                    {
                        firm.CountDiscount(firm.DateOfRegistration.Value);
                    }
                    _context.Firms.Add(firm);
                }

                _context.SaveChanges();
            }
        }

        public void SeedBankOperations()
        {
            if (!_context.Set<BankOperation>().Any())
            {
                var financialPeople = _context.FinancialPeople.Select(c => c.Id).ToList();

                var bankOperations = new[]
                {
                new BankOperation
                {
                    NetAmount = 1000,
                    GrossAmount = 1200,
                    Date = new DateTime(2024, 1, 1),
                    Status = "Completed",
                    Description = "Initial deposit",
                    FinancialPersonId =  financialPeople.FirstOrDefault(),
                },
                new BankOperation
                {
                    NetAmount = 2000,
                    GrossAmount = 2400,
                    Date = new DateTime(2024, 2, 1),
                    Status = "Pending",
                    Description = "Monthly transfer",
                    FinancialPersonId =  financialPeople.LastOrDefault(),
                }
            };
                _context.Set<BankOperation>().AddRange(bankOperations);
                _context.SaveChanges();
            }
        }

        public void SeedInvoices()
        {
            if (!_context.Invoices.Any())
            {
                var financialPeople = _context.FinancialPeople.Select(c => c.Id).ToList();

                var invoices = new[]
                {
                new Invoice
                {
                    NetAmount = 5000,
                    GrossAmount = 6000,
                    Date = new DateTime(2024, 1, 15),
                    Status = "Paid",
                    Description = "Invoice for January",
                    FinancialPersonId = financialPeople.FirstOrDefault(),
                    Seller = "Seller A",
                    Buyer = "Buyer A"
                },
                new Invoice
                {   
                    NetAmount = 3000,
                    GrossAmount = 3600,
                    Date = new DateTime(2024, 2, 15),
                    Status = "Unpaid",
                    Description = "Invoice for February",
                    FinancialPersonId = financialPeople.LastOrDefault(),
                    Seller = "Seller B",
                    Buyer = "Buyer B"
                }
            };
                _context.Invoices.AddRange(invoices);
                _context.SaveChanges();
            }
        }

        public void SeedTaxes()
        {
            if (!_context.Taxes.Any())
            {
                var taxes = new[]
                {
                    new Tax
                    {
                        Type = "VAT",
                        Rate = 20,                    
                    },
                    new Tax
                    {
                        Type = "Income Tax",
                        Rate = 15,
                    }
                };
                _context.Taxes.AddRange(taxes);

                var receipt = _context.Receipts.FirstOrDefault(e => e.Id == 1);
                var receipt2 = _context.Receipts.FirstOrDefault(e => e.Id == 2);
                if (receipt != null && receipt2 != null) 
                {
                    receipt.Taxes.Add(taxes[0]);
                    receipt2.Taxes.Add(taxes[1]);
                }               
                _context.SaveChanges();
            }
        }
    }
}
