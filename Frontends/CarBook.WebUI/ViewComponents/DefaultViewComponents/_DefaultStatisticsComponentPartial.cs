using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace CarBook.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async  Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
            
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                ViewBag.c1 = values.carCount;
             
            }


            var responseMessage2 = await client.GetAsync("https://localhost:7290/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
              
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData2);
                ViewBag.c2 = values2.locationCount;
            
            }

            var responseMessage3 = await client.GetAsync("https://localhost:7290/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
               
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData3);
                ViewBag.c3 = values3.authorCount;
             
            }

            var responseMessage4 = await client.GetAsync("https://localhost:7290/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
           
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData4);
                ViewBag.c4 = values4.blogCount;
          
            }



            return View();
        }


    }
}
