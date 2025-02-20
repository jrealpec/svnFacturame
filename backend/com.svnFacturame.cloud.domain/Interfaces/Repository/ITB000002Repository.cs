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
    public interface ITB000002Repositoryy<TContext> : IBaseRepository<TB000002, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<TB000002>> GetTB000002Async(CancellationToken cancellationToken = default);
        Task<TB000002> GetTB000002Async(int id, CancellationToken cancellationToken = default);
        Task<TB000002> SingleTB000002Async(Expression<Func<TB000002, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TB000002>> FilterTB000002Async(Expression<Func<TB000002, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTB000002Async(TB000002 obj, CancellationToken cancellationToken = default);
        Task AddRangeTB000002Async(IEnumerable<TB000002> obj, CancellationToken cancellationToken = default);
        void UpdateTB000002(TB000002 obj);
    }
}
