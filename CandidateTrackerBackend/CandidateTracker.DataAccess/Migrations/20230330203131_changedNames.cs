using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CandidateTracker.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class changedNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidates_Resume_ResumeId",
                table: "Candidates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates");

            migrationBuilder.RenameTable(
                name: "Candidates",
                newName: "Candidate");

            migrationBuilder.RenameIndex(
                name: "IX_Candidates_ResumeId",
                table: "Candidate",
                newName: "IX_Candidate_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Resume_ResumeId",
                table: "Candidate",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Resume_ResumeId",
                table: "Candidate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Candidate",
                table: "Candidate");

            migrationBuilder.RenameTable(
                name: "Candidate",
                newName: "Candidates");

            migrationBuilder.RenameIndex(
                name: "IX_Candidate_ResumeId",
                table: "Candidates",
                newName: "IX_Candidates_ResumeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Candidates",
                table: "Candidates",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidates_Resume_ResumeId",
                table: "Candidates",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "ResumeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
