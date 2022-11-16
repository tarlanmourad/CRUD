using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developedCRUD.DB
{
    public class connStr
    {
        public static string GetConnStr
        {
            get { return "Data Source=TARLAN\\LOCALHOST;Initial Catalog=Northwind;Integrated Security=True"; }
        }
    }
}
