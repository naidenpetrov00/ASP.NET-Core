namespace MyFirstAspNetApp.Services
{
	public interface IYearsService
	{
		IEnumerable<int> GetLastYears(int count);
	}
}
