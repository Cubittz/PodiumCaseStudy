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
                name: "MortgageRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PropertyValue = table.Column<int>(nullable: false),
                    DepositAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MortgageProposals",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ApplicantId = table.Column<Guid>(nullable: false),
                    MortgageRequirementId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageProposals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageProposals_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MortgageProposals_MortgageRequirements_MortgageRequirementId",
                        column: x => x.MortgageRequirementId,
                        principalTable: "MortgageRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Lender = table.Column<string>(nullable: true),
                    InterestRate = table.Column<decimal>(nullable: false),
                    LoanType = table.Column<int>(nullable: false),
                    LoanToValue = table.Column<decimal>(nullable: false),
                    MortgageProposalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_MortgageProposals_MortgageProposalId",
                        column: x => x.MortgageProposalId,
                        principalTable: "MortgageProposals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposals_ApplicantId",
                table: "MortgageProposals",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposals_MortgageRequirementId",
                table: "MortgageProposals",
                column: "MortgageRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_MortgageProposalId",
                table: "Products",
                column: "MortgageProposalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "MortgageProposals");

            migrationBuilder.DropTable(
                name: "Applicants");

            migrationBuilder.DropTable(
                name: "MortgageRequirements");
        }
    }
}
