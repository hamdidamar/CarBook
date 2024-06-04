using CarBook.Application.Features.Mediator.Queries.RentACarQueries;
using CarBook.Application.Features.Mediator.Results.PricingResults;
using CarBook.Application.Features.Mediator.Results.RentACarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.RentACarHandlers
{
    public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
    {
        private readonly IRepository<RentACar> _repository;

        public GetRentACarQueryHandler(IRepository<RentACar> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetListWithPredicateAndIncludes(
               predicate: x => x.IsActive && x.Location.IsActive && x.Car.IsActive && x.LocationId == request.LocationId && x.Avaible,
               include: c => c.Include(c => c.Car)
               .Include(c => c.Car.Model)
               .Include(c => c.Car.Color)
               .Include(c => c.Car.Model.Brand)
               .Include(c => c.Car.Model.Fuel)
               .Include(c => c.Car.Model.Transmission)
               .Include(c => c.Location)
               );
            return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetRentACarQueryResult
            {
                Id = x.Id,
                CarId = x.CarId,
                ColorId = x.Car.ColorId,
                ColorName = x.Car.Color.Name,
                BrandName = x.Car.Model.Brand.Name,
                ModelName = x.Car.Model.Name,
                ModelPrice = x.Car.Model.DailyPrice.ToString(),
                ModelId = x.Car.ModelId,
                Kilometer = x.Car.Kilometer,
                ModelYear = x.Car.ModelYear,
                Plate = x.Car.Plate,
                Seat = x.Car.Seat,
                Luggage = x.Car.Luggage,
                ImageUrl = x.Car.ImageUrl,
                DetailImageUrl = x.Car.DetailImageUrl,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                UpdatedDate = x.UpdatedDate

            }).OrderBy(x => x.CreatedDate).ToList();
        }
    }
}
