using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;

namespace тест_асп.Data
{
    public class DbObject
    {
        public static void initial(AppDbContent dbContent)
        {
           
                if (!dbContent.Category.Any())
                dbContent.Category.AddRange(Categories.Select(c => c.Value));
            if (!dbContent.Cars.Any())
                dbContent.AddRange(
                    new Car
                {
                    name = "tesla",
                    shortDesc = "car tesla",
                    longDesc = "car tesla electro",
                    img = "/img/scale_1200.jpg",
                    price = 4500,
                    isFavorite = true,
                    avaiLabel = true,
                    Category =Categories["Электромобили"]
                },
                 new Car
                 {
                     name = "bmv",
                     shortDesc = "benz car",
                     longDesc = "vrum vrum car",
                     img = "/img/kartinki-bmv-24.jpg",
                     price = 4500,
                     isFavorite = false,
                     avaiLabel = false,
                     Category = Categories["двс"]
                 },
                  new Car
                  {
                      name = "bmv",
                      shortDesc = "benz car",
                      longDesc = "vrum vrum car",
                      img = "/img/kartinki-bmv-24.jpg",
                      price = 4500,
                      isFavorite = false,
                      avaiLabel = false,
                      Category = Categories["двс"]
                  }
                   
);
            dbContent.SaveChanges();
        }
        private static Dictionary<string, category> categories;
        public static Dictionary<string, category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var list = new category[]
                            {
                             new category{categoryName="Электромобили",desc="современный вид тр" },
                             new category{categoryName="двс",desc="машины с двс"  }
                            };

                    categories = new Dictionary<string, category>();
                    foreach (category cat in list)
                    {
                        categories.Add(cat.categoryName, cat);
                    }
                }
                return categories;
            }
        }
    }
}
