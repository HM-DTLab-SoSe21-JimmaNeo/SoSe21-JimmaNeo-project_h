using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SEIIApp.Server.Data;
using SEIIApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEIIApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProfilController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var prof = await _context.Profile.ToListAsync();
            return Ok(prof);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var prof = await _context.Profile.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(prof);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Profil profil)
        {
            _context.Add(profil);
            await _context.SaveChangesAsync();
            return Ok(profil.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Profil profil)
        {
            _context.Entry(profil).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var prof = new Profil { Id = id };
            _context.Remove(prof);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
