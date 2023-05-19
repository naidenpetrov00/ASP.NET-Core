namespace MyFirstAspNetApp.Services
{
	public interface ICountInstancesService
	{
		public int Instances { get; }
	}

	public class CountInstancesService : ICountInstancesService
	{
		private static int count;

		public CountInstancesService()
		{
			count++;
		}

		public int Instances => count;
	}
}
