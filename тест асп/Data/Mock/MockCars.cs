using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;

namespace тест_асп.Data.Mock
{
    public class MockCars : iAllCars
    {

        private readonly iCarsCategory iCarsCategory = new MockCategories();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car>
            {
                new Car {name="tesla",shortDesc="car tesla",
                    longDesc="car tesla electro",
                    img="/img/scale_1200.jpg",
                    price=4500,isFavorite=true,avaiLabel=true,Category=iCarsCategory.allCategories.First() },
                 new Car {name="bmv",shortDesc="benz car",
                    longDesc="vrum vrum car",
                    img="/img/kartinki-bmv-24.jpg",
                    price=4500,isFavorite=false,avaiLabel=false,Category=iCarsCategory.allCategories.Last() },
                  new Car {name="bmv",shortDesc="benz car",
                    longDesc="vrum vrum car",
                    img="/img/kartinki-bmv-24.jpg",
                    price=4500,isFavorite=false,avaiLabel=false,Category=iCarsCategory.allCategories.Last() }

            };
            }
        }
        public IEnumerable<Car> getFavCars { get; set; }

        public Car getObjectCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
