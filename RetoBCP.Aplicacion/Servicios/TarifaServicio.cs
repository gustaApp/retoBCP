using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using RetoBCP.Dominio.Interfaces.Repositorios;
using RetoBCP.Aplicacion.Interfaces;

namespace RetoBCP.Aplicacion.Servicios
{
    public class TarifaServicio : IServicioBase<Tarifa, Guid, string>
    {
        private readonly IRepositorioBase<Tarifa, Guid, string> repoTarifa;

        public TarifaServicio(IRepositorioBase<Tarifa, Guid, string> _repoTarifa) {
            repoTarifa = _repoTarifa;
        }
        public Tarifa Agregar(Tarifa entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Tarifa es requerida.");
            var resultadoTarifa = repoTarifa.Agregar(entidad);
            repoTarifa.GuardarTodosLosCambios();

            return resultadoTarifa;

        }

        public void Editar(Tarifa entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Tarifa es requerido para editar");

            repoTarifa.Editar(entidad);
            repoTarifa.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoTarifa.Eliminar(entidadId);
            repoTarifa.GuardarTodosLosCambios();
        }

        public List<Tarifa> Listar()
        {
            return repoTarifa.Listar();
        }

        public Tarifa SeleccionarPorID(Guid entidadId)
        {
            return repoTarifa.SeleccionarPorID(entidadId);
        }

        public Tarifa SeleccionarPorMoneda(string entidadOrigen, string entidadDestino)
        {
            return repoTarifa.SeleccionarPorMoneda(entidadOrigen, entidadDestino);
        }
    }
}
