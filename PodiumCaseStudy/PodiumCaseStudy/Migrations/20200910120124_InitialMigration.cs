using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PodiumCaseStudy.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: false),
                    LoanType = table.Column<int>(nullable: false),
                    LoanToValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MortgageRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicantId = table.Column<Guid>(nullable: false),
                    PropertyValue = table.Column<int>(nullable: false),
                    DepositAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageRequirements_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MortgageProposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MortgageRequirementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageProposals_MortgageRequirements_MortgageRequirementId",
                        column: x => x.MortgageRequirementId,
                        principalTable: "MortgageRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MortgageProposalProduct",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MortgageProposalId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageProposalProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageProposalProduct_MortgageProposals_MortgageProposalId",
                        column: x => x.MortgageProposalId,
                        principalTable: "MortgageProposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MortgageProposalProduct_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType" },
                values: new object[] { new Guid("6210c659-2bba-40c5-a1ab-3ebdbdbfad1b"), 0.02m, "Bank A", 0.6m, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType" },
                values: new object[] { new Guid("fb57f274-7fa7-45b0-a5c1-1b5757195664"), 0.03m, "Bank B", 0.6m, 0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType" },
                values: new object[] { new Guid("9bf06b0f-b937-4c4b-81c4-d00475af4b0d"), 0.04m, "Bank C", 0.9m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposalProduct_MortgageProposalId",
                table: "MortgageProposalProduct",
                column: "MortgageProposalId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposalProduct_ProductId",
                table: "MortgageProposalProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposals_MortgageRequirementId",
                table: "MortgageProposals",
                column: "MortgageRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageRequirements_ApplicantId",
                table: "MortgageRequirements",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageProposalProduct");

            migrationBuilder.DropTable(
                name: "MortgageProposals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MortgageRequirements");

            migrationBuilder.DropTable(
                name: "Applicants");
        }
    }
}
