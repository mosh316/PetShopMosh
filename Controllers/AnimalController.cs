using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopMosh.Data;
using PetShopMosh.Models;
using PetShopMosh.Repository;
using System.Drawing;

namespace PetShopMosh.Controllers
{
    public class AnimalController : Controller
    {
        private IRepository _repository;
        public AnimalController(IRepository repository)
        {
            _repository = repository;
        }

       

        public IActionResult AnimalDes(int id)
        {
           var animal= _repository.GetAnimal(id);
            ViewBag.CategoryName= _repository.GetCategory(id).Single().Name;
            ViewBag.Comments = _repository.GetComments(id);

            return View(animal);
        }
        [HttpPost]
        public IActionResult AddComment(string content, int AnimalId)
        {
            _repository.AddComment(content, AnimalId);

            return RedirectToAction("AnimalDes", new { id = AnimalId });
        }
        //public IActionResult addComment(string content)
        //{

        //}
    }
}
