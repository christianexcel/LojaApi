using System;
using LojaApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaApi.Data;

public class LojaContext : DbContext
{
    public LojaContext(DbContextOptions<LojaContext> options) : base(options)
    {

    }

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<PedidoProduto> PedidosProdutos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("TB_CLIENTES");

            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnName("id_cliente");
            entity.Property(c => c.Nome).HasColumnName("nome_cliente").HasMaxLength(150).IsRequired();
            entity.Property(c => c.Email).HasColumnName("email_cliente").HasMaxLength(150).IsRequired();
            entity.Property(c => c.Ativo).HasColumnName("ativo").HasColumnName("ativo");
            entity.Property(c => c.DataCadastro).HasColumnName("data_cadastro");
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.ToTable("TB_ENDERECOS");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id_cliente");
            entity.Property(e => e.Rua).HasColumnName("rua").HasMaxLength(200).IsRequired();
            entity.Property(e => e.Cidade).HasColumnName("cidade").HasMaxLength(100).IsRequired();
            entity.Property(e => e.Estado).HasColumnName("estado").HasMaxLength(50).IsRequired();
            entity.Property(e => e.Cep).HasColumnName("cep").HasMaxLength(10).IsRequired();
        });

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Endereco>(e => e.Id);

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("TB_PRODUTOS");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("id_produto");
            entity.Property(p => p.CategoriaId).HasColumnName("id_categoria");
            entity.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(150).IsRequired();
            entity.Property(p => p.Estoque).HasColumnName("estoque").HasPrecision(2).IsRequired();
            entity.Property(p => p.Valor).HasColumnName("valor").HasPrecision(2).IsRequired();
            entity.Property(p => p.Ativo).HasColumnName("ativo").IsRequired();
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("TB_CATEGORIAS");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnName("id_categoria");
            entity.Property(c => c.Descricao).HasColumnName("descricao").HasMaxLength(100).IsRequired();
            entity.Property(c => c.Ativo).HasColumnName("ativo").IsRequired();
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.ToTable("TB_PRODUTOS");

            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                    .HasColumnName("id_produto");

            entity.Property(p => p.Descricao)
                    .HasColumnName("descricao")
                    .IsRequired()
                    .HasMaxLength(100);

            entity.Property(p => p.Valor)
                    .HasColumnName("valor")
                    .IsRequired()
                    .HasColumnType("decimal(10, 2)");

            entity.Property(p => p.Estoque)
                    .HasColumnName("estoque");

            entity.Property(p => p.CategoriaId)
                    .HasColumnName("id_categoria")
                    .IsRequired();
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.ToTable("TB_PEDIDOS");
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).HasColumnName("id_pedido");
            entity.Property(p => p.DataPedido).HasColumnName("data_pedido");
            entity.Property(p => p.ValorTotal).HasColumnName("valor_total").HasColumnType("decimal(10, 2)");
            entity.Property(p => p.ClienteId).HasColumnName("id_cliente");
        });

        modelBuilder.Entity<PedidoProduto>(entity =>
        {
            entity.ToTable("TB_PEDIDOS_PRODUTOS");
            entity.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });
            entity.Property(pp => pp.PedidoId).HasColumnName("id_pedido");
            entity.Property(pp => pp.ProdutoId).HasColumnName("id_produto");
            entity.Property(pp => pp.Quantidade).HasColumnName("quantidade");
        });

        #region Relacionamentos
        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Endereco)
            .WithOne(e => e.Cliente)
            .HasForeignKey<Endereco>(e => e.Id); 

        modelBuilder.Entity<Categoria>()
            .HasMany(c => c.Produtos)
            .WithOne(p => p.Categoria)
            .HasForeignKey(c => c.CategoriaId);

        modelBuilder.Entity<Produto>()
            .HasMany(p => p.PedidoProdutos)
            .WithOne(pp => pp.Produto)
            .HasForeignKey(pp => pp.ProdutoId)
            .HasConstraintName("fk_produto");

        modelBuilder.Entity<Pedido>()
            .HasMany(p => p.PedidoProdutos)
            .WithOne(pp => pp.Pedido)
            .HasForeignKey(pp => pp.PedidoId)
            .HasConstraintName("fk_pedido");
        #endregion
    }
}
