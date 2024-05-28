﻿using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.CategoryDtos;
using CarBook.Dto.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/CarFeatures/GetCarFeatureByCarId?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);

                return View(values);

            }
            return View();
        }


        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {
            foreach(var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                   

                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7290/api/CarFeatures/CarFeatureChangeToTrue?id=" + item.CarFeatureID);

                    
                  
                }
                else
                {
                    

                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7290/api/CarFeatures/CarFeatureChangeToFalse?id=" + item.CarFeatureID);


                }
            }
            return RedirectToAction("Index", "AdminCar");
        }


        [Route("CreateFeatureByCarId")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7290/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);

                return View(values);

            }
            return View();
        }


    }
}
