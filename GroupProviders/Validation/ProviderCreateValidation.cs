using Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProviders.Validation
{
    public class ProviderCreateValidation : AbstractValidator<ProviderViewModel>
    {
        public ProviderCreateValidation()
        {
            this.RuleFor(p => p.Name)
              .Cascade(CascadeMode.Stop)
              .NotEmpty().WithMessage("Name should be not empty.")
              .Length(2, 25);
            this.RuleFor(p => p.Type)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Type should be not empty.")
                .Length(2, 25);
        }
    }
}
