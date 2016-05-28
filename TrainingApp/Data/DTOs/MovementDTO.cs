using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    public class MovementResumenDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public TipoElemento tipo_elemento { get; set; }
        public string descripcion { get; set; }

        public MovementResumenDTO() { }

        public MovementResumenDTO(Movement m)
        {
            this.id = m.Id;
            this.nombre = m.Nombre;
            this.tipo_elemento = m.Elemento;
            this.descripcion = m.Descripcion;
        }
    }

    public class MovementNuevoDTO
    {
        [Required]
        [MaxLength(80)]
        public string nombre { get; set; }

        [Required]
        public TipoElemento tipo_elemento { get; set; }

        public string Descripcion { get; set; }
    }
}
