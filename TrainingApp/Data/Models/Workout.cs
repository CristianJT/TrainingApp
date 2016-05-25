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
        amrap = 1,
        rounds_per_time = 2,
        chipper = 3,
        emom = 4,
        e2mo2m = 5,
        otm = 6,
        ot2m = 7
    }

    public class Workout
    {
        public Workout()
        {
            Movimientos = new HashSet<WorkoutMovement>();
        }

        public int Id { get; set; }

        [Required]
        public Tipo Tipo { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [Index]
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int TiempoMaximoMinuto { get; set; }

        [Required]
        public int TiempoMaximoSegundo { get; set; }

        public float? Rx { get; set; }

        public int? Rondas { get; set; }

        //AMRAP
        public int? VueltasCompletas { get; set; }
        public int? RepeticionesExtra { get; set; }

        //ON MINUTE
        public int? RondasGrupoEjercicio { get; set; }

        //ROUNDS PER TIME
        public int? TiempoFinalizacionMinuto { get; set; }
        public int? TiempoFinalizacionSegundo { get; set; }

        [NotMapped]
        public Estado? WorkoutEstado
        {
            get
            {
                if (TiempoFinalizacionMinuto.HasValue && TiempoFinalizacionSegundo.HasValue)
                    return Estado.completo;
                else
                    return Estado.incompleto;
            }

        }

        public virtual ICollection<WorkoutMovement> Movimientos { get; set; }

    }

}