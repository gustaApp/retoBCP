using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using RetoBCP.Dominio.Interfaces.Repositorios;
using RetoBCP.Infraestructura.Datos.Contextos;
using System.Linq;

namespace RetoBCP.Infraestructura.Datos.Repositorios
{
    public class TarifaRepositorio : IRepositorioBase<Tarifa, Guid, string>
    {
        private TarifaContexto db;

        public TarifaRepositorio(TarifaContexto _db) {
            db = _db;
        }
        public Tarifa Agregar(Tarifa entidad)
        {
            entidad.Id = Guid.NewGuid();

            db.Tarifas.Add(entidad);

            return entidad;

        }

        public void Editar(Tarifa entidad)
        {
            var tarifaSeleccionado = db.Tarifas.Where(c => c.Id == entidad.Id).FirstOrDefault();
            if (tarifaSeleccionado != null)
            {
                tarifaSeleccionado.OrigenMoneda = entidad.OrigenMoneda;
                tarifaSeleccionado.DestinoMoneda = entidad.DestinoMoneda;
                tarifaSeleccionado.TipoCambio = entidad.TipoCambio;
                tarifaSeleccionado.FechaModifica = DateTime.Now;
                tarifaSeleccionado.UserModifica = entidad.UserModifica;

                db.Entry(tarifaSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidad)
        {
            var tarifaSeleccionado = db.Tarifas.Where(c => c.Id == entidad).FirstOrDefault();
            if (tarifaSeleccionado != null)
            {
                db.Tarifas.Remove(tarifaSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<Tarifa> Listar()
        {
            return db.Tarifas.ToList();
        }

        public Tarifa SeleccionarPorID(Guid entidadId)
        {
            var tarifaSeleccionado = db.Tarifas.Where(c => c.Id == entidadId).FirstOrDefault();

            return tarifaSeleccionado;
        }

        public Tarifa SeleccionarPorMoneda(string entidadOrigen, string entidadDestino)
        {
            var tarifaSeleccionado = db.Tarifas.Where(c => c.OrigenMoneda == entidadOrigen & c.DestinoMoneda == entidadDestino).FirstOrDefault();
            return tarifaSeleccionado;
        }
    }
}
