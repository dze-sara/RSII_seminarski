using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Rentacar.DataAccess.Migrations
{
    public partial class AddSupplementalTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardInfos",
                columns: table => new
                {
                    CardInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardInfos", x => x.CardInfoId);
                });

            migrationBuilder.CreateTable(
                name: "IssuedTokens",
                columns: table => new
                {
                    TokenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssuedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValidFor = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuedTokens", x => x.TokenId);
                });

            migrationBuilder.CreateTable(
                name: "LoginAttempts",
                columns: table => new
                {
                    LoginAttemptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    AttemptedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginAttempts", x => x.LoginAttemptId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentInfos",
                columns: table => new
                {
                    PaymentInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentAmount = table.Column<long>(type: "bigint", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentInfos", x => x.PaymentInfoId);
                });

            migrationBuilder.InsertData(
                table: "CardInfos",
                columns: new[] { "CardInfoId", "CardNumber", "ExpiryDate" },
                values: new object[,]
                {
                    {1, "5454545454545454", "11/25" },
                    {2, "5454545454545454", "12/25" },
                    {3, "5454545454545454", "01/23" }
                });

            migrationBuilder.InsertData(
                table: "IssuedTokens",
                columns: new[] { "TokenId", "TokenValue", "IssuedOn", "ValidFor", "UserId" },
                values: new object[,]
                {
                    {1, "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJuYmYiOjE2NTUwNTc2MjUsImV4cCI6MTY1NTI3MzYyNSwiaWF0IjoxNjU1MDU3NjI1fQ.jMZq0dyWJxMtw3YUAGVbT91vFyZTFpkrKw2j5L_tmJg", "2022-06-12T18:13:15.473", 3600, 2 },
                    {2, "eyJhbGciOiJIUzI3NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJuYmYiOjE2NTUwNTc2MjUsImV4cCI6MTY1NTI3MzYyNSwiaWF0IjoxNjU1MDU3NjI1fQ.jMZq0dyWJxMtw3YUAGVbT91vFyZTFpkrKw2j5L_tmJg", "2022-06-12T18:13:15.473", 3600, 1 },
                    {3, "eyJhbGciOiJIUzI4NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJuYmYiOjE2NTUwNTc2MjUsImV4cCI6MTY1NTI3MzYyNSwiaWF0IjoxNjU1MDU3NjI1fQ.jMZq0dyWJxMtw3YUAGVbT91vFyZTFpkrKw2j5L_tmJg", "2022-06-12T18:13:15.473", 3600, 2 },
                    {4, "eyJhbGciOiJIUzI5NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6InVzZXIiLCJuYmYiOjE2NTUwNTc2MjUsImV4cCI6MTY1NTI3MzYyNSwiaWF0IjoxNjU1MDU3NjI1fQ.jMZq0dyWJxMtw3YUAGVbT91vFyZTFpkrKw2j5L_tmJg", "2022-06-12T18:13:15.473", 3600, 1 }
                });
            
            migrationBuilder.InsertData(
                table: "LoginAttempts",
                columns: new[] { "LoginAttemptId", "UserId", "AttemptedOn", "Status", "Email" },
                values: new object[,]
                {
                    {1, 2, "2022-06-12T18:13:15.473", 1, "sara@email.com" },
                    {2, 2, "2022-06-12T18:13:15.473", 2, "sara@edu.fit.ba" },
                    {3, 1, "2022-06-12T18:13:15.473", 1, "admin@edu.fit.ba" },
                });

            migrationBuilder.InsertData(
                table: "PaymentInfos",
                columns: new[] { "PaymentInfoId", "CreatedOn", "PaymentIntentId", "PaymentAmount", "Currency", "InvoiceId", "PaymentMethodId" },
                values: new object[,]
                {
                    {1, "2022-06-12T18:13:15.473", "pi_3L9vJKGC5YHd2keh0ehZQXzW", 1000, "eur", "in_1L9vJJGC5YHd2kehQrjAxti1", "pm_1L9vJJGC5YHd2kehQrjAxti1"  },
                    {2, "2022-06-11T18:13:15.473", "pi_239vJKGC5YHd2keh0ehZQXzW", 200, "eur", "in_1L9vJJGC5YHd2kehQrjAxti1", "pm_1L9vJJGC5YHd2kehQrjAxti1"  },
                    {3, "2022-05-16T08:13:15.473", "pi_3L9vJ12C5YHd2keh0ehZQXzW", 10000, "eur", "in_1L9vJJGC5YHd2kehQrjAxti1", "pm_1L9vJJGC5YHd2kehQrjAxti1"  },
                    {4, "2022-06-11T11:13:15.473", "pi_3L9vJ55C5YHd2keh0ehZQXzW", 341, "eur", "in_1L9vJJGC5YHd2kehQrjAxti1", "pm_1L9vJJGC5YHd2kehQrjAxti1"  }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardInfos");

            migrationBuilder.DropTable(
                name: "IssuedTokens");

            migrationBuilder.DropTable(
                name: "LoginAttempts");

            migrationBuilder.DropTable(
                name: "PaymentInfos");
        }
    }
}
