using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace Library
{
    public class Condicional
    {
        public Condicional()
        {
        }

        public long Id { get; set; }
        public Library.Cliente Cliente { get; set; }
        public Library.Funcionario Funcionario { get; set; }
        public DateTime? Data { get; set; }
        public decimal Valor { get; set; }
    }

    static public class CondicionalBD
    {
        static public void Save(Library.Condicional condicional)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Condicional (idCliente, idFuncionario, data, valor) VALUES (@idCliente, @idFuncionario, @data, @valor)"
                +"SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idCliente", condicional.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", condicional.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", condicional.Data);
                comando.Parameters.AddWithValue("@valor", condicional.Valor);

                conexao.Open();

                //comando.ExecuteNonQuery();
                condicional.Id = (long)comando.ExecuteScalar();
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

        static public void Update(Library.Condicional condicional)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE Condicional SET idCliente = @idCliente, idFuncionario = @idFuncionario, data = @data, valor = @valor WHERE (id= " + condicional.Id + ")";
                comando.Parameters.AddWithValue("@idCliente", condicional.Cliente.Id);
                comando.Parameters.AddWithValue("@idFuncionario", condicional.Funcionario.Id);
                comando.Parameters.AddWithValue("@data", condicional.Data);
                comando.Parameters.AddWithValue("@valor", condicional.Valor);

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

        static public void Delete(Library.Condicional condicional)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Condicional WHERE id='" + condicional.Id + "'";

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

        static public List<Library.Condicional> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Condicional AS o ";
                query += "INNER JOIN Cliente AS c ON o.idCliente = c.id ";
                query += "INNER JOIN Funcionario AS f ON o.idFuncionario = f.id ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (qi.Campo != null)
                    {
                        if (p == 0)
                            pre = "WHERE ";
                        else
                            pre = "AND ";

                        p++;

                        switch (qi.Campo)
                        {
                            case "o.id":
                                query += pre + "o.id = @id";
                                comando.Parameters.AddWithValue("@id", qi.Objeto);
                                break;
                            case "o.data varchar":
                                query += pre + "(CONVERT(varchar, o.data, 103) = '@data')";
                                comando.Parameters.AddWithValue("@data", qi.Objeto);
                                break;
                            case "o.formaPagamento":
                                query += pre + "(o.formaPagamento = @formaPagamento)";
                                comando.Parameters.AddWithValue("@formaPagamento", qi.Objeto);
                                break;
                            case "c.nome LIKE %%":
                                query += pre + "(c.nome LIKE '%' + @nome + '%')";
                                comando.Parameters.AddWithValue("@nome", qi.Objeto);
                                break;


                            case "dataMaior":
                                query += pre + "(CONVERT(varchar,o.data, 23) <= @dataMaior)";
                                comando.Parameters.AddWithValue("@dataMaior", qi.Objeto);
                                break;
                            case "dataMenor":
                                query += pre + "(CONVERT(varchar,o.data, 23) >= @dataMenor)";
                                comando.Parameters.AddWithValue("@dataMenor", qi.Objeto);
                                break;
                            case "ORDER BY":
                                query += " ORDER BY " + qi.Objeto;
                                break;
                        }
                    }
                }

                comando.CommandText = query;

                comando.Connection = conexao;

                conexao.Open();

                rdr = comando.ExecuteReader();

                List<Library.Condicional> condicionals = new List<Library.Condicional>();

                while (rdr.Read())
                {
                    Library.Condicional condicional = new Condicional();
                    condicional.Id = (long)rdr["id"];
                    condicional.Cliente = Library.ClienteBD.FindById((long)rdr["idCliente"]);
                    condicional.Funcionario = Library.FuncionarioBD.FindById((long)rdr["idFuncionario"]);
                    condicional.Data = (DateTime)rdr["data"];
                    condicional.Valor = (decimal)rdr["valor"];

                    condicionals.Add(condicional);
                }

                return condicionals;
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

        static public Library.Condicional FindById(long idCondicional)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Condicional condicional = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Condicional WHERE id='" + idCondicional + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Condicional");

                if (ds.Tables["Condicional"].Rows.Count == 1)
                {
                    condicional = new Condicional();
                    condicional.Id = (long)ds.Tables["Condicional"].Rows[0]["id"];
                    condicional.Cliente = Library.ClienteBD.FindById((long)ds.Tables["Condicional"].Rows[0]["idCliente"]);
                    condicional.Funcionario = Library.FuncionarioBD.FindById((long)ds.Tables["Condicional"].Rows[0]["idFuncionario"]);
                    condicional.Data = (DateTime)ds.Tables["Condicional"].Rows[0]["data"];
                    condicional.Valor = (decimal)ds.Tables["Condicional"].Rows[0]["valor"];
                }
                return condicional;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
                dap.Dispose();
                ds.Dispose();
            }
            return null;
        }

        static public long GetNextId()
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "SELECT IDENT_CURRENT('Condicional') AS lastId";

                conexao.Open();
                long lastId = 0;
                long.TryParse(comando.ExecuteScalar().ToString(), out lastId);


                return lastId + 1;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
            }
            finally
            {
                conexao.Close();
            }
            return 0;
        }
    }
}
