using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;

        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(x=>x.Pricing).Where(z=>z.PricingID==3).ToList();
            return values;
        }

		public List<CarPricing> GetCarPricingWithTimePeriod()
		{
       //     var values = from x in _context.CarPricings
       //                  group x by x.CarPricingID into g
       //                  select new
       //                  {
       //                      Model=g.Key,
       //                      DailyPrice=g.Where(y=>y.CarPricingID==3).Sum(z=>z.Amount),
       //                      WeeklyPrice=g.Where(y=>y.CarPricingID==4).Sum(z=>z.Amount),
							// MonthlyPrice = g.Where(y => y.CarPricingID == 1004).Sum(z => z.Amount),
						 //};

       //     return values;
		}
	}
}
