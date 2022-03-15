using FluentValidation;
using Getty.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getty.Infrastructure.Validators
{
    public class EmployeeValidator : AbstractValidator<EmpEmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(post => post.EmpId)
               .NotNull()
               .WithName("Employe ID");

            RuleFor(post => post.EmpFirstName)
                .NotNull()
                .WithName("First name")
                .Length(1, 50);

            RuleFor(post => post.EmpLastName)
                .NotNull()
                .WithName("Last name")
                .Length(1, 50);

            RuleFor(post => post.EmpStsId)
                .NotNull()
                .GreaterThan(0)
                .WithName("Site");

            RuleFor(post => post.EmpStatus)
                .NotNull()
                .WithName("Status");

        }

    }
}
