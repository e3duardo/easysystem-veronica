using System;
using System.Data.SqlClient;

namespace Library
{
    static public class Backup
    {
        static public void Execute(string file)
        {
            SqlConnection conexao = null;

            try
            {
                conexao = new SqlConnection(global::Connection.Connection.String());

                SqlCommand comando = conexao.CreateCommand();

                comando.CommandText = "BACKUP DATABASE " + Connection.Connection.Database() + " TO DISK=@back";

                comando.Parameters.AddWithValue("@back", file);

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
    }
}