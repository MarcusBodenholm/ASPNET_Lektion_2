using Infrastructure.Contexts;
using Infrastructure.Factories;
using Infrastructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeModel model)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(model);
            var check = await _context.Subscribers.AnyAsync(s => s.Email == model.Email);
            if (check == true) return Conflict();
            try
            {
                var entity = SubscribeFactory.Create(model);
                _context.Subscribers.Add(entity);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(SubscribeModel model)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(model);
            try
            {
                var entity = _context.Subscribers.FirstOrDefault(s => s.Email == model.Email);
                if (entity == null) return NotFound("Subscriber not found");
                entity = SubscribeFactory.Update(entity, model);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return Problem();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Unsubscribe(string email)
        {
            if (!ModelState.IsValid) return UnprocessableEntity(email);
            try
            {
                var entity = await _context.Subscribers.FirstOrDefaultAsync(s => s.Email == email);
                if (entity == null) return NotFound("Email not subscribed");
                _context.Subscribers.Remove(entity);
                await _context.SaveChangesAsync();
                return Ok();

            }
            catch
            {
                return Problem();
            }
        }
    }
}
