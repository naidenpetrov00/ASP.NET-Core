namespace MyFirstAspNetApp.Services
{
	public class StringManipulation : IStringManipulation
	{
		public string MakeFirstLetterUpper(string input)
		{
			if (input == null)
			{
				return null;
			}
			if (input.Length < 2)
			{
				return input.ToUpper();
			}
			return input;
		}
	}
}
