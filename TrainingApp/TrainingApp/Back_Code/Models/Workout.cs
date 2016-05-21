using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp
{
    public enum Estado
    {
        completo = 1,
        incompleto = 2
    }

    public enum Tipo
    {
        emom = 1,
        e2mo2m = 2,
        otm = 3,
        ot2m = 4
    }

    public class Workout
    {
        public Workout()
        {
            Movimientos = new HashSet<WorkoutMovement>();
        }

        public int Id { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [Index]
        [Required]
        public DateTime Fecha { get; set; }

        public int TiempoMaximoMinuto { get; set; }

        public int TiempoMaximoSegundo { get; set; }

        public float? Rx { get; set; }

        public virtual ICollection<WorkoutMovement> Movimientos { get; set; }

    }

    public class WorkoutAmrap : Workout
    {
        public int VueltasCompletas { get; set; }
        public int? RepeticionesExtra { get; set; }
    }

    public class WorkoutPerTime: Workout
    {
        public int Rondas { get; set; }
        public int? TiempoFinalizacionMinuto { get; set; }
        public int? TiempoFinalizacionSegundo { get; set; }

        [NotMapped]
        public Estado WorkoutEstado
        {
            get
            {
                if (TiempoFinalizacionMinuto.HasValue && TiempoFinalizacionSegundo.HasValue)               
                    return Estado.completo;
                 else               
                    return Estado.incompleto;              
            }
            
        }
    }

    public class WorkoutOnMinute: Workout
    {
        public Tipo Tipo { get; set; }
        public int RondasGrupoEjercicio { get; set; }
        public int RondasTotales { get; set; }

    }
}