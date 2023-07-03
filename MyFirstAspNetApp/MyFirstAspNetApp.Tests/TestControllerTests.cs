namespace MyFirstAspNetApp.Tests
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Mvc.Rendering;
	using Moq;
	using MyFirstAspNetApp.Controllers;
	using MyFirstAspNetApp.Services;
	using MyFirstAspNetApp.ViewModels.Test;
	using System.Collections.Generic;

	public class TestControllerTests
	{
		[Fact]
		public void TestViewModelForIndexForm()
		{
			var mockService = new Mock<IPositionsService>();
			mockService.Setup(x => x.GetAll())
				.Returns(new List<SelectListItem>
				{
					new SelectListItem {Value="1",Text="Dev"},
					new SelectListItem {Value="2",Text="QA"}
				});

			var controller = new TestController(mockService.Object);
			var result = controller.Index();
			Assert.IsType<ViewResult>(result);
			var viewResult = result as ViewResult;
			Assert.IsType<TestInputModel>(viewResult.Model);
			var viewModel = viewResult.Model as TestInputModel;
			Assert.Equal(2, viewModel.AllTypes.Count());

			mockService.Verify(x => x.GetAll(), Times.Once);
		}
	}
}