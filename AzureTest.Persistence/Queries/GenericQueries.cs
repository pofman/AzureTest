using System;
using System.Collections.Generic;
using System.Linq;
using AzureTest.Foundations;

namespace AzureTest.Persistence.Queries
{
    public static class GenericQueries
    {
        public static IQueryable<T> ById<T>(this IQueryable<T> repository, long id)
            where T : Entity<T>
        {
            return repository.Where(x => x.Id == id);
        }

        public static TResult ById<T, TResult>(this IQueryable<T> repository, long id, Func<T, TResult> transformation)
            where T : Entity<T>
            where TResult : class, new()
        {
            return repository.ById(id).Select(transformation).SingleOrDefault();
        }

        public static IQueryable<T> IdIn<T>(this IQueryable<T> repository, IEnumerable<long> ids) where T : Entity<T>
        {
            return repository.Where(x => ids.Contains(x.Id));
        }
    }
}
