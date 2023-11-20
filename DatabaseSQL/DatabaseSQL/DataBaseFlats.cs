using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database;
using Microsoft.Data.SqlClient;

namespace DatabaseSQL
{
    internal class DataBaseFlats
    {
        public static DataBase dataBaseFlats = new DataBase("Server=127.0.0.1;Database=db22205;TrustServerCertificate=true;User Id=User050;Password=User050][7");
    
        public static Dictionary<string, int> ListObject_Id(string sqlCommand, string obj, string id)
        {
            var list = new Dictionary<string, int>();

            DataBaseFlats.dataBaseFlats.OpenConnection();

            var slqCommand = new SqlCommand(sqlCommand, DataBaseFlats.dataBaseFlats.Connection);

            var reader = slqCommand.ExecuteReader();

            while (reader.Read())
                list.Add(reader[obj].ToString(), Convert.ToInt32(reader[id]));

            DataBaseFlats.dataBaseFlats.CloseConnection();

            return list;
        }
    }
}
