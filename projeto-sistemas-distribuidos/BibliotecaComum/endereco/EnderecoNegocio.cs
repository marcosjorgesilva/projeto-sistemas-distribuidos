using System;
using System.Collections.Generic;

namespace BibliotecaComum.endereco
{
    class EnderecoNegocio : EnderecoInterface
    {
        public void CreateEndereco(Endereco endereco)
        {

            if (endereco == null)
                throw new Exception("É obrigatório informar um endereço!");

            if (string.IsNullOrEmpty(endereco.Logradouro) == true)
                throw new Exception("Informe o logradouro!");

            if (endereco.Logradouro.Length > 150)
                throw new Exception("O logradouro não pode conter mais que 100 dígitos!");

            if (endereco.Numero <= 0)
                throw new Exception("Informe a matricula!");
            

            if (string.IsNullOrEmpty(endereco.Cep) == true)
                throw new Exception("Informe o endereço!");

            if (endereco.Cep.Length > 8)
                throw new Exception("O cep não pode conter mais uqe 8 dígitos!");

            if (string.IsNullOrEmpty(endereco.Complemento) == true)
                throw new Exception("Informe o complemento!");

            if (endereco.Complemento.Length > 150)
                throw new Exception("O complemento não pode conter mais que 100 dígitos!");

            if (string.IsNullOrEmpty(endereco.Bairro) == true)
                throw new Exception("Informe o Bairro!");

            if (endereco.Bairro.Length > 50)
                throw new Exception("O bairro não pode conter mais que 100 dígitos!");

            if (string.IsNullOrEmpty(endereco.Referencia) == true)
                throw new Exception("Informe a Referencia!");

            if (endereco.Referencia.Length > 150)
                throw new Exception("A referência não pode conter mais que 100 digítos!");

            if (string.IsNullOrEmpty(endereco.Cidade) == true)
                throw new Exception("Informe a Cidade!");

            if (endereco.Cidade.Length > 20)
                throw new Exception("A cidade não pode conter mais que 20 digítos!");

            if (string.IsNullOrEmpty(endereco.Estado) == true)
                throw new Exception("Informe o Estado!");

            if (endereco.Estado.Length > 2)
                throw new Exception("O estado não pode conter mais que 2 digítos!");

            validarEndereco(endereco);


           
            new EnderecoDados().CreateEndereco(endereco);
        }

        private void validarEndereco(Endereco endereco)
        {
            string[] simbolosNom =  {"!", "@", "#", "$", "%", "&", "*", "(", ")", "-", "+", "=", "'", "/", ".",
                                     ",", "|", "<", ">", ":", ";", "?", "~", "^", "´", "`", "_", "[", "]", "{",
                                     "}", "ª", "º", "°",  "\\"};

            string[] numeros = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            for (int i = 0; i < simbolosNom.Length; i++)
            {
                if (endereco.Logradouro.Contains(simbolosNom[i]))
                    throw new Exception("Logradouro não pode conter caracteres especiais!");



                if (endereco.Cep.Contains(simbolosNom[i]))
                    throw new Exception("O cep não pode conter caracteres especiais!");



                if (endereco.Bairro.Contains(simbolosNom[i]))
                    throw new Exception("Bairro não pode conter  caracteres especiais!");



                if (endereco.Complemento.Contains(simbolosNom[i]))
                    throw new Exception("Complemento não pode conter numeros e/ou caracteres especiais!");



                if (endereco.Referencia.Contains(simbolosNom[i]))
                    throw new Exception("Referencia não pode conter caracteres especiais!");
            }

            for (int i = 0; i < numeros.Length; i++)
            {
                if (endereco.Referencia.Contains(numeros[i]))
                    throw new Exception("Referencia  não pode conter números!");

                if (endereco.Complemento.Contains(numeros[i]))
                    throw new Exception("Complemento não pode conter números!");

                if (endereco.Bairro.Contains(numeros[i]))
                    throw new Exception("Bairro não pode conter números!");

                if (endereco.Cep.Contains(numeros[i]))
                    throw new Exception("O cep não pode conter números!");

                if (endereco.Logradouro.Contains(numeros[i]))
                    throw new Exception("Logradouro não pode conter números!");
            }
            
        }

        public void RemoveEndereco(Endereco endereco)
        {
            new EnderecoDados().RemoveEndereco(endereco);
        }

        public void UpdateEndereco(Endereco endereco)
        {
            validarEndereco(endereco);
            new EnderecoDados().UpdateEndereco(endereco);
        }

        public List<Endereco> DetailEndereco(Endereco filtro)
        {
            return new EnderecoDados().DetailEndereco(filtro);
        }
    }
}