using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//importing
using apiprueba.Data;
using apiprueba.Models;

//migrations...
/*
    /*
     * 
     * to use Dbcontext you need to install EntityFrameworkCore
     * you need to install entity framework core design for migrations
     * and install entity framework core sql to manage the db
     * 
     * to install entity ef dotnet  tool install --global dotnet-ef
     * 
     * dotnet ef migrations add name to genete the migrations file
     * 
     * dotnet ef database update to create the data base
*/



namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasRequest : ControllerBase
    {
        //only readonly
        public readonly ApiContext _context;

        public NotasRequest(ApiContext context)
        {
            _context = context;
        }

        //it is posible
        [HttpGet]
        public async Task<ActionResult<Notas>> GetNotas()
        {
            try
            {
                //optional
                var results = await _context.Notas.ToListAsync();
                return Ok(results);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //it is posible
        [HttpGet("{id}")]//accept this parameter.
        public async Task<ActionResult<NotasRequest>> GetNotasById(int id)
        {
            try
            {
                var results = await _context.Notas.FindAsync(id);

                if(results == null)
                {
                    return NotFound();
                }

                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //it is posible
        [HttpPost]//accept this parameter.
        public async Task<ActionResult<List<NotasRequest>>> PostNotas(Notas request)
        {
            try
            {
                _context.Notas.Add(request);
                await _context.SaveChangesAsync();

                return Ok(await _context.Notas.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //it is posible
        [HttpPut("{id}")]//accept this parameter.
        public async Task<ActionResult<List<NotasRequest>>> PutNotas(Notas request)
        {
            try
            {
                var results = await _context.Notas.FindAsync(request.Id);
            
                if(results == null)
                {
                    return NotFound();
                }

                results.Author = request.Author;
                results.Email = request.Email;
                results.Description = request.Description;


                await _context.SaveChangesAsync();

                return Ok(await _context.Notas.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //it is posible
        [HttpDelete("{id}")]//accept this parameter.
        public async Task<ActionResult<List<NotasRequest>>> DeleteNotas(Notas request)
        {
            try
            {
                var results = await _context.Notas.FindAsync(request.Id);

                if (results == null)
                {
                    return NotFound();
                }

                _context.Notas.Remove(results);
                await _context.SaveChangesAsync();

                return Ok(await _context.Notas.ToListAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
