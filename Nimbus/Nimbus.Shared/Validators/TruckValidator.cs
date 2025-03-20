using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nimbus.Shared.Entities;

namespace Nimbus.Shared.Validators
{
    public class TruckValidator : AbstractValidator<TruckEntity>
    {
        public TruckValidator()
        {
            RuleFor(truck => truck.mileage).GreaterThan(0);
        }
    }
}
