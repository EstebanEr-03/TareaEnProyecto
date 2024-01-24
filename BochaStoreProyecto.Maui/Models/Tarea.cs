using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BochaStoreProyecto.Maui.Models
{
    public class Tarea
    {
        public int idTarea { get; set; }
        public string nombreTarea { get; set; }
        public string descripcionTarea { get; set; }
        public string estadoTarea { get; set; }
    }
}
