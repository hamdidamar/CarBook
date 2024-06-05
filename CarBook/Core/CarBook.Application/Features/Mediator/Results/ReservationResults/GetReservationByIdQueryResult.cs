using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.ReservationResults
{
    public class GetReservationByIdQueryResult:BaseResult
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public int DriverLicenseYear { get; set; }
        public string Description { get; set; }
        public string CarId { get; set; }
        public Car Car { get; set; }
        public string? PickUpLocationId { get; set; }
        public Location PickUpLocation { get; set; }
        public string? DropOffLocationId { get; set; }
        public Location DropOffLocation { get; set; }
    }
}
