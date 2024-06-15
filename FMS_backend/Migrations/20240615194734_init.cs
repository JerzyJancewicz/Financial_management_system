using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budget",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProjectName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budget", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NIP = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    DateOfDelivery = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TypeOfCustomer = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taxes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taxes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: false),
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_BankAccount_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ContactDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    ContactDetailsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_ContactDetails_ContactDetailsId",
                        column: x => x.ContactDetailsId,
                        principalTable: "ContactDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Admin_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiefOfFinance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DateOfEmployment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinancialScore = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiefOfFinance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiefOfFinance_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPerson",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    FinancialPersonRoles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialization = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NumberOfReports = table.Column<int>(type: "int", nullable: false),
                    NumberOfPredictions = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPerson_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OperationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => new { x.BudgetId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Transaction_Budget_BudgetId",
                        column: x => x.BudgetId,
                        principalTable: "Budget",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPlan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskValue = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    PotentialIncome = table.Column<double>(type: "float", nullable: false),
                    IsRealised = table.Column<bool>(type: "bit", nullable: false),
                    ChiefOfFinanceId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPlan_ChiefOfFinance_ChiefOfFinanceId",
                        column: x => x.ChiefOfFinanceId,
                        principalTable: "ChiefOfFinance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankOperation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NetAmount = table.Column<double>(type: "float", nullable: false),
                    GrossAmount = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FinancialPersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankOperation_FinancialPerson_FinancialPersonId",
                        column: x => x.FinancialPersonId,
                        principalTable: "FinancialPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinancialPrediction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Profit = table.Column<double>(type: "float", nullable: false),
                    FinancialPersonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialPrediction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialPrediction_FinancialPerson_FinancialPersonId",
                        column: x => x.FinancialPersonId,
                        principalTable: "FinancialPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FinancialReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Turnover = table.Column<double>(type: "float", nullable: false),
                    FinancialPersonId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Income = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinancialReport_FinancialPerson_FinancialPersonId",
                        column: x => x.FinancialPersonId,
                        principalTable: "FinancialPerson",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Seller = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_BankOperation_Id",
                        column: x => x.Id,
                        principalTable: "BankOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    FirmId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_BankOperation_Id",
                        column: x => x.Id,
                        principalTable: "BankOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipt_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Firms_FirmId",
                        column: x => x.FirmId,
                        principalTable: "Firms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receipt_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptTax",
                columns: table => new
                {
                    ReceiptsId = table.Column<int>(type: "int", nullable: false),
                    TaxesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptTax", x => new { x.ReceiptsId, x.TaxesId });
                    table.ForeignKey(
                        name: "FK_ReceiptTax_Receipt_ReceiptsId",
                        column: x => x.ReceiptsId,
                        principalTable: "Receipt",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptTax_Taxes_TaxesId",
                        column: x => x.TaxesId,
                        principalTable: "Taxes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_BudgetId",
                table: "BankAccount",
                column: "BudgetId");

            migrationBuilder.CreateIndex(
                name: "IX_BankOperation_FinancialPersonId",
                table: "BankOperation",
                column: "FinancialPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ContactDetailsId",
                table: "Employees",
                column: "ContactDetailsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPlan_ChiefOfFinanceId",
                table: "FinancialPlan",
                column: "ChiefOfFinanceId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialPrediction_FinancialPersonId",
                table: "FinancialPrediction",
                column: "FinancialPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_FinancialReport_FinancialPersonId",
                table: "FinancialReport",
                column: "FinancialPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Firms_NIP",
                table: "Firms",
                column: "NIP",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_ContactDetailsId",
                table: "PhoneNumbers",
                column: "ContactDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_EmployeeId",
                table: "Receipt",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_FirmId",
                table: "Receipt",
                column: "FirmId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_InvoiceId",
                table: "Receipt",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptTax_TaxesId",
                table: "ReceiptTax",
                column: "TaxesId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "BankAccount");

            migrationBuilder.DropTable(
                name: "FinancialPlan");

            migrationBuilder.DropTable(
                name: "FinancialPrediction");

            migrationBuilder.DropTable(
                name: "FinancialReport");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "ReceiptTax");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "ChiefOfFinance");

            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Taxes");

            migrationBuilder.DropTable(
                name: "Budget");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "BankOperation");

            migrationBuilder.DropTable(
                name: "FinancialPerson");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
