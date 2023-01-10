using System;  
using System.Collections.Generic;  
using System.ComponentModel.DataAnnotations;  
using System.Linq;  
using System.Web;  
//using System.Web.Mvc; 

namespace AltFuture.CustomValidation
{
    public class CustomIsInitialValue : ValidationAttribute
    {
        string _initialValue;
        public CustomIsInitialValue(string InitialValue)
        {
            this._initialValue = InitialValue;
        }

        public override bool IsValid(object value)
        {
            Boolean isValid = !(value.ToString() == _initialValue);
            return isValid;
        }
    }
}


 
  
