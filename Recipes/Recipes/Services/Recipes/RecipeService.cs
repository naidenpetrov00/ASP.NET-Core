using MongoDB.Driver;
using Recipes.Models;

namespace Recipes.Services.Recipes
{
	public class RecipeService : IRecipeService
	{
		private IMongoCollection<Recipe> recipeCollection;

		public RecipeService(IMongoClient client)
		{
			var db = client.GetDatabase("Cooking");
			this.recipeCollection = db.GetCollection<Recipe>("Recipes");
		}

		public void AddRecipe(string title, string desctiption, string ingredients)
		{
			var recipe = new Recipe
			{
				Title = title,
				Desctiption = desctiption,
				Ingredients = ingredients
			};

			this.recipeCollection.InsertOne(recipe);
		}
	}
}
