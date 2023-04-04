using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DeskData.Migrations
{
    public partial class secretkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "floors",
                columns: table => new
                {
                    FloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floors", x => x.FloorId);
                });

            migrationBuilder.CreateTable(
                name: "LoginTables",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(30)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginTables", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RStatus = table.Column<bool>(type: "bit", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_rooms_floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "floors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    FloorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_seats_floors_FloorId",
                        column: x => x.FloorId,
                        principalTable: "floors",
                        principalColumn: "FloorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeNumber = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", nullable: false),
                    SecurityQuestion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_employees_LoginTables_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "LoginTables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingRooms",
                columns: table => new
                {
                    BookingRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomStatus = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingHours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeetingStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MeetingEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingRooms", x => x.BookingRoomId);
                    table.ForeignKey(
                        name: "FK_bookingRooms_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingRooms_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingSeats",
                columns: table => new
                {
                    BookingSeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatStatus = table.Column<int>(type: "int", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SeatShiftTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShiftStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bookingrequesttype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingSeats", x => x.BookingSeatId);
                    table.ForeignKey(
                        name: "FK_bookingSeats_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookingSeats_seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "seats",
                        principalColumn: "SeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "choices",
                columns: table => new
                {
                    ChoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodPerferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choices", x => x.ChoiceId);
                    table.ForeignKey(
                        name: "FK_choices_bookingSeats_BookingSeatId",
                        column: x => x.BookingSeatId,
                        principalTable: "bookingSeats",
                        principalColumn: "BookingSeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "qrscanners",
                columns: table => new
                {
                    QId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QRCode = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    BookingSeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_qrscanners", x => x.QId);
                    table.ForeignKey(
                        name: "FK_qrscanners_bookingSeats_BookingSeatId",
                        column: x => x.BookingSeatId,
                        principalTable: "bookingSeats",
                        principalColumn: "BookingSeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receptionists",
                columns: table => new
                {
                    ReceptionistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    REmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receptionists", x => x.ReceptionistID);
                    table.ForeignKey(
                        name: "FK_receptionists_bookingSeats_BookingSeatId",
                        column: x => x.BookingSeatId,
                        principalTable: "bookingSeats",
                        principalColumn: "BookingSeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "secretKeys",
                columns: table => new
                {
                    SecretId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecretKeyGen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretKeyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingSeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_secretKeys", x => x.SecretId);
                    table.ForeignKey(
                        name: "FK_secretKeys_bookingSeats_BookingSeatId",
                        column: x => x.BookingSeatId,
                        principalTable: "bookingSeats",
                        principalColumn: "BookingSeatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingRooms_EmployeeID",
                table: "bookingRooms",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_bookingRooms_RoomId",
                table: "bookingRooms",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_bookingSeats_EmployeeID",
                table: "bookingSeats",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_bookingSeats_SeatId",
                table: "bookingSeats",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_choices_BookingSeatId",
                table: "choices",
                column: "BookingSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_qrscanners_BookingSeatId",
                table: "qrscanners",
                column: "BookingSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_receptionists_BookingSeatId",
                table: "receptionists",
                column: "BookingSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_rooms_FloorId",
                table: "rooms",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_seats_FloorId",
                table: "seats",
                column: "FloorId");

            migrationBuilder.CreateIndex(
                name: "IX_secretKeys_BookingSeatId",
                table: "secretKeys",
                column: "BookingSeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookingRooms");

            migrationBuilder.DropTable(
                name: "choices");

            migrationBuilder.DropTable(
                name: "qrscanners");

            migrationBuilder.DropTable(
                name: "receptionists");

            migrationBuilder.DropTable(
                name: "secretKeys");

            migrationBuilder.DropTable(
                name: "rooms");

            migrationBuilder.DropTable(
                name: "bookingSeats");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropTable(
                name: "LoginTables");

            migrationBuilder.DropTable(
                name: "floors");
        }
    }
}
