using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIBlueModas.Dominio
{
    public class Cliente
    {
        public string ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        public List<Compra> Compras { get; set; }
    }
}
