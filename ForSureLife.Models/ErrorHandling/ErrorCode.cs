using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ForSureLife.Models.ErrorHandling
{
    public enum ErrorCode 
    {
        [Description("There was an error with your request.")]
        BadRequest = 400,
        [Description("You are not permitted to access this resource.")]
        Forbidden = 403,
        [Description("The requested resource cannot be found.")]
        NotFound = 404,
        [Description("The resource already exists.")]
        Conflict = 409,
        [Description("The requested resource is no longer available.")]
        Gone = 410,
        [Description("An unexpected error has occurred.")]
        UnhandledError = 500,
    }
}
