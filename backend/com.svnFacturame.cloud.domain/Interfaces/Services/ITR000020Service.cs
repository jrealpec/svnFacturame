using com.svnFacturame.cloud.domain.DTO.Facturas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace com.svnFacturame.cloud.domain.Interfaces.Services
{
    public interface ITR000020Service
    {
        Task<TR000020DTO> FindTR000020Async(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TR000020DTO>> GetTR000020Async(CancellationToken cancellationToken = default);
    }
}
