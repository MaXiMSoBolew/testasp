using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using тест_асп.Data.interfeises;
using тест_асп.Data.models;
using тест_асп.ViewModel;

namespace тест_асп.controller
{
    public class HomeController : Controller
        {
            private readonly iAllCars carRep;
            private readonly ShopCart _shopCart;

            public HomeController(iAllCars carRep, ShopCart shopCart)
            {
                this.carRep = carRep;
                this._shopCart = shopCart;
            }
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {favcars=carRep.getFavCars };
            return View(homeCars);
        }
        }
}
