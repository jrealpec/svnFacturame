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
    public class TB000001Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;
        public TB000001Controller(asaCloud_Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TB000001>>> GetTB000001()
        {
            return await _context.TB000001.ToListAsync();
        }

        // GET: BANCOS/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TB000001>> GetTB000001(int id)
        {
            var _TB000001 = await _context.TB000001.FindAsync(id);

            if (_TB000001 == null)
            {
                return NotFound();
            }

            return _TB000001;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTB000001(int id, TB000001 _TB000001Edit)
        {
            var _TB000001 = await _context.TB000001.FindAsync(id);
            if (id != _TB000001.Id)
            {
                return BadRequest();
            }

            _TB000001.Name = _TB000001Edit.Name;
            _TB000001.Status = _TB000001Edit.Status;
            _TB000001.Visible = _TB000001Edit.Visible;

            _context.TB000001.Update(_TB000001);
            _context.Entry(_TB000001).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TB000001Exists(id))
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
        public async Task<ActionResult<TB000001>> PostTB000001(TB000001 _TB000001)
        {
            _context.TB000001.Add(_TB000001);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTB000001", new { id = _TB000001.Id }, _TB000001);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TB000001>> DeleteTB000001(int id)
        {
            var _TB000001 = await _context.TB000001.FindAsync(id);

            if (_TB000001 == null)
            {
                return NotFound();
            }

            _context.TB000001.Remove(_TB000001);
            await _context.SaveChangesAsync();

            return _TB000001;
        }
        private bool TB000001Exists(int id)
        {
            return _context.TG000001.Any(e => e.Id == id);
        }
    }
}
