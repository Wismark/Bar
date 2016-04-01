using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Bar.DataModel
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public double Amount { get; set; }
        public Product Prod { get; set; }
    }
    public  class Recipe
    {
        public int RecipeId { get; set; }
        [MaxLength(256)]
        [Required]
        public string Name { get; set; }
        [MaxLength(1000)]
        public string Description { get; set; }
        public double Price { get; set; }
        public List<Ingredient> Ingred { get; set; }
    }
}
