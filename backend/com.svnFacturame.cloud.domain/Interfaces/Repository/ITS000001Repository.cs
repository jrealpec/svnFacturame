using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Menu;
using com.svnFacturame.cloud.domain.Interfaces.Base;

namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    internal interface ITS000001Repository<TContext> : IBaseRepository<TS000001, TContext>
        where TContext : DbContext, new() {

        Task<IEnumerable<TS000001>> GetTS000001Async(CancellationToken cancellationToken = default);
        Task<TS000001> GetTS000001Async(int id, CancellationToken cancellationToken = default);
        Task<TS000001> SingleTS000001Async(Expression<Func<TS000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TS000001>> FilterTS000001Async(Expression<Func<TS000001, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTS000001Async(TS000001 obj, CancellationToken cancellationToken = default);
        Task AddRangeTS000001Async(IEnumerable<TS000001> obj, CancellationToken cancellationToken = default);
        void UpdateTS000001(TS000001 obj);
    }
}
