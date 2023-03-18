using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application2.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportSeries = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanatoriumPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityOfProcedures = table.Column<int>(type: "int", nullable: false),
                    MinQuantityDays = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanatoriumPrograms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanatoriumRoomCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Coefficient = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanatoriumRoomCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SanatoriumRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomSize = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityOfSeats = table.Column<int>(type: "int", nullable: false),
                    QuantityOfRooms = table.Column<int>(type: "int", nullable: false),
                    RoomAmenities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomWindow = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SanatoriumRoomCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanatoriumRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SanatoriumRooms_SanatoriumRoomCategories_SanatoriumRoomCategoryId",
                        column: x => x.SanatoriumRoomCategoryId,
                        principalTable: "SanatoriumRoomCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfConclusion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfCheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    SanatoriumProgramId = table.Column<int>(type: "int", nullable: false),
                    SanatoriumRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_SanatoriumPrograms_SanatoriumProgramId",
                        column: x => x.SanatoriumProgramId,
                        principalTable: "SanatoriumPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_SanatoriumRooms_SanatoriumRoomId",
                        column: x => x.SanatoriumRoomId,
                        principalTable: "SanatoriumRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_PaymentMethodId",
                table: "Contracts",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SanatoriumProgramId",
                table: "Contracts",
                column: "SanatoriumProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SanatoriumRoomId",
                table: "Contracts",
                column: "SanatoriumRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_SanatoriumRooms_SanatoriumRoomCategoryId",
                table: "SanatoriumRooms",
                column: "SanatoriumRoomCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "SanatoriumPrograms");

            migrationBuilder.DropTable(
                name: "SanatoriumRooms");

            migrationBuilder.DropTable(
                name: "SanatoriumRoomCategories");
        }
    }
}
