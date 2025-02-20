using System;

using Microsoft.EntityFrameworkCore;

namespace com.svnFacturame.cloud.domain.Interfaces.Base
{
  public interface IDbFactory<TContext> : IDisposable where TContext : DbContext, new()
  {
    TContext Init();
  }
}
