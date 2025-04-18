using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        //RequestDelegate is a fucntion that processes http request
        //and next to pass it to next middleware  
        //ILogger 
        //A generic interface for logging where the category name is derived from the specified ExceptionMiddleware type name. Generally used to enable activation of a named ILogger from dependency injection.
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next , ILogger<ExceptionMiddleware> logger,IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext context){
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                context.Response.ContentType="application/json";
                context.Response.StatusCode = 500 ;//StatusCodes.Status500InternalServerError;
                

                var response = new ProblemDetails{
                    Title = ex.Message,
                    Status = 500,
                    Detail = _env.IsDevelopment()?ex.StackTrace?.ToString() : null
                };

                var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase};
                var json = JsonSerializer.Serialize(response, jsonOptions);

                await context.Response.WriteAsync(json);
            }
        }
        
        
    }
}