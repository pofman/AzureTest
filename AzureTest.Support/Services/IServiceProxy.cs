using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureTest.Support.Services
{
    public interface IServiceProxy<T> where T : IService
    {
        void Invoke(Expression<Action<T>> method);
        Task<TResult> Invoke<TResult>(Expression<Func<T, TResult>> method);
    }
}
