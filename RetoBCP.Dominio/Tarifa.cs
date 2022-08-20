using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBCP.Dominio
{
    public class Tarifa
    {
        public Guid Id { get; set; }

        public string OrigenMoneda { get; set; }

        public string DestinoMoneda { get; set; }
        public double TipoCambio { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string UserIngreso { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string UserModifica { get; set; }
    }
}
