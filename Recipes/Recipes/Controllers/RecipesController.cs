namespace Recipes.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Recipes.Services.Recipes;
	using Recipes.ViewModels.Recipes;

	public class RecipesController : Controller
	{
		private readonly IRecipeService recipeService;

		public RecipesController(IRecipeService recipeService)
		{
			this.recipeService = recipeService;
		}

		public IActionResult AddRecipe()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddRecipe(RecipeInputModel recipe)
		{
			this.recipeService.AddRecipe(recipe.Title, recipe.Desctiption, recipe.Ingredients);

			return this.Redirect("/");
		}
	}
}
