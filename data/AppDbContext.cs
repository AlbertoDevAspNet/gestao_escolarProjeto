

using Microsoft.EntityFrameworkCore;

using gestao_escolar.Models;

namespace GestaoEscolar.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as opções de configuração
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet representa cada tabela na base de dados
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        // Configurações adicionais usando Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar índice único para Email do Professor
            modelBuilder.Entity<Professor>()
                .HasIndex(p => p.Email)
                .IsUnique();

            // Configurar índice único para Código da Turma
            modelBuilder.Entity<Turma>()
                .HasIndex(t => t.CodigoTurma)
                .IsUnique();

            // Configurar índice único para Código da Disciplina
            modelBuilder.Entity<Disciplina>()
                .HasIndex(d => d.Codigo)
                .IsUnique();

            // Configurar relação Professor -> Disciplinas
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.SetNull);

            // Configurar relação Turma -> Disciplinas
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Turma)
                .WithMany(t => t.Disciplinas)
                .HasForeignKey(d => d.TurmaId)
                .OnDelete(DeleteBehavior.SetNull);

            // Seed Data (Dados iniciais para teste)
            modelBuilder.Entity<Professor>().HasData(
                new Professor
                {
                    Id = 1,
                    Nome = "Maria Silva",
                    Email = "maria.silva@escola.pt",
                    Especialidade = "Matemática",
                    Telefone = "912345678",
                    dataAdmissao = new DateTime(2020, 3, 1),
                    Ativo = true
                },
                new Professor
                {
                    Id = 2,
                    Nome = "João Santos",
                    Email = "joao.santos@escola.pt",
                    Especialidade = "Informática",
                    Telefone = "913456789",
                    dataAdmissao = new DateTime(2019, 9, 1),
                    Ativo = true
                }
            );

            modelBuilder.Entity<Turma>().HasData(
                new Turma
                {
                    Id = 1,
                    CodigoTurma = "T2024-A",
                    Nome = "Turma A - 1º Ano",
                    AnoLetivo = 2024,
                    Periodo = "Matutino",
                    Capacidade = 35,
                    Sala = "Sala 101",
                    Ativo = true
                }
            );
        }
    }
}