using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using RetoBCP.Dominio.Interfaces.Repositorios;
using RetoBCP.Infraestructura.Datos.Contextos;
using System.Linq;

namespace RetoBCP.Infraestructura.Datos.Repositorios
{
    public class BcpTipoCambioRepositorio : IRepositorioBase<BcpTipoCambio, Guid, string>
    {
        private TarifaContexto db;

        public BcpTipoCambioRepositorio(TarifaContexto _db)
        {
            db = _db;
        }
        public BcpTipoCambio Agregar(BcpTipoCambio entidad)
        {
            entidad.Id = Guid.NewGuid();

            db.BcpTipoCambios.Add(entidad);

            return entidad;
        }

        public void Editar(BcpTipoCambio entidad)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Guid entidad)
        {
            var TipoCambioSeleccionado = db.BcpTipoCambios.Where(c => c.Id == entidad).FirstOrDefault();
            if (TipoCambioSeleccionado != null)
            {
                db.BcpTipoCambios.Remove(TipoCambioSeleccionado);
            }
        }

        public void GuardarTodosLosCambios()
        {
            db.SaveChanges();
        }

        public List<BcpTipoCambio> Listar()
        {
            return db.BcpTipoCambios.ToList();
        }

        public BcpTipoCambio SeleccionarPorID(Guid entidadId)
        {
            var tarifaSeleccionado = db.BcpTipoCambios.Where(c => c.Id == entidadId).FirstOrDefault();

            return tarifaSeleccionado;
        }

        public BcpTipoCambio SeleccionarPorMoneda(string entidadOrigen, string entidadDestino)
        {
            throw new NotImplementedException();
        }
    }
}
