using CarBook.Application.Features.Mediator.Commands.CarFeatureCommands;
using CarBook.Application.Features.Mediator.Commands.CarPricingCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class RemoveCarFeatureCommandHandler : IRequestHandler<RemoveCarFeatureCommand>
    {
        private readonly IRepository<CarFeature> _repository;
        public RemoveCarFeatureCommandHandler(IRepository<CarFeature> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            value.IsActive = false;
            value.IsDeleted = true;
            value.UpdatedDate = DateTime.Now;
            await _repository.RemoveAsync(value);
        }
    }
}
