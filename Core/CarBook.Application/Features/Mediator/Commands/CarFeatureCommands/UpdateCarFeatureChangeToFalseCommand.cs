using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureChangeToFalseCommand:IRequest
    {
        public UpdateCarFeatureChangeToFalseCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
