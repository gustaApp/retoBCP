using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBCP.Dominio.Interfaces
{
    public interface IEliminar<TEntidadID>
    {
        void Eliminar(TEntidadID entidad);
    }
}
