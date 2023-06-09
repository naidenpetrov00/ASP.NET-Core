﻿namespace MyFirstAspNetApp.Services
{
	public class YearsService : IYearsService
	{
		public IEnumerable<int> GetLastYears(int count)
		{
			for (int year = DateTime.UtcNow.Year; year >= DateTime.UtcNow.Year - count; year--)
			{
				yield return year;
			}
		}
	}
}
