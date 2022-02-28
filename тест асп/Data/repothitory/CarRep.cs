using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;
using Microsoft.EntityFrameworkCore;

namespace тест_асп.Data.repothitory
{
    public class CarRep : iAllCars
    {
        private readonly AppDbContent dbContent;
        public CarRep(AppDbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public IEnumerable<Car> Cars =>dbContent.Cars.Include(c=>c.Category);

        public IEnumerable<Car> getFavCars => dbContent.Cars.Where(p => p.isFavorite).Include(c => c.Category);

        public Car getObjectCar(int carID)
        {
           return dbContent.Cars.FirstOrDefault(p => p.id == carID);
        }
    }
}
