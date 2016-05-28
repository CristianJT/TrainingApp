using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public enum TipoElemento
    {
        barra = 1,
        barra_dominadas = 2,
        ketllebell = 3,
        pelota = 5,
        soga = 7,
        libre = 9,
        anillas = 10,
        cajon = 11
    }

    public class Movement
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        [Required]
        public TipoElemento Elemento { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

        public virtual ICollection<WorkoutMovement> Wods { get; set; }

    }
}