using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ReservationCommands
{
    public class RemoveReservationCommand:IRequest
    {
        public string Id { get; set; }

        public RemoveReservationCommand(string id)
        {
            Id = id;
        }
    }
}
