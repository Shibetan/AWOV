using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Entidades
{
    /// <summary>
    /// Clase que contiene los resultados que retorna una transacción en la Base de Datos,
    /// además de los mensajes de errores que produce.
    /// </summary>
    public class Resultado
    {
        public int FilasAfectadas { get; set; }
        public bool isCorrecto { get; set; }
        public string Mensaje { get; set; }
        public DataTable Tabla { get; set; }
        public int Id { get; set; }
    }
}