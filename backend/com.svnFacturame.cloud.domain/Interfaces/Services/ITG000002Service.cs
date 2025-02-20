using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

using com.svnFacturame.cloud.domain.DTO.Ciudades;


namespace com.svnFacturame.cloud.domain.Interfaces.Services
{
    public interface ITG000002Service
    {
        Task<TG000002DTO> FindTG000002Async(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TG000002DTO>> GetTG000002Async(CancellationToken cancellationToken = default);
    }
}
