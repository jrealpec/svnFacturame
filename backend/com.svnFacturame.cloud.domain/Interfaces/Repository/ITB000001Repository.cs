using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.CIE;
using com.svnFacturame.cloud.domain.Interfaces.Base;

namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITB000001Repository<TContext> : IBaseRepository<TB000001, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<TB000001>> GetTB000001Async(CancellationToken cancellationToken = default);
        Task<TB000001> GetTB000001Async(int id, CancellationToken cancellationToken = default);
        Task<TB000001> SingleTB000001Async(Expression<Func<TB000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TB000001>> FilterTB000001Async(Expression<Func<TB000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTB000001Async(TB000001 obj, CancellationToken cancellationToken = default);
        Task AddRangeTB000001Async(IEnumerable<TB000001> obj, CancellationToken cancellationToken = default);
        void UpdateTB000001(TB000001 obj);

    }
}
