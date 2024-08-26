using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarReviewCommands;

public class UpdateCarReviewCommand : BaseUpdateCommand
{
	public string Comment { get; set; }
	public string CustomerImg { get; set; }
	public string CustomerName { get; set; }
	public string RatingValue { get; set; }
	public string CarId { get; set; }
}
