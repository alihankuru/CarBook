using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using CarBook.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlarımız";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/CarPricings");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);

            }

            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Araba Detayı ve Yorumlar";
            ViewBag.cardetailId = id;


            //var client = _httpClientFactory.CreateClient();
            //var responseMessage2 = await client.GetAsync($"https://localhost:7290/api/Comments/GetCountCommentByBlog?id=" + id);
            //var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            //ViewBag.commentCount = jsonData2;


            return View();
        }

    }
}
