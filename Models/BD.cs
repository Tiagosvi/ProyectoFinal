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
        private static string _ConnectionString = @"Server=A-CIDI-105;Database=BaseProyecto;Trusted_Connection=True;";
        private static string sql="";


/*Select E1.Nombre AS Equipo1, P.Goles1, E2.Nombre AS Equipo2, P.Goles2  From Partidos P 
Inner Join Equipos E1 on P.IdEquipo1 = E1.IdEquipo
Inner Join Equipos E2 on P.IdEquipo2 = E2.IdEquipo
inner join Fechas F on P.IdFecha = F.IdFecha
Where F.Fecha = 1 AND F.IdLiga = 1
 */


 public static List<FechasModel> ListarFechas(int idLiga)
{
    List<FechasModel> ListaFec = null;
    using(SqlConnection db = new SqlConnection(_ConnectionString))
    {
        sql = "SELECT * FROM Fechas Where idLiga=@pIdLiga";
        ListaFec = db.Query<FechasModel>(sql, new { pIdLiga = idLiga }).ToList();
    }
    return ListaFec;
}

 public static List<LigasModel> ListarLigas()
{
    List<LigasModel> Lista = null;
    using(SqlConnection db = new SqlConnection(_ConnectionString))
    {
        sql = "SELECT * FROM Ligas";
        Lista = db.Query<LigasModel>(sql).ToList();
    }
    return Lista;
}

  public static  List<ResultadosModel> ListaResultados(int IdLiga, int IdFecha ){
            ResultadosModel Resultados = null;
            using(SqlConnection db = new SqlConnection(_connectionString)){
                string sql="SELECT * from productos WHERE IdLiga = @pIdLiga && IdFecha =@pIdFecha";
                Resultados = db.QueryFirstOrDefault<ResultadosModel>(sql, new{pIdLiga = IdLiga, pIdFecha = IdFecha});
            }
            return Resultados;

        }
    }
}


/*
public static List<ResultadosModel> ListarResultados()
        {
            List<ResultadosModel> Lista = null;
            using(SqlConnection db = new SqlConnection(_ConnectionString))
            {
                    sql = 
                    Lista = db.Query<ResultadosModel>(sql).ToList();
            }
            return Lista;
        }






/*
"Select E1.Nombre AS Equipo1, P.Goles1, E2.Nombre AS Equipo2, P.Goles2 From Partidos P "+
                    "Inner Join Equipos E1 on P.IdEquipo1 = E1.IdEquipo "+
                    "Inner Join Equipos E2 on P.IdEquipo2 = E2.IdEquipo "+
                    "Inner join Fechas F on P.IdFecha = F.IdFecha "+
                    "Where F.Fecha = 1 AND F.IdLiga = 1";*/