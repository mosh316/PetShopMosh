using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetShopMosh.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
        [Required(ErrorMessage = "you cannot write an empty comment")]
        [Display(Name = "Category(Mamal,Reptile,Acuatic)")]

        public string Content { get; set; }
        



    }
}
