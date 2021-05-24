using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBlueModas.Dominio
{
    public class Compra
    {
        public int CompraId { get; set; }
        public string ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public ICollection<CompraProduto> ComprasProdutos { get; set; }
    }
}
