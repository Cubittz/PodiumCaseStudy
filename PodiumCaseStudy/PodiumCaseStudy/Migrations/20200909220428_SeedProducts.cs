using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PodiumCaseStudy.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType", "MortgageProposalId" },
                values: new object[] { new Guid("ac9d10eb-639c-44a7-b8e0-94c799824b63"), 0.02m, "Bank A", 0.6m, 1, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType", "MortgageProposalId" },
                values: new object[] { new Guid("e3306135-c662-483a-884b-e6123ecf4697"), 0.03m, "Bank B", 0.6m, 0, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "InterestRate", "Lender", "LoanToValue", "LoanType", "MortgageProposalId" },
                values: new object[] { new Guid("4ebd1d33-7215-44d0-9f1b-a8f45f13c882"), 0.04m, "Bank C", 0.9m, 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4ebd1d33-7215-44d0-9f1b-a8f45f13c882"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("ac9d10eb-639c-44a7-b8e0-94c799824b63"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e3306135-c662-483a-884b-e6123ecf4697"));
        }
    }
}
