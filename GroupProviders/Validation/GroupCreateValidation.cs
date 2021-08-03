using Core.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupProviders.Validation
{
    public class GroupCreateValidation : AbstractValidator<GroupViewModel>
    {
        public GroupCreateValidation()
        {
            this.RuleFor(g => g.Name)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Name should be not empty.")
               .Length(2, 25);
            this.RuleFor(g => g.Type)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Type should be not empty.")
                .Length(2, 25);
        }
       
    }
}
