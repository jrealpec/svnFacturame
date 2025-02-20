using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Empresas;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;
using com.svnFacturame.cloud.domain.Entities.Ciudades;

namespace com.svnFacturame.cloud.Api.Controllers.Empresas
{
    [Route("api/[controller]")]
    [ApiController]
    public class TG000003Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;

        public TG000003Controller(asaCloud_Context context)
        {
            _context = context;
        }

        //GET, EMPRESAS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TG000003>>> GetTG000003()
        {
            return await _context.TG000003.ToListAsync();
        }

        // GET: EMPRESAS/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TG000003>> GetTG000003(int id)
        {
            var _TG000003 = await _context.TG000003.FindAsync(id);

            if (_TG000003 == null)
            {
                return NotFound();
            }

            return _TG000003;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutTG000003(int id, TG000003 _TG000003Edit)
        {
            var _TG000003 = await _context.TG000003.FindAsync(id);
            if (id != _TG000003.Id)
            {
                return BadRequest();
            }

            _TG000003.IdDeptoEmpAdm = _TG000003Edit.IdDeptoEmpAdm;
            _TG000003.Name = _TG000003Edit.Name;
            _TG000003.SiglasEmpresa = _TG000003Edit.SiglasEmpresa;
            _TG000003.DireccionEmpresa = _TG000003Edit.DireccionEmpresa;


            _context.TG000003.Update(_TG000003);
            _context.Entry(_TG000003).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TG000003Exists(id))
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

        private bool TG000003Exists(int id)
        {
            return _context.TG000003.Any(e => e.Id == id);
        }
    }
}
