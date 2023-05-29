namespace MyFirstAspNetApp.ViewModels.Test
{
	using Microsoft.AspNetCore.Mvc.Rendering;
	using MyFirstAspNetApp.Data.Enums;
	using MyFirstAspNetApp.ValidationAttributes;
	using System.ComponentModel.DataAnnotations;

	public class TestInputModel : IValidatableObject
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
		[EgnValidation]
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

		public IFormFile CV { get; set; }

		public IEnumerable<SelectListItem>? AllTypes { get; set; }

		public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
		{
			if (int.Parse(this.Egn.Substring(0, 2)) != this.DateOfBirth.Year % 100)
			{
				yield return new ValidationResult("Годината на раждане и ЕГН-то не са валидна комбинация");
			}
		}
	}
}
