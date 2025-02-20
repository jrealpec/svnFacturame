using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using com.svnFacturame.cloud.domain.Entities.Menu;
using com.svnFacturame.cloud.domain.Wrappers;
using com.svnFacturame.cloud.infraestructura.persistence.Data;

using MediatR;
using Microsoft.Extensions.Configuration;

namespace com.svnFacturame.cloud.Api.Controllers.Menu
{
    [Route("api/[controller]")]
    [ApiController]
    public class TS000001Controller : ControllerBase
    {
        private readonly asaCloud_Context _context;
        public IConfigurationRoot configuration;
        public TS000001Controller(asaCloud_Context context)
        {
            _context = context;
        }
        //GET, BANCOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TS000001>>> GetTS000001()
        {
            return await _context.TS000001.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TS000001>> GetTS000001(int id)
        {
            var _TS000001 = await _context.TS000001.FindAsync(id);

            if (_TS000001 == null)
            {
                return NotFound();
            }

            return _TS000001;
        }
        //[HttpGet("GetSubMenuByIdCodPadre")]
        //public async Task<ActionResult<TS000001>> GetSubMenuByIdCodPadre(int Id)
        //{
        //    TS000001 menuHijos = await _context.TS000001.Select(
        //            s => new TS000001
        //            {
        //                Id = s.Id,
        //                FirstName = s.FirstName,
        //                LastName = s.LastName,
        //                Username = s.Username,
        //                Password = s.Password,
        //                EnrollmentDate = s.EnrollmentDate
        //            })
        //        .FirstOrDefaultAsync(s => s.Id == Id);
        //    if (User == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return User;
        //    }
        //}
        [HttpGet("GetTS000001CodNPadre")]
        public async Task<List<TS000001>> GetTS000001CodNPadre(int CodNPadre)
        {
            var _TS000001 = await _context.TS000001.Where(x => x.Cod_NPadre == CodNPadre).ToListAsync();

            if (_TS000001 == null)
            {
                return null;
            }

            return _TS000001;
        }
        [HttpGet("GetTS000001Padre")]
        public async Task<List<TS000001>> GetTS000001Padre(int CodNPadre)
        {
            var _TS000001 = await _context.TS000001.Where(x => x.Cod_NPadre == CodNPadre).ToListAsync();

            if (_TS000001 == null)
            {
                return null;
            }

            return _TS000001;
        }
    }
}