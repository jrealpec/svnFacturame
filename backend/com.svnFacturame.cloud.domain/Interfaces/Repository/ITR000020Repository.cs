using com.svnFacturame.cloud.domain.Entities.CIE;
using com.svnFacturame.cloud.domain.Entities.Facturas;
using com.svnFacturame.cloud.domain.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITR000020Repository<TContext> : IBaseRepository<TR000020, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<TR000020>> GetTR000020Async(CancellationToken cancellationToken = default);
        Task<TR000020> GetTR000020Async(int id, CancellationToken cancellationToken = default);
        Task<TR000020> SingleTR000020Async(Expression<Func<TR000020, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TR000020>> FilterTR000020Async(Expression<Func<TR000020, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTR000020Async(TR000020 obj, CancellationToken cancellationToken = default);
        Task AddRangeTR000020Async(IEnumerable<TR000020> obj, CancellationToken cancellationToken = default);
        void UpdateTR000020(TR000020 obj);
    }
}
