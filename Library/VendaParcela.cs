using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Library
{
    public class VendaParcela
    {
        public VendaParcela()
        {
        }

        public long Id { get; set; }
        public Library.Venda Venda { get; set; }
        public DateTime? Vencimento { get; set; }
        public DateTime? Pagamento { get; set; }
        public int? Pago { get; set; }
        public decimal? Valor { get; set; }
        public decimal? ValorPago { get; set; }
    }

    static public class VendaParcelaBD
    {
        static public void Save(Library.VendaParcela vendaParcela)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO VendaParcela (idVenda, vencimento, pagamento, pago, valor, valorPago) VALUES (@idVenda, @vencimento, @pagamento, @pago, @valor, @valorPago)"
                + "SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@idVenda", vendaParcela.Venda.Id);
                comando.Parameters.AddWithValue("@pago", vendaParcela.Pago);
                comando.Parameters.AddWithValue("@valor", vendaParcela.Valor);
                comando.Parameters.AddWithValue("@valorPago", vendaParcela.ValorPago);


                if (vendaParcela.Vencimento != null & vendaParcela.Vencimento > SqlDateTime.MinValue.Value & vendaParcela.Vencimento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@vencimento", vendaParcela.Vencimento);
                else
                    comando.Parameters.AddWithValue("@vencimento", SqlDateTime.Null);

                if (vendaParcela.Pagamento != null & vendaParcela.Pagamento > SqlDateTime.MinValue.Value & vendaParcela.Pagamento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@pagamento", vendaParcela.Pagamento);
                else
                    comando.Parameters.AddWithValue("@pagamento", SqlDateTime.Null);

                conexao.Open();

                //comando.ExecuteNonQuery();
                vendaParcela.Id = (long)comando.ExecuteScalar();

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

        static public void Update(Library.VendaParcela vendaParcela)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();
                comando.CommandText = "UPDATE VendaParcela SET idVenda = @idVenda, vencimento = @vencimento, pagamento = @pagamento, pago = @pago, valor = @valor, valorPago = @valorPago WHERE id= " + vendaParcela.Id;
                
                comando.Parameters.AddWithValue("@idVenda", vendaParcela.Venda.Id);
                comando.Parameters.AddWithValue("@pago", vendaParcela.Pago);
                comando.Parameters.AddWithValue("@valor", vendaParcela.Valor);
                comando.Parameters.AddWithValue("@valorPago", vendaParcela.ValorPago);
                
                if (vendaParcela.Vencimento != null & vendaParcela.Vencimento > SqlDateTime.MinValue.Value & vendaParcela.Vencimento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@vencimento", vendaParcela.Vencimento);
                else
                    comando.Parameters.AddWithValue("@vencimento", SqlDateTime.Null);

                if (vendaParcela.Pagamento != null & vendaParcela.Pagamento > SqlDateTime.MinValue.Value & vendaParcela.Pagamento < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@pagamento", vendaParcela.Pagamento);
                else
                    comando.Parameters.AddWithValue("@pagamento", SqlDateTime.Null);



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

        static public void Delete(Library.VendaParcela vendaParcela)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM VendaParcela WHERE (id=" + vendaParcela.Id;

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

        static public void DeleteByVenda(Library.Venda venda)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM VendaParcela WHERE (idVenda= " + venda.Id + ")";

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

        static public List<Library.VendaParcela> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM VendaParcela AS vp ";
                query += "INNER JOIN Venda AS v ON vp.idVenda = v.id ";
                query += "INNER JOIN Cliente AS c ON v.idCliente = c.id ";

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
                        case "vp.id":
                            query += pre + "vp.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "vp.idVenda":
                            query += pre + "vp.idVenda = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "vp.vencimento":
                            query += pre + "vp.vencimento = @vencimento";
                            comando.Parameters.AddWithValue("@vencimento", qi.Objeto);
                            break;
                        case "vp.pagamento":
                            query += pre + "vp.pagamento = @pagamento";
                            comando.Parameters.AddWithValue("@pagamento", qi.Objeto);
                            break;
                        case "vp.pago":
                            query += pre + "vp.pago = @pago";
                            comando.Parameters.AddWithValue("@pago", qi.Objeto);
                            break;
                        case "vp.valor":
                            query += pre + "vp.valor = @valor";
                            comando.Parameters.AddWithValue("@valor", qi.Objeto);
                            break;
                        case "vp.valorPago":
                            query += pre + "vp.valorPago = @valorPago";
                            comando.Parameters.AddWithValue("@valorPago", qi.Objeto);
                            break;
                        case "v.id":
                            query += pre + "v.id = @idVenda";
                            comando.Parameters.AddWithValue("@idVenda", qi.Objeto);
                            break;
                        case "c.id":
                            query += pre + "c.id = @idCliente";
                            comando.Parameters.AddWithValue("@idCliente", qi.Objeto);
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

                List<Library.VendaParcela> vendaParcelas = new List<Library.VendaParcela>();

                while (rdr.Read())
                {
                    Library.VendaParcela vendaParcela = new VendaParcela();
                    vendaParcela.Id = (long)rdr["id"];
                    vendaParcela.Venda = Library.VendaBD.FindById((long)rdr["idVenda"]);
                    vendaParcela.Vencimento = (DateTime)rdr["vencimento"];

                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(rdr["pagamento"].ToString(), out data);
                    vendaParcela.Pagamento = data;

                    vendaParcela.Pago = (int)rdr["pago"];
                    vendaParcela.Valor = (decimal)rdr["valor"];
                    vendaParcela.ValorPago = (decimal)rdr["valorPago"];

                    vendaParcelas.Add(vendaParcela);
                }

                return vendaParcelas;
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

        static public Library.VendaParcela FindById(long id)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM VendaParcela WHERE id= " + id, conexao);

                ds = new DataSet();

                dap.Fill(ds, "VendaParcela");

                Library.VendaParcela vendaParcela = new VendaParcela();

                if (ds.Tables["VendaParcela"].Rows.Count == 1)
                {
                    vendaParcela.Id = (long)ds.Tables["VendaParcela"].Rows[0]["id"];
                    vendaParcela.Venda = Library.VendaBD.FindById((long)ds.Tables["VendaParcela"].Rows[0]["idVenda"]);
                    vendaParcela.Vencimento = (DateTime)ds.Tables["VendaParcela"].Rows[0]["vencimento"];

                    DateTime data = DateTime.MinValue;
                    DateTime.TryParse(ds.Tables["VendaParcela"].Rows[0]["pagamento"].ToString(), out data);
                    vendaParcela.Pagamento = data;

                    vendaParcela.Pago = (int)ds.Tables["VendaParcela"].Rows[0]["pago"];
                    vendaParcela.Valor = (decimal)ds.Tables["VendaParcela"].Rows[0]["valor"];
                    vendaParcela.ValorPago = (decimal)ds.Tables["VendaParcela"].Rows[0]["valorPago"];
                }

                return vendaParcela;
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
    }
}
