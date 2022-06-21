using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ThreadPainter.Validation
{
    class IntMinMaxValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {    
                string toValidateString = (string)value;
                if (Int32.TryParse(toValidateString, out int toValidate))
                {
                    if (toValidate > 0 && toValidate <= 20)
                    {
                        return ValidationResult.ValidResult;
                    }
                }
                return new ValidationResult(false, "Type in the integer between 1 and 20");
            }
            catch (Exception ex)
            {
                return new ValidationResult(false, "this is not a valid input");
            }
        }
    }
    
}
