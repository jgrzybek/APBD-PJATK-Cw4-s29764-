using APBD_PJATK_Cw4_s29764.DTOs;
using APBD_PJATK_Cw4_s29764.Exceptions;
using APBD_PJATK_Cw4_s29764.Infrastructure;
using APBD_PJATK_Cw4_s29764.Models;
using Microsoft.EntityFrameworkCore;

namespace APBD_PJATK_Cw4_s29764.Services;

public class PcService(AppDbContext adc) : IPcService
{
    public async Task<IEnumerable<PcResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await adc.Pcs.Select(pc => new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
            )).ToListAsync(cancellationToken);
    }

    public async Task<PcDetailsResponse> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await adc.Pcs.Where(pc => pc.Id == id).Select(pc => new PcDetailsResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock,
            pc.PcComponents.Select(c => new PcComponentsResponse(
                c.Amount,
                new ComponentResponse(
                    c.ComponentCode,
                    c.Component.Name,
                    c.Component.Description,
                    new ComponentManufacturerResponse(
                        c.Component.ComponentManufacturersId,
                        c.Component.ComponentManufacturer.Abbreviation,
                        c.Component.ComponentManufacturer.FullName,
                        c.Component.ComponentManufacturer.FoundationDate
                        ),
                    new ComponentTypeResponse(
                        c.Component.ComponentType.Id,
                        c.Component.ComponentType.Abbreviation,
                        c.Component.ComponentType.Name
                        )
                    )
                ))
            )).FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException("PC", id);
    }

    public async Task<PcResponse> AddAsync(CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = new Pc
        {
            Name = request.Name,
            Weight = request.Weight,
            Warranty = request.Warranty,
            CreatedAt = request.CreatedAt,
            Stock = request.Stock
        };

        adc.Add(pc);
        await adc.SaveChangesAsync(cancellationToken);

        return new PcResponse(
            pc.Id,
            pc.Name,
            pc.Weight,
            pc.Warranty,
            pc.CreatedAt,
            pc.Stock
        );
    }

    public async Task UpdateAsync(int id, UpdatePcRequest request, CancellationToken cancellationToken)
    {
        int affectedRows = await adc.Pcs.Where(e => e.Id == id)
            .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Name, request.Name)
                    .SetProperty(e => e.Weight, request.Weight)
                    .SetProperty(e => e.Warranty, request.Warranty)
                    .SetProperty(e => e.CreatedAt, request.CreatedAt)
                    .SetProperty(e => e.Stock, request.Stock)
                , cancellationToken
            );

        if (affectedRows == 0)
        {
            throw new NotFoundException("PC", id);
        }
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var pc = await adc.Pcs.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        if (pc == null)
        {
            throw new NotFoundException("PC", id);
        }
        
        adc.Pcs.Remove(pc);
        await adc.SaveChangesAsync(cancellationToken);
    }
}