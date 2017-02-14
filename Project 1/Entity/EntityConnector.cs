using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EntityConnector
    {
        private testEntities _Entity = null;

        public EntityConnector()
        {
            _Entity = new testEntities();
        }

        public List<employee> GetAll()
        {
            return _Entity.employees.ToList();
        }
    }
}
