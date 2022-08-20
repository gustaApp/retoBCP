using System;
using RetoBCP.Infraestructura.Datos.Contextos;

namespace RetoBCP.Infraestructura.Datos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creando la DB si no existe...");
            TarifaContexto db = new TarifaContexto();
            db.Database.EnsureCreated();
            Console.WriteLine("Listo!!!!!");
            Console.ReadKey();
        }
    }
}
