using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio.Interfaces;

namespace RetoBCP.Aplicacion.Interfaces
{
    public interface IServicioBcpTipoCambio<TEntidad, TEntidadID, TEntidadString>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID, TEntidadString>
    {
    }
}
