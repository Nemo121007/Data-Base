using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DataBaseForms
{
    internal class DataBase
    {
        public SqlConnection Connection { get; private set; }

        public DataBase(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public bool OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();

            return Connection.State == ConnectionState.Open;
        }

        public bool CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();

            return Connection.State == ConnectionState.Closed;
        }
    }
}
