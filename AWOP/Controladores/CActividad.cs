using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Controladores
{
    public class CActividad: BaseADONet
    {
        public Resultado getActividades()
        {
            List<Actividad> lista = new List<Actividad>();
            String sql = "select id,numeroPregunta,descripcion,id_areaOcupacional from actividad order by numeroPregunta";
            Resultado resultado = ExecuteSql_Select(sql);
            if (!resultado.isCorrecto)
            {
                Console.WriteLine(resultado.Mensaje);
            }
            return resultado;
        } 
    }
}
