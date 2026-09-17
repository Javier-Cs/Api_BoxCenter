using Api_BoxCenter.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            var entities = _boxCenterDbContext.Model
                .GetEntityTypes()
                .Select(x => x.ClrType.Name)
                .ToList();

            var entiTabla = _boxCenterDbContext.Model
                .GetEntityTypes()
                .Select(entity => new
                {
                    Entity = entity.ClrType.Name,
                    Table = entity.GetTableName()
                }).ToList();

            var entiTablawithPk = _boxCenterDbContext.Model
                .GetEntityTypes()
                .Select(entit => new
                {
                    entity = entit.ClrType.Name,
                    tabla = entit.GetTableName(),
                    pk = entit.FindPrimaryKey()!
                        .Properties
                        .Select(property => property.Name)
                        .ToList()
                }).ToList();

            var usuarioEntity = _boxCenterDbContext.Model
                .FindEntityType(typeof(Api_BoxCenter.Domain.Entities.Usuario));

            var foreignKeys = usuarioEntity?
                .GetForeignKeys()
                .Select(fk => new
                {
                    ForeignKey = fk.Properties
                        .Select(x => x.Name)
                        .ToList(),

                    PrincipalEntity = fk.PrincipalEntityType.ClrType.Name,

                    PrincipalKey = fk.PrincipalKey.Properties
                        .Select(x => x.Name)
                        .ToList(),

                    DeleteBehavior = fk.DeleteBehavior.ToString()
                })
                .ToList();



            return Ok(new
            {
                status = "OK",
                service = "BoxCenter API",
                database = databaseEstaConectado
                ? "Conectado"
                : "Desconectado",
                entities,
                entiTabla,
                entiTablawithPk,
                foreignKeys
            });
        }

    }
}
