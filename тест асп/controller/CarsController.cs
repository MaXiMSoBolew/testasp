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
    public class CarsController:Controller
    {
        private readonly iAllCars allCars;
        private readonly iCarsCategory carsCategory;

        public CarsController(iAllCars allCars, iCarsCategory carsCategory) {
            this.carsCategory = carsCategory;this.allCars = allCars;
        }
   [Route ("Cars/List")]
      [Route("Cars/List/{cat}")]
     
        public ViewResult List(string cat) {
            string curcat ="all";
            IEnumerable<Car> cars=null;

            if (string.IsNullOrEmpty(cat))
            {
                cars = allCars.Cars.OrderBy(c => c.id);
            }

            else
            {
                if (string.Equals("electro", cat, StringComparison.OrdinalIgnoreCase)) { 
                    cars = allCars.Cars.Where(c => c.Category.categoryName == "Электромобили").OrderBy(c => c.id);
                curcat = "Электромобили"; }
                else if (string.Equals("fuel", cat, StringComparison.OrdinalIgnoreCase))
                {
                    cars = allCars.Cars.Where(c => c.Category.categoryName == "двс").OrderBy(c => c.id);
                    curcat = "двс";
                }


           
            }
            var obj=new CarsListViewModel { GetAllCars=cars,currCategory=curcat };


            ViewBag.Title = "avto page";
            
            return View(obj); }
    }
}
