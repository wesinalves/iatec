using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iatec.Data;
using iatec.Models;
using System.Linq;

namespace iatec.Controllers
{
    [ApiController]
    [Route("v1/events")]
    public class EventController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Event>>> GetEvents([FromServices] DataContext context)
        {
            var events = await context.Events.ToListAsync();
            return events;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Event>> GetEventsById([FromServices] DataContext context, int id)
        {
            var ev = await context.Events.Include(x => x.User)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
            return ev;
        }

        [HttpGet]
        [Route("users/{id:int}")]
        public async Task<ActionResult<List<Event>>> GetEventsByUser([FromServices] DataContext context, int id)
        {
            var events = await context.Events.Include(x => User)
                .Include(x => x.Id == id)
                .AsNoTracking()
                .Where(x => x.UserId == id)
                .ToListAsync();
            return events;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Event>> Post(
            [FromServices] DataContext context,
            [FromBody]Event model)
        {
            if (ModelState.IsValid)
            {
                context.Events.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }

        }
    }
}