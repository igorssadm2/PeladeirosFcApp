using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeladeirosfcApp.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Apelido = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Genero = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    FotoUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Cidade = table.Column<string>(type: "TEXT", nullable: true),
                    Bairro = table.Column<string>(type: "TEXT", nullable: true),
                    CEP = table.Column<string>(type: "TEXT", nullable: true),
                    Altura = table.Column<decimal>(type: "TEXT", nullable: true),
                    Peso = table.Column<decimal>(type: "TEXT", nullable: true),
                    TamanhoPe = table.Column<int>(type: "INTEGER", nullable: true),
                    PeDominante = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Posicao = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
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
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "GruposPelada",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CriadorId = table.Column<string>(type: "TEXT", nullable: false),
                    Local = table.Column<string>(type: "TEXT", nullable: false),
                    TipoQuadra = table.Column<string>(type: "TEXT", nullable: false),
                    Configuracao = table.Column<string>(type: "TEXT", nullable: false),
                    ValorAvulso = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorMensal = table.Column<decimal>(type: "TEXT", nullable: false),
                    Intensidade = table.Column<int>(type: "INTEGER", nullable: false),
                    DiaDoJogo = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GruposPelada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GruposPelada_AspNetUsers_CriadorId",
                        column: x => x.CriadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MembrosGrupo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GrupoPeladaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false, defaultValue: true),
                    DataEntrada = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembrosGrupo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembrosGrupo_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembrosGrupo_GruposPelada_GrupoPeladaId",
                        column: x => x.GrupoPeladaId,
                        principalTable: "GruposPelada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    GrupoPeladaId = table.Column<Guid>(type: "TEXT", nullable: true),
                    DataPartida = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    Finalizada = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_GruposPelada_GrupoPeladaId",
                        column: x => x.GrupoPeladaId,
                        principalTable: "GruposPelada",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "JogadoresPartida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PartidaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    UsuarioId = table.Column<string>(type: "TEXT", nullable: false),
                    Presente = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataConfirmacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JogadoresPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JogadoresPartida_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JogadoresPartida_Partidas_PartidaId",
                        column: x => x.PartidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AvaliacoesJogadorPartida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JogadorPartidaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AvaliadorId = table.Column<string>(type: "TEXT", nullable: true),
                    Nota = table.Column<int>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacoesJogadorPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvaliacoesJogadorPartida_AspNetUsers_AvaliadorId",
                        column: x => x.AvaliadorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AvaliacoesJogadorPartida_JogadoresPartida_JogadorPartidaId",
                        column: x => x.JogadorPartidaId,
                        principalTable: "JogadoresPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstatisticasJogadorPartida",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    JogadorPartidaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Gols = table.Column<int>(type: "INTEGER", nullable: false),
                    Assistencias = table.Column<int>(type: "INTEGER", nullable: false),
                    Desarmes = table.Column<int>(type: "INTEGER", nullable: false),
                    Defesas = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstatisticasJogadorPartida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstatisticasJogadorPartida_JogadoresPartida_JogadorPartidaId",
                        column: x => x.JogadorPartidaId,
                        principalTable: "JogadoresPartida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesJogadorPartida_AvaliadorId",
                table: "AvaliacoesJogadorPartida",
                column: "AvaliadorId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacoesJogadorPartida_JogadorPartidaId",
                table: "AvaliacoesJogadorPartida",
                column: "JogadorPartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_EstatisticasJogadorPartida_JogadorPartidaId",
                table: "EstatisticasJogadorPartida",
                column: "JogadorPartidaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GruposPelada_CriadorId",
                table: "GruposPelada",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_JogadoresPartida_PartidaId",
                table: "JogadoresPartida",
                column: "PartidaId");

            migrationBuilder.CreateIndex(
                name: "IX_JogadoresPartida_UsuarioId_PartidaId",
                table: "JogadoresPartida",
                columns: new[] { "UsuarioId", "PartidaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MembrosGrupo_GrupoPeladaId",
                table: "MembrosGrupo",
                column: "GrupoPeladaId");

            migrationBuilder.CreateIndex(
                name: "IX_MembrosGrupo_UsuarioId_GrupoPeladaId",
                table: "MembrosGrupo",
                columns: new[] { "UsuarioId", "GrupoPeladaId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_GrupoPeladaId",
                table: "Partidas",
                column: "GrupoPeladaId");
        }

        /// <inheritdoc />
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
                name: "AvaliacoesJogadorPartida");

            migrationBuilder.DropTable(
                name: "EstatisticasJogadorPartida");

            migrationBuilder.DropTable(
                name: "MembrosGrupo");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "JogadoresPartida");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "GruposPelada");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
