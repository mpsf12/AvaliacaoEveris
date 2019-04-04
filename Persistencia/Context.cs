using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.Extensions.Configuration;
using Modelo;

namespace Persistencia
{
    public partial class Context : DbContext
    {
        //public IConfiguration Configuration { get; set; }

        public Context()
        {
            //var builder = new ConfigurationBuilder()
            //.AddJsonFile("appSettings.json");
            //Configuration = builder.Build();
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            //var builder = new ConfigurationBuilder()
            //.AddJsonFile("AppSettings.json");
            //Configuration = builder.Build();
        }

        public virtual DbSet<Modelo.Empresa> Empresa { get; set; }
        public virtual DbSet<Modelo.Produto> Produto { get; set; }
        public virtual DbSet<Modelo.ProdutoEstoque> ProdutoEstoque { get; set; }
        public virtual DbSet<Modelo.ProdutoMovimentacao> ProdutoMovimentacao { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:marcioserafim.database.windows.net,1433;Initial Catalog=Everis;Persist Security Info=False;User ID=marcio;Password=M@rcio3265977;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<Modelo.Empresa>(entity =>
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

            modelBuilder.Entity<Produto>(entity =>
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

            modelBuilder.Entity<ProdutoEstoque>(entity =>
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

            modelBuilder.Entity<ProdutoMovimentacao>(entity =>
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
