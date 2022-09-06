using System.ComponentModel.DataAnnotations;

namespace IntroASP.Models.ViewModels
{
    public class BeerViewModel
    {
        [Required]
        //se súpone que esto es para que aparezca en español, pero ya lo puse desde un principio así :'3
        [Display(Name = "Nombre")] 
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Marca")]
        public int BrandId { get; set; }

    }
}
