namespace MyRecipes.Data.Models
{
    using System.Collections.Generic;

    using MyRecipes.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
