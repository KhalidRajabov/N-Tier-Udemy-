using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTOs;
using NLayer.Service.Exceptions;
using System.Text.Json;

namespace NLayer.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UserCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        //returns 400 if error type is made by ClientSideException class. It is like "If => return"
                        ClientSideException => 400,

                        //returns 404 if error type is made by NotFoundException class. It is like "If => return"
                        NotFoundException => 404,

                        //returns 500 if error type is not ClientSideException. It is like "Else => return"
                        _ => 500
                    } ;
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDTO<NoContentDTO>.Fail(statusCode, exceptionFeature.Error.Message);
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
