using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace APBD_PJATK_Cw4_s29764.DTOs;

public record UpdatePcRequest(
    [MaxLength(50), Required] string Name,
    [Required] float Weight,
    int Warranty,
    [Required] DateTime CreatedAt,
    int Stock
    );