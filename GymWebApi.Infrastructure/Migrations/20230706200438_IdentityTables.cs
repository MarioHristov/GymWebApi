using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymWebApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    CardId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    CardCVC = table.Column<int>(type: "int", nullable: true),
                    CardExpDate = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    CardBalance = table.Column<int>(type: "int", nullable: true),
                    CardNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardId", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    ClubName = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    ClubLocation = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ClubWorkingHours = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubId", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MembershipId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    MembershipType = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    MembershipDuration = table.Column<int>(type: "int", nullable: false),
                    MembershipBasePricePerMonth = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipId", x => x.MembershipId);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    TrainerSpecialization = table.Column<string>(type: "varchar(70)", unicode: false, maxLength: 70, nullable: true),
                    TrainerPicture = table.Column<string>(type: "text", nullable: true),
                    TrainerFirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    TrainerLastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainerId", x => x.TrainerId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "(getdate())"),
                    TransactionCost = table.Column<int>(type: "int", nullable: true),
                    TransactionDescription = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionId", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivateInformation",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PIN = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    CardId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_UserPrivateInformation_CardId",
                        column: x => x.CardId,
                        principalTable: "CardDetails",
                        principalColumn: "CardId");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    ActivityId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    ActivityName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    ActivityDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActivityStartTime = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    ActivityEndTime = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    ActivityMaxPeople = table.Column<int>(type: "int", nullable: true),
                    ClubId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true),
                    TrainerId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityId", x => x.ActivityId);
                    table.ForeignKey(
                        name: "FK_Activities_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId");
                    table.ForeignKey(
                        name: "FK_Activities_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "TrainerSpecialInformation",
                columns: table => new
                {
                    TrainerId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true),
                    TrainerPhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    TrainerEmail = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "TrainerId");
                });

            migrationBuilder.CreateTable(
                name: "TransactionLog",
                columns: table => new
                {
                    TransactionId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true),
                    CardId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_TransactionLog_CardId",
                        column: x => x.CardId,
                        principalTable: "CardDetails",
                        principalColumn: "CardId");
                    table.ForeignKey(
                        name: "FK_TransactionLog_TransactionId",
                        column: x => x.TransactionId,
                        principalTable: "Transactions",
                        principalColumn: "TransactionId");
                });

            migrationBuilder.CreateTable(
                name: "ActivityCreation",
                columns: table => new
                {
                    ActivityId = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: true),
                    ActivityCreationDate = table.Column<DateTime>(type: "date", nullable: true),
                    ActivityDeletionDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ActivityCreation_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "ActivityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ClubId",
                table: "Activities",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_TrainerId",
                table: "Activities",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityCreation_ActivityId",
                table: "ActivityCreation",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainerSpecialInformation_TrainerId",
                table: "TrainerSpecialInformation",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLog_CardId",
                table: "TransactionLog",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_TransactionLog_TransactionId",
                table: "TransactionLog",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivateInformation_CardId",
                table: "UserPrivateInformation",
                column: "CardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityCreation");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "TrainerSpecialInformation");

            migrationBuilder.DropTable(
                name: "TransactionLog");

            migrationBuilder.DropTable(
                name: "UserPrivateInformation");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
