using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDanielMolina.Models
{
    public partial class Transaccion
    {
        public int IdTransaccion { get; set; }
        public int? IdCliente { get; set; }
        public decimal? Saldo { get; set; }
        public int? TipoTransaccion { get; set; }
        public int? IdCuenta { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
