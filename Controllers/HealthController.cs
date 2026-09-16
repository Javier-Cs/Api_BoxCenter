using Api_BoxCenter.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;

namespace Api_BoxCenter.Controllers
{
    [ApiController]
    [Route("api/v1/health")]
    public class HealthController : ControllerBase 
    {
        private readonly BoxCenterDbContext _boxCenterDbContext;

        // inyeccion de dependencia 
        public HealthController(BoxCenterDbContext boxCenterDbContext) {
            _boxCenterDbContext = boxCenterDbContext;
        }


        // controlador
        [HttpGet]
        public async Task<IActionResult> Get() {

            // comprobamos la conecion a la base de datos 
            var databaseEstaConectado = await _boxCenterDbContext.Database.CanConnectAsync();

            return Ok(new
            {
                status = "OK",
                service = "BoxCenter API",
                database = databaseEstaConectado
                ? "Conectado"
                : "Desconectado"
            });
        }

    }
}
