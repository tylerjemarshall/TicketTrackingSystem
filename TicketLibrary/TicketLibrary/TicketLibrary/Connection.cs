using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{
    class Connection
    {
        private static readonly string connectionString;

        static Connection()
        {
            connectionString = "Data Source=bisiisdev;Initial Catalog=EZTicket10;User ID=bisstudent;Password=bobby2013";
        }

        public static string ConnectionString()
        {
            return connectionString;
        }


    }
}
