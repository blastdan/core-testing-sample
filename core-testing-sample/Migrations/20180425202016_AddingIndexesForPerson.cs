using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreTestingSample.Migrations
{
    public partial class AddingIndexesForPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_person_FirstName",
                table: "person",
                column: "FirstName");

            migrationBuilder.CreateIndex(
                name: "IX_person_LastName",
                table: "person",
                column: "LastName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_person_FirstName",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_LastName",
                table: "person");
        }
    }
}
