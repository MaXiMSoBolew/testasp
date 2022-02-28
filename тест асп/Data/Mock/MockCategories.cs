using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;

namespace тест_асп.Data.Mock
{
    public class MockCategories : iCarsCategory 
    {
        public IEnumerable<category> allCategories { get { return new List<category> {
        
        new category{categoryName="Электромобили",desc="современный вид тр" },
        new category{categoryName="двс",desc="машины с двс"  }

        }; } }
    }
}
