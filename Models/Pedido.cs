using System.Collections.Generic;

namespace avd4.Models
{
    public class Pedido
    {
        
        public int Id { get; set; }
        public int ClienteId {get; set;}
        public int ProdutoId {get; set;}
        
        public Cliente Cliente {get; set;}
        public Produto Produto {get; set;}

        public ICollection<Entrega> Entregas {get; set;}
    }
}