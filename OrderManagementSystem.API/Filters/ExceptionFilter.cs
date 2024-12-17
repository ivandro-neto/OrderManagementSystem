using OrderManagementSystem.Communication.Responses;
using OrderManagementSystem.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace OrderManagementSystem.API.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is OrderManagementSystemException)
            {
                HandleProjectException(context);
            }
            else
            {
                ThrowUnknownException(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ErrorOnValidationException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Result = new BadRequestObjectResult(new ErrorResponseJson((int)HttpStatusCode.BadRequest, context.Exception.Message));
                    break;
                case NotFoundException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    context.Result = new NotFoundObjectResult(new ErrorResponseJson((int)HttpStatusCode.NotFound, context.Exception.Message));
                    break;
                case ConflictErrorException:
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    context.Result = new ConflictObjectResult(new ErrorResponseJson((int)HttpStatusCode.Conflict, context.Exception.Message));
                    break;
            }
        }

        private void ThrowUnknownException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ErrorResponseJson((int)HttpStatusCode.InternalServerError, context.Exception.Message));
        }
    }
}
