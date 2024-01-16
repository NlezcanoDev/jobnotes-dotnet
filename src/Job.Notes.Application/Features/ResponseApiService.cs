using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Features;

public static class ResponseApiService
{
    public static BaseResponseModel Response(int statusCode, object data = null, string message = null)
    {
        bool success = statusCode is >= 200 and < 300;

        var result = new BaseResponseModel
        {
            StatusCode = statusCode,
            Message = message,
            Data = data,
            Success = success
        };

        return result;
    }
}