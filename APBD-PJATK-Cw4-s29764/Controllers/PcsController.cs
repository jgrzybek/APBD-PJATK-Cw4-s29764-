using APBD_PJATK_Cw4_s29764.DTOs;
using APBD_PJATK_Cw4_s29764.Exceptions;
using APBD_PJATK_Cw4_s29764.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_PJATK_Cw4_s29764.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PcsController(IPcService service) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Getall(CancellationToken cancellationToken)
    {
        return Ok(await service.GetAllAsync(cancellationToken));
    }
    
    [HttpGet("{id:int}/components")]
    public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await service.GetByIdAsync(id, cancellationToken));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreatePcRequest request, CancellationToken cancellationToken)
    {
        var pc = await service.AddAsync(request, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = pc.Id }, pc);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdatePcRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await service.UpdateAsync(id, request, cancellationToken);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken)
    {
        try
        {
            await service.DeleteAsync(id, cancellationToken);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}