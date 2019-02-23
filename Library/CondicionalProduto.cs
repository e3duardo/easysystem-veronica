using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Library
{
    public class CondicionalProduto
    {
        public CondicionalProduto()
        {
        }

        public Library.Condicional Condicional { get; set; }
        public Library.Produto Produto { get; set; }
        public decimal? Preco { get; set; }
        public decimal? PrecoTotal { get; set; }
        public double? Quantidade { get; set; }
    }

    static public class CondicionalProdutoBD
    {
        static public void Save(Library.CondicionalProduto condicionalProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO CondicionalProduto (idCondicional, idProduto, preco, precoTotal, quantidade) VALUES (@idCondicional, @idProduto, @preco, @precoTotal, @quantidade)";

                comando.Parameters.AddWithValue("@idCondicional", condicionalProduto.Condicional.Id);
                comando.Parameters.AddWithValue("@idProduto", condicionalProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", condicionalProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", condicionalProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", condicionalProduto.Quantidade);

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

        static public void Update(Library.CondicionalProduto condicionalProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE CondicionalProduto SET idCondicional = @idCondicional, idProduto = @idProduto, preco = @preco, precoTotal = @precoTotal, quantidade = @quantidade WHERE (idCondicional= @WidCondicional AND idProduto = @WidProduto)";
                comando.Parameters.AddWithValue("@idCondicional", condicionalProduto.Condicional.Id);
                comando.Parameters.AddWithValue("@idProduto", condicionalProduto.Produto.Id);
                comando.Parameters.AddWithValue("@preco", condicionalProduto.Preco);
                comando.Parameters.AddWithValue("@precoTotal", condicionalProduto.PrecoTotal);
                comando.Parameters.AddWithValue("@quantidade", condicionalProduto.Quantidade);

                comando.Parameters.AddWithValue("@WidCondicional", condicionalProduto.Condicional.Id);
                comando.Parameters.AddWithValue("@WidProduto", condicionalProduto.Produto.Id);

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

        static public void Delete(Library.CondicionalProduto condicionalProduto)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM CondicionalProduto WHERE (idCondicional= @WidCondicional AND idProduto = @WidProduto)";

                comando.Parameters.AddWithValue("@WidCondicional", condicionalProduto.Condicional.Id);
                comando.Parameters.AddWithValue("@WidProduto", condicionalProduto.Produto.Id);

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

        static public List<Library.CondicionalProduto> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM CondicionalProduto AS opd ";
                query += "INNER JOIN Condicional AS o ON opd.idCondicional = o.id ";
                query += "INNER JOIN Produto AS p ON opd.idProduto = p.id ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = "AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "opd.idCondicional":
                            query += pre + "opd.idCondicional = @idCondicional";
                            comando.Parameters.AddWithValue("@idCondicional", qi.Objeto);
                            break;
                        case "opd.idProduto":
                            query += pre + "opd.idProduto = @idProduto";
                            comando.Parameters.AddWithValue("@idProduto", qi.Objeto);
                            break;
                        case "opd.preco":
                            query += pre + "opd.preco = @preco";
                            comando.Parameters.AddWithValue("@preco", qi.Objeto);
                            break;
                        case "opd.precoTotal":
                            query += pre + "opd.precoTotal = @precoTotal";
                            comando.Parameters.AddWithValue("@precoTotal", qi.Objeto);
                            break;
                        case "opd.quantidade":
                            query += pre + "opd.quantidade = @quantidade";
                            comando.Parameters.AddWithValue("@quantidade", qi.Objeto);
                            break;
                        case "o.id":
                            query += pre + "o.id = @idCondicional";
                            comando.Parameters.AddWithValue("@idCondicional", qi.Objeto);
                            break;
                        case "ORDER BY":
                            query += " ORDER BY " + qi.Objeto;
                            break;
                    }
                }

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.CondicionalProduto> CondicionalProdutos = new List<Library.CondicionalProduto>();

                while (rdr.Read())
                {
                    Library.CondicionalProduto condicionalProduto = new CondicionalProduto();
                    condicionalProduto.Condicional = Library.CondicionalBD.FindById((long)rdr["idCondicional"]);
                    condicionalProduto.Produto = Library.ProdutoBD.FindById((long)rdr["idProduto"]);
                    condicionalProduto.Preco = (decimal)rdr["preco"];
                    condicionalProduto.PrecoTotal = (decimal)rdr["precoTotal"];
                    condicionalProduto.Quantidade = (double)rdr["quantidade"];

                    CondicionalProdutos.Add(condicionalProduto);
                }

                return CondicionalProdutos;
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
