namespace ApiDemo.Controllers
{
	using ApiDemo.Data;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	[Route("api/[controller]")]
	public class CandidatesController : ControllerBase
	{
		public CandidatesController(ApplicationDbContext db)
		{

		}
	}
}
