using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Bancos;
using com.svnFacturame.cloud.domain.Interfaces.Base;

namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITG000001Repository<TContext> : IBaseRepository<TG000001, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TG000001>> GetTG000001Async(CancellationToken cancellationToken = default);
        Task<TG000001> GetTG000001Async(int id, CancellationToken cancellationToken = default);
        Task<TG000001> SingleTG000001Async(Expression<Func<TG000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000001>> FilterTG000001Async(Expression<Func<TG000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTG000001Async(TG000001 obj, CancellationToken cancellationToken = default);
        Task AddRangeTG000001Async(IEnumerable<TG000001> obj, CancellationToken cancellationToken = default);
        void UpdateTG000001(TG000001 obj);
        //void DeleteTG000001(TG000001 obj);
    }
}
