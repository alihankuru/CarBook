using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticDtos
{
    public class ResultStatisticDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal avgRentPriceForDaily { get; set; }
        public decimal avgRentPriceForWeekly { get; set; }
        public decimal getAvgRentPriceForMonthly { get; set; }
        public int carCountByTranmissionIsAuto { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }
        public int carCountByKmSmallerThen1000 { get; set; }
        public int carCountByFuelGasolineOrDiesel { get; set; }
        public int carCountByFuelElectric { get; set; }
        public string carBrandAndModelByRentPriceDailyMin { get; set; }
        public string carBrandAndModelByRentPriceDailyMax { get; set; }
    }
}
