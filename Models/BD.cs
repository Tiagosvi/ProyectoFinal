using System;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;
using ProyectoFinal.Models;

namespace ProyectoFinal.Models
{
    public static class BD
    {
        private static string _ConnectionString = @"Server=A-CIDI-104;Database=BaseProyecto;Trusted_Connection=True;";
        private static string sql="";


/*Select E1.Nombre AS Equipo1, P.Goles1, E2.Nombre AS Equipo2, P.Goles2  From Partidos P 
Inner Join Equipos E1 on P.IdEquipo1 = E1.IdEquipo
Inner Join Equipos E2 on P.IdEquipo2 = E2.IdEquipo
inner join Fechas F on P.IdFecha = F.IdFecha
Where F.Fecha = 1 AND F.IdLiga = 1
 */

public static List<ResultadosModel> ListarResultados()
        {
            List<ResultadosModel> Lista = null;
            using(SqlConnection db = new SqlConnection(_ConnectionString))
            {
                    sql = "Select E1.Nombre AS Equipo1, P.Goles1, E2.Nombre AS Equipo2, P.Goles2 From Partidos P "+
                    "Inner Join Equipos E1 on P.IdEquipo1 = E1.IdEquipo "+
                    "Inner Join Equipos E2 on P.IdEquipo2 = E2.IdEquipo "+
                    "Inner join Fechas F on P.IdFecha = F.IdFecha "+
                    "Where F.Fecha = 1 AND F.IdLiga = 1";
                    Lista = db.Query<ResultadosModel>(sql).ToList();
            }
            return Lista;
        }




    public static List<ResultadosModel> ListarResultadosXFecha(int fecha)
        {
            List<ResultadosModel> Lista = null;
            using(SqlConnection db = new SqlConnection(_ConnectionString))
            {
                    sql = "Select E1.Nombre AS Equipo1, P.Goles1, E2.Nombre AS Equipo2, P.Goles2 From Partidos P "+
                    "Inner Join Equipos E1 on P.IdEquipo1 = E1.IdEquipo "+
                    "Inner Join Equipos E2 on P.IdEquipo2 = E2.IdEquipo "+
                    "Inner join Fechas F on P.IdFecha = F.IdFecha "+
                    "Where F.Fecha ="+ fecha +"AND F.IdLiga = 1";
                    Lista = db.Query<ResultadosModel>(sql).ToList();
            }
            return Lista;
        }

}
}