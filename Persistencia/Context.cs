using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Persistencia
{
    public partial class Context : DbContext
    {
        public IConfiguration Configuration { get; set; }

        public Context()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appSettings.json");
            Configuration = builder.Build();
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("AppSettings.json");
            Configuration = builder.Build();
        }

        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbProduto> TbProduto { get; set; }
        public virtual DbSet<TbProdutoEstoque> TbProdutoEstoque { get; set; }
        public virtual DbSet<TbProdutoMovimentacao> TbProdutoMovimentacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration["connectionString"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.ToTable("tb_empresa");

                entity.HasIndex(e => e.Id)
                    .HasName("KEY_tb_empresa_id")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProduto>(entity =>
            {
                entity.ToTable("tb_produto");

                entity.HasIndex(e => e.Id)
                    .HasName("KEY_tb_produto_Id")
                    .IsUnique();

                entity.Property(e => e.NomeProduto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbProdutoEstoque>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_tb_produto_estoque_Id")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("tb_produto_estoque");

                entity.HasIndex(e => new { e.IdProduto, e.IdEmpresa })
                    .HasName("KEY_tb_produto_estoque")
                    .IsUnique();

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbProdutoEstoque)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_produto_estoque_IdEmpresa");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.TbProdutoEstoque)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_produto_estoque_IdProduto");
            });

            modelBuilder.Entity<TbProdutoMovimentacao>(entity =>
            {
                entity.ToTable("tb_produto_movimentacao");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.TbProdutoMovimentacao)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_produto_movimentacao_IdEmpresa");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.TbProdutoMovimentacao)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tb_produto_movimentacao_IdProduto");
            });
        }
    }
}
