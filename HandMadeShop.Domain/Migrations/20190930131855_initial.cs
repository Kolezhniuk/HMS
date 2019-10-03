using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HandMadeShop.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 945, DateTimeKind.Local).AddTicks(171)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 942, DateTimeKind.Local).AddTicks(6981)),
                    CategoryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 55, 5, DateTimeKind.Local).AddTicks(422)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 55, 4, DateTimeKind.Local).AddTicks(9487)),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 948, DateTimeKind.Local).AddTicks(5472)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 948, DateTimeKind.Local).AddTicks(4954)),
                    DetailId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detail_Detail_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 951, DateTimeKind.Local).AddTicks(2547)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 951, DateTimeKind.Local).AddTicks(2074)),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderState",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 978, DateTimeKind.Local).AddTicks(5616)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 978, DateTimeKind.Local).AddTicks(5157)),
                    Code = table.Column<string>(maxLength: 64, nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderState", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 987, DateTimeKind.Local).AddTicks(4531)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 987, DateTimeKind.Local).AddTicks(3857)),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 989, DateTimeKind.Local).AddTicks(3899)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 989, DateTimeKind.Local).AddTicks(3314)),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    PhotoUrl = table.Column<string>(maxLength: 64, nullable: false),
                    IsHidden = table.Column<bool>(nullable: false),
                    IsAvailable = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 55, 1, DateTimeKind.Local).AddTicks(2719)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 55, 1, DateTimeKind.Local).AddTicks(2200)),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 64, nullable: false),
                    Phone = table.Column<string>(maxLength: 32, nullable: false),
                    Gender = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategory_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    DetailId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => new { x.ProductId, x.DetailId });
                    table.ForeignKey(
                        name: "FK_ProductDetail_Detail_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Detail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDetail_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductMeasure",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    MeasureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductMeasure", x => new { x.ProductId, x.MeasureId });
                    table.ForeignKey(
                        name: "FK_ProductMeasure_Measure_MeasureId",
                        column: x => x.MeasureId,
                        principalTable: "Measure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductMeasure_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 970, DateTimeKind.Local).AddTicks(3331)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 970, DateTimeKind.Local).AddTicks(2751)),
                    UserId = table.Column<int>(nullable: false),
                    OrderStateId = table.Column<int>(nullable: false),
                    DeliveryMethodId = table.Column<int>(nullable: false),
                    DeliveryPrice = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 512, nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryMethod_DeliveryMethodId",
                        column: x => x.DeliveryMethodId,
                        principalTable: "DeliveryMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderState_OrderStateId",
                        column: x => x.OrderStateId,
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 976, DateTimeKind.Local).AddTicks(308)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 975, DateTimeKind.Local).AddTicks(9398)),
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItem_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItem_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStateHistory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 980, DateTimeKind.Local).AddTicks(6065)),
                    ModifiedOn = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 9, 30, 16, 18, 54, 980, DateTimeKind.Local).AddTicks(5608)),
                    UserId = table.Column<int>(nullable: false),
                    OrderId = table.Column<int>(nullable: false),
                    OldOrderStateId = table.Column<int>(nullable: true),
                    NewOrderStateId = table.Column<int>(nullable: true),
                    Text = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStateHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStateHistory_OrderState_OldOrderStateId",
                        column: x => x.OldOrderStateId,
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderStateHistory_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderStateHistory_OrderState_OrderId",
                        column: x => x.OrderId,
                        principalTable: "OrderState",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderStateHistory_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryId",
                table: "Category",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_Id",
                table: "Category",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryMethod_Id",
                table: "DeliveryMethod",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detail_DetailId",
                table: "Detail",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_Id",
                table: "Detail",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Measure_Id",
                table: "Measure",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryMethodId",
                table: "Order",
                column: "DeliveryMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Id",
                table: "Order",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStateId",
                table: "Order",
                column: "OrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentMethodId",
                table: "Order",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserId",
                table: "Order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_Id",
                table: "OrderItem",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_ProductId",
                table: "OrderItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderState_Id",
                table: "OrderState",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderStateHistory_Id",
                table: "OrderStateHistory",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderStateHistory_OldOrderStateId",
                table: "OrderStateHistory",
                column: "OldOrderStateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStateHistory_OrderId",
                table: "OrderStateHistory",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStateHistory_UserId",
                table: "OrderStateHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_Id",
                table: "PaymentMethod",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_Id",
                table: "Product",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_CategoryId",
                table: "ProductCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategory_ProductId_CategoryId",
                table: "ProductCategory",
                columns: new[] { "ProductId", "CategoryId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetail_ProductId_DetailId",
                table: "ProductDetail",
                columns: new[] { "ProductId", "DetailId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasure_MeasureId",
                table: "ProductMeasure",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductMeasure_ProductId_MeasureId",
                table: "ProductMeasure",
                columns: new[] { "ProductId", "MeasureId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Id",
                table: "User",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItem");

            migrationBuilder.DropTable(
                name: "OrderStateHistory");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductDetail");

            migrationBuilder.DropTable(
                name: "ProductMeasure");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Measure");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "DeliveryMethod");

            migrationBuilder.DropTable(
                name: "OrderState");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
