using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Staff.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffEmploymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEmploymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffEmploymentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEmploymentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffPositionLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPositionLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DepartmentInfo_DepartmentCategory_DepartmentCategoryId",
                        column: x => x.DepartmentCategoryId,
                        principalTable: "DepartmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffEmploymentDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    PositionLevelId = table.Column<int>(type: "int", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    EmployedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeftAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentCategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEmploymentDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetail_DepartmentCategory_DepartmentCategoryId",
                        column: x => x.DepartmentCategoryId,
                        principalTable: "DepartmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetail_StaffEmploymentStatus_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StaffEmploymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetail_StaffEmploymentType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "StaffEmploymentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetail_StaffPositionLevel_PositionLevelId",
                        column: x => x.PositionLevelId,
                        principalTable: "StaffPositionLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffEmploymentDetialDepartment",
                columns: table => new
                {
                    EmploymentDetialId = table.Column<int>(type: "int", nullable: false),
                    DepartmentInfoId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEmploymentDetialDepartment", x => new { x.DepartmentInfoId, x.EmploymentDetialId });
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetialDepartment_DepartmentInfo_DepartmentInfoId",
                        column: x => x.DepartmentInfoId,
                        principalTable: "DepartmentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEmploymentDetialDepartment_StaffEmploymentDetail_EmploymentDetialId",
                        column: x => x.EmploymentDetialId,
                        principalTable: "StaffEmploymentDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidentialAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NicImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmploymentDetailId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffInfos_StaffEmploymentDetail_EmploymentDetailId",
                        column: x => x.EmploymentDetailId,
                        principalTable: "StaffEmploymentDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StaffEducationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PreviousInstituteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CertificateImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    DegreeLevelId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffEducationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffEducationDetails_DegreeLevel_DegreeLevelId",
                        column: x => x.DegreeLevelId,
                        principalTable: "DegreeLevel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StaffEducationDetails_StaffInfos_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentInfo_DepartmentCategoryId",
                table: "DepartmentInfo",
                column: "DepartmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEducationDetails_DegreeLevelId",
                table: "StaffEducationDetails",
                column: "DegreeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEducationDetails_StaffId",
                table: "StaffEducationDetails",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmploymentDetail_DepartmentCategoryId",
                table: "StaffEmploymentDetail",
                column: "DepartmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmploymentDetail_PositionLevelId",
                table: "StaffEmploymentDetail",
                column: "PositionLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmploymentDetail_StatusId",
                table: "StaffEmploymentDetail",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmploymentDetail_TypeId",
                table: "StaffEmploymentDetail",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffEmploymentDetialDepartment_EmploymentDetialId",
                table: "StaffEmploymentDetialDepartment",
                column: "EmploymentDetialId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffInfos_EmploymentDetailId",
                table: "StaffInfos",
                column: "EmploymentDetailId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StaffEducationDetails");

            migrationBuilder.DropTable(
                name: "StaffEmploymentDetialDepartment");

            migrationBuilder.DropTable(
                name: "DegreeLevel");

            migrationBuilder.DropTable(
                name: "StaffInfos");

            migrationBuilder.DropTable(
                name: "DepartmentInfo");

            migrationBuilder.DropTable(
                name: "StaffEmploymentDetail");

            migrationBuilder.DropTable(
                name: "DepartmentCategory");

            migrationBuilder.DropTable(
                name: "StaffEmploymentStatus");

            migrationBuilder.DropTable(
                name: "StaffEmploymentType");

            migrationBuilder.DropTable(
                name: "StaffPositionLevel");
        }
    }
}
