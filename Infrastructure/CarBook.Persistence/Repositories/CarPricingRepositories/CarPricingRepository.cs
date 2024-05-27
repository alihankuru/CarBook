using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
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
			throw new NotImplementedException();
		}

		public List<CarPricingViewModel> GetCarPricingWithTimePeriod1()
		{
			List<CarPricingViewModel> values = new List<CarPricingViewModel>();
			using (var command = _context.Database.GetDbConnection().CreateCommand())
			{
				command.CommandText = @"
            SELECT Model,Name, CoverImageUrl, [3], [4], [1004]
            FROM (
                SELECT Model,Name, CoverImageUrl, PricingID, Amount
                FROM CarPricings
                INNER JOIN Cars ON Cars.CarID = CarPricings.CarId
                INNER JOIN Brands ON Brands.BrandID = Cars.BrandID
            ) AS SourceTable
            PIVOT (
                SUM(Amount)
                FOR PricingID IN ([3], [4], [1004])
            ) AS PivotTable;";
				command.CommandType = System.Data.CommandType.Text;
				_context.Database.OpenConnection();
				using (var reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
						{
							Brand= reader["Name"].ToString(),
							Model = reader["Model"].ToString(),
							CoverImageUrl = reader["CoverImageUrl"].ToString(),
							Amounts = new List<decimal>
					{
						reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0,
						reader["4"] != DBNull.Value ? Convert.ToDecimal(reader["4"]) : 0,
						reader["1004"] != DBNull.Value ? Convert.ToDecimal(reader["1004"]) : 0
					}
						};
						values.Add(carPricingViewModel);
					}
				}
				_context.Database.CloseConnection();
				return values;
			}
		}
	}
}
