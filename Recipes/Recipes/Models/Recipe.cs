namespace Recipes.Models
{
	public class Recipe
	{
		public Recipe()
		{
			this.Id = Guid.NewGuid().ToString();
		}

		public string Id { get; set; }

		public string Title { get; set; }

		public string Desctiption { get; set; }

		public string Ingredients { get; set; }
	}
}
