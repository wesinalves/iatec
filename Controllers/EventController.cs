using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using iatec.Data;
using iatec.Models;

namespace iatec.Controllers
{
    [ApiController]
    [Route("v1/events")]
    public class EventController: ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Event>>> Get([FromServices] DataContext context)
        {
            var events = await context.Events.ToListAsync();
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