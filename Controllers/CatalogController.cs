using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using PetShopMosh.Data;
using PetShopMosh.Models;
using PetShopMosh.Repository;
using System.Linq;

namespace PetShopMosh.Controllers
{
    public class CatalogController : Controller
   
        
    {  
        
        private IRepository _repository;
        public CatalogController(PShopContext pShopContext, IRepository repository)
        {
            _repository= repository;
            
        }

     
      

        
        public IActionResult CatalogAction(string categoryId)
        {   
            var animals=_repository.GetAnimals();
            int catId = int.Parse(categoryId);
            var Filtered= _repository.FilterByCat(catId);
            //ViewBag.animals = _pShopContext.Animals!.ToList();
            ViewBag.categories = _repository.GetCategories();
            int lastSelectedCategory = -1;
            if (Request.Method == "POST")
            {
                int selectedCategoryId;
                if (int.TryParse(Request.Form["categoryId"], out selectedCategoryId))
                {
                    lastSelectedCategory = selectedCategoryId;
                }
            }

            // Set the value of ViewBag.LastSelectedCategory
            ViewBag.LastSelectedCategory = lastSelectedCategory;


            //ViewBag.DefaultCategory = _pShopContext.Categories!.AsParallel<Category>().ToList();
            //ViewBag.comments= _pShopContext.Comments!.ToList();
            if (catId <= 0)
            {
                return View(animals);
            }
            else
                return View(Filtered);

        }
        [HttpPost]
        public IActionResult Filter(string categoryId,int lastSelectedCategory) 
        {
            
            return RedirectToAction("CatalogAction", new { categoryId = categoryId });

        }
       

    }
}