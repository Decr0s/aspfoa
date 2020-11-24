using System;

namespace avd4.Models
{
    public class Entrega
    {
        public int id {get; set;}
        public DateTime DataHora {get; set;}

        public Pedido Pedido {get; set;}
    }
}