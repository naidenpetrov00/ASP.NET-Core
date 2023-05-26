using System.ComponentModel.DataAnnotations;

namespace MyFirstAspNetApp.ViewModels.Test
{
	public class TestInputModel
	{
		public int Id { get; set; }

		[Required]
		[Display(Name = "First name")]
		public string FirstName { get; set; }

		[Required]
		[Display(Name = "Last name")]
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

		[Display(Name = "Date of birth")]
		public DateTime DateOfBirth{ get; set; }

		[Display(Name = "Years of experience")]
        public int YearsOfExperience { get; set; }
    }
}
