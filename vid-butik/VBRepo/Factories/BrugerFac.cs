using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace VBRepo
{
   public class BrugerFac : AutoFac<Bruger>
    {
        public Bruger Login(string email, string password)
        {
            Bruger b = new Bruger();
            Mapper<Bruger> mapper = new Mapper<Bruger>();
            using (var CMD = new SqlCommand("select * FROM Bruger WHERE Email=@email AND Password=@password", Conn.CreateConnection()))
            {
                CMD.Parameters.AddWithValue("@email", email);
                CMD.Parameters.AddWithValue("@password", password);

                var r = CMD.ExecuteReader();

                if (r.Read())
                {
                    b = mapper.Map(r);
                }
            }

            return b;
        }

    }
}
