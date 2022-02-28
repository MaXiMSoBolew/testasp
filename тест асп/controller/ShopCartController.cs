using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;

using тест_асп.Migrations;
using тест_асп.ViewModel;

namespace тест_асп.controller
{
    public class ShopCartController: Controller
    {
        private readonly iAllCars carRep;
        private readonly ShopCart _shopCart;

        public ShopCartController (iAllCars carRep, ShopCart shopCart)
        {
            this.carRep = carRep;
            this._shopCart = shopCart;
        }
          public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.listShopCarItems = items;

            var obj = new ShopCartViewModels { shopCart = _shopCart };
            return View(obj);
        }
        public RedirectToActionResult addToCart(int id)
        {
            var item = carRep.Cars.FirstOrDefault(i => i.id == id);
            if (item != null)
                _shopCart.addToCart(item);
            return RedirectToAction("Index");
        }
    }
}
