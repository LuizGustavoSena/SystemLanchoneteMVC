using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Util
{
    public class ConnectionDB : IDisposable
    {
        private static SqlConnection _conn;

        public ConnectionDB()
        {
            _conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConexaoSQLServer"].ConnectionString);
            _conn.Open();
        }

        public bool ExecQuery(string query)
        {
            var cmd = new SqlCommand
            {
                CommandText = query,
                CommandType = CommandType.Text,
                Connection = _conn
            };
            return cmd.ExecuteNonQuery() == 1 ? true : false;
        }
        public int ExecQueryReturnId(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return (int)cmd.ExecuteScalar();
        }
        public SqlDataReader ExecQueryReturn(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteReader();
        }

        public void Dispose()
        {
            if (_conn.State == ConnectionState.Open)
                _conn.Close();
        }
    }
}
