namespace ApiDemo.Data
{
	using Microsoft.EntityFrameworkCore;

	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-ERAGAG4\\SQLEXPRESS;Database=ApiDemo;Integrated Security=True;Encrypt=False");
			base.OnConfiguring(optionsBuilder);
		}

		public DbSet<Candidate> Candidates { get; set; }
	}
}
