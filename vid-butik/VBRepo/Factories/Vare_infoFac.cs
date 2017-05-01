using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VBRepo
{
    public class Vare_infoFac : AutoFac<Vare_info>
    {
        private Mapper<Vare_info> mapper = new Mapper<Vare_info>();
        public IEnumerable<Vare_info> NewProduct()
        {
            using (var cmd = new SqlCommand("SELECT TOP 4 * FROM Vare_info ORDER BY ID DESC", Conn.CreateConnection()))
            {

                Mapper<Vare_info> mapper = new Mapper<Vare_info>();

                IEnumerable<Vare_info> list = mapper.MapList(cmd.ExecuteReader());
                cmd.Connection.Close();
                return list;

            }
        }
    }
}
