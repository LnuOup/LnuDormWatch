using System.Linq;
using LnuDormWatch.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LnuDormWatch.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DormsController : Controller
    {
        readonly ApiContext _context;

        public DormsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = _context.Dorms.ToList();
            return Ok(new {Dorms = model});
        }
        
        [HttpPost]
        public IActionResult Create([FromBody]Dorm model)
        {
            if ( !ModelState.IsValid )
                return BadRequest(ModelState);
            
            _context.Dorms.Add(model);
            _context.SaveChanges();
            
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Dorm model)
        {
            if ( !ModelState.IsValid )
                return BadRequest(ModelState);

            var dormToUpdate = _context.Dorms.Find(id);

            if (dormToUpdate == null)
                return NotFound();

            dormToUpdate.Address = model.Address;
            dormToUpdate.Number = model.Number;
            
            return Ok(dormToUpdate);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var dormToDelete = _context.Dorms.Find(id);

            if (dormToDelete == null)
                return NotFound();

            _context.Dorms.Remove(dormToDelete);
            _context.SaveChanges();
            
            return Ok(dormToDelete);
        }
    }
}