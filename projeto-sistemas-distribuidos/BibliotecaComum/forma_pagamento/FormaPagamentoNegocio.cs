using System;
using System.Collections.Generic;

namespace BibliotecaComum.forma_pagamento
{
    public class FormaPagamentoNegocio : FormaPagamentoInterface
    {
        
        #region validação Insert
        public void Insert(FormaPagamento formaPagamento)
        {
            #region validações

            #region validação de objeto
            isformaPagamentoValida(formaPagamento);
            #endregion

            #region validação de Id
            isIdFormaPagamentoValida(formaPagamento);
            #endregion

            #region validações de descrição
            isDescricaoValida(formaPagamento);
            #endregion

            #region validações de tipo
            isTipoValido(formaPagamento);
            #endregion

            #endregion

            // chamada ao DAO
            new FormaPagamentoDados().Insert(formaPagamento);
        }
        #endregion

        #region validação Update
        public void Update(FormaPagamento formaPagamento)
        {
            new FormaPagamentoDados().Update(formaPagamento);
        }
        #endregion

        #region validação Delete
        public void Delete(FormaPagamento formaPagamento)
        {            
            new FormaPagamentoDados().Delete(formaPagamento);
        }
        #endregion

        #region validação Select
        public List<FormaPagamento> Select(FormaPagamento filtro)
        {
            return new FormaPagamentoDados().Select(filtro);
        }
        #endregion                                   

        #region métodos para uso interno da classe
        private static bool isformaPagamentoValida(FormaPagamento formaPagamento)
        {
            if (formaPagamento.Equals(null))
                throw new Exception("Nulo: instanciar o forma de pagamento!");
            return true;
        }

        private static bool isIdFormaPagamentoValida(FormaPagamento formaPagamento)
        {
            if (formaPagamento.IdFormaPagamento <= 0)
                throw new Exception("Código Inválido: o código da forma de pagamento precisa ser maior que zero!");
            return true;
        }

        private static bool isDescricaoValida(FormaPagamento formaPagamento)
        {
            if (formaPagamento.DescricaoFp == null)
                throw new Exception("Nulo: Informar a forma de pagamento!");
            if (formaPagamento.DescricaoFp.Length > 50)
                throw new Exception("A descrição da forma de pagamento não pode exceder 50 caracteres");

            return true;
        }

        private static bool isTipoValido(FormaPagamento formaPagamento)
        {
            if (formaPagamento.TipoFp == null)
                throw new Exception("Nulo: Informar o tipo de forma de pagamento!");
            if (formaPagamento.TipoFp.Length > 50)
                throw new Exception("O tipo de forma pagamento não pode exceder 50 caracteres");

            return true;
        }
        #endregion

    }
}