using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Database
{
    internal class DataBase
    {
        public SqlConnection Connection { get; private set; }

        public DataBase(string connection)
        {
            Connection = new SqlConnection(connection);
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
