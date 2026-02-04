using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PeladeirosfcApp.Models;

namespace PeladeirosfcApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Usuario>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // =========================
        // DbSets
        // =========================
        public DbSet<GrupoPelada> GruposPelada { get; set; }
        public DbSet<MembroGrupo> MembrosGrupo { get; set; }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<JogadorPartida> JogadoresPartida { get; set; }

        public DbSet<EstatisticaJogadorPartida> EstatisticasJogadorPartida { get; set; }
        public DbSet<AvaliacaoJogadorPartida> AvaliacoesJogadorPartida { get; set; }

        // =========================
        // Fluent API
        // =========================
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // =====================================================
            // USUARIO (Identity extendido)
            // =====================================================
            builder.Entity<Usuario>(entity =>
            {
                entity.Property(u => u.Nome)
                      .HasMaxLength(150);

                entity.Property(u => u.Apelido)
                      .HasMaxLength(100);

                entity.Property(u => u.Genero)
                      .HasMaxLength(20);

                entity.Property(u => u.PeDominante)
                      .HasMaxLength(20);

                entity.Property(u => u.Posicao)
                      .HasMaxLength(50);
            });

            // =====================================================
            // GRUPO PELADA
            // =====================================================
            builder.Entity<GrupoPelada>(entity =>
            {
                entity.HasKey(g => g.Id);

                entity.Property(g => g.Nome)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.HasOne(g => g.Criador)
                      .WithMany()
                      .HasForeignKey(g => g.CriadorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // =====================================================
            // MEMBRO GRUPO (Usuario x GrupoPelada)
            // =====================================================
            builder.Entity<MembroGrupo>(entity =>
            {
                entity.HasKey(mg => mg.Id);

                entity.Property(mg => mg.Tipo)
                      .IsRequired();

                entity.Property(mg => mg.Ativo)
                      .HasDefaultValue(true);

                entity.Property(mg => mg.DataEntrada)
                      .IsRequired();

                entity.HasOne(mg => mg.GrupoPelada)
                      .WithMany(g => g.Membros)
                      .HasForeignKey(mg => mg.GrupoPeladaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mg => mg.Usuario)
                      .WithMany()
                      .HasForeignKey(mg => mg.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Evita usuário duplicado no mesmo grupo
                entity.HasIndex(mg => new { mg.UsuarioId, mg.GrupoPeladaId })
                      .IsUnique();
            });

            // =====================================================
            // PARTIDA (Grupo opcional)
            // =====================================================
            builder.Entity<Partida>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.GrupoPelada)
                      .WithMany(g => g.Partidas)
                      .HasForeignKey(p => p.GrupoPeladaId)
                      .OnDelete(DeleteBehavior.SetNull);

                entity.Property(p => p.DataCriacao)
                      .IsRequired();
            });

            // =====================================================
            // JOGADOR PARTIDA
            // =====================================================
            builder.Entity<JogadorPartida>(entity =>
            {
                entity.HasKey(jp => jp.Id);

                entity.HasOne(jp => jp.Partida)
                      .WithMany(p => p.Jogadores)
                      .HasForeignKey(jp => jp.PartidaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(jp => jp.Usuario)
                      .WithMany()
                      .HasForeignKey(jp => jp.UsuarioId)
                      .OnDelete(DeleteBehavior.Restrict);

                // Um usuário só pode aparecer uma vez por partida
                entity.HasIndex(jp => new { jp.UsuarioId, jp.PartidaId })
                      .IsUnique();
            });

            // =====================================================
            // ESTATISTICA JOGADOR PARTIDA (1:1)
            // =====================================================
            builder.Entity<EstatisticaJogadorPartida>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne(e => e.JogadorPartida)
                      .WithOne(jp => jp.Estatistica)
                      .HasForeignKey<EstatisticaJogadorPartida>(e => e.JogadorPartidaId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // =====================================================
            // AVALIACAO JOGADOR PARTIDA (1:N)
            // =====================================================
            builder.Entity<AvaliacaoJogadorPartida>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Nota)
                      .IsRequired();

                entity.Property(a => a.DataCriacao)
                      .IsRequired();

                entity.HasOne(a => a.JogadorPartida)
                      .WithMany()
                      .HasForeignKey(a => a.JogadorPartidaId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Avaliador)
                      .WithMany()
                      .HasForeignKey(a => a.AvaliadorId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
