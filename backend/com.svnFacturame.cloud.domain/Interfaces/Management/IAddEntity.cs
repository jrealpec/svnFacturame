using System;

namespace com.svnFacturame.cloud.domain.Interfaces.Management
{
  public interface IAddEntity<TKey>
  {
    public TKey Id { get; set; }
    public long? CreatedBy { get; set; }
    public DateTime? CreationDate { get; set; }

   }
}
