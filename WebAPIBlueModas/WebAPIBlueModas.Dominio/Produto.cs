using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBlueModas.Dominio
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco { get; set; }

        public ICollection<CompraProduto> ComprasProdutos { get; set; }
    }
}
