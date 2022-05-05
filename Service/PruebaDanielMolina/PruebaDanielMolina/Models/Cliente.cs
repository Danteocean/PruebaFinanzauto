using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaDanielMolina.Models
{
    public partial class Cliente
    {
    
        public int IdCliente { get; set; }
        public int? TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string RazonSocial { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public string Municipio { get; set; }
        public string Departamento { get; set; }
    }
}
