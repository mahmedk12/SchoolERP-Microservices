using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Reponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomValidationException = Staff.Application.Exceptions.CustomValidationException;

namespace Staff.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,TResponse>
            where TRequest : MediatR.IRequest<ApiResponse<object>>
            
             // <- this is the part you're missing
         
    {
        private readonly ILogger<TRequest> _logger;

        public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (CustomValidationException ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Validation Exception for Request {Name}", requestName);

                // Construct ApiResponse for validation exception
                var response = new ApiResponse<object>
                {
                    StatusCode = 400,
                    Url = "", // You can set the URL or leave it empty
                    ValidationErrors = ex.Errors,
                    Data = null
                };

                // Return the ApiResponse
                return (TResponse)(object)response;
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}