using System;
using System.Collections.Generic;

namespace BibliotecaComum.itens_pedido
{
    public class ItensPedidoNegocio : ItensPedidoInterface
    {
        #region validação Insert
        public void Insert(ItensPedido itensPedido)
        {
            #region validações

            #region validação de objeto
            isItensPedidoValido(itensPedido);
            #endregion

            #region validação de Id do Pedido
            isIdPedidoValido(itensPedido);
            #endregion

            #region validação de Id do Produto
            isIdProdutoValido(itensPedido);
            #endregion
            
            #region validação de quantidade
            isQuantidadeValida(itensPedido);
            #endregion

            #region validação de valor dos itens
            isValorItemValido(itensPedido);
            #endregion

            #region validação de descrição
            isDescricaoValida(itensPedido);
            #endregion

            #endregion


            // chamada ao DAO
            new ItensPedidoDados().Insert(itensPedido);

        }
        #endregion

        #region validação Update
        public void Update(ItensPedido itensPedido)
        {
            new ItensPedidoDados().Update(itensPedido);
        }
        #endregion

        #region validação Delete
        public void Delete(ItensPedido itensPedido)
        {
            new ItensPedidoDados().Delete(itensPedido);
        }
        #endregion

        #region validação Select
        public List<ItensPedido> Select(ItensPedido filtro)
        {
            return new ItensPedidoDados().Select(filtro);
        }
        #endregion

        #region métodos para uso interno da classe
        private static bool isItensPedidoValido(ItensPedido itensPedido)
        {
            if (itensPedido.Equals(null))
                throw new Exception("Nulo: instanciar itens pedido!");
            return true;
        }

        private static bool isIdPedidoValido(ItensPedido itensPedido)
        {
            if (itensPedido.IdPedido <= 0)
                throw new Exception("Código Inválido: o código do pedido precisa ser maior que zero!");
            return true;
        }

        private static bool isIdProdutoValido(ItensPedido itensPedido)
        {
            if (itensPedido.IdProduto <= 0)
                throw new Exception("Código Inválido: o código do produto precisa ser maior que zero!");
            return true;
        }

        private static bool isQuantidadeValida(ItensPedido itensPedido)
        {
            if (itensPedido.Quantidade <= 0)
                throw new Exception("Quantidade Inválida: a quantidade de produtos precisa ser maior que zero!");
            return true;
        }

        private static bool isValorItemValido(ItensPedido itensPedido)
        {
            if (itensPedido.ValorItens <= 0)
                throw new Exception("Valor Inválido: o valor dos produtos precisa ser maior que zero!");
            return true;
        }

        private static bool isDescricaoValida(ItensPedido itensPedido)
        {
            if (itensPedido.DescricaoIp.Length > 150)
                throw new Exception("A descrição do pedido não pode exceder 150 caracteres");

            return true;
        }

        #endregion
    }
}