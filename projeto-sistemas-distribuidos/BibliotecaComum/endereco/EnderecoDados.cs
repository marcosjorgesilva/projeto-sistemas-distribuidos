using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BibliotecaComum.conexao;

namespace BibliotecaComum.endereco
{
    public class EnderecoDados : Conexao, EnderecoInterface
    {
        
      

        #region Insert
        public void CreateEndereco(Endereco endereco)  // logradouro, numero, bairro, cep, complemento, referencia
        {
            this.abrirConexao();
            string sqlQuery = "INSERT INTO endereco (logradouro, numero, bairro, cep, complemento, referencia, cidade, estado) ";
            sqlQuery += "VALUES ( @logradouro, @numero, @bairro, @cep, @complemento, @referencia, @cidade, @estado)";
            
            SqlCommand cmd = new SqlCommand(sqlQuery, this.sqlConnection);

           
               

            cmd.Parameters.Add("@logradouro", SqlDbType.VarChar);
            cmd.Parameters["@logradouro"].Value = endereco.Logradouro;

            cmd.Parameters.Add("@numero", SqlDbType.Int);
            cmd.Parameters["@numero"].Value = endereco.Numero;

            cmd.Parameters.Add("@bairro", SqlDbType.VarChar);
            cmd.Parameters["@bairro"].Value = endereco.Bairro;

            cmd.Parameters.Add("@cep", SqlDbType.VarChar);
            cmd.Parameters["@cep"].Value = endereco.Bairro;

            cmd.Parameters.Add("@complemento", SqlDbType.VarChar);
            cmd.Parameters["@complemento"].Value = endereco.Complemento;

            cmd.Parameters.Add("@referencia", SqlDbType.VarChar);
            cmd.Parameters["@referencia"].Value = endereco.Referencia;

            cmd.Parameters.Add("@cidade", SqlDbType.VarChar);
            cmd.Parameters["@cidade"].Value = endereco.Cidade;

            cmd.Parameters.Add("@estado", SqlDbType.VarChar);
            cmd.Parameters["@estado"].Value = endereco.Estado;


            // execução da query
            cmd.ExecuteNonQuery();

            // liberação de memória alocada para o objeto SqlCommand
            cmd.Dispose();

            // fechamento de conexão com base de dados
            this.fecharConexao();
        }
        #endregion


        #region delete
        public void RemoveEndereco(Endereco endereco)
        {
            // lógica que acessa a base de dados e realiza instrução DELETE baseado no idEndereco do usuário
            this.abrirConexao();
            string sql = "DELETE endereco WHERE id_endereco = @idEndereco ";
            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@idEndereco", SqlDbType.Int);
            cmd.Parameters["@idEndereco"].Value = endereco.IdEndereco;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();
        }
        #endregion

        #region update
        public void UpdateEndereco(Endereco endereco)
        {
            //abrir a conexão
            this.abrirConexao();
            string sql = "UPDATE endereco SET ";
            sql += "logradouro = @logradouro, ";
            sql += "numero = @numero, ";
            sql += "bairro = @bairro, ";
            sql += "cep = @cep, ";
            sql += "complemento = @complemento, ";
            sql += "referencia = @referencia, ";
            sql += "cidade = @cidade, ";
            sql += "estado = @estado ";

            sql += "WHERE id_endereco = @idEndereco";

            SqlCommand cmd = new SqlCommand(sql, this.sqlConnection);

            cmd.Parameters.Add("@idEndereco", SqlDbType.Int);
            cmd.Parameters["@idEndereco"].Value = endereco.IdEndereco;

            cmd.Parameters.Add("@logradouro", SqlDbType.VarChar);
            cmd.Parameters["@logradouro"].Value = endereco.Logradouro;

            cmd.Parameters.Add("@numero", SqlDbType.Int);
            cmd.Parameters["@numero"].Value = endereco.Numero;

            cmd.Parameters.Add("@bairro", SqlDbType.VarChar);
            cmd.Parameters["@bairro"].Value = endereco.Bairro;

            cmd.Parameters.Add("@cep", SqlDbType.VarChar);
            cmd.Parameters["@cep"].Value = endereco.Cep;

            cmd.Parameters.Add("@complemento", SqlDbType.VarChar);
            cmd.Parameters["@complemento"].Value = endereco.Complemento;

            cmd.Parameters.Add("@referencia", SqlDbType.VarChar);
            cmd.Parameters["@referencia"].Value = endereco.Referencia;

            cmd.Parameters.Add("@cidade", SqlDbType.VarChar);
            cmd.Parameters["@cidade"].Value = endereco.Cidade;

            cmd.Parameters.Add("@estado", SqlDbType.VarChar);
            cmd.Parameters["@estado"].Value = endereco.Estado;

            //executando a instrução
            cmd.ExecuteNonQuery();

            //liberando a memória 
            cmd.Dispose();

            //fechando a conexão
            this.fecharConexao();






        }
        #endregion

        #region Select
        public List<Endereco> DetailEndereco(Endereco filtro)

        {
            List<Endereco> retorno = new List<Endereco>();

            this.abrirConexao();
            string sql = "SELECT id_endereco, logradouro, numero, bairro, cep, complemento, referencia, cidade, estado ";
            sql += "FROM Endereco ";
            sql += "WHERE idEndereco = id_endereco";

            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            //se foi passada um idEndereco válido como critério de filtro.
            if (filtro.IdEndereco > 0)
            {
                sql += " and id_endereco = @idEndereco";

                cmd.Parameters.Add("@idEndereco", SqlDbType.Int);
                cmd.Parameters["@idEndereco"].Value = filtro.IdEndereco;
            }


            if (!(String.IsNullOrEmpty(filtro.Logradouro) && String.IsNullOrWhiteSpace(filtro.Logradouro)))
            {
                sql += " and logradouro = @logradouro";

                cmd.Parameters.Add("@logradouro", SqlDbType.VarChar);
                cmd.Parameters["@logradouro"].Value = "%" + filtro.Logradouro + "%";
            }

            if (filtro.Numero > 0)
            {
                sql += " and numero = @numero";

                cmd.Parameters.Add("@numero", SqlDbType.Int);
                cmd.Parameters["@numero"].Value = filtro.Numero;
            }

            if (!(String.IsNullOrEmpty(filtro.Bairro) && String.IsNullOrWhiteSpace(filtro.Bairro)))
            {
                sql += " and bairro = @bairro";

                cmd.Parameters.Add("@bairro", SqlDbType.VarChar);
                cmd.Parameters["@bairro"].Value = "%" + filtro.Bairro + "%";
            }

            if (!(String.IsNullOrEmpty(filtro.Cep) && String.IsNullOrWhiteSpace(filtro.Cep)))
            {
                sql += " and cep = @cep";

                cmd.Parameters.Add("@cep", SqlDbType.VarChar);
                cmd.Parameters["@cep"].Value = "%" + filtro.Cep + "%";
            }

            if (!(String.IsNullOrEmpty(filtro.Complemento) && String.IsNullOrWhiteSpace(filtro.Complemento)))
            {
                sql += " and complemento = @complemento";

                cmd.Parameters.Add("@complemento", SqlDbType.VarChar);
                cmd.Parameters["@complemento"].Value = "%" + filtro.Complemento + "%";
            }

            if (!(String.IsNullOrEmpty(filtro.Referencia) && String.IsNullOrWhiteSpace(filtro.Referencia)))
            {
                sql += " and referencia = @referencia";

                cmd.Parameters.Add("@referencia", SqlDbType.VarChar);
                cmd.Parameters["@referencia"].Value = "%" + filtro.Referencia + "%";
            }


            if (!(String.IsNullOrEmpty(filtro.Cidade) && String.IsNullOrWhiteSpace(filtro.Cidade)))
            {
                sql += " and cidade = @cidade";

                cmd.Parameters.Add("@cidade", SqlDbType.VarChar);
                cmd.Parameters["@cidade"].Value = "%" + filtro.Cidade + "%";
            }

            if (!(String.IsNullOrEmpty(filtro.Estado) && String.IsNullOrWhiteSpace(filtro.Estado)))
            {
                sql += " and estado = @estado";

                cmd.Parameters.Add("@estado", SqlDbType.VarChar);
                cmd.Parameters["@estado"].Value = "%" + filtro.Referencia + "%";
            }


            SqlDataReader DbReader = cmd.ExecuteReader();

            while (DbReader.Read())
            {
                Endereco endereco = new Endereco();

                endereco.IdEndereco = DbReader.GetInt32(DbReader.GetOrdinal("id_endereco"));
                endereco.Logradouro = DbReader.GetString(DbReader.GetOrdinal("logradouro"));
                endereco.Numero = DbReader.GetInt32(DbReader.GetOrdinal("numero"));
                endereco.Bairro = DbReader.GetString(DbReader.GetOrdinal("bairro"));
                endereco.Cep = DbReader.GetString(DbReader.GetOrdinal("cep"));
                endereco.Complemento = DbReader.GetString(DbReader.GetOrdinal("complemento"));
                endereco.Referencia = DbReader.GetString(DbReader.GetOrdinal("referencia"));
                endereco.Cidade = DbReader.GetString(DbReader.GetOrdinal("cidade"));
                endereco.Estado = DbReader.GetString(DbReader.GetOrdinal("estado"));


                retorno.Add(endereco);
            }

            DbReader.Close();

            cmd.ExecuteNonQuery();

            cmd.Dispose();

            this.fecharConexao();

            return retorno;

            



            
        }
        #endregion
    }
}
