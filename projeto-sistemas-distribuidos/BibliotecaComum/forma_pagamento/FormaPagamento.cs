﻿namespace BibliotecaComum.forma_pagamento
{
    public class FormaPagamento
    {
        private int idFormaPagamento;
        private string descricaoFp;
        private string tipoFp;

        public int IdFormaPagamento { get => idFormaPagamento; set => idFormaPagamento = value; }
        public string DescricaoFp { get => descricaoFp; set => descricaoFp = value; }
        public string TipoFp { get => tipoFp; set => tipoFp = value; }
    }
}
