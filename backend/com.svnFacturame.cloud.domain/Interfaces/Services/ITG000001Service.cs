using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

using com.svnFacturame.cloud.domain.DTO.Bancos;


namespace com.svnFacturame.cloud.domain.Interfaces.Services
{
    public interface ITG000001Service 
    {
        Task<TG000001DTO> FindTG000001Async(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000001DTO>> GetTG000001Async(CancellationToken cancellationToken = default);
    }
}
