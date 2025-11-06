using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace StayEasy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaseEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false),
                    PropertyId = table.Column<int>(type: "integer", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Favorites_UserId = table.Column<int>(type: "integer", nullable: true),
                    Favorites_PropertyId = table.Column<int>(type: "integer", nullable: true),
                    SenderId = table.Column<int>(type: "integer", nullable: true),
                    ReceiverId = table.Column<int>(type: "integer", nullable: true),
                    Message_PropertyId = table.Column<int>(type: "integer", nullable: true),
                    Content = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    IsRead = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Notifications_UserId = table.Column<int>(type: "integer", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: true),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Notifications_Content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Notifications_IsRead = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    ReleatedEntityId = table.Column<int>(type: "integer", nullable: true),
                    Payments_UserId = table.Column<int>(type: "integer", nullable: true),
                    BookingId = table.Column<int>(type: "integer", nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Currency = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    PaymentMethod = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: true),
                    TransactionId = table.Column<int>(type: "integer", maxLength: 200, nullable: true),
                    PropertyAmenities_PropertyId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Icon = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PropertyImageUrl_PropertyId = table.Column<int>(type: "integer", nullable: true),
                    ImageUrl = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    Order = table.Column<int>(type: "integer", nullable: true),
                    Propertys_UserId = table.Column<int>(type: "integer", nullable: true),
                    Propertys_Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Propertys_Type = table.Column<int>(type: "integer", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: true),
                    Rooms = table.Column<int>(type: "integer", nullable: true),
                    Area = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: true),
                    Floor = table.Column<int>(type: "integer", nullable: true),
                    Address = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    City = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    District = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Propertys_Status = table.Column<int>(type: "integer", nullable: true),
                    Reviews_PropertyId = table.Column<int>(type: "integer", nullable: true),
                    Reviews_UserId = table.Column<int>(type: "integer", nullable: true),
                    Reviews_BookingId = table.Column<int>(type: "integer", nullable: true),
                    Comment = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    Response = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    FirstName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PasswordHash = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "boolean", nullable: true, defaultValue: false),
                    ProfileImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_BookingId",
                        column: x => x.BookingId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Favorites_PropertyId",
                        column: x => x.Favorites_PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Favorites_UserId",
                        column: x => x.Favorites_UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Message_PropertyId",
                        column: x => x.Message_PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Notifications_UserId",
                        column: x => x.Notifications_UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Payments_UserId",
                        column: x => x.Payments_UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_PropertyAmenities_PropertyId",
                        column: x => x.PropertyAmenities_PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_PropertyImageUrl_PropertyId",
                        column: x => x.PropertyImageUrl_PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Propertys_UserId",
                        column: x => x.Propertys_UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reviews_BookingId",
                        column: x => x.Reviews_BookingId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reviews_PropertyId",
                        column: x => x.Reviews_PropertyId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_Reviews_UserId",
                        column: x => x.Reviews_UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_SenderId",
                        column: x => x.SenderId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseEntity_BaseEntity_UserId",
                        column: x => x.UserId,
                        principalTable: "BaseEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_BookingId",
                table: "BaseEntity",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Category",
                table: "BaseEntity",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_City",
                table: "BaseEntity",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_CreatedAt",
                table: "BaseEntity",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_District",
                table: "BaseEntity",
                column: "District");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Email",
                table: "BaseEntity",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Favorites_PropertyId",
                table: "BaseEntity",
                column: "Favorites_PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Favorites_UserId",
                table: "BaseEntity",
                column: "Favorites_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Favorites_UserId_Favorites_PropertyId",
                table: "BaseEntity",
                columns: new[] { "Favorites_UserId", "Favorites_PropertyId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_IsRead",
                table: "BaseEntity",
                column: "IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Message_PropertyId",
                table: "BaseEntity",
                column: "Message_PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Notifications_IsRead",
                table: "BaseEntity",
                column: "Notifications_IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Notifications_UserId",
                table: "BaseEntity",
                column: "Notifications_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Order",
                table: "BaseEntity",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Payments_UserId",
                table: "BaseEntity",
                column: "Payments_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PaymentStatus",
                table: "BaseEntity",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PhoneNumber",
                table: "BaseEntity",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Price",
                table: "BaseEntity",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PropertyAmenities_PropertyId",
                table: "BaseEntity",
                column: "PropertyAmenities_PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PropertyId",
                table: "BaseEntity",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_PropertyImageUrl_PropertyId",
                table: "BaseEntity",
                column: "PropertyImageUrl_PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Propertys_Status",
                table: "BaseEntity",
                column: "Propertys_Status");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Propertys_Type",
                table: "BaseEntity",
                column: "Propertys_Type");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Propertys_UserId",
                table: "BaseEntity",
                column: "Propertys_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_ReceiverId",
                table: "BaseEntity",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reviews_BookingId",
                table: "BaseEntity",
                column: "Reviews_BookingId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reviews_PropertyId",
                table: "BaseEntity",
                column: "Reviews_PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Reviews_UserId",
                table: "BaseEntity",
                column: "Reviews_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Role",
                table: "BaseEntity",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_SenderId",
                table: "BaseEntity",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StartDate",
                table: "BaseEntity",
                column: "StartDate");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Status",
                table: "BaseEntity",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_TransactionId",
                table: "BaseEntity",
                column: "TransactionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Type",
                table: "BaseEntity",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaseEntity");
        }
    }
}
