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
        ketllebell = 2,
        pelota = 3,
        soga = 4,
        libre = 5,
    }

    public class Movement
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Nombre { get; set; }

        public TipoElemento Elemento { get; set; }

        [MaxLength(255)]
        public string Descripcion { get; set; }

    }
}