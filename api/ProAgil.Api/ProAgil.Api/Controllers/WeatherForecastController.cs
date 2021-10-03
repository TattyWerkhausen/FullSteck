using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Repository.Data;

namespace ProAgil.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ProAgilContext _context;

        public WeatherForecastController(ProAgilContext context )
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
           

        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id){
            try
            {
                var results = await _context.Eventos.FirstOrDefaultAsync(x =>x.Id == id);
                return Ok(results);
            }
            catch (System.Exception)
            {
                
               return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de dados falhou");
            }
        }
    }
}
