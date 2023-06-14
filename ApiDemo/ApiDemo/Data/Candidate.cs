namespace ApiDemo.Data
{
	using System.ComponentModel.DataAnnotations;


	public class Candidate
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

		[Display(Name = "Date of birth")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Range(2, int.MaxValue)]
		[Display(Name = "Years of experience")]
		public int YearsOfExperience { get; set; }

		public CandidateType CandidateType { get; set; }
	}
}
