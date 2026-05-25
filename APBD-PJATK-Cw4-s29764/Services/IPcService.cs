using APBD_PJATK_Cw4_s29764.DTOs;

namespace APBD_PJATK_Cw4_s29764.Services;

public interface IPcService
{
    Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken);
    Task<PcDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken);
    Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(int id, CancellationToken cancellationToken);
}