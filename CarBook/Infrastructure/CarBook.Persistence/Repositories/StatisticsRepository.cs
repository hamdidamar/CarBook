using CarBook.Application.Interfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }
        public string GetBlogTitleByMaxBlogComment()
        {
            var values = _context.BlogComments.GroupBy(x => x.Id).
                              Select(y => new
                              {
                                  Id = y.Key,
                                  Count = y.Count()
                              }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            return _context.Blogs.Where(x => x.Id == values.Id).Select(y => y.Title).FirstOrDefault();
        }

        public string GetBrandNameByMaxCar()
        {
            var values = _context.Cars.GroupBy(x => x.Model.BrandId).
                             Select(y => new
                             {
                                 Id = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            return _context.Brands.Where(x => x.Id == values.Id).Select(y => y.Name).FirstOrDefault();
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var id = _context.Pricings.Where(y => y.Name == "Günlük").Select(z => z.Id).FirstOrDefault();
            return _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.Id).FirstOrDefault();
            return _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.Id).FirstOrDefault();
            return _context.CarPricings.Where(w => w.Id == id).Average(x => x.Amount);
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            var pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.Id).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.Id == pricingID).Max(x => x.Amount);
            var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            return _context.Cars.Where(x => x.Id == carId).Include(y => y.Model.Brand).Select(z => z.Model.Brand.Name + " " + z.Model).FirstOrDefault();
        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            var pricingID = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.Id).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.Id == pricingID).Min(x => x.Amount);
            var carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            return _context.Cars.Where(x => x.Id == carId).Include(y => y.Model.Brand).Select(z => z.Model.Brand.Name + " " + z.Model).FirstOrDefault();
        }

        public int GetCarCount()
        {
            return _context.Cars.Count();
        }

        public int GetCarCountByFuelElectric()
        {
            return _context.Cars.Where(x => x.Model.Fuel.Name == "Elektrik").Count();
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            return _context.Cars.Where(x => x.Model.Fuel.Name == "Benzin" || x.Model.Fuel.Name == "Dizel").Count();
        }

        public int GetCarCountByKmSmallerThenTousand()
        {
            return _context.Cars.Where(x => x.Kilometer <= 1000).Count();
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            return _context.Cars.Where(x => x.Model.Transmission.Name == "Otomatik").Count();
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
