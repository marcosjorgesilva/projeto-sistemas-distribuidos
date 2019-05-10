using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.pedido
{
    public class Pedido
    {
        private int idPedido;
        private Usuario usuario;
        private DateTime dataPedido;
        private DateTime dataEntrega;
        private double valorPedido;
        public FormaPagamento formaPagamento { get; set; }

        public int IdPedido { get => idPedido; set => idPedido = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime DataPedido { get => dataPedido; set => dataPedido = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public double ValorPedido { get => valorPedido; set => valorPedido = value; }
    }
}
