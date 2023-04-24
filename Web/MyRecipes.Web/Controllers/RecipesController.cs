namespace MyRecipes.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using MyRecipes.Services.Data;
    using MyRecipes.Web.ViewModels.Recipes;
    using System.Threading.Tasks;

    public class RecipesController : Controller
    {
        private readonly ICategoriesServices categoriesServices;
        private readonly IRecipesService recipesService;

        public RecipesController(ICategoriesServices categoriesService, IRecipesService recipesService)
        {
            this.categoriesServices = categoriesService;
            this.recipesService = recipesService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateRecipeInputModel();
            viewModel.CategoriesItems = this.categoriesServices.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRecipeInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.CategoriesItems = this.categoriesServices.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.recipesService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
