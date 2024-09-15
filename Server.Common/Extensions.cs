using System.Linq.Expressions;

namespace Server.Common;

public enum OrderType
{
    Ascending,
    Descending
}

public static class Extensions
{
    public static IOrderedQueryable<TSource> OrderBy<TSource, TKey>(
        this IQueryable<TSource> source,
        Expression<Func<TSource, TKey>> keySelector,
        OrderType type) =>
        type == OrderType.Ascending ? source.OrderBy(keySelector) : source.OrderByDescending(keySelector);
    
    public static IOrderedQueryable<TSource> ThenBy<TSource, TKey>(
        this IOrderedQueryable<TSource> source,
        Expression<Func<TSource, TKey>> keySelector,
        OrderType type) =>
        type == OrderType.Ascending ? source.ThenBy(keySelector) : source.ThenByDescending(keySelector);
}