using System;

namespace com.svnFacturame.cloud.domain.Interfaces.Management
{
  public interface IUpdateEntity<TKey> : IAddEntity<TKey>
  {
    public long? UpdateBy { get; set; }
    public DateTime? UpdateDate { get; set; }
  }
}
