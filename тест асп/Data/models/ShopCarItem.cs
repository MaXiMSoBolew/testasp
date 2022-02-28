using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace тест_асп.Data.models
{
    public class ShopCarItem
    {
        public int Id
        { get; set; }
        public Car car { get; set; }
        public int price { get; set; }

        public string ShopCarId { get; set; }
        }
}
