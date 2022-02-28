using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;
using Microsoft.EntityFrameworkCore;
namespace тест_асп.Data.repothitory
{
    public class CategorRep : iCarsCategory
    {
        private readonly AppDbContent dbContent;
        public CategorRep(AppDbContent dbContent)
        { this.dbContent = dbContent; }
        public IEnumerable<category> allCategories =>dbContent.Category;
    }
}
