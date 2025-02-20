using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Departamentos;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;

namespace com.svnFacturame.cloud.Api.Controllers.Departamentos
{
    [Route("api/[controller]")]
    [ApiController]
    public class TG000004Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;
        public TG000004Controller(asaCloud_Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TG000004>>> GetTG000004()
        {
            return await _context.TG000004.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TG000004>> GetTG000004(int id)
        {
            var _TG000004 = await _context.TG000004.FindAsync(id);

            if (_TG000004 == null)
            {
                return NotFound();
            }

            return _TG000004;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTG000004(int id, TG000004 _TG000004Edit)
        {
            var _TG000004 = await _context.TG000004.FindAsync(id);
            if (id != _TG000004.Id)
            {
                return BadRequest();
            }

            _TG000004.Name = _TG000004Edit.Name;
            _TG000004.Status = _TG000004Edit.Status;
            _TG000004.Visible = _TG000004Edit.Visible;

            _context.TG000004.Update(_TG000004);
            _context.Entry(_TG000004).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TG000004Exists(id))
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
        public async Task<ActionResult<TG000004>> PostTG000004(TG000004 _TG000004)
        {
            _context.TG000004.Add(_TG000004);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTG000004", new { id = _TG000004.Id }, _TG000004);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TG000004>> DeleteTG000004(int id)
        {
            var _TG000004 = await _context.TG000004.FindAsync(id);

            if (_TG000004 == null)
            {
                return NotFound();
            }

            _context.TG000004.Remove(_TG000004);
            await _context.SaveChangesAsync();

            return _TG000004;
        }
        private bool TG000004Exists(int id)
        {
            return _context.TG000004.Any(e => e.Id == id);
        }
    }
}
