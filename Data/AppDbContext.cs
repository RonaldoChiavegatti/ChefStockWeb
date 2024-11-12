using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ChefStock.Models;
using Microsoft.AspNetCore.Identity;
using SeuProjeto.Models;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Fornecedor> Fornecedores { get; set; }
    public DbSet<PedidoCompra> PedidosCompra { get; set; }
    public DbSet<ItemPedidoCompra> ItensPedidoCompra { get; set; }
    public DbSet<Inventario> Inventarios { get; set; }
    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<ItemCompra> ItensCompra { get; set; }

    // Adicionando as novas entidades para Restaurante e Funcionário
    public DbSet<Restaurante> Restaurantes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações de precisão para propriedades decimais
        modelBuilder.Entity<ItemPedidoCompra>()
            .Property(i => i.PrecoUnitario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<PedidoCompra>()
            .Property(p => p.Total)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<Produto>()
            .Property(p => p.PrecoUnitario)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<ItemPedidoCompra>()
            .Property(i => i.PrecoUnitario)
            .HasColumnType("decimal(18,2)");

        // Configurações para relacionamentos de ItemPedidoCompra
        modelBuilder.Entity<ItemPedidoCompra>()
            .HasOne(i => i.Produto)
            .WithMany()
            .HasForeignKey(i => i.ProdutoId);

        modelBuilder.Entity<ItemPedidoCompra>()
            .HasOne(i => i.PedidoCompra)
            .WithMany(p => p.Itens)
            .HasForeignKey(i => i.PedidoCompraId);

        // Configuração de relacionamento entre Restaurante e Funcionario
        modelBuilder.Entity<Funcionario>()
            .HasOne(f => f.Restaurante)
            .WithMany(r => r.Funcionarios)
            .HasForeignKey(f => f.RestauranteId)
            .OnDelete(DeleteBehavior.Cascade); // Excluir funcionários associados quando o restaurante for excluído

        base.OnModelCreating(modelBuilder);
    }
}
