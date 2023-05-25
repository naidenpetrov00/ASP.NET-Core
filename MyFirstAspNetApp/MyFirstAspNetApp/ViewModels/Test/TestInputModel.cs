using System.ComponentModel.DataAnnotations;

namespace MyFirstAspNetApp.ViewModels.Test
{
	public class TestInputModel
	{
		public int Id { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[RegularExpression("[0-9]{10}")]
		[StringLength(10, MinimumLength =10)]
		public string Egn { get; set; }

		[Required]
		[MinLength(3)]
		public string University { get; set; }

		public int Year { get; set; }

		public int[]? Years { get; set; }
	}
}
