using FluentValidation;
using MediatR;
using System.Text.Json;

namespace Ecommerce.Core.Behavior
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        #region Fields
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        #endregion

        #region Constructors
        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        #endregion

        #region Methods
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {


                var messages = failures.Select(err => new
                {
                    PropertyName = err.PropertyName,
                    ErrorMessage = err.ErrorMessage
                });

                var jsonString = System.Text.Json.JsonSerializer.Serialize(messages, new JsonSerializerOptions
                {
                    WriteIndented = true
                });


                throw new ValidationException(jsonString);
            }
            return await next();
        }
        #endregion

    }
}
