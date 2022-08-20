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
    public class BcpTipoCambioController : ControllerBase
    {
        RetoBcpTipoCambioServicio CrearServicio()
        {
            TarifaContexto db = new TarifaContexto();
            BcpTipoCambioRepositorio repo = new BcpTipoCambioRepositorio(db);
            TarifaRepositorio repoT = new TarifaRepositorio(db);
            RetoBcpTipoCambioServicio servicio = new RetoBcpTipoCambioServicio(repo, repoT);
            return servicio;
        }

        // GET: api/<BcpTipoCambioController>
        [HttpGet]
        public ActionResult<List<BcpTipoCambio>>  Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<BcpTipoCambioController>/5
        [HttpGet("{id}")]
        public ActionResult<BcpTipoCambio> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<BcpTipoCambioController>
        [HttpPost]
        public ActionResult Post([FromBody] BcpTipoCambio tipoCambio)
        {
            var servicio = CrearServicio();
            servicio.Agregar(tipoCambio);
            return Ok("Ingresado Correctamente");
        }

        // PUT api/<BcpTipoCambioController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] BcpTipoCambio tipoCambio)
        {
            var servicio = CrearServicio();
            tipoCambio.Id = id;
            servicio.Editar(tipoCambio);
            return Ok("Editado Correctamente");
        }

        // DELETE api/<BcpTipoCambioController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado Correctamente");
        }
    }
}
