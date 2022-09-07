using Infrastructure.Common.DTOs;
using Infrastructure.Common.Exceptions;


namespace Infrastructure.Common.Middlewares;

public class ErrorHandlingMiddleware : IMiddleware
{
    private readonly ILogger<ErrorHandlingMiddleware> _logger;
    public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) =>
        (_logger) = (logger);

    private static ErrorResponseDto GenerateErrorResponse(ref Exception ex)
    {
        ErrorResponseDto responseDto = new(Guid.NewGuid(), ex.Message.Trim());
        responseDto.Messages.Add(ex.Message);
        if (ex is not CustomException && ex.InnerException != null)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
        }
        switch (ex)
        {
            case CustomException e:
                responseDto.StatusCode = e.StatusCode;
                if (e.ErrorMessages is not null)
                {
                    responseDto.Messages.AddRange(e.ErrorMessages);
                }
                break;
            case KeyNotFoundException:
                responseDto.StatusCode = HttpStatusCode.NotFound;
                break;

            default:
                responseDto.StatusCode = HttpStatusCode.InternalServerError;
                break;
        }

        return responseDto;
    }

    public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception ex)
        {

            ErrorResponseDto responseDto = GenerateErrorResponse(ref ex);
            var response = httpContext.Response;
            if (!response.HasStarted)
            {
                response.ContentType = "application/json";
                response.StatusCode = (int)responseDto.StatusCode;
                await response.WriteAsync(JsonConvert.SerializeObject(responseDto));
            }
            else
            {
                _logger.LogWarning("Can't write error response. Response has already started.");
            }
        }
    }
}