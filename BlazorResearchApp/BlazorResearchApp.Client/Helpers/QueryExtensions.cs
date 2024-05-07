using System.Linq.Expressions;

namespace BlazorResearchApp.Client.Helpers
{
    public static class QueryExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string propertyName, bool ascending)
        {
            var parameter = Expression.Parameter(typeof(T), "p");

            Expression propertyAccess = Expression.PropertyOrField(parameter, propertyName);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);

            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                ascending ? "OrderBy" : "OrderByDescending",
                new Type[] { typeof(T), propertyAccess.Type },
                source.Expression, Expression.Quote(orderByExp));

            return source.Provider.CreateQuery<T>(resultExp);
        }
    }
}