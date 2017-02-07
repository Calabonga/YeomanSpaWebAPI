using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;

namespace YeomanTemplate.Web.Infrastructure.Extensions {
    /// <summary>
    /// Custom sorting by reflection
    /// </summary>
    public static class SortExtensions {

        public static IQueryable<TEntity> OrderByDirection<TEntity>(this IQueryable<TEntity> source, string orderByProperty, ListSortDirection direction) {
            try {
                var command = direction == ListSortDirection.Descending ? "OrderByDescending" : "OrderBy";
                var type = typeof(TEntity);
                var property = type.GetProperty(orderByProperty);
                var parameter = Expression.Parameter(type, "p");
                var propertyAccess = Expression.MakeMemberAccess(parameter, property);
                var orderByExpression = Expression.Lambda(propertyAccess, parameter);
                var resultExpression = Expression.Call(typeof(Queryable), command, new[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExpression));
                return source.Provider.CreateQuery<TEntity>(resultExpression);
            }
            catch {
                return source;
            }
        }
    }
}