using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		[Route("Index/{id}")]
		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.cardetailId=id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7290/api/CarFeatures/GetCarFeatureByCarId?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

				return View(values);

			}
			return View();
		}


	}
}
