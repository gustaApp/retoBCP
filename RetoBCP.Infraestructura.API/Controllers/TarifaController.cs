using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using RetoBCP.Dominio;
using RetoBCP.Aplicacion.Servicios;
using RetoBCP.Infraestructura.Datos.Contextos;
using RetoBCP.Infraestructura.Datos.Repositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RetoBCP.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarifaController : ControllerBase
    {
        TarifaServicio CrearServicio()
        {
            TarifaContexto db = new TarifaContexto();
            TarifaRepositorio repo = new TarifaRepositorio(db);
            TarifaServicio servicio = new TarifaServicio(repo);
            return servicio;
        }

        // GET: api/<TarifaController>
        [HttpGet]
        public ActionResult<List<Tarifa>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<TarifaController>/5
        [HttpGet("{id}")]
        public ActionResult<Tarifa> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<TarifaController>
        [HttpPost]
        public ActionResult Post([FromBody] Tarifa tarifa)
        {
            var servicio = CrearServicio();
            servicio.Agregar(tarifa);
            return Ok("Ingresado Correctamente");

        }

        // PUT api/<TarifaController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Tarifa tarifa)
        {
            var servicio = CrearServicio();
            tarifa.Id = id;
            servicio.Editar(tarifa);
            return Ok("Editado Correctamente");
        }

        // DELETE api/<TarifaController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }

        [HttpGet("tipoCambio")]
        public ActionResult GetParameter( string entidadOrigen, string entidadDestino) {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorMoneda(entidadOrigen,entidadDestino));
        }
    }
}
