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
    }

}
