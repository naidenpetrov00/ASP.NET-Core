namespace MyFirstAspNetApp.TagHelpers
{
	using Microsoft.AspNetCore.Mvc.TagHelpers;
	using Microsoft.AspNetCore.Razor.TagHelpers;

	[HtmlTargetElement("h1", Attributes = "greeting-string")]
	[HtmlTargetElement("h2")]
	[HtmlTargetElement("h3")]
	[HtmlTargetElement("h4")]
	public class GreetingHeaderTagHelper : TagHelper
	{
		public string GreetingString { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.Attributes.Add("name", "Naiden");
			base.Process(context, output);
		}
	}
}
