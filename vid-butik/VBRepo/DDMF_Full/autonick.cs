using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoDeathNote
{
   public class autonick<T> where T : new()
    {
        private string table;
        Mapper<T> mapper = new Mapper<T>();

        public autonick()
        {
            table = typeof(T).Name;
        }

        public List<T> GetAll()
        {
            using(SqlCommand CMD = new SqlCommand("select * from " + table,Conn.CreateConnection()))
            {
                List<T> list = mapper.MapList(CMD.ExecuteReader());
                CMD.Connection.Close();


                return list;
            }
        }
    }
}
