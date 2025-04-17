using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace coding_challenge.Dao
{
    internal class DBUtility
    {
        static readonly string connectionString = @"Server =NIMALAN\SQLEXPRESS ; Database = codingchallenge2 ; Integrated Security =True ; MultipleActiveResultSets=true;";

        

        public static SqlConnection GetConnection()
        {

            SqlConnection ConnectionObject = new SqlConnection(connectionString);
            try
            {
                ConnectionObject.Open();
                return ConnectionObject;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Opening the connection:{ex.Message}");
                return null;
            }
        }

        public static void CloseDBConnection(SqlConnection ConnectionObject)
        {

            if (ConnectionObject.State != null)
            {
                try
                {
                    if (ConnectionObject.State != ConnectionState.Open)
                    {
                        ConnectionObject.Close();
                        ConnectionObject.Dispose();
                        Console.WriteLine("Connection closed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error closing connection {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("connection is already null");
            }

        }
    }
}
