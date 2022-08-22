// we need this to validate those methods or data.
using System.ComponentModel.DataAnnotations;

namespace apiprueba.Models
{
    //creating the connection
    public class Notas
    {
        
        //creating public method 
        public int Id { get; set; }

        [Required] //requerid... this is part of DAnnotation.
        [StringLength(20)]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }

}