using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio;
using RetoBCP.Dominio.Interfaces.Repositorios;
using RetoBCP.Aplicacion.Interfaces;

namespace RetoBCP.Aplicacion.Servicios
{
    public class RetoBcpTipoCambioServicio : IServicioBase<BcpTipoCambio, Guid,string>
    {
        private readonly IRepositorioBase<BcpTipoCambio, Guid,string> repoTipoCambio;
        private readonly IRepositorioBase<Tarifa, Guid,string> repoTarifa;

        public RetoBcpTipoCambioServicio(IRepositorioBase<BcpTipoCambio, Guid,string> _repoTipoCambio
            , IRepositorioBase<Tarifa, Guid,string> _repoTarifa)
        {
            repoTipoCambio = _repoTipoCambio;
            repoTarifa = _repoTarifa;
        }

        public BcpTipoCambio Agregar(BcpTipoCambio entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Tipo Cambio es requerida.");
            
            var resultadoTarifa = repoTarifa.SeleccionarPorMoneda(entidad.MonedaOrigen, entidad.MonedaDestino);

            entidad.MontoConvertido = entidad.Monto * resultadoTarifa.TipoCambio;

            var resultadoTipoCambio = repoTipoCambio.Agregar(entidad);

            repoTipoCambio.GuardarTodosLosCambios();

            return resultadoTipoCambio;
        }

        public void Editar(BcpTipoCambio entidad)
        {
            if (entidad == null)
                throw new ArgumentNullException("La Tipo Cambio es requerido para editar");

            repoTipoCambio.Editar(entidad);
            repoTipoCambio.GuardarTodosLosCambios();
        }

        public void Eliminar(Guid entidadId)
        {
            repoTipoCambio.Eliminar(entidadId);
            repoTipoCambio.GuardarTodosLosCambios();
        }

        public List<BcpTipoCambio> Listar()
        {
            return repoTipoCambio.Listar();
        }

        public BcpTipoCambio SeleccionarPorID(Guid entidadId)
        {
            return repoTipoCambio.SeleccionarPorID(entidadId);
        }

        public BcpTipoCambio SeleccionarPorMoneda(string entidadOrigen, string entidadDestino)
        {
            throw new NotImplementedException();
        }
    }
}
