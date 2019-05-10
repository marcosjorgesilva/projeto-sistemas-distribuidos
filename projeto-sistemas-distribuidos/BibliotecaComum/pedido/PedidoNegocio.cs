using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaComum.pedido
{
    public class PedidoNegocio : PedidoInterface
    {
        #region Remover
        public void Remove(Pedido pedido)
        {
            if(pedido == null)
            {
                throw new Exception("");
            }
            if(pedido.IdPedido <=0 )
            {
                throw new Exception("Id inválido");
               
            }
            Pedido p = new Pedido();
            p.IdPedido = pedido.IdPedido;
            PedidoDados dados = new PedidoDados();
            if(dados.Select(p).Count <= 0)
            {
                throw new Exception("O id não se encontra cadastrado");
            }
            dados.Remove(pedido);

        }
        #endregion
        #region Create
        public void Create(Pedido pedido)
        {
            if(pedido == null)
            {
                throw new Exception("");
            }
            if(pedido.IdPedido <= 0)
            {
                throw new Exception("Id invalido");
            }
            PedidoDados dados = new PedidoDados();
            Pedido p = new Pedido();
            p.IdPedido = pedido.IdPedido;

            if(dados.Select(p).Count > 0)
            {
                throw new Exception("Pedido Cadastrado");
            }
            dados.Create(pedido);
        }
        #endregion
        #region Select
        public List<Pedido> Select(Pedido filtro)
        {
            return new PedidoDados().Select(filtro);
        }
        #endregion
        #region Valida Update
        public void Update(Pedido pedido)
        {
            if (pedido.IdPedido <= 0)
            {
                throw new Exception("id invalido");
            }
            PedidoDados dados = new PedidoDados();
            Pedido p = new Pedido();
            p.IdPedido = pedido.IdPedido;

            if (dados.Select(p).Count > 0)
            {
                throw new Exception("Pedido cadastrado");
            }
            dados.Update(pedido);

        }
        #endregion

    }
}//falta validar datas(TextBox) e forma de pagamento(?), predefinir campo de datas e campo de fp só receber número (TextBox)
