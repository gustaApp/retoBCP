using System;
using System.Collections.Generic;
using System.Text;

namespace RetoBCP.Dominio
{
    public class BcpTipoCambio
    {
        public Guid Id { get; set; }

        //public Guid TarifaId { get; set; }
        public double Monto { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double MontoConvertido { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public string UserIngreso { get; set; }
        public DateTime? FechaModifica { get; set; }
        public string UserModifica { get; set; }

    }
}
