﻿namespace MyFirstAspNetApp.ViewModels.Home
{
	public class IndexViewModel
	{
		public string Message { get; set; }

		public int Year { get; set; }

		public IEnumerable<string> Names { get; set; }
	}
}
