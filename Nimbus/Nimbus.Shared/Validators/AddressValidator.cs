using FluentValidation;
using Nimbus.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimbus.Shared.Validators
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.streetNumber).GreaterThan(0);
            RuleFor(address => address.streetName).NotEmpty();
            RuleFor(address => address.city).NotEmpty();
            RuleFor(address => address.state).NotEmpty();
            RuleFor(address => address.zipCode).GreaterThan(0).LessThan(99999);
        }
    }
}
