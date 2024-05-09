using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int v1 = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.c1 = values.carCount; 
                ViewBag.v1 = v1;
            }

            var responseMessage2 = await client.GetAsync("https://localhost:7290/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int v2 = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.c2 = values2.locationCount;
                ViewBag.v2 = v2;
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7290/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int v3 = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.c3 = values3.authorCount;
                ViewBag.v3 = v3;
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7290/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int v4 = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.c4 = values4.blogCount;
                ViewBag.v4 = v4;
            }

            var responseMessage5 = await client.GetAsync("https://localhost:7290/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int v5 = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData5);
                ViewBag.c5 = values5.brandCount;
                ViewBag.v5 = v5;
            }

            var responseMessage6 = await client.GetAsync("https://localhost:7290/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int v6 = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData6);
                ViewBag.c6 = values6.avgRentPriceForDaily.ToString("0.00");
                ViewBag.v6 = v6;
            }

            var responseMessage7 = await client.GetAsync("https://localhost:7290/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int v7 = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData7);
                ViewBag.c7 = values7.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.v7 = v7;
            }

            var responseMessage8 = await client.GetAsync("https://localhost:7290/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int v8 = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData8);
                ViewBag.c8 = values8.getAvgRentPriceForMonthly.ToString("0.00");
                ViewBag.v8 = v8;
            }

            var responseMessage9 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCountByTranmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int v9 = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData9);
                ViewBag.c9 = values9.carCountByTranmissionIsAuto;
                ViewBag.v9 = v9;
            }

            var responseMessage10 = await client.GetAsync("https://localhost:7290/api/Statistics/GetBrandNameByMaxCar");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int v10 = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData10);
                ViewBag.c10 = values10.BrandNameByMaxCar;
                ViewBag.v10 = v10;
            }

            var responseMessage11 = await client.GetAsync("https://localhost:7290/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int v11 = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData11);
                ViewBag.c11 = values11.BlogTitleByMaxBlogComment;
                ViewBag.v11 = v11;
            }

            var responseMessage12 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCountByKmSmallerThen1000");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int v12 = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData12);
                ViewBag.c12 = values12.carCountByKmSmallerThen1000;
                ViewBag.v12 = v12;
            }

            var responseMessage13 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage13.IsSuccessStatusCode)
            {
                int v13 = random.Next(0, 101);
                var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
                var values13 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData13);
                ViewBag.c13 = values13.carCountByFuelGasolineOrDiesel;
                ViewBag.v13 = v13;
            }

            var responseMessage14 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage14.IsSuccessStatusCode)
            {
                int v14 = random.Next(0, 101);
                var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
                var values14 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData14);
                ViewBag.c14 = values14.carCountByFuelElectric;
                ViewBag.v14 = v14;
            }

            var responseMessage15 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarBrandAndModelByRentPriceDailyMin");
            if (responseMessage15.IsSuccessStatusCode)
            {
                int v15 = random.Next(0, 101);
                var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
                var values15 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData15);
                ViewBag.c15 = values15.carBrandAndModelByRentPriceDailyMin;
                ViewBag.v15 = v15;
            }

            var responseMessage16 = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarBrandAndModelByRentPriceDailyMax");
            if (responseMessage16.IsSuccessStatusCode)
            {
                int v16 = random.Next(0, 101);
                var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
                var values16 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData16);
                ViewBag.c16 = values16.carBrandAndModelByRentPriceDailyMax;
                ViewBag.v16 = v16;
            }


            return View();
        }
       
    }
}
