using CarBook.Application.Features.Mediator.Queries.ReservationQueries;
using CarBook.Application.Features.Mediator.Results.ReservationResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationQueryHandler : IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetListWithPredicateAndIncludes(
              predicate: x => x.IsActive,
              include: c => c.Include(c => c.Car)
              .Include(c => c.Car.Model)
              .Include(c => c.Car.Color)
              .Include(c => c.Car.Model.Brand)
              .Include(c => c.Car.Model.Fuel)
              .Include(c => c.Car.Model.Transmission)
              .Include(c => c.PickUpLocation)
              .Include(c => c.DropOffLocation)
              );
            return values.Where(x => x.IsActive && !x.IsDeleted).Select(x => new GetReservationQueryResult
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Email = x.Email,
                Phone = x.Phone,
                Age = x.Age,
                DriverLicenseYear = x.DriverLicenseYear,
                Description = x.Description,
                CarId = x.CarId,
                PickUpLocationId = x.PickUpLocationId,
                DropOffLocationId = x.DropOffLocationId,
                CreatedDate = x.CreatedDate,
                IsActive = x.IsActive,
                IsDeleted = x.IsDeleted,
                UpdatedDate = x.UpdatedDate

            }).OrderBy(x => x.CreatedDate).ToList();


        }
    }
}
