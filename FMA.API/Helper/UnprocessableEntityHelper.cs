using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace FMA.API.Helper
{

    // not using this. Using the frameworks built-in UnprocessableEntityObjectResult class.
    //However I have an understanding of how you can extend the objectresult class for future use.
    public class UnprocessableEntityHelper : ObjectResult
    {
        public UnprocessableEntityHelper(ModelStateDictionary modelState)
            : base(new SerializableError(modelState))
        {
            if(modelState is null)
            {
                throw new ArgumentException(nameof(modelState));
            }

            StatusCode = 422;
        }
    }
}
