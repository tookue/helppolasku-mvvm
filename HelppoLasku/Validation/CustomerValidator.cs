﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelppoLasku.ViewModels;

namespace HelppoLasku.Validation
{
    public class CustomerValidator : DataValidator
    {
        public CustomerValidator(EditCustomerViewModel viewmodel) : base(viewmodel)
        {
        }

        protected override string[] Properties => new string[] { "Name", "CustomerID", "Email", "Address", "PostalCode", "City" };

        public override string Validate(string property)
        {
            switch (property)
            {
                case "Name":
                    return Validation.Unique(property, Model, true) ;
                case "CustomerID":
                    return Validation.Unique(property, Model, false);
                case "Address":
                case "PostalCode":
                case "City":
                    return Validation.Required(property, ViewModel);
                case "Email":
                    return Validation.Format(property, ViewModel, false);
                default:
                    return null;
            }
        }
    }
}
