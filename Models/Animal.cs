using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PetShopMosh.Models
{
    public class Animal
    {

        public int AnimalId { get; set; }
        [Required(ErrorMessage = "You must pick a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You must pick age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "You must declare Picture name")]
        public string PictureName { get; set; }

        [Required(ErrorMessage = "You must describe the animal")]
        public string Descripotion { get; set; }

        [Required(ErrorMessage = "You must choose a category")]
        [Display(Name = "Category(Mamal,Reptile,Acuatic)")]
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        
        public virtual ICollection<Comment>? Comments {get;  set; }
        



    }
}
     
