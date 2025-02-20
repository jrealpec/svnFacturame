using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Ciudades;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;

namespace com.svnFacturame.cloud.Api.Controllers.Ciudades
{
    [Route("api/[controller]")]
    [ApiController]
    public class TG000002Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;

        public TG000002Controller(asaCloud_Context context)
        {
            _context = context;
        }
        //GET, BANCOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TG000002>>> GetTG000002()
        {
            return await _context.TG000002.Include(o => o._TG000004).ToListAsync();
        }

        // GET: BANCOS/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TG000002>> GetTG000002(int id)
        {
            var _TG000002 = await _context.TG000002.FindAsync(id);

            if (_TG000002 == null)
            {
                return NotFound();
            }
            
            return _TG000002;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTG000002 (int id, TG000002 _TG000002Edit)
        {
            var _TG000002 = await _context.TG000002.FindAsync(id);
            if (id != _TG000002.Id)
            {
                return BadRequest();
            }

            _TG000002.Name = _TG000002Edit.Name;
            _TG000002.IdDeptoCiud = _TG000002Edit.IdDeptoCiud;
            _TG000002.Status = _TG000002Edit.Status;
            _TG000002.Visible = _TG000002Edit.Visible;
            _TG000002.UpdateDate = _TG000002Edit.UpdateDate;

            _context.TG000002.Update(_TG000002);
            _context.Entry(_TG000002).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException) { 
                if (!TG000002Exists(id))
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
        public async Task<ActionResult<TG000002>> PostTG000002(TG000002 _TG000002)
        {
            _context.TG000002.Add(_TG000002);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTG000002", new { id = _TG000002.CodCiudad }, _TG000002);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TG000002>> DeleteTG000002(int id)
        {
            var _TG000002 = await _context.TG000002.FindAsync(id);

            if (_TG000002 == null)
            {
                return NotFound();
            }

            _context.TG000002.Remove(_TG000002);
            await _context.SaveChangesAsync();

            return _TG000002;
        }

        private bool TG000002Exists(int id)
        {
            return _context.TG000002.Any(e => e.Id == id);
        }
    }
}
