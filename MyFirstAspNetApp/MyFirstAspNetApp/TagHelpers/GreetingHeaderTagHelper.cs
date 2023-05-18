namespace MyFirstAspNetApp.TagHelpers
{
	using Microsoft.AspNetCore.Mvc.TagHelpers;
	using Microsoft.AspNetCore.Razor.TagHelpers;

	[HtmlTargetElement("h2", Attributes = "greeting-string")]
	public class GreetingHeaderTagHelper : TagHelper
	{
		public string GreetingString { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Content.SetContent(GreetingString);
		}
	}
}
