using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBlueModas.Dominio
{
    public class CompraProduto
    {
        [Key]
        public int CompraProdutoId { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }

        public Compra Compra { get; set; }
        public Produto Produto { get; set; }
    }
}
