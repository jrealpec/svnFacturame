using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.CIE;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;


namespace com.svnFacturame.cloud.Api.Controllers.CIE
{
    [Route("api/[controller]")]
    [ApiController]
    public class TB000002Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;

        public TB000002Controller(asaCloud_Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TB000002>>> GetTB000002()
        {
            return await _context.TB000002.Include(o => o._TB000001).ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TB000002>> GetTB000002(int id)
        {
            var _TB000002 = await _context.TB000002.FindAsync(id);

            if (_TB000002 == null)
            {
                return NotFound();
            }

            return _TB000002;
        }

        [HttpGet("{idGrupo}")]
        public async Task<ActionResult<TB000002>> GetTB000002IdGrupo(int idGrupo)
        {
            var _TB000002 = await _context.TB000002.Include(o => o._TB000001).FirstOrDefaultAsync(o => o.idGrupo == idGrupo);

            if (_TB000002 == null)
            {
                return NotFound();
            }

            return _TB000002;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTB000002(int id, TB000002 _TB000002Edit)
        {
            var _TB000002 = await _context.TB000002.FindAsync(id);
            if (id != _TB000002.Id)
            {
                return BadRequest();
            }

            _TB000002.Name = _TB000002Edit.Name;
            _TB000002.Status = _TB000002Edit.Status;
            _TB000002.Visible = _TB000002Edit.Visible;
            _TB000002.idGrupo = _TB000002Edit.idGrupo;

            _context.TB000002.Update(_TB000002);
            _context.Entry(_TB000002).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB000002Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        [HttpPost]
        public async Task<ActionResult<TB000002>> PostTB000002(TB000002 _TB000002)
        {
            _context.TB000002.Add(_TB000002);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTB000002", new { id = _TB000002.Id }, _TB000002);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TB000002>> DeleteTB000002(int id)
        {
            var _TB000002 = await _context.TB000002.FindAsync(id);

            if (_TB000002 == null)
            {
                return NotFound();
            }

            _context.TB000002.Remove(_TB000002);
            await _context.SaveChangesAsync();

            return _TB000002;
        }
        private bool TB000002Exists(int id)
        {
            return _context.TG000002.Any(e => e.Id == id);
        }
    }
}
