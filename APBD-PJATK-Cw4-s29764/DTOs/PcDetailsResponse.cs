namespace APBD_PJATK_Cw4_s29764.DTOs;

public record PcDetailsResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<PcComponentsResponse> Components
    );