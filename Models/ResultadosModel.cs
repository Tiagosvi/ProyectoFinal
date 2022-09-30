using System;

namespace ProyectoFinal.Models
{
    public class ResultadosModel
    {
         private int? _IdFecha;
        private string _Equipo1;
        private string _Equipo2;
        private int _Goles1;
        private int _Goles2;
        private string _UrlImagenEquipo1;
        private string _UrlImagenEquipo2;
       
        public int? IdFecha { get { return _IdFecha;} set {_IdFecha = value;} }
        public string Equipo1 { get { return _Equipo1;} set {_Equipo1 = value;} }
        public string Equipo2 { get { return _Equipo2;} set {_Equipo2 = value;}}
        public int Goles1 { get { return _Goles1;} set {_Goles1 = value;} }
        public int Goles2 { get { return _Goles2;} set {_Goles2 = value;} }
        public string UrlImagenEquipo1 { get { return _UrlImagenEquipo1;} set {_UrlImagenEquipo1 = value;} }
        public string UrlImagenEquipo2 { get { return _UrlImagenEquipo2;} set {_UrlImagenEquipo2 = value;} }

        
        
 public ResultadosModel()       
        {

        }

        public ResultadosModel(int IdFecha, string Equipo1, string Equipo2, int Goles1, int Goles2, string UrlImagenEquipo1, string UrlImagenEquipo2)
        {
            _IdFecha = IdFecha;
            _Equipo1 = Equipo1;
            _Equipo2 = Equipo2;
            _Goles1 = Goles1;
            _Goles2 = Goles2;
            _UrlImagenEquipo1 = UrlImagenEquipo1;
            _UrlImagenEquipo2 = UrlImagenEquipo2;
        }

         public ResultadosModel(int IdFecha, string Equipo1, string Equipo2, int Goles1, int Goles2)
        {
            _IdFecha = IdFecha;
            _Equipo1 = Equipo1;
            _Equipo2 = Equipo2;
            _Goles1 = Goles1;
            _Goles2 = Goles2;
        }
    }
}