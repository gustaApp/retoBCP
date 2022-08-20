using System;
using System.Collections.Generic;
using System.Text;
using RetoBCP.Dominio.Interfaces;
namespace RetoBCP.Dominio.Interfaces.Repositorios
{
	public interface IRepositorioBase<TEntidad, TEntidadID, TEntidadString>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID, TEntidadString>, ITransaccion
	{
	}
}
