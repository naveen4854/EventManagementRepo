using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EventManagement.DataModels.Helpers
{
    public class MustBeTrueAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }

        public override string FormatErrorMessage(string name)
        {
            return "The " + name + " field must be checked in order to continue.";
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            //return new ModelClientValidationRule[] { new ModelClientValidationRule() { ValidationType = "booleanrequired", ErrorMessage = this.ErrorMessage } };
            return new ModelClientValidationRule[] { new ModelClientValidationRule { ValidationType = "checkboxtrue", ErrorMessage = this.ErrorMessage } };
        }
    }
}
