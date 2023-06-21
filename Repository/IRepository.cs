using PetShopMosh.Models;

namespace PetShopMosh.Repository
{
    public interface IRepository
    {
        //T GetById(int id);
        //IEnumerable<T> GetAll();
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        IEnumerable<Animal> FilterByCat(int cat);
        IEnumerable<Category> GetCategories();
        IEnumerable<Animal> GetAnimals();

        IEnumerable<Animal> GetAnimal(int id);
        IEnumerable<Category> GetCategory(int id);
        IEnumerable<Comment> GetComments(int id);
        void AddComment(string content, int AnimalId);
        void DeleteAnimal(int id);  
        void AddAnimal(Animal animal);
        void EditAnimal(int AnimalId,Animal animal);
    }

}
