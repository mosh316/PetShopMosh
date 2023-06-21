using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopMosh.Data;
using PetShopMosh.Models;
using PetShopMosh.Repository;
using System.Drawing;

namespace PetShopMosh.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _repository;
        public AdminController(IRepository repository)
        {
            _repository = repository;
        }
        public IActionResult AdminAction(string categoryId)
        {
            var animals = _repository.GetAnimals();
            int catId = int.Parse(categoryId);
            var Filtered = _repository.FilterByCat(catId);
            
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

            ViewBag.LastSelectedCategory = lastSelectedCategory;


           
            if (catId <= 0)
            {
                return View(animals);
            }
            else
                return View(Filtered);

        }

        public IActionResult EditClick(int id)
        {


            var animal = _repository.GetAnimal(id).ToList();
            ViewBag.CategoryId = _repository.GetCategory(id).Single().CategoryId;
            ViewBag.CategoryName = _repository.GetCategory(id).Single().Name;
            ViewBag.categories = _repository.GetCategories();
            ViewBag.Comments = _repository.GetComments(id);

            return View(animal);
        }
        [HttpPost]
        public IActionResult Filter(string categoryId, int lastSelectedCategory)
        {

            return RedirectToAction("AdminAction", new { categoryId = categoryId });

        }
        public IActionResult EditAnimal(int id, string name, string LastPicure,int age,IFormFile imageFile, string animalDescription, int CategoryId)
        {
            string uppath;
            if (imageFile == null)
            {
                uppath = $"~/images/{LastPicure}";
                _repository.EditAnimal(id, new Animal { Name = name, Age = age, PictureName = LastPicure, Descripotion = animalDescription, CategoryId = CategoryId });
            }
            else
            {
                uppath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
                using (var stream = new FileStream(uppath, FileMode.OpenOrCreate))
                {
                    imageFile.CopyTo(stream);
                }
                _repository.EditAnimal(id, new Animal { Name = name, Age = age, PictureName = imageFile.FileName, Descripotion = animalDescription, CategoryId = CategoryId });

            }
            return RedirectToAction("AdminAction", new { categoryId = -1 });
        }
        [HttpPost]
        public IActionResult AddAnimal(int id, string name, int age, IFormFile imageFile, string animalDescription, int CategoryId)
        {
            string uppath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
            using (var stream = new FileStream(uppath, FileMode.OpenOrCreate))
            {
                imageFile.CopyTo(stream);
            }

            _repository.AddAnimal(new Animal { Name = name, Age = age, PictureName = imageFile.FileName, Descripotion = animalDescription, CategoryId = CategoryId });
            return RedirectToAction("AdminAction", new { categoryId = -1 });
        }

        public IActionResult DeleteClick(int id)
        {
            _repository.DeleteAnimal(id);
            return RedirectToAction("AdminAction", new { categoryId = -1 });
        }
        public IActionResult AddClick()
        {
            var animals = _repository.GetAnimals();
            if (ModelState.IsValid)
            {

            }
            
            ViewBag.categories = _repository.GetCategories();
            

            return View(animals);
        }
    }
}
