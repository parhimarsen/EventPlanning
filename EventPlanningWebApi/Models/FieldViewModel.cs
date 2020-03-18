using System;
using EventPlanningWebApi.Validators;
using FluentValidation.Attributes;

namespace EventPlanningWebApi.Models
{
    [Validator(typeof(FieldViewModelValidator))]
    public class FieldViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}