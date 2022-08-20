using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio.Interfaces;

namespace RetoBCP.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBcpTipoCambio<TEntidad,TEntidadID, TEntidadString>
        : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID, TEntidadString>,ITransaccion
    {
    }
}
