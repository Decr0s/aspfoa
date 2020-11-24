using System.Collections.Generic;

namespace avd4.Models
{
    public class Cliente
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        public int Telefone {get; set;}
        public string Email {get; set;}
        public string Cpf {get; set;}

        public ICollection<Pedido> Pedidos {get; set;}
    }
}