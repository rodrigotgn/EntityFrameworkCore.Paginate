using System;
using System.Linq;
using System.Linq.Expressions;

namespace EntityFrameworkCore.Paginate
{
    /// <summary>
    /// Paginate Extensions.
    /// </summary>
    public static class PaginateExtensions
    {
        /// <summary>
        /// Query pagination extension. 
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source"></param>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, IPaginationInfo pagination)
        {
            pagination.Page -= 1;

            if (pagination.Page < 0)
                pagination.Page = 0;

            return source
                .Skip(pagination.Page * pagination.Per_Page)
                .Take(pagination.Per_Page);
        }

        /// <summary>
        /// Query pagination extension
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source"></param>
        /// <param name="pagination"></param>
        /// <param name="totalrow"></param>
        /// <returns></returns>
        public static IQueryable<T> Paginate<T>(this IQueryable<T> source, IPaginationInfo pagination, out Int32 totalrow)
        {
            source = source.SortQuery(pagination);

            totalrow = source.Count();

            if (totalrow > 0)
            {
                var max = (int)Math.Ceiling((decimal)totalrow / pagination.Per_Page);
                pagination.Page = pagination.Page > max ? max : pagination.Page;
            }

            return Paginate(source, pagination);
        }

        /// <summary>
        /// Query sort extension.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IQueryable<T> SortQuery<T>(this IQueryable<T> source, IPaginationInfo args)
        {
            if (args.sort_order == EnumSortOrder.Asc)
            {
                return source.OrderBy(ToLambda<T>(args.sort_by));
            }
            else
            {
                return source.OrderByDescending(ToLambda<T>(args.sort_by));
            }
        }

        /// <summary>
        /// Query sort extension.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> SortQueryBy<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderBy(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="source"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static IQueryable<T> SortQueryByDescending<T>(this IQueryable<T> source, string propertyName)
        {
            return source.OrderByDescending(ToLambda<T>(propertyName));
        }

        /// <summary>
        /// Convert property to lambda.
        /// </summary>
        /// <typeparam name="T">Source type.</typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
        {
            var parameter = Expression.Parameter(typeof(T));

            MemberExpression property;

            try
            {
                property = Expression.Property(parameter, propertyName);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to sort entity because past property '{propertyName}' does not belong to entity.", ex);
            }

            var propAsObject = Expression.Convert(property, typeof(object));

            return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
        }
    }
}
