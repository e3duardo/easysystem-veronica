using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library
{
    public class Configuracoes
    {
        public Configuracoes()
        {
        }


        public long Id { get; set; }
        public string Empresa { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Impressora { get; set; }
        public string ImpressoraCabecalho { get; set; }
        public string ImpressoraPorta { get; set; }
        public int VendaDiasMinimoEditar { get; set; }
        public DateTime? DataCadastro { get; set; }

        public override string ToString()
        {
            return base.ToString() + "| ID: " + this.Id.ToString() + "| NOME: " + this.Empresa;
        }
    }

    static public class ConfiguracoesBD
    {
        static public void Update(Library.Configuracoes configuracoes)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "UPDATE Configuracoes SET empresa = @empresa, telefone = @telefone, endereco = @endereco, impressora = @impressora, impressoraCabecalho = @impressoraCabecalho, impressoraPorta = @impressoraPorta, dataCadastro = @dataCadastro WHERE (id= " + configuracoes.Id + ")";
                comando.Parameters.AddWithValue("@empresa", configuracoes.Empresa);
                comando.Parameters.AddWithValue("@telefone", configuracoes.Telefone);
                comando.Parameters.AddWithValue("@endereco", configuracoes.Endereco);
                comando.Parameters.AddWithValue("@impressora", configuracoes.Impressora);
                comando.Parameters.AddWithValue("@impressoraCabecalho", configuracoes.ImpressoraCabecalho);
                comando.Parameters.AddWithValue("@impressoraPorta", configuracoes.ImpressoraPorta);
                comando.Parameters.AddWithValue("@vendaDiasMinimoEditar", configuracoes.VendaDiasMinimoEditar);
                comando.Parameters.AddWithValue("@dataCadastro", configuracoes.DataCadastro);

                conexao.Open();

                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
        }

        static public Library.Configuracoes FindById(long idConfiguracoes)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Configuracoes WHERE id='" + idConfiguracoes + "'";

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                while (rdr.Read())
                {
                    Library.Configuracoes configuracoes = new Configuracoes();
                    configuracoes.Id = (long)rdr["id"];
                    configuracoes.Empresa = rdr["empresa"].ToString();
                    configuracoes.Telefone = rdr["telefone"].ToString();
                    configuracoes.Endereco = rdr["endereco"].ToString();
                    configuracoes.Impressora = rdr["impressora"].ToString();
                    configuracoes.ImpressoraCabecalho = rdr["impressoraCabecalho"].ToString();
                    configuracoes.ImpressoraPorta = rdr["impressoraPorta"].ToString();
                    configuracoes.VendaDiasMinimoEditar = (int)rdr["vendaDiasMinimoEditar"];
                    configuracoes.DataCadastro = (DateTime)rdr["dataCadastro"];

                    return configuracoes;
                }
            }
            catch (SqlException ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                comando.Dispose();
            }
            return null;
        }
    }
}
