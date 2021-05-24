using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPIBlueModas.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<string>(maxLength: 80, nullable: false),
                    Nome = table.Column<string>(maxLength: 200, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 200, nullable: true),
                    Imagem = table.Column<string>(maxLength: 200, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.ProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Compras",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compras", x => x.CompraId);
                    table.ForeignKey(
                        name: "FK_Compras_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComprasProdutos",
                columns: table => new
                {
                    CompraProdutoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompraId = table.Column<int>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComprasProdutos", x => x.CompraProdutoId);
                    table.ForeignKey(
                        name: "FK_ComprasProdutos_Compras_CompraId",
                        column: x => x.CompraId,
                        principalTable: "Compras",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComprasProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "ProdutoId", "Imagem", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "http://lucasduarte.me/produto/tenis-nike-sb-charge-cnvs-masculino-img.jpg", "Tênis Nike SB Charge CNVS", 189.99m },
                    { 2, "http://lucasduarte.me/produto/calcao-adams-futaw-masculino-img.jpg", "Calção Adams Futaw", 21.99m },
                    { 3, "http://lucasduarte.me/produto/tenis-adidas-vs-pace-masculino-img.jpg", "Tênis adidas VS Pace", 189.99m },
                    { 4, "http://lucasduarte.me/produto/regata-basica-feminina.jpg", "Regata Feminina Básica Com Alça Fina", 17.99m },
                    { 5, "http://lucasduarte.me/produto/blusa-manga-curta-feminina.jpg", "Blusa Feminina Manga Curta Com Gola Redonda", 19.99m },
                    { 6, "http://lucasduarte.me/produto/camisa-masculino-manga-curta.jpg", "Camisa Masculino Manga Curta Regular Algodão", 69.99m },
                    { 7, "http://lucasduarte.me/produto/camiseta-star-wars.jpg", "Camiseta Masculina Slim Manga Curta Star Wars", 45.99m },
                    { 8, "http://lucasduarte.me/produto/camiseta-contraste-azul.jpg", "Camiseta Masculina Manga Curta Azul", 29.99m },
                    { 9, "http://lucasduarte.me/produto/blusa-feminina-manga-curta-com-gola-alta-cinza.jpg", "Blusa Feminina Manga Curta Com Gola Alta Cinza", 39.99m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasProdutos_CompraId",
                table: "ComprasProdutos",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_ComprasProdutos_ProdutoId",
                table: "ComprasProdutos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComprasProdutos");

            migrationBuilder.DropTable(
                name: "Compras");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
