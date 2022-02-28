using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.models;

namespace тест_асп.Data.interfeises
{
   public interface iAllCars
    {
        IEnumerable<Car> Cars{get;}
        IEnumerable<Car> getFavCars { get;  }
        Car getObjectCar(int carID);
    }
}
