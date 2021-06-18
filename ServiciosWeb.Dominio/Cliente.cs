using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiciosWeb.Dominio
{
    public class Cliente
    {
        public int IdTrabajador { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaNac { get; set; }

    }
}
