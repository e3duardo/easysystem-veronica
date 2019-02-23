using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Library
{
    public class Class1
    {
        public Class1()
        {
            try
            {
                for (int i = 1; i < 500; i++)
                {
                    try
                    {
                        SqlConnection conexao = new SqlConnection(global::Connection.Connection.String());
                        SqlCommand comando = conexao.CreateCommand();

                        comando.CommandText = "INSERT INTO Venda (idCliente,idFuncionario,data,valor,pago,formaPagamento,entrada)" +
                 "VALUES (" + i + ", 1, '" + DateTime.Now + "', 0, 0, 'avista', 0)";

                       // conexao.Open();
                        //comando.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public void class2()
        {
            Random r = new Random();



            try
            {
                for (int i = 1; i < 1124; i++)
                {
                    long venda = r.Next(1, 1124);

                    for (int j = 1; j < 881; i++)
                    {
                        try
                        {
                            SqlConnection conexao = new SqlConnection(global::Connection.Connection.String());
                            SqlCommand comando = conexao.CreateCommand();

                            comando.CommandText = "INSERT INTO VendaProduto (idVenda,idProduto,preco,precoTotal,quantidade)" +
                "VALUES (" + venda + "," + r.Next(1, 881) + ",0,0," + r.Next(1, 10) + ")";

                            conexao.Open();
                            comando.ExecuteScalar();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

    }
}
