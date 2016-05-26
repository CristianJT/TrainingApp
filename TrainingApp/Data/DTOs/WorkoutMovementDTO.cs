using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    public class WorkoutMovementDTO
    {
        public string movimiento { get; set; }
        public int repeticiones { get; set; }

        public float? peso { get; set; }
        public float? peso_alternativo { get; set; }
        public decimal? distancia { get; set; }
        public decimal? altura { get; set; }

        public bool restriccion { get; set; }
        public string restriccion_tipo { get; set; }
        public bool adaptacion { get; set; }
        public string adaptacion_tipo { get; set; }

        public int? ronda { get; set; }
        public int? minuto { get; set; }
        public bool completo { get; set; }

        public WorkoutMovementDTO() { }

        public WorkoutMovementDTO(WorkoutMovement wm)
        {
            this.movimiento = wm.Movement.Nombre;
            this.repeticiones = wm.Repeticiones;
            this.peso = wm.PesoEjecutado;
            this.peso_alternativo = wm.PesoAlternativo;
            this.distancia = wm.Distancia;
            this.altura = wm.Altura;
            this.restriccion = wm.Restriccion;
            this.restriccion_tipo = wm.RestriccionTipo;
            this.adaptacion = wm.Adaptacion;
            this.adaptacion_tipo = wm.AdaptacionTipo;
            this.ronda = wm.RondaNumero;
            this.minuto = wm.MinutoNumero;
            this.completo = wm.Completo;
        }
    }

    public class WorkoutMovementNuevoDTO
    {
        [Required]
        public int movimiento_id { get; set; }

        [Required]
        public int repeticiones { get; set; }

        public float? peso { get; set; }
        public float? peso_alternativo { get; set; }
        public decimal? distancia { get; set; }
        public decimal? altura { get; set; }

        public bool restriccion { get; set; }
        public string restriccion_tipo { get; set; }
        public bool adaptacion { get; set; }
        public string adaptacion_tipo { get; set; }

        public int? ronda { get; set; }
        public int? minuto { get; set; }
        public bool completo { get; set; }
    }
}
