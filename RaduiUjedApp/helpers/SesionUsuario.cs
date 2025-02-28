using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaduiUjedApp.helpers
{
    public static class SesionUsuario
    {
        public static int Id { get; set; }
        public static string Nombre { get; set; }
        public static string Paterno { get; set; }
        public static string Materno { get; set; }
        public static int Rol { get; set; }
        public static string Usuario { get; set; }

        public static void CerrarSesion()
        {
            Id = 0;
            Nombre = null;
            Paterno = null;
            Materno = null;
            Rol = 0;
            Usuario = null;
        }
    }
}
