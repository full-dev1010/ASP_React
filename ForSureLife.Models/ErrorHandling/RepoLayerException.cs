using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ForSureLife.Models.ErrorHandling
{
    public class RepoLayerException : Exception
    { 
     public ErrorCode DataError { get; set; }

    public override string Message { get; }

    public Dictionary<string, object> AdditionalInformation { get; set; }

    public RepoLayerException(ErrorCode dataError, string message) : this(dataError, null, message)
    { }

    public RepoLayerException(ErrorCode dataError, Exception e) : this(dataError, e, null)
    { }

    public RepoLayerException(ErrorCode dataError, Exception e, string message) : this(dataError, e, message, null)
    { }

    public RepoLayerException(ErrorCode dataError, Exception e, string message, Dictionary<string, object> additionalInformation) : base(null, e)
    {
        this.DataError = dataError;
        this.Message = !string.IsNullOrWhiteSpace(message) ? message : this.DataError.ToString();
        this.AdditionalInformation = additionalInformation;
    }

    public RepoLayerException(HttpStatusCode statusCode, string message) : this(statusCode, null, message)
    { }

    public RepoLayerException(HttpStatusCode statusCode, Exception e) : this(statusCode, e, null)
    { }

    public RepoLayerException(HttpStatusCode statusCode, Exception e, string message) : this(statusCode, e, message, null)
    { }

    public RepoLayerException(HttpStatusCode statusCode, Exception e, string message, Dictionary<string, object> additionalInformation) : base(null, e)
    {
        this.DataError = MapStatusCodeToDataError(statusCode);
        this.Message = !string.IsNullOrWhiteSpace(message) ? message : this.DataError.ToString();
        this.AdditionalInformation = additionalInformation;
    }

    private static ErrorCode MapStatusCodeToDataError(HttpStatusCode statusCode)
    {
        switch (statusCode)
        {
            case HttpStatusCode.Conflict:
                return ErrorCode.Conflict;
            case HttpStatusCode.NotFound:
                return ErrorCode.NotFound;
            case HttpStatusCode.Gone:
                return ErrorCode.Gone;
            case HttpStatusCode.BadRequest:
                return ErrorCode.BadRequest;
            default:
                return ErrorCode.UnhandledError;
        }
    }
}
}
