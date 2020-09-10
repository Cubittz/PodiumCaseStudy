using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PodiumCaseStudy.Migrations
{
    public partial class RemoveApplicantIdFromRequirement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageProposals_Applicants_ApplicantId",
                table: "MortgageProposals");

            migrationBuilder.DropIndex(
                name: "IX_MortgageProposals_ApplicantId",
                table: "MortgageProposals");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "MortgageProposals");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "MortgageRequirements",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageRequirements_ApplicantId",
                table: "MortgageRequirements",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageRequirements_Applicants_ApplicantId",
                table: "MortgageRequirements",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageRequirements_Applicants_ApplicantId",
                table: "MortgageRequirements");

            migrationBuilder.DropIndex(
                name: "IX_MortgageRequirements_ApplicantId",
                table: "MortgageRequirements");

            migrationBuilder.DropColumn(
                name: "ApplicantId",
                table: "MortgageRequirements");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicantId",
                table: "MortgageProposals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageProposals_ApplicantId",
                table: "MortgageProposals",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageProposals_Applicants_ApplicantId",
                table: "MortgageProposals",
                column: "ApplicantId",
                principalTable: "Applicants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
