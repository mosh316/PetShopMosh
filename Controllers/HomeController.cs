using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopMosh.Data;
using PetShopMosh.Models;
using PetShopMosh.Repository;
using System.Data.Entity;
using System.Linq;

namespace PetShopMosh.Controllers
{
    public class HomeController : Controller
    {   
        private IRepository _repository;
        public HomeController(IRepository repository)
        {

            _repository = repository;
        }

        public IActionResult Index()
        {
            
            var animals = _repository.GetAnimals()!.OrderByDescending(row => row.Comments!.Count()).Take(2).ToList(); 
            return View(animals);
        }
        public IActionResult CatalogAction()
        {

            var animals = _repository.GetAnimals()!.ToList();
            return View(animals);
        }

    }
}
