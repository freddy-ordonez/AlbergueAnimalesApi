using Domain.Entities.ErrorModel;
using Domain.Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace AlbergueAnimalesRescatadosApi.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {               
                    context.Response.ContentType = "application/json";

                    var contextFeacture = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeacture != null)
                    {
                        context.Response.StatusCode = contextFeacture.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _=> StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Something went wrong: {contextFeacture.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeacture.Error.Message,
                        }.ToString());
                    }
                });
            });
        }
    }
}
