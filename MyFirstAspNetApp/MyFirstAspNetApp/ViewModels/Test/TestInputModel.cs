namespace MyFirstAspNetApp.ViewModels.Test
{
	using Microsoft.AspNetCore.Mvc.Rendering;
	using MyFirstAspNetApp.Data.Enums;
	using System.ComponentModel.DataAnnotations;

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
		[RegularExpression("[0-9]{10}", ErrorMessage = "Невалидно ЕГН")]
		[StringLength(10, MinimumLength = 10)]
		public string Egn { get; set; }

		[Required]
		[MinLength(3)]
		public string University { get; set; }

		[Display(Name = "Date of birth")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Range(2, int.MaxValue)]
		[Display(Name = "Years of experience")]
		public int YearsOfExperience { get; set; }

		public int CandidateType { get; set; }

		public IEnumerable<SelectListItem> AllTypes { get; set; }
	}
}
