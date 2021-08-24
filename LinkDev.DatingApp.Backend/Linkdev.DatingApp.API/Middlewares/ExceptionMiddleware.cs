using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.DatingApp.API.Errors;
using LinkDev.DatingApp.Application.Errors;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LinkDev.DatingApp.API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, 
        IHostEnvironment env)
        {
            this._env = env;
            this._next = next;
            this._logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        { 
            try{

                await _next(context);

            }catch (Exception ex)
            {
              if(ex is BusinessException)
              {
                  var exceptoinResponse = new {StatusCode=400, Message=ex.Message};
                    await context.Response.WriteAsJsonAsync(exceptoinResponse);
              }
              _logger.LogError(ex,ex.Message);
              context.Response.ContentType="application/json";
              context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
              
              var response = _env.IsDevelopment() ? 
              new ApiException(context.Response.StatusCode,ex.Message,ex.StackTrace.ToString())
             :new ApiException(context.Response.StatusCode,"Internal Server Error");

              var options= new JsonSerializerOptions(){PropertyNamingPolicy=JsonNamingPolicy.CamelCase};
              var json= JsonSerializer.Serialize(response,options);
              await context.Response.WriteAsync(json);
            }
        }
    }
}