using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Empresas;
using com.svnFacturame.cloud.domain.Interfaces.Base;


namespace com.svnFacturame.cloud.domain.Interfaces.Repository
{
    public interface ITG000003Repository<TContext>: IBaseRepository<TG000003, TContext> where TContext : DbContext, new()
    {
        Task<IEnumerable<TG000003>> GetTG000003Async(CancellationToken cancellationToken = default);
        Task<TG000003> GetTG000003Async(int id, CancellationToken cancellationToken = default);
        Task<TG000003> SingleTG000003Async(Expression<Func<TG000003, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000003>> FilterTG000003Async(Expression<Func<TG000003, bool>> predicate, CancellationToken cancellationToken = default);
        Task AddTG000003Async(TG000003 obj, CancellationToken cancellationToken = default);
        Task AddRangeTG000003Async(IEnumerable<TG000003> obj, CancellationToken cancellationToken = default);
        void UpdateTG000003(TG000003 obj);


    }
}
