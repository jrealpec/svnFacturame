using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Bancos;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;

namespace com.svnFacturame.cloud.Api.Controllers.Bancos
{
    [Route("api/[controller]")]
    [ApiController]
    public class TG000001Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;

        public TG000001Controller(asaCloud_Context context)
        {
            _context = context;
        }
        //GET, BANCOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TG000001>>> GetTG000001()
        {
            return await _context.TG000001.ToListAsync();
        }

        // GET: BANCOS/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TG000001>> GetTG000001(int id)
        {
            var _TG000001 = await _context.TG000001.FindAsync(id);

            if (_TG000001 == null)
            {
                return NotFound();
            }
            
            return _TG000001;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTG000001 (int id, TG000001 _tg000001Edit)
        {
            var _tg000001 = await _context.TG000001.FindAsync(id);
            if (id != _tg000001.Id)
            {
                return BadRequest();
            }

            _tg000001.Name = _tg000001Edit.Name;
            _tg000001.Status = _tg000001Edit.Status;
            _tg000001.Visible = _tg000001Edit.Visible;

            _context.TG000001.Update(_tg000001);
            _context.Entry(_tg000001).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }catch (DbUpdateConcurrencyException) { 
                if (!tg000001Exists(id))
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
        public async Task<ActionResult<TG000001>> PostTG000001(TG000001 _tg000001)
        {
            _context.TG000001.Add(_tg000001);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTG000001", new { id = _tg000001.CodBanco }, _tg000001);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TG000001>> DeleteTG000001(int id)
        {
            var _tg000001 = await _context.TG000001.FindAsync(id);

            if (_tg000001 == null)
            {
                return NotFound();
            }

            _context.TG000001.Remove(_tg000001);
            await _context.SaveChangesAsync();

            return _tg000001;
        }

        private bool tg000001Exists(int id)
        {
            return _context.TG000001.Any(e => e.Id == id);
        }
    }
}
