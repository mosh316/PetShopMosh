using Microsoft.EntityFrameworkCore;
using PetShopMosh.Models;
using System;
using System.ComponentModel.Design;

namespace PetShopMosh.Data
{
    public class PShopContext:DbContext     
    {
      

        public PShopContext(DbContextOptions<PShopContext> options) : base(options)
        {
        }

        public DbSet<Animal>? Animals { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Comment>? Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal { AnimalId=1,Name = "Dog", Age = 2, PictureName = "Dog.jpg", Descripotion = "A cute and playful dog.", CategoryId = 1},
                new Animal { AnimalId=2, Name = "Cat", Age = 1, PictureName = "Cat.jpg", Descripotion = "A cute and playful cat.", CategoryId = 1 },
                new Animal { AnimalId=3,Name = "Iguana", Age = 3, PictureName = "Iguana.jpg", Descripotion = "A cute and playful Iguana.", CategoryId = 4 },
                new Animal { AnimalId = 4, Name = "goldi", Age = 3, PictureName = "GoldenFish.jpg", Descripotion = "make a wish ;)", CategoryId = 2 },

               new Animal { AnimalId = 5, Name = "Jimi THE PARROT", Age = 3, PictureName = "AraParrot.jpg", Descripotion = "A cute and COLORFUL PARROT.", CategoryId = 4 }


            );



            modelBuilder.Entity<Category>().HasData(
               
               new { CategoryId = 1, Name = "Mamal"},
               new { CategoryId = 2, Name = "aquatic"},
               new { CategoryId = 3, Name = "Bird" },
               new { CategoryId = 4, Name = "Riptile" }

           );
            modelBuilder.Entity<Comment>().HasData(
               new { CommentId=1,AnimalId = 1, Content = "greatest pet ever" },
               new { CommentId=2, AnimalId = 1, Content = "very friendly" },
               new { CommentId=3,AnimalId = 3, Content = "such a cutyyyy" },
               new { CommentId=4,AnimalId =2, Content = "haha looking good" }

           );
        }

    }
}
