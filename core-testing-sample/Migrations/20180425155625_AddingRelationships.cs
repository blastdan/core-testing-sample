using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CoreTestingSample.Migrations
{
    public partial class AddingRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_person_address_AddressId",
                table: "person");

            migrationBuilder.DropForeignKey(
                name: "FK_person_company_CompanyId",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_AddressId",
                table: "person");

            migrationBuilder.DropIndex(
                name: "IX_person_CompanyId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "person");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "person");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "company",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "address",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_company_PersonId",
                table: "company",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_address_PersonId",
                table: "address",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_address_person_PersonId",
                table: "address",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_company_person_PersonId",
                table: "company",
                column: "PersonId",
                principalTable: "person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_person_PersonId",
                table: "address");

            migrationBuilder.DropForeignKey(
                name: "FK_company_person_PersonId",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_company_PersonId",
                table: "company");

            migrationBuilder.DropIndex(
                name: "IX_address_PersonId",
                table: "address");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "company");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "address");

            migrationBuilder.AddColumn<Guid>(
                name: "AddressId",
                table: "person",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "person",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_person_AddressId",
                table: "person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_person_CompanyId",
                table: "person",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_person_address_AddressId",
                table: "person",
                column: "AddressId",
                principalTable: "address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_person_company_CompanyId",
                table: "person",
                column: "CompanyId",
                principalTable: "company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
