using MediatR;
using Microsoft.Extensions.Logging;
using Staff.Application.Exceptions;
using Staff.Application.Shared;

namespace Staff.Application.Behaviours
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : MediatR.IRequest<TResponse>
            where TResponse : ApiResponse<object>, new()

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
                return new TResponse()
                {
                    StatusCode = 400,
                    ValidationErrors = ex.Errors,
                    Data = null
                };
            }
            catch (CustomNotFoundException n_ex)
            {
                return new TResponse()
                {
                    StatusCode = 404,
                    Message = n_ex.Message,
                    Data = null
                };
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Application Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);
                return new TResponse()
                {
                    StatusCode = 500,
                    Message = ex.Message,
                    Data = null
                };
            }
        }
    }
}