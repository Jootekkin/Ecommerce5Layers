using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace Ecommerce.Core.Pagination
{
    public static class PaginationExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PaginationRequest request)
        {
            if (request.PageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(request.PageNumber), "Page number must be greater than 0.");
            }
            if (request.PageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(request.PageSize), "Page size must be greater than 0.");
            }
            return query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize);
        }

        public static async Task<PaginationResponse<T>> ToPaginatedResponseAsync<T>(this IQueryable<T> query, PaginationRequest request, CancellationToken cancellationToken = default)
        {
            var totalRecords = await query.CountAsync(cancellationToken);
            var data = await query.Paginate(request).ToListAsync(cancellationToken);
            return new PaginationResponse<T>(data, totalRecords, request.PageNumber, request.PageSize);
        }


        public static IQueryable<T> Sort<T>(this IQueryable<T> query, string? sortBy, string? sortDirection)
        {
            if (string.IsNullOrWhiteSpace(sortBy))
                return query;

            var propertyInfo = typeof(T).GetProperty(sortBy, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
                return query;

            if (sortDirection?.ToLower() == "desc")
                return query.OrderByDescending(x => propertyInfo.GetValue(x, null));
            else
                return query.OrderBy(x => propertyInfo.GetValue(x, null));
        }


        public static IQueryable<T> Search<T>(this IQueryable<T> query, string? searchTerm, params string[] propertyNames)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || !propertyNames.Any())
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            var properties = propertyNames
                .Select(prop => typeof(T).GetProperty(prop, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance))
                .Where(prop => prop != null && prop.PropertyType == typeof(string))
                .ToList();

            if (!properties.Any())
                return query;

            var searchExpression = properties
                .Select(prop =>
                {
                    var propertyAccess = Expression.Property(parameter, prop!);
                    var toLowerMethod = typeof(string).GetMethod("ToLower", Type.EmptyTypes);
                    var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

                    var propertyToLower = Expression.Call(propertyAccess, toLowerMethod!);
                    var searchTermToLower = Expression.Constant(searchTerm.ToLower(), typeof(string));

                    return Expression.Call(propertyToLower, containsMethod!, searchTermToLower);
                })
                .Aggregate<Expression, Expression?>(null, (current, expression) =>
                    current == null ? expression : Expression.OrElse(current, expression));

            if (searchExpression == null)
                return query;

            var lambda = Expression.Lambda<Func<T, bool>>(searchExpression, parameter);
            return query.Where(lambda);
        }



    }
}
