using System;
using System.ComponentModel.DataAnnotations;
using CrudFood.Models;

namespace CrudFood.Models
{
    public class DishRecipe
    {
        [Key]
        public int DishRecipeId {get; set; }
        
        [Required(ErrorMessage = "please do not leave  recipe field empty")]
        [MinLength(5, ErrorMessage = "Name of dish must be at minimum 5 characters")]
        [Display(Name = "Recipe Name: ")]
        public string Name {get; set; }

        [Required(ErrorMessage = "Why would you leave an chef name input field empty for didn't your mom teach you better?")]
        [MinLength(5, ErrorMessage = "Your chef name needs an input of at least 5 characters, if your name is less than 5, then I'm sorry, no really, sorry....")]
        [Display(Name = "Chef's Name: ")]
        public string Chef {get; set;}

        [Required(ErrorMessage = "Please do not leave calories consumed empty")]
        [Range(1,3000, ErrorMessage = "input must be between 1 and 3000 calories, if your food doesn't fall in that range, increaes or decrease your dish size")]
        [Display(Name = "Calories Contained: ")]
        public int Calories {get; set; }

        [Required(ErrorMessage = "Please do not leave this tastiness field empty ")]
        [Range(1,5, ErrorMessage = "input of 1-5 is needed")]
        public int Tastiness {get; set; }

        [Required(ErrorMessage = "Do not leave description box empty")]
        [MinLength(15, ErrorMessage = "15 characters minimum required, dont be lazy!!!!!")]
        public string Description {get; set; }

        public DateTime CreatedAt {get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt {get; set; } = DateTime.UtcNow;

       
    }
}