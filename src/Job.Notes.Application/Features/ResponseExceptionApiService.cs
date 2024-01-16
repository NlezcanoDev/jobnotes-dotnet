using Job.Notes.Domain.Models;

namespace Job.Notes.Application.Features;

public static class ResponseExceptionApiService
{
    public static BaseResponseModel Response(int statusCode, string message = "")
    {

        var result = new BaseResponseModel
        {
            StatusCode = statusCode,
            Message = message,
            Data = null!,
            Success = false
        };

        return result;
    }
}