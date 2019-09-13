using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.Exceptions;

namespace TechnicalRadiation.WebApi.ExceptionHandlerExtensions
{
    public static class ExceptionHandlerExtensions
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => 
            {
                error.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var exception = exceptionHandlerFeature.Error;
                        var statusCode = HttpStatusCode.InternalServerError;

                        if (exception is ResourceNotFoundException)
                        {
                            statusCode = HttpStatusCode.NotFound;
                        }
                        else if (exception is ModelFormatException)
                        {
                            statusCode = HttpStatusCode.PreconditionFailed;
                        }
                        else if (exception is ArgumentOutOfRangeException)
                        {
                            statusCode = HttpStatusCode.BadRequest;
                        }

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = (int) statusCode;

                        var exceptionModel = new ExceptionModel
                        {
                            StatusCode = (int) statusCode,
                            ExceptionMessage = exception.Message,
                            StackTrace = exception.StackTrace
                        };

                        await context.Response.WriteAsync(exceptionModel.ToString());
                    }
                });
            });
        }
    }
}