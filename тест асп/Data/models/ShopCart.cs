using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace тест_асп.Data.models
{
    public class ShopCart
    {
        private readonly AppDbContent dbContent;
        public ShopCart (AppDbContent dbContent)
        {
            this.dbContent = dbContent;
        }
        public string ShopCartId { get; set; }

        public List<ShopCarItem> listShopCarItems
        { get; set; }

        public static ShopCart getCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<AppDbContent>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CarId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId};
        }

        public void addToCart(Car car)
        {
            this.dbContent.shopCarItems.Add(new ShopCarItem { ShopCarId = ShopCartId, car = car, price = car.price });
            dbContent.SaveChanges();
        }

        public List<ShopCarItem> getShopItems()
        {
            return dbContent.shopCarItems.Where(c => c.ShopCarId == ShopCartId).Include(s => s.car).ToList();

        }

    }
}
