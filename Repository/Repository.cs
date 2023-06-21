using Microsoft.EntityFrameworkCore;
using PetShopMosh.Data;
using PetShopMosh.Models;

namespace PetShopMosh.Repository
{
    public class Repository : IRepository
    {
        private PShopContext _pShopContext;

        public Repository(PShopContext dbContext)
        {
            _pShopContext = dbContext;
        }

        //public T GetById(int id)
        //{
        //    // Implement logic to retrieve entity by ID from the data source
        //    // using _dbContext or appropriate data access methods
        //}

        //public IEnumerable<T> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public void Add(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Update(T entity)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Delete(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        public IEnumerable<Animal> GetAnimals()
        {
            return _pShopContext.Animals!.ToList();
        }
        public IEnumerable<Animal> FilterByCat(int cat)
        {
            var animalsF = _pShopContext.Animals!.ToList();
            var FilteredAnimals=animalsF.Where(a => a.CategoryId == cat).ToList();
            if(FilteredAnimals.Count > 0)
                return FilteredAnimals;

            else
                return Enumerable.Empty<Animal>();
        }
        public IEnumerable<Category> GetCategories()
        {
            return _pShopContext.Categories!.ToList();  
        }
        public IEnumerable<Animal> GetAnimal(int id)
        {
            return _pShopContext.Animals!.Where(a=>a.AnimalId==id).ToList();
        }
        public IEnumerable<Category> GetCategory(int id)
        {
            var categoryid = _pShopContext.Animals!.Where(a => a.AnimalId == id).Single().CategoryId;
            return _pShopContext.Categories!.Where(a => a.CategoryId == categoryid).ToList();
        }
        public IEnumerable<Comment> GetComments(int id) 
        {
            var commentsF = _pShopContext.Comments!.Where(a=>a.AnimalId==id).ToList();
            return commentsF;
        }
        public void AddComment(string content,int AnimalId)
        {
            _pShopContext.Comments.Add(new Comment { Content = content, AnimalId = AnimalId });
            _pShopContext.SaveChanges();
        }
        public void DeleteAnimal(int animalId)
        {
            // Replace "YourDbContext" with your actual DbContext class
          
                var animal = _pShopContext.Animals!.Find(animalId); // Find the entity by its primary key

                if (animal != null)
                {
                _pShopContext.Animals.Remove(animal); // Mark the entity as deleted
                _pShopContext.SaveChanges(); // Save the changes to persist the deletion
                }
            
        }
        public void EditAnimal(int AnimalId, Animal animal)
        {
            DeleteAnimal(AnimalId);
            AddAnimal(animal);
        }
        public void AddAnimal(Animal animal)
        {
            //var existingAnimal = _pShopContext.Animals.FirstOrDefault(a => a.AnimalId == animal.AnimalId);
            //if (existingAnimal != null)
            //{
            //    _pShopContext.Animals.Remove(existingAnimal);
            //}

            _pShopContext.Animals.Add(animal);
            _pShopContext.SaveChanges();
        }



    }
}
