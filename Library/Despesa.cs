using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Library
{
    public class Despesa
    {
        public Despesa()
        {
        }

        public long Id { get; set; }
        public DateTime? Data { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }


        public DateTime VencimentoInicio { get; set; }
        public DateTime VencimentoFim { get; set; }

        public bool repetitivo { get; set; }
        public string ocorre { get; set; }


        /// <summary>
        /// recor_dia: (se = 0: todos os dias uteis, se > 0 dia especifico.), para valores em 'recorrencia-diariamente'
        /// </summary>
        public int recor_dia { get; set; } // 


        /// <summary>
        /// recor_sem: valor de semanas que se repetem, para valor em 'recorrencia-semanalmente'
        /// </summary>
        public int recor_sem { get; set; }

        /// <summary>
        /// recorsem_lst: dias das semanas selecionados (formato: '0,1,2,3,4,5,6', para todos os dias), para valores em 'recorrencia-semanalmente'
        /// </summary>
        public string recorsem_lst { get; set; }


        /// <summary>
        /// recor_men: valor de meses que se repetem, usado em conjunto com recor_dia, para valor em 'recorrencia-mensalmente'
        /// </summary>
        public int recor_men { get; set; }

        /// <summary>
        /// recor_ord: valor ordinal (ex: primeira quinta feira do mes), 0 == ultimo, usado em conjunto com recordsem_lst, para valor em 'recorrencia-mensalmente'
        /// </summary>
        public int recor_ord { get; set; }
    }
    static public class DespesaBD
    {
        static public void Save(Library.Despesa despesa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "INSERT INTO Despesa (descricao, valor, vencimentoInicio, vencimentoFim, repetitivo, ocorre, recor_dia, recor_sem, recorsem_lst, recor_men, recor_ord) VALUES (@descricao, @valor, @vencimentoInicio, @vencimentoFim, @repetitivo, @ocorre, @recor_dia, @recor_sem, @recorsem_lst, @recor_men, @recor_ord)"
                + "SELECT CAST(scope_identity() AS bigint)";

                comando.Parameters.AddWithValue("@descricao", despesa.Descricao);
                comando.Parameters.AddWithValue("@valor", despesa.Valor);

                if (despesa.VencimentoInicio != null & despesa.VencimentoInicio > SqlDateTime.MinValue.Value & despesa.VencimentoInicio < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@vencimentoInicio", despesa.VencimentoInicio);
                else
                    comando.Parameters.AddWithValue("@vencimentoInicio", DBNull.Value);

                if  (despesa.VencimentoFim != null & despesa.VencimentoFim > SqlDateTime.MinValue.Value & despesa.VencimentoFim < SqlDateTime.MaxValue.Value)
                    comando.Parameters.AddWithValue("@vencimentoFim", despesa.VencimentoFim);
                else
                    comando.Parameters.AddWithValue("@vencimentoFim", DBNull.Value);

                if (despesa.repetitivo)
                    comando.Parameters.AddWithValue("@repetitivo", 1);
                else
                    comando.Parameters.AddWithValue("@repetitivo", 0);




                if (despesa.ocorre != null && despesa.ocorre != "")
                    comando.Parameters.AddWithValue("@ocorre", despesa.ocorre);
                else
                    comando.Parameters.AddWithValue("@ocorre", DBNull.Value);
                
                if (despesa.recor_dia != -1)
                    comando.Parameters.AddWithValue("@recor_dia", despesa.recor_dia);
                else
                    comando.Parameters.AddWithValue("@recor_dia", DBNull.Value);

                if (despesa.recor_sem != -1)
                    comando.Parameters.AddWithValue("@recor_sem", despesa.recor_sem);
                else
                    comando.Parameters.AddWithValue("@recor_sem", DBNull.Value);

                if (despesa.recorsem_lst != null && despesa.recorsem_lst != "")
                    comando.Parameters.AddWithValue("@recorsem_lst", despesa.recorsem_lst);
                else
                    comando.Parameters.AddWithValue("@recorsem_lst", DBNull.Value);

                if (despesa.recor_men != -1)
                    comando.Parameters.AddWithValue("@recor_men", despesa.recor_men);
                else
                    comando.Parameters.AddWithValue("@recor_men", DBNull.Value);

                if (despesa.recor_ord != -1)
                    comando.Parameters.AddWithValue("@recor_ord", despesa.recor_ord);
                else
                    comando.Parameters.AddWithValue("@recor_ord", DBNull.Value);

                conexao.Open();

                //comando.ExecuteNonQuery();
                despesa.Id = (long)comando.ExecuteScalar();

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

        static public bool Delete(Library.Despesa despesa)
        {
            SqlConnection conexao = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());
                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "DELETE FROM Despesa WHERE id='" + despesa.Id + "'";

                conexao.Open();
                int teste = comando.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Library.Diagnostics.Logger.Error(ex);
                return false;
            }
            finally
            {
                conexao.Close();
            }
        }

        static public List<Library.Despesa> FindAdvanced(params Library.Classes.QItem[] args)
        {
            SqlDataReader rdr = null;
            SqlConnection conexao = null;
            SqlCommand comando = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                comando = new SqlCommand();

                string query = "SELECT * FROM Despesa AS d ";

                int p = 0;
                string pre = "";
                foreach (Library.Classes.QItem qi in args)
                {
                    if (p == 0)
                        pre = "WHERE ";
                    else
                        pre = " AND ";

                    p++;

                    switch (qi.Campo)
                    {
                        case "d.id":
                            query += pre + "d.id = @id";
                            comando.Parameters.AddWithValue("@id", qi.Objeto);
                            break;
                        case "d.data":
                            query += pre + "(CONVERT(varchar, d.data, 103) = '@data')";
                            comando.Parameters.AddWithValue("@data", qi.Objeto);
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

                List<Library.Despesa> despesas = new List<Library.Despesa>();

                while (rdr.Read())
                {
                    Library.Despesa despesa = new Despesa();
                    despesa.Id = (long)rdr["id"];
                    despesa.Data = (DateTime)rdr["data"];
                    despesa.Descricao = rdr["descricao"].ToString();
                    despesa.Valor = (decimal)rdr["valor"];


                    despesa.VencimentoInicio = (DateTime)rdr["vencimentoInicio"];
                    despesa.VencimentoFim = (DateTime)rdr["vencimentoFim"];
                    if ((int)rdr["repetitivo"] == 1)
                        despesa.repetitivo = true;
                    else
                        despesa.repetitivo = false;
                    despesa.ocorre = (string)rdr["ocorre"];
                    despesa.recor_dia = (int)rdr["recor_dia"];
                    despesa.recor_sem = (int)rdr["recor_sem"];
                    despesa.recorsem_lst = (string)rdr["recorsem_lst"];
                    despesa.recor_men = (int)rdr["recor_men"];
                    despesa.recor_ord = (int)rdr["recor_ord"];


                    despesas.Add(despesa);
                }

                return despesas;
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

        static public Library.Despesa FindById(long idDespesa)
        {
            SqlConnection conexao = null;
            SqlDataAdapter dap = null;
            DataSet ds = null;
            Library.Despesa despesa = null;
            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                dap = new SqlDataAdapter("SELECT * FROM Despesa WHERE id='" + idDespesa + "'", conexao);

                ds = new DataSet();

                dap.Fill(ds, "Despesa");

                if (ds.Tables["Despesa"].Rows.Count == 1)
                {
                    despesa = new Despesa();
                    despesa.Id = (long)ds.Tables["Despesa"].Rows[0]["id"];
                    despesa.Data = (DateTime)ds.Tables["Despesa"].Rows[0]["data"];
                    despesa.Descricao = ds.Tables["Despesa"].Rows[0]["descricao"].ToString();
                    despesa.Valor = (decimal)ds.Tables["Despesa"].Rows[0]["valor"];

                    despesa.VencimentoInicio = (DateTime)ds.Tables["Despesa"].Rows[0]["vencimentoInicio"];
                    despesa.VencimentoFim = (DateTime)ds.Tables["Despesa"].Rows[0]["vencimentoFim"];
                    despesa.repetitivo = (bool)ds.Tables["Despesa"].Rows[0]["repetitivo"];
                    despesa.ocorre = (string)ds.Tables["Despesa"].Rows[0]["ocorre"];
                    despesa.recor_dia = (int)ds.Tables["Despesa"].Rows[0]["recor_dia"];
                    despesa.recor_sem = (int)ds.Tables["Despesa"].Rows[0]["recor_sem"];
                    despesa.recorsem_lst = (string)ds.Tables["Despesa"].Rows[0]["recorsem_lst"];
                    despesa.recor_men = (int)ds.Tables["Despesa"].Rows[0]["recor_men"];
                    despesa.recor_ord = (int)ds.Tables["Despesa"].Rows[0]["recor_ord"];
                }
                return despesa;
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

                comando.CommandText = "SELECT IDENT_CURRENT('Despesa') AS lastId";

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
