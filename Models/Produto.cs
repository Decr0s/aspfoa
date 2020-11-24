using System.Collections.Generic;

namespace avd4.Models
{
    public class Produto
    {
        public int Id {get; set;} 
        public string Nome {get; set;}
        public float Valor {get; set;}
        public string Tipo {get; set;}

        public ICollection<Pedido> Pedidos {get; set;}
    }
}