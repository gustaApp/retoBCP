using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBCP.Dominio.Interfaces
{
	public interface IListar<TEntidad, TEntidadID,TEntidadString>
	{
		List<TEntidad> Listar();

		TEntidad SeleccionarPorID(TEntidadID entidadId);

		TEntidad SeleccionarPorMoneda(TEntidadString entidadOrigen, TEntidadString entidadDestino);
	}
}
