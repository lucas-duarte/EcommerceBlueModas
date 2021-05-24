using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIBlueModas.Dominio;
using WebAPIBlueModas.Repository;

namespace WebAPIBlueModas.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options){}

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<CompraProduto> ComprasProdutos { get; set; }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //------------- Clientes -----------------------//
            modelBuilder.Entity<Cliente>()
            .Property(p => p.ClienteId)
              .HasMaxLength(80)
              .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Nome)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
              .Property(p => p.Telefone)
                .HasMaxLength(20)
                .IsRequired();

            //------------- ComprasProdutos -----------------------//
            modelBuilder.Entity<CompraProduto>()
                .HasOne(f => f.Compra)
                .WithMany(x => x.ComprasProdutos)
                .HasForeignKey(c => c.CompraId);

            modelBuilder.Entity<CompraProduto>()
                .HasOne(f => f.Produto)
                .WithMany(x => x.ComprasProdutos)
                .HasForeignKey(c => c.ProdutoId);

            //------------- Produto -----------------------//
            modelBuilder.Entity<Produto>()
             .HasKey(p => p.ProdutoId);

            modelBuilder.Entity<Produto>()
              .Property(p => p.Nome)
                .HasMaxLength(200);

            modelBuilder.Entity<Produto>()
              .Property(p => p.Imagem)
                .HasMaxLength(200);
            //--------------------------------- Inserindo os dados na tabela Produto --------------//
            modelBuilder.Entity<Produto>()
                .HasData(
                new Produto { ProdutoId = 1, Nome = "Tênis Nike SB Charge CNVS", Imagem = "http://lucasduarte.me/produto/tenis-nike-sb-charge-cnvs-masculino-img.jpg", Preco = 189.99M },
                new Produto { ProdutoId = 2, Nome = "Calção Adams Futaw", Imagem = "http://lucasduarte.me/produto/calcao-adams-futaw-masculino-img.jpg", Preco = 21.99M },
                new Produto { ProdutoId = 3, Nome = "Tênis adidas VS Pace", Imagem = "http://lucasduarte.me/produto/tenis-adidas-vs-pace-masculino-img.jpg", Preco = 189.99M },
                new Produto { ProdutoId = 4, Nome = "Regata Feminina Básica Com Alça Fina", Imagem = "http://lucasduarte.me/produto/regata-basica-feminina.jpg", Preco = 17.99M },
                new Produto { ProdutoId = 5, Nome = "Blusa Feminina Manga Curta Com Gola Redonda", Imagem = "http://lucasduarte.me/produto/blusa-manga-curta-feminina.jpg", Preco = 19.99M },
                new Produto { ProdutoId = 6, Nome = "Camisa Masculino Manga Curta Regular Algodão", Imagem = "http://lucasduarte.me/produto/camisa-masculino-manga-curta.jpg", Preco = 69.99M },
                new Produto { ProdutoId = 7, Nome = "Camiseta Masculina Slim Manga Curta Star Wars", Imagem = "http://lucasduarte.me/produto/camiseta-star-wars.jpg", Preco = 45.99M },
                new Produto { ProdutoId = 8, Nome = "Camiseta Masculina Manga Curta Azul", Imagem = "http://lucasduarte.me/produto/camiseta-contraste-azul.jpg", Preco = 29.99M },
                new Produto { ProdutoId = 9, Nome = "Blusa Feminina Manga Curta Com Gola Alta Cinza", Imagem = "http://lucasduarte.me/produto/blusa-feminina-manga-curta-com-gola-alta-cinza.jpg", Preco = 39.99M }

                );
        }
    }

}
