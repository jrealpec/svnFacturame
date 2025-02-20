using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Ciudades;
using com.svnFacturame.cloud.domain.Interfaces.Base;

namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITG000002Repository<TContext> : IBaseRepository<TG000002, TContext>
        where TContext : DbContext, new()
    {
        Task<IEnumerable<TG000002>> GetTG000002Async(CancellationToken cancellationToken = default);
        Task<TG000002> GetTG000002Async(int id, CancellationToken cancellationToken = default);
        Task<TG000002> SingleTG000002Async(Expression<Func<TG000002, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000002>> FilterTG000002Async(Expression<Func<TG000002, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTG000002Async(TG000002 obj, CancellationToken cancellationToken = default);
        Task AddRangeTG000002Async(IEnumerable<TG000002> obj, CancellationToken cancellationToken = default);
        void UpdateTG000002(TG000002 obj);
        //void DeleteTG000001(TG000001 obj);
    }
}
