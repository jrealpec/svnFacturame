using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Facturas;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;
using com.svnFacturame.cloud.domain.Entities.CIE;


namespace com.svnFacturame.cloud.Api.Controllers.Facturas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TR000020Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;
        public TR000020Controller (asaCloud_Context context)
        {
            _context = context;
            TR000020 tr = new TR000020();
            tr.Status = true;
            TR000020 model = new TR000020();
            model.Status = tr.Status;
        }

        //GET, TR000020
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TR000020>>> GetTR000020()
        {
            return await _context.TR000020.ToListAsync();
        }
        // GET: BANCOS/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TR000020>> GetTR000020(int id)
        {
            var _TR000020 = await _context.TR000020.FindAsync(id);

            if (_TR000020 == null)
            {
                return NotFound();
            }

            return _TR000020;
        }

        [HttpPost]
        public async Task<ActionResult<TR000020>> PostTR000020(TR000020 _TR000020)
        {
            _context.TR000020.Add(_TR000020);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTR000020", new { id = _TR000020.Id }, _TR000020);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTR000020(int id, TR000020 _TR000020Edit)
        {
            var _TR000020 = await _context.TR000020.FindAsync(id);
            if (id != _TR000020.Id)
            {
                return BadRequest();
            }

            _TR000020.Nombre = _TR000020Edit.Nombre;
            _TR000020.Monto = _TR000020Edit.Monto;
            _TR000020.Status = _TR000020Edit.Status;

            _context.TR000020.Update(_TR000020);
            _context.Entry(_TR000020).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TR000020Exists(id))
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<TR000020>> DeleteTR000020(int id)
        {
            var _TR000020 = await _context.TR000020.FindAsync(id);

            if (_TR000020 == null)
            {
                return NotFound();
            }

            _context.TR000020.Remove(_TR000020);
            await _context.SaveChangesAsync();

            return _TR000020;
        }

        private bool TR000020Exists(int id)
        {
            return _context.TR000020.Any(e => e.Id == id);
        }
    }
}
