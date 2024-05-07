using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;

namespace DAL.MiddleWares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (MySqlConnector.MySqlException ex)
            {
                await HandleExceptionAsync(context, "Unable to connect to MySQL host.");
            }
            catch (NullReferenceException ex)
            {
                await HandleExceptionAsync(context, "Null reference encountered: " + ex.Message);
            }
            catch (SystemException ex)
            {
                await HandleExceptionAsync(context, "System error: " + ex.Message);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, "Unexpected error: " + ex.Message);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, string errorMessage)
        {
            var code = HttpStatusCode.InternalServerError; // 500
            var result = JsonConvert.SerializeObject(new { error = errorMessage });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}