using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Connection
{
    public static class Connection
    {
        public static string String()
        {
            return "Data Source=127.0.0.1;Initial Catalog=" + Database() + ";Persist Security Info=True;User ID=sa;Password=temporal";
        }


        public static string Database()
        {
            return "ClaudiaBD";
        }
    }
}
