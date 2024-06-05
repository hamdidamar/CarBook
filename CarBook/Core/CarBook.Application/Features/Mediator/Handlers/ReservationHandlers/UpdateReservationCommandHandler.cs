using CarBook.Application.Features.Mediator.Commands.ReservationCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Reservation> _repository;

        public UpdateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.Name = request.Name;
            value.Surname = request.Surname;
            value.Email = request.Email;
            value.Phone = request.Phone;
            value.Age = request.Age;
            value.Description = request.Description;
            value.DriverLicenseYear = request.DriverLicenseYear;
            value.PickUpLocationId = request.PickUpLocationId;
            value.DropOffLocationId = request.DropOffLocationId;
            value.IsActive = request.IsActive;
            value.IsDeleted = request.IsDeleted;
            value.UpdatedDate = request.UpdatedDate;

            await _repository.UpdateAsync(value);
        }
    }
}
