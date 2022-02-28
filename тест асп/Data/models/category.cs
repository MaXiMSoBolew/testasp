using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace тест_асп.Data.models
{
    public class category
    {
        public int ID{ set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List<Car>Cars { set; get; }

    }
}
