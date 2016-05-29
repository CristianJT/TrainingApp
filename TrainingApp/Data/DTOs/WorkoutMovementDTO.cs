using System;
using System.ComponentModel.DataAnnotations;

namespace TrainingApp
{
    public class WorkoutMovementResumenDTO
    {
        public DateTime wod_fecha { get; set; }
        public int repeticiones { get; set; }
        public float? peso { get; set; }
        public float? peso_alternativo { get; set; }
        public decimal? distancia { get; set; }
        public decimal? altura { get; set; }
        public bool restriccion { get; set; }
        public string restriccion_tipo { get; set; }
        public bool adaptacion { get; set; }
        public string adaptacion_tipo { get; set; }
        public bool unbroken { get; set; }
        public string detalle { get; set; }
        public bool completo { get; set; }

        public WorkoutMovementResumenDTO() { }

        public WorkoutMovementResumenDTO(WorkoutMovement wm)
        {
            this.wod_fecha = wm.Workout.Fecha;
            this.repeticiones = wm.Repeticiones;
            this.peso = wm.PesoEjecutado;
            this.peso_alternativo = wm.PesoAlternativo;
            this.distancia = wm.Distancia;
            this.altura = wm.Altura;
            this.restriccion = wm.Restriccion;
            this.restriccion_tipo = wm.RestriccionTipo;
            this.adaptacion = wm.Adaptacion;
            this.adaptacion_tipo = wm.AdaptacionTipo;
            this.unbroken = wm.Unbroken;
            this.detalle = wm.Detalle;        
            this.completo = wm.Completo;
        }
    }

    public class WorkoutMovementDTO : WorkoutMovementResumenDTO
    {
        public string movimiento { get; set; }
        public string movimiento_alternativo { get; set; }
        public int? numero_ronda { get; set; }
        public int? numero_minuto { get; set; }

        public WorkoutMovementDTO() { }

        public WorkoutMovementDTO(WorkoutMovement wm)
        {
            this.wod_fecha = wm.Workout.Fecha;
            this.movimiento = wm.Movement.Nombre;
            this.movimiento_alternativo = wm.MovimientoAlternativo;
            this.repeticiones = wm.Repeticiones;
            this.numero_ronda = wm.RondaNumero;
            this.numero_minuto = wm.MinutoNumero;
            this.peso = wm.PesoEjecutado;
            this.peso_alternativo = wm.PesoAlternativo;
            this.distancia = wm.Distancia;
            this.altura = wm.Altura;
            this.restriccion = wm.Restriccion;
            this.restriccion_tipo = wm.RestriccionTipo;
            this.adaptacion = wm.Adaptacion;
            this.adaptacion_tipo = wm.AdaptacionTipo;
            this.unbroken = wm.Unbroken;
            this.detalle = wm.Detalle;
            this.completo = wm.Completo;
        }
    }

    public class WorkoutMovementNuevoDTO
    {
        [Required]
        public int movimiento_id { get; set; }

        [Required]
        public int repeticiones { get; set; }

        public string movimiento_alternativo { get; set; }
        public float? peso { get; set; }
        public float? peso_alternativo { get; set; }
        public decimal? distancia { get; set; }
        public decimal? altura { get; set; }
        public bool restriccion { get; set; }
        public string restriccion_tipo { get; set; }
        public bool adaptacion { get; set; }
        public string adaptacion_tipo { get; set; }
        public bool unbroken { get; set; }
        public string detalle { get; set; }
        public int? ronda { get; set; }
        public int? minuto { get; set; }
        public bool completo { get; set; }
    }
}
