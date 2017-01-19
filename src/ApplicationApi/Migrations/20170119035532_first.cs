using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApplicationApi.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    comment = table.Column<string>(maxLength: 500, nullable: true),
                    contact = table.Column<string>(nullable: false),
                    cv = table.Column<byte[]>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    experienceCompany = table.Column<string>(nullable: true),
                    experienceDate = table.Column<DateTime>(nullable: false),
                    experienceInRole = table.Column<string>(nullable: true),
                    experienceTitle = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
