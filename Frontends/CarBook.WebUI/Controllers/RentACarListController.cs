using CarBook.Dto.BrandDtos;
using CarBook.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {


            var locationID = TempData["locationID"];


            //filterRentACarDto.LocationID = int.Parse(locationID.ToString());
            //filterRentACarDto.Available = true;
            id = int.Parse(locationID.ToString()); 

       
            ViewBag.locationID = locationID;

       
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($" https://localhost:7290/api/RentACars?locationID={id}&available=true");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);

                return View(values);

            }
            return View();


        }
    }
}
