using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using ADO.NET;

namespace Project_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //EntityConnector connector = new EntityConnector();
            //var obj = connector.GetAll();

            AdoConnector connector = new AdoConnector();
            var obj = connector.GetAll();
        }
    }
}
