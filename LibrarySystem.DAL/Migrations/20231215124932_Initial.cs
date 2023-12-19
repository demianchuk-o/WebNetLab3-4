using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_AspNetUsers_BorrowerId",
                        column: x => x.BorrowerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Availability = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookLoan",
                columns: table => new
                {
                    BooksId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoansId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLoan", x => new { x.BooksId, x.LoansId });
                    table.ForeignKey(
                        name: "FK_BookLoan_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookLoan_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4e9277db-6d0c-437c-a31c-7b4c384b93dd"), "bda3d87a-922f-47aa-b30b-bde2adfa41a4", "CatalogManager", null },
                    { new Guid("75d0748f-b493-4527-a9e3-4c365a1a3f9c"), "e83b1934-48d3-4edb-9c28-8e3fab0e4f13", "LoansManager", null },
                    { new Guid("9877fd6f-9c30-4e85-811d-b4243d62a7fe"), "d23efca7-df30-44f5-987a-020081d8d6eb", "Admin", null },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), "5cc310bf-6592-4ee0-8b57-04eebd3cd864", "Reader", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("06f96e7d-b90d-4cd0-8f2e-e6f298c39850"), 0, "5b58917c-3d46-4020-8149-9d12ccab0137", "reader6@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECGQ4tyiCYTGey3I62k6C2Ws2vfV5HHiug84fA+RTsCEdXIxvdq9vUuto/9KN5Urgw==", null, false, null, false, "reader6" },
                    { new Guid("0d1daf36-3978-4667-bf3d-642a4fdaace9"), 0, "42234453-b39f-4d42-8f58-08ffc114f3b8", "catalogManager@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIF6fmvwwzS37RNUICwNM/6v2ZVdDCLWBV3QWE1AoURyTcP6jjfw0j6d1FvxEhCqvA==", null, false, null, false, "catalogManager" },
                    { new Guid("2d99ff9c-023f-47c7-a428-db6b89610389"), 0, "ab5eb99b-8b55-4e4e-89da-f26f74622ad8", "reader9@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJfLKTDtfEA/UVHY9jfAsRE2farc1VyVerY/n0h1GVn6OThiAcTAZk3rIO2wpNtCgg==", null, false, null, false, "reader9" },
                    { new Guid("36be9494-f4c2-42b4-848b-53b0386fddb5"), 0, "9dd779fb-724f-4eb9-92b0-6a357320f9b7", "reader1@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKh8ndmPSZ6M9Htaa7I2Ptpu5OizlFSFDi05w5XeVQwcg3KVv2gBVKxs6kEci5udpw==", null, false, null, false, "reader1" },
                    { new Guid("760282ab-8623-4c8d-98bc-e61fcff8bb4f"), 0, "95d5b328-29fd-4736-b9b1-954af823885f", "reader4@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEA7y6pSaTTlNym2P0J9KN9jhY4op88faUS1U3nDkirbM6USSFcPcYe/K4kJDCOqj7Q==", null, false, null, false, "reader4" },
                    { new Guid("a8be73a8-2e8d-4a0c-9ac0-568bded668f6"), 0, "483dbc23-3980-498c-8d66-ff4c91f1ac43", "admin@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAED5RNw7wOEyli4v3DUCSAOrzlmsYI/R1R4e/jMczriusUEkAc7rQmQV5IvWTh/njQw==", null, false, null, false, "admin" },
                    { new Guid("bc0a4e50-f77a-44df-9d6c-c6e36ea2093d"), 0, "824b3da3-f042-4ac4-b3f3-84f33a0cb835", "reader7@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEE3qNKFYhAJyV0sxfC/ZyadyhqMmN6hjgOUBlZRyAX9CR3+g2GqpxqH+UlkjyR31FQ==", null, false, null, false, "reader7" },
                    { new Guid("cd0753b2-1342-4aaa-b679-e833a19b3162"), 0, "12a6396a-0996-4428-a84d-e295cdfc28a5", "reader3@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOUG231M/DodbXJ2BdCohhX4JsHYCpMy/81MmiMm1KkaEGuzEgizkLpmW6ZAjB4vsw==", null, false, null, false, "reader3" },
                    { new Guid("dfd71714-95c9-4adb-92cc-714c151e888f"), 0, "1dafa739-2238-4302-88be-e093bdb681d8", "reader10@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFAmL2N/SThXrPCq/UjFNr8AqxsqdWgnFwBLS3oBN+v6shlnifS5CHGZie/8FVA7BQ==", null, false, null, false, "reader10" },
                    { new Guid("e0d1b732-1463-42f4-b26b-4b83d049ccfc"), 0, "a41a6bf3-c9a6-4a0c-86da-daaa8e8215da", "reader2@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEExsTW/gI1MOwtDMuVkgOxKYf5vHrWPNANe0KisvL8LUL/KzhjRpJKzqnP1mlL0tfA==", null, false, null, false, "reader2" },
                    { new Guid("fa631af6-cc10-424d-abb2-e1d11a599339"), 0, "d2ad4923-d82a-48d5-9809-96e0b079d8db", "reader5@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHVq86OxApAeDpkA0mp1fUpuv2IQMyXvxd75sLtrwyDK+W6Sl6nC5efP39TjjlTr8g==", null, false, null, false, "reader5" },
                    { new Guid("fd958838-a6ce-4ea3-a3c6-d27e11ee84e5"), 0, "2687dc82-996f-4080-995c-b61093d0ef9e", "reader8@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHGJrqbxww9hiNel2x9MW0mv+kpBQ+C7xNXYU0zLmMMAyDe1Pqw+A+6W/vN3WpTrKA==", null, false, null, false, "reader8" },
                    { new Guid("fe1d664e-c1fb-4ce3-a8d8-bb02873534cc"), 0, "c18750bf-6db6-42d1-87ed-7c43ec5954aa", "loansManager@mail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJFYR9c3YsqkSn0r/CrPZn4Daq1Xdr62Hx/N4rssn3l5aW+VtDtcV2W4LGJlyLHN+g==", null, false, null, false, "loansManager" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), "Deanna Dickinson" },
                    { new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), "Alfonso Yundt" },
                    { new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), "Ernesto Spencer" },
                    { new Guid("5146984f-f3eb-480d-92cc-243034cde758"), "Laurence King" },
                    { new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), "Adrienne Turcotte" },
                    { new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), "Cesar Bashirian" },
                    { new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), "Virgil Morar" },
                    { new Guid("911ef870-c00b-474d-b760-f23dbddab681"), "Alberto Hagenes" },
                    { new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), "Darlene Langworth" },
                    { new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), "Lisa Cronin" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "possimus" },
                    { new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "quia" },
                    { new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "quis" },
                    { new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "molestias" },
                    { new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "nisi" },
                    { new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "ratione" },
                    { new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "facere" },
                    { new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "quo" },
                    { new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "natus" },
                    { new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "occaecati" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("06f96e7d-b90d-4cd0-8f2e-e6f298c39850") },
                    { new Guid("4e9277db-6d0c-437c-a31c-7b4c384b93dd"), new Guid("0d1daf36-3978-4667-bf3d-642a4fdaace9") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("2d99ff9c-023f-47c7-a428-db6b89610389") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("36be9494-f4c2-42b4-848b-53b0386fddb5") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("760282ab-8623-4c8d-98bc-e61fcff8bb4f") },
                    { new Guid("9877fd6f-9c30-4e85-811d-b4243d62a7fe"), new Guid("a8be73a8-2e8d-4a0c-9ac0-568bded668f6") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("bc0a4e50-f77a-44df-9d6c-c6e36ea2093d") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("cd0753b2-1342-4aaa-b679-e833a19b3162") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("dfd71714-95c9-4adb-92cc-714c151e888f") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("e0d1b732-1463-42f4-b26b-4b83d049ccfc") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("fa631af6-cc10-424d-abb2-e1d11a599339") },
                    { new Guid("cb05e631-1f92-4c75-bb57-ca79bd4a6444"), new Guid("fd958838-a6ce-4ea3-a3c6-d27e11ee84e5") },
                    { new Guid("75d0748f-b493-4527-a9e3-4c365a1a3f9c"), new Guid("fe1d664e-c1fb-4ce3-a8d8-bb02873534cc") }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("01ff4603-b117-45ea-b158-46f4d28fcbb1"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Tenetur ipsum et quia voluptatibus qui." },
                    { new Guid("029e60b5-8f54-4060-be97-a8231b972201"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Repellendus sunt voluptas qui sit hic et quis totam perspiciatis." },
                    { new Guid("0303d67b-46e4-4010-93e3-c8fc49176afb"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Ut fuga soluta rerum quas itaque dolore." },
                    { new Guid("03710ddd-c5c6-4dc5-bcc8-179b0c806bb8"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Sunt blanditiis distinctio et ullam repudiandae perferendis fugit." },
                    { new Guid("03837b3b-2401-4935-ba59-d4164596b3cd"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Omnis cupiditate est et ut temporibus." },
                    { new Guid("07ecd768-597d-4b74-9af5-7e38f4bf6648"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Voluptatum ad quibusdam est doloremque dolorem." },
                    { new Guid("0839087a-388a-4ef7-9616-89e883c3178a"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Earum soluta quam ut maxime numquam aperiam impedit eum." },
                    { new Guid("08595667-e67a-4c39-9765-7f1e610efa85"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Placeat voluptatem adipisci incidunt quis rem error." },
                    { new Guid("0958c526-bcfa-4e49-8523-75e7b775f1a7"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Eum consequatur eum cupiditate consequuntur dolorum nihil veniam." },
                    { new Guid("0a6917db-f8c3-485f-966b-11be707bc9c2"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Similique itaque doloremque ab doloribus et voluptatem vel harum mollitia." },
                    { new Guid("0c8be18f-3578-4dff-9c86-dcfa473ba7b8"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Corporis minima dolorum et illum et ut." },
                    { new Guid("0d5f645b-23f3-4a51-b06c-55eb48044fea"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Illum laudantium voluptatem." },
                    { new Guid("0fdeb4d8-b9c6-4432-9a0a-ea2985d6d1af"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Ut assumenda qui sed dolorem voluptatibus." },
                    { new Guid("10480e10-3896-4828-b49b-5b89d69c03a0"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Ea aperiam nihil velit ullam." },
                    { new Guid("11a0dc58-e823-4c89-9c35-0900063f484b"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Molestiae incidunt qui asperiores assumenda ab quis." },
                    { new Guid("127806a5-c2ec-4431-84bc-2c66ecfd9013"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "A iusto eos." },
                    { new Guid("137a0fee-448b-4b09-9a21-9cf0079b52d3"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Eius corrupti asperiores autem enim quis accusamus itaque." },
                    { new Guid("13b86f8b-174d-4575-9447-b0928084f022"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Consequatur inventore natus." },
                    { new Guid("14b8d9f0-3e27-4ef4-a539-9343699474af"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Voluptas temporibus illum repudiandae recusandae similique sed aut." },
                    { new Guid("19bd3955-e925-47fb-848e-9175fea38aa1"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "In quidem ut cum voluptas qui in." },
                    { new Guid("1dea6df0-844d-4925-8a9f-49020f0bc362"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Aut ut laudantium ea animi quam." },
                    { new Guid("1f9e378b-85e9-4048-9c5b-a42a12224b7f"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Ut itaque iusto." },
                    { new Guid("20077c19-1367-4a25-90d6-5b146a5d9306"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Veniam dolorum veritatis et libero et rerum quisquam." },
                    { new Guid("2037bed7-864f-40bc-a757-fcecb691df7b"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Enim nihil earum aliquam qui molestiae ipsum sint." },
                    { new Guid("20b7e650-bf7d-43ae-a33e-dff4d72d4959"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Quo et tenetur ipsum autem a adipisci aut in atque." },
                    { new Guid("24dfa8cf-50f9-429e-8102-31e537ce212b"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Doloribus et et qui blanditiis laudantium veritatis quo." },
                    { new Guid("251a2ba4-4242-4557-8b38-a6fca09e43a5"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Et consequuntur placeat et iste." },
                    { new Guid("26332a99-6a60-400d-9088-562fa5e674b2"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Aspernatur ut aliquam." },
                    { new Guid("270d1732-1044-445c-9aa5-341e64a6898d"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Facilis eaque ullam ut accusantium omnis explicabo provident." }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("2712f743-a4b1-47e5-972a-50d4dfd385a8"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Qui rerum laudantium occaecati voluptas necessitatibus." },
                    { new Guid("2800e1fa-bfd3-4921-a5fb-919f1c8ca0a8"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Voluptas quisquam dolorem voluptatem quia optio libero perferendis." },
                    { new Guid("2dbffedb-7ce4-476e-8c68-e34178cb6221"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Delectus recusandae et laudantium vel quam incidunt voluptates." },
                    { new Guid("2fad15bf-f729-43e2-8fd1-aa0833732169"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Accusamus id ea qui sunt." },
                    { new Guid("30d5a5f9-45b0-45e6-8c59-210e16615d1e"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Unde autem voluptas vel fugiat itaque." },
                    { new Guid("3132eb44-ac59-45e8-ade4-d32697586bd9"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Autem sint temporibus ad et eum veritatis." },
                    { new Guid("322749ca-baef-4b93-b66d-360515e5c971"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Minima voluptas quod dolores nulla labore voluptatem aut error molestiae." },
                    { new Guid("337622db-cb57-4117-9b3c-e489088286ad"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Maiores voluptatem dolorum excepturi enim doloribus velit facere." },
                    { new Guid("33d4172b-3b76-4a4a-a64f-1f18614b7f99"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Cumque debitis quaerat quos ad aut ut voluptas." },
                    { new Guid("34e27600-12c7-4fc7-87dc-85b944baf1c9"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Et sunt ut est sint." },
                    { new Guid("35b9d0ba-2ca8-4ba3-aa14-83648fefa0c3"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Sunt et unde veniam alias tempore iste consequatur saepe." },
                    { new Guid("38d3c290-ecc2-43e4-9e20-cf7dded13658"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Quibusdam necessitatibus enim eius dignissimos eveniet ex aliquid." },
                    { new Guid("3c902ed4-98ff-4b2e-9a80-faefb56b2067"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Enim magni est ut vel veritatis labore et molestias." },
                    { new Guid("3e914f6b-2189-433d-9a9a-d576b588eea8"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Amet suscipit ad non fuga." },
                    { new Guid("4168ca15-e717-47ef-9178-54ab368df938"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Iure aut cum pariatur." },
                    { new Guid("426145b2-7f39-4b5a-ab09-e9f6ec08a2b3"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Ut earum sint rerum." },
                    { new Guid("43117c5d-9766-4e55-910c-5d9303d15640"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Quisquam temporibus rerum ut aut deserunt." },
                    { new Guid("4320f561-2a8d-42f5-b67a-712d885e7b15"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Neque quod perferendis commodi quo dicta sed voluptas omnis voluptas." },
                    { new Guid("453302bd-ba89-4c14-9070-c282a1c03c64"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Laudantium possimus aperiam quia at voluptatem quis." },
                    { new Guid("458d5eaa-591b-4ac6-b0b8-651279edaae0"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Eos neque iste quia." },
                    { new Guid("46a0835c-8ce0-4759-af57-5c975c6fd3e4"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Fugiat nemo illum." },
                    { new Guid("473386d3-45bb-4c23-b6d2-8cceab69fc51"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Dignissimos sit est est unde atque et." },
                    { new Guid("491572d7-c65a-4ac9-b784-efacd2a6f464"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Fuga odio laboriosam voluptas facilis itaque accusantium harum nemo explicabo." },
                    { new Guid("4ba712be-29cd-44f0-8165-163475c7d1a4"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Ut qui fugiat minus voluptatem nisi natus necessitatibus assumenda dolores." },
                    { new Guid("4c1abe27-1b8a-45d6-baa4-d0d38d3ca5a8"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Doloremque suscipit perferendis harum omnis nisi." },
                    { new Guid("4c8dfaa1-2fa2-4828-95de-12dbb60fde61"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Ratione nihil aliquam et vero asperiores atque quae soluta blanditiis." },
                    { new Guid("4cb589eb-769e-4e2c-8b94-44f85d2767fd"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Cumque et labore exercitationem cupiditate id." },
                    { new Guid("4d0fb1cc-d70c-4d54-840a-8ef37c699116"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Ratione sed qui nostrum dolor vero." },
                    { new Guid("4d5b2f8b-c9a9-4604-9553-23bc6ca39480"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Dolores sit et ex dolores quia voluptate dignissimos repellendus." },
                    { new Guid("5038cb34-cb7d-4c89-a8f3-83009bc9a4be"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Nesciunt illo sed in harum dolores perspiciatis quas." },
                    { new Guid("5161dd94-8ac5-4535-a3de-ccac849f2023"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Incidunt earum eius distinctio aut eos aut sapiente omnis." },
                    { new Guid("51d30561-1537-4614-941f-c35853147866"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Fugiat incidunt nihil perspiciatis aut." },
                    { new Guid("5243b35e-f180-4b88-8fe4-f447395fd245"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Non at adipisci." },
                    { new Guid("52730cb5-d818-411f-8125-a6d93050206d"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Corrupti placeat qui sequi voluptas animi id nihil." },
                    { new Guid("54ef386f-061b-44fe-8e53-0d9455a8e8cb"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Deleniti incidunt nesciunt delectus quas soluta rem est." },
                    { new Guid("55623252-f007-41f1-be7d-519ee7591302"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Corrupti illum voluptatem explicabo est ut." },
                    { new Guid("56a76f52-09a1-4575-be71-afd9adc90362"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Architecto est delectus cum voluptate pariatur." },
                    { new Guid("591da2bd-1e3d-4459-8593-f94dcfda7111"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Rem odit omnis dolorem." },
                    { new Guid("59222d10-a94b-4897-8883-3111da7400b2"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Dolores ratione minima sunt." },
                    { new Guid("5aa7a634-02f8-4fd5-8206-d1915c4293fb"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Dolorum consequatur alias tempore quis." },
                    { new Guid("5d080805-1298-43b5-a11a-7c769de2e9bf"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Minima veniam reiciendis et." },
                    { new Guid("5e250a95-93bd-466e-8f82-37da37a948cd"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Est optio exercitationem neque excepturi sed aliquam." }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("5e892e6c-4683-4fb4-9081-88c39dbe5fec"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Sint autem quaerat quod mollitia quos corporis quis ut." },
                    { new Guid("5f7ba6c6-5a6e-43cc-a7da-28f6bd55189b"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Ab expedita at dolorum placeat eum hic et." },
                    { new Guid("5fcc1cae-ebb7-4201-8be0-a2188ebbbe80"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Voluptatem provident odio est aspernatur at velit qui qui iste." },
                    { new Guid("6174d26b-b4f5-467f-9af2-2d0b07593d56"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Aut officia esse nisi fuga est natus dicta architecto ducimus." },
                    { new Guid("6299c142-e3a3-4921-aaf2-2f877ffdd48f"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Id sunt eum nam amet tenetur ab quis." },
                    { new Guid("632df8dc-b48d-47b3-8f03-420e925cb6ea"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Quidem voluptatem nam voluptatum occaecati." },
                    { new Guid("655385c9-9ae6-49bc-a7de-2aeaedca0bb2"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Vel eos voluptate dolorem." },
                    { new Guid("6587a9bc-9b13-4317-9651-8f20b933f0be"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Rem sit at et doloribus." },
                    { new Guid("65a4e185-3627-4c5f-8024-9e9946587f03"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Et omnis aliquid quae consequatur." },
                    { new Guid("65c8a051-496f-41d2-8445-0659b8dba2dc"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Voluptatem maxime hic." },
                    { new Guid("67c563e3-93e1-4387-9692-6855a6552565"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Magnam qui deleniti." },
                    { new Guid("68ede836-0387-4158-a846-4d8790cba16c"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Aut occaecati culpa minus omnis neque pariatur." },
                    { new Guid("695375d7-0fdb-4c11-bbaf-68a8028d1c94"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Nihil numquam praesentium inventore." },
                    { new Guid("697e5d92-9e86-4ed6-8571-914686a3fd29"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Quia et doloremque quia." },
                    { new Guid("6c2f3b66-0ff0-4ccd-94b6-3f40289da580"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Id ea sunt sit voluptatem dignissimos quo et aut omnis." },
                    { new Guid("6c5850f9-8315-4e18-a36f-db96cf6793c0"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Ratione est aliquam repudiandae earum." },
                    { new Guid("6cfbde10-be25-48bc-96b2-f87f63b42cfd"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Qui in numquam ut minus sint nam tenetur." },
                    { new Guid("6dba502d-76bc-423d-86f8-be987665a2e8"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Velit sapiente ea totam iure in ut accusantium incidunt et." },
                    { new Guid("6e90e44e-9241-411d-98f5-035b2784f89b"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Id cum rerum velit error consequatur voluptatibus." },
                    { new Guid("6f9ca396-ade7-46bf-9f92-0afef92f54ff"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Rerum ut dolor." },
                    { new Guid("727e363d-db37-42cf-bff8-2503975dd0b3"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Quam sit veritatis reprehenderit aut." },
                    { new Guid("7303c5b1-9656-4bda-88f3-83cccf497d3c"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Illum eius accusantium non tenetur consequuntur mollitia." },
                    { new Guid("74e89a98-fe88-4b58-b3e6-36a45b34c0c2"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Animi quas praesentium atque eligendi est deleniti non et ipsa." },
                    { new Guid("770c71e3-ee89-4c90-b861-9a31268ea592"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Necessitatibus consectetur debitis sapiente." },
                    { new Guid("77556b3a-3fcf-4446-97e3-a04ac9333e65"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Aut veniam repellendus officia." },
                    { new Guid("7b3b2e33-d3f7-4234-a60b-919bbef9c4d9"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Dolorum consectetur ut illo consequatur accusamus aut reiciendis et." },
                    { new Guid("7c0a0ec1-e513-4a86-af03-e6a437b8d250"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Reprehenderit ut distinctio earum quia non ea optio." },
                    { new Guid("7d0f0649-fee9-4b6c-8f1f-640db09534f5"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Error ipsam atque amet nihil amet non quaerat rerum dolores." },
                    { new Guid("80074efb-4692-4b38-a542-63984464e84a"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Expedita laborum aut." },
                    { new Guid("8197f2ce-90a2-4d40-9f53-83c27b439d9c"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "At eligendi nostrum sunt possimus quo qui officia." },
                    { new Guid("837c8a92-4c2b-415d-b0fa-c6e6d0c5a238"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Deleniti possimus corrupti deleniti deserunt tempore repudiandae et." },
                    { new Guid("85257bbe-dd67-4579-8d8c-696f292c993d"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Magnam vel non quis occaecati corporis quia et." },
                    { new Guid("85922dd1-9407-4770-bb7d-01e1b72414d1"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Tenetur dolores voluptatem eligendi labore." },
                    { new Guid("8677b23b-6eed-44a4-a705-5ef52ea44f59"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Sit velit facilis." },
                    { new Guid("86b98941-f0a6-4071-ab44-36a90f8d190b"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Quae eaque nemo voluptas quas perferendis." },
                    { new Guid("871bbc4f-a07a-4a1a-a86b-2ea48473974c"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Laborum laborum incidunt possimus sequi tempora." },
                    { new Guid("875ed700-e43d-4497-a8ee-743929fdf859"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Quo ipsa consequatur nobis optio expedita mollitia." },
                    { new Guid("881d147e-64ea-4558-8468-7426923370d0"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Ut optio similique labore quis." },
                    { new Guid("8c2fce14-6a1c-40f5-8912-e8ece412f7d5"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Voluptate voluptatem harum dolorem et omnis." },
                    { new Guid("8cdfb0d7-5082-44e8-936d-8cb58c9c2e3d"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Quia eius delectus quasi maiores et a explicabo iure." },
                    { new Guid("8d2a1f32-edea-4253-85d2-3326ebcf2755"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Sit aut ex laboriosam officia fuga quo sed ut." },
                    { new Guid("8f06e138-b389-4649-be6f-b013fec65cea"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Quas optio adipisci assumenda iure reprehenderit architecto quia." }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("9056c6d9-2436-4ea9-af2b-0ae658b2cc54"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Omnis ipsum aspernatur eius." },
                    { new Guid("90e68165-f256-47e5-a20b-2314e5a3da50"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Laboriosam voluptate ab autem fuga vero non sit consequuntur eaque." },
                    { new Guid("9387d981-935e-42ba-b9e4-347a32397ac9"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Est excepturi doloremque sint voluptas ut." },
                    { new Guid("94626b3b-edfd-47a4-9bf3-b635882f110a"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Deleniti assumenda et pariatur ipsam quis perspiciatis cupiditate." },
                    { new Guid("949096a3-480a-437e-8312-09f49398bed0"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Ipsam aut assumenda quia." },
                    { new Guid("9557f8d2-8f2d-42ed-a3ac-e63e99369312"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Veniam consequuntur nihil magnam eaque eum qui." },
                    { new Guid("9736da8a-5142-4b2b-b3ef-7fbd4b51a92a"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Necessitatibus accusantium sunt culpa." },
                    { new Guid("978324d0-c3b3-41c5-bf83-eb7b35bd3e05"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Eos fugiat eos eaque eos et consequatur sed cum quia." },
                    { new Guid("97eb7c95-a98a-401a-9870-29a0cfa42b86"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Consequatur quia et soluta sit quam sapiente velit consectetur." },
                    { new Guid("98171b4d-3abb-4853-87af-9fa37417c27b"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Repellat sed debitis voluptatem ullam." },
                    { new Guid("9a87cfc4-1ac9-45ed-89da-c6f25b7f1b5d"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Atque natus repellendus corporis assumenda voluptas." },
                    { new Guid("9a88dbf8-cafb-4818-9808-4c0502e8f4e4"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Asperiores porro voluptatem suscipit." },
                    { new Guid("9e465714-b15a-439a-95f2-eeec3c43bbfb"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Doloremque eos ea." },
                    { new Guid("9f7586ac-2962-401f-80b2-9ac62040eabe"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Eveniet magnam enim id distinctio doloribus eos perferendis dolor." },
                    { new Guid("9fbcb72d-78d4-4d99-9d68-785f18d59d6d"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Tempore est magnam." },
                    { new Guid("a05e4271-8db8-49f2-8f12-e04c3e3ef646"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Illo et quas quo in quos magnam." },
                    { new Guid("a290a615-56e9-44ec-bae6-47f183c8c5bf"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Aliquid sit ducimus." },
                    { new Guid("a2db2a63-8de8-4a1d-b6b4-a36929de9652"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Consequatur in beatae." },
                    { new Guid("a76765fa-fe11-4e8e-b1d2-54aa88e8e627"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Non ad excepturi provident doloribus eos natus consequuntur hic quae." },
                    { new Guid("a84b26d5-6f7a-4aec-93d4-4fba82b62617"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Nam iusto sunt reiciendis suscipit." },
                    { new Guid("a856aee5-869c-4c23-8c05-74ad0a965ecd"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Ut repellendus optio." },
                    { new Guid("a95bc3ac-23ae-47db-b1eb-1228c897ba90"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Dolorem nemo quasi non enim autem non reiciendis natus." },
                    { new Guid("ac78f69c-ef15-4ace-85fb-a74c59c88050"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Aliquam vel quam vel quo." },
                    { new Guid("ac8db5e8-340f-48ca-a0e6-447001b10976"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Assumenda minus magnam illum neque dolore." },
                    { new Guid("acfa2958-c9f2-403d-94bc-696b9faae732"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Est voluptas id quo quia doloremque expedita non delectus aut." },
                    { new Guid("ad136cf0-45fd-4920-b0cb-7befb2c407ba"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Ut omnis eos distinctio consequatur sunt." },
                    { new Guid("ad6dc755-1c08-493d-9583-297405deec0e"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "At quia aperiam tenetur sed est." },
                    { new Guid("aeab7516-52f1-4594-be6b-9a0dfa186656"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Ut quo hic odit iste architecto sit." },
                    { new Guid("af34c0d9-cf03-43bf-9de8-dfd28e88e44c"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Qui cupiditate ex dignissimos quod iure cupiditate." },
                    { new Guid("af566c59-152b-4c12-a49b-8dd0b95ac3b7"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Eligendi quis expedita omnis aut itaque a ut quibusdam." },
                    { new Guid("b1a44fa9-1dad-4908-8b98-66172ca0d772"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Delectus quia voluptatum sit." },
                    { new Guid("b4ca5ed8-2cfa-403a-b76e-0520b6e61871"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Sit et omnis et dolor." },
                    { new Guid("b5fb7473-82ea-4ae2-9516-144f7ded4e6e"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Et magni voluptatem voluptate beatae laborum nesciunt et cumque." },
                    { new Guid("b63ea733-e35e-4da7-af9b-6992f6eefc5f"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Mollitia facere delectus velit esse beatae." },
                    { new Guid("b83ec421-3735-4a47-a45d-7b48e1ae67cf"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Consequatur in hic qui dignissimos et tempore." },
                    { new Guid("b8bac8ff-b2ab-41ea-a3e5-75374b271f1b"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Sit excepturi labore." },
                    { new Guid("bb3de89e-5e59-486e-aad4-795328ba0cfc"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Adipisci voluptatem ea eaque sed et dolorum." },
                    { new Guid("bc4e643f-79e3-4fd5-9583-54f3a8377e3c"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Mollitia iste voluptatem." },
                    { new Guid("bd8c2bf1-af23-44d1-b3b1-f2230f9c3fd5"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Et voluptatem molestiae molestiae et doloribus." },
                    { new Guid("be6b9040-a071-47ec-9848-c34be4fb347a"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Aliquid et dolores." },
                    { new Guid("bec657c6-23f7-4bdc-bbc3-8056217635c4"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Nostrum aut et laboriosam neque non amet nam id ea." },
                    { new Guid("c062f0ac-d6e3-4364-b0cc-55aacce28dc1"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Quasi alias ut sequi illum est." }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[,]
                {
                    { new Guid("c13df484-3fcd-4bf7-bbdf-8fdb1afedea2"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Sit sint earum quas sapiente." },
                    { new Guid("c3217126-9071-4269-9010-0a99f4c7656f"), new Guid("6a58d1ab-d6f8-4fd6-bec6-67a6aa8253c0"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Distinctio expedita saepe atque magni esse nemo." },
                    { new Guid("c56a4450-1ec2-4767-a7dd-aa52a19653ad"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Earum quia voluptatem aut ipsa omnis cumque quas fugiat." },
                    { new Guid("c7ffb2b6-516a-4851-b910-76fc1b4d164a"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Debitis possimus laudantium sit quis quos esse reprehenderit exercitationem." },
                    { new Guid("c9959147-1607-4174-8ee4-c185e0f1ee78"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Deleniti sunt temporibus omnis." },
                    { new Guid("cba6f03a-3064-403b-983d-b5f78a3b2a72"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Commodi non vel porro ducimus est qui consequatur qui maxime." },
                    { new Guid("cbd0bd5c-0264-4c50-9042-5b65d7c5a95a"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Et qui blanditiis est amet enim dolores dolore rerum nemo." },
                    { new Guid("cc083b89-ae82-4039-9e72-ec2167601bc9"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Dolor sit est fugit." },
                    { new Guid("cd5f4389-88f8-40ba-ba58-0a060f28c851"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Optio vero error doloribus beatae amet non aut rerum aperiam." },
                    { new Guid("cf9344d5-eb50-4929-821e-852f70dbf2d9"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Beatae fuga id cum cum enim fugiat voluptatem." },
                    { new Guid("d04d840e-4d37-4c70-b195-8c2c24e981c1"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Temporibus sequi aliquam possimus." },
                    { new Guid("d1b2836a-9ce0-4606-88f2-8ef548728038"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Unde eaque nam vitae." },
                    { new Guid("d274858b-038d-44f7-b2e0-463bca126b66"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Similique animi molestiae incidunt perspiciatis saepe quaerat minus." },
                    { new Guid("d2e26b29-d1f6-4876-b6ef-788b6e855f01"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Neque ipsam et at voluptatem." },
                    { new Guid("d3e84291-ad20-400c-bf81-15c75b0c065e"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Autem vero accusantium." },
                    { new Guid("d3f44d11-5cff-4219-99af-7a7564de9241"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("342577d3-4ca1-47cc-982e-c6e1ea4fc65a"), "Quidem nam ad." },
                    { new Guid("d87cfc8e-da93-4450-85e2-801cad0bffdb"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Voluptatem ut dicta non consequuntur culpa rem sed." },
                    { new Guid("d90bf737-9a32-4c52-bd0d-6876749e5a0f"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Odit est magni veniam laboriosam et minus." },
                    { new Guid("d97ab601-de0b-4122-9234-2266b64527d5"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Deleniti numquam tenetur veniam ea." },
                    { new Guid("d9ee3059-9fcd-4476-9517-bb5407216587"), new Guid("ffc50835-5180-4126-a1f8-a0ed7ea3fa07"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Voluptate rerum quaerat dolorem possimus maiores est dolorem." },
                    { new Guid("da212074-2403-41ec-b32c-dd887391757d"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Atque et dolorem hic voluptates dolores magni quibusdam ullam consequuntur." },
                    { new Guid("dc22f290-85db-4175-9e6d-be54c966c9de"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Rerum sequi aut accusantium." },
                    { new Guid("dd635543-f766-4ae1-a54a-025113766880"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("f441332b-64a7-465d-a350-ebf4dd258fdb"), "Quo iste distinctio." },
                    { new Guid("dff19419-ad23-4fac-b25e-64a6b5e85894"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Impedit mollitia et saepe." },
                    { new Guid("e274073e-f60b-4392-9b53-73e20d5e1e61"), new Guid("911ef870-c00b-474d-b760-f23dbddab681"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Aut quod excepturi rem quis quisquam quo." },
                    { new Guid("e71d2257-c78f-47ac-a639-c70647f4eb59"), new Guid("6f33014a-e15c-44b8-a3b3-c34eb70f7a72"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Sunt ipsum enim placeat suscipit quia veritatis maiores cum voluptatem." },
                    { new Guid("e77fdf04-a7bd-4de8-92de-ac4cb41ff5a4"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Vitae non perferendis magnam nemo quam sint molestiae." },
                    { new Guid("e860cb41-9ab6-45c2-a1bb-8b60ddfd23e5"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "Autem adipisci voluptatibus voluptate nihil officia." },
                    { new Guid("e86a844e-95a5-489d-91a3-28bdaed595ab"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Repudiandae ut similique veritatis atque culpa nemo." },
                    { new Guid("e88c69cc-a0be-49f5-965b-3bccb8fa6ca0"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Et sed consectetur dicta quaerat sint at nulla earum." },
                    { new Guid("eac7f28a-f198-4f60-8b46-8344fae1e2ce"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Sit perspiciatis quod velit consequatur repellendus deleniti." },
                    { new Guid("eb089cc8-9d16-47d7-9404-8ac96ab4d7c5"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Aliquam suscipit neque enim consequatur quis maiores et." },
                    { new Guid("eb3a7d1e-bdcc-4743-aba1-880b2c22ecdb"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Exercitationem soluta non quia illum." },
                    { new Guid("ecb87dfd-631f-41bb-b085-b4956ba8d3e3"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("687e0246-6925-4a8d-b035-99a5a0edf53e"), "Sit quibusdam minima quibusdam eum." },
                    { new Guid("eda0a065-75d1-4d0f-af63-2525a475e197"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Cum sapiente exercitationem debitis ab." },
                    { new Guid("eeda1766-6224-4176-8000-189a961e36c4"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Ducimus mollitia molestiae aut possimus ut." },
                    { new Guid("f3add9a8-de1d-425e-ae01-8309295cddd9"), new Guid("5ac5caea-4b3d-4105-8850-a978b91e9c3b"), true, new Guid("7963cd83-0c5b-4717-89bc-718378a0df1c"), "Enim enim dolorem eum qui." },
                    { new Guid("f5e74784-1435-42b6-ae09-a4670f9c55a0"), new Guid("3b081551-b7e9-4f6e-91f2-e5fb3a2fc8b6"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Deserunt sed incidunt omnis sint." },
                    { new Guid("f7c0dc24-b5b7-4796-a867-47b4576fa533"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("3b43e159-6948-4e1a-a167-1e9e600a4992"), "Praesentium assumenda magni ullam est atque aut aut." },
                    { new Guid("f7ef4c53-3b4e-4eca-a26e-234004889595"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("b45e2f7b-ac43-4168-8584-92c48a92bf93"), "Corporis porro sit amet numquam." },
                    { new Guid("f9cb82eb-dab2-4b41-bd16-bc4132f38fde"), new Guid("0d5ea239-b8b4-44b9-9aaf-a5a48944c3de"), true, new Guid("0ffd9882-ac0b-4d52-9e95-7ed0fa3b015b"), "Quas optio omnis aut." },
                    { new Guid("fa59a97a-e395-4cd0-b3a5-5fd3184da1ee"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Officia sed et nobis recusandae sint aspernatur qui et." }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[] { new Guid("fcaa5207-bff9-4f60-a048-286def696a3c"), new Guid("5146984f-f3eb-480d-92cc-243034cde758"), true, new Guid("66284f0e-e7ee-4b6c-a8a2-8d7f22b57fda"), "Nostrum repellat aut at rerum ipsam minus." });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[] { new Guid("fd600d75-963a-49ce-92e8-c873ce49cc4d"), new Guid("03b40b7e-90b9-4ac5-820c-5682efa4fbe0"), true, new Guid("5172a0b6-e48a-4900-a487-98b0006b1ee2"), "Ducimus quis quas." });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "Availability", "SubjectId", "Title" },
                values: new object[] { new Guid("ffc5e6d7-0c58-4341-93f9-22a9541ab824"), new Guid("b21db772-792c-4789-b56c-4b2a449adbc0"), true, new Guid("a30aa283-f3e0-41a4-89f0-9f001854ff8c"), "A exercitationem natus iste." });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookLoan_LoansId",
                table: "BookLoan",
                column: "LoansId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_SubjectId",
                table: "Books",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BorrowerId",
                table: "Loans",
                column: "BorrowerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "BookLoan");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
