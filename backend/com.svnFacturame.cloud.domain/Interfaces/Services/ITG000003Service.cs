using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

using com.svnFacturame.cloud.domain.DTO.Empresas;

namespace com.svnFacturame.cloud.domain.Interfaces.Services
{
    public interface ITG000003Service
    {
        Task<TG000003DTO> FindTG000003Async(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000003DTO>> GetTG000003Async(CancellationToken cancellationToken = default);
    }
}
