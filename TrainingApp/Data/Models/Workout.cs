using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingApp
{
    public enum WodTipo
    {
        met_con = 1,
        fuerza = 3,
        potencia = 5,
        cardio = 7,
        skill = 9,
        bar_complex = 11
    }

    public enum Estado
    {
        completo = 1,
        incompleto = 2
    }

    public enum EntrenamientoTipo
    {
        amrap = 1,
        rounds_per_time = 2,
        chipper = 3,
        emom = 4,
        e2mo2m = 5,
        otm = 6,
        ot2m = 7,
        libre = 8
    }

    public enum GrupoTipo
    {
        individual = 1,
        en_parejas = 3,
        grupal = 5
    }

    public class Workout
    {
        public Workout()
        {
            Movimientos = new HashSet<WorkoutMovement>();
        }

        public int Id { get; set; }

        [Required]
        public WodTipo Tipo { get; set; }

        [Required]
        public EntrenamientoTipo SubTipo { get; set; }

        [Required]
        public GrupoTipo GrupoTipo { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [Index]
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int TiempoMaximoMinuto { get; set; }

        [Required]
        public int TiempoMaximoSegundo { get; set; }

        public string Detalle { get; set; }

        public float? Rx { get; set; }

        public int? Rondas { get; set; }

        //AMRAP
        public int? VueltasCompletas { get; set; }
        public string RepeticionesExtra { get; set; }

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
                if (SubTipo == EntrenamientoTipo.chipper || SubTipo == EntrenamientoTipo.rounds_per_time)
                {
                    if (TiempoFinalizacionMinuto.HasValue && TiempoFinalizacionSegundo.HasValue)
                        return Estado.completo;
                    else
                        return Estado.incompleto;
                }
                else
                    return null;
            }

        }

        public virtual ICollection<WorkoutMovement> Movimientos { get; set; }

    }

}