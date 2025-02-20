using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Departamentos;
using com.svnFacturame.cloud.domain.Interfaces.Base;


namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITG000004Repository<TContext> : IBaseRepository<TG000004, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<TG000004>> GetTG000004Async(CancellationToken cancellationToken = default);
        Task<TG000004> GetTG000004Async(int id, CancellationToken cancellationToken = default);
        Task<TG000004> SingleTG000004Async(Expression<Func<TG000004, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000004>> FilterTG000004Async(Expression<Func<TG000004, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTG000004Async(TG000004 obj, CancellationToken cancellationToken = default);
        Task AddRangeTG000004Async(IEnumerable<TG000004> obj, CancellationToken cancellationToken = default);
        void UpdateTG000004(TG000004 obj);
    }
}
