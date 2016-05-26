using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApp
{
    public class WorkoutResumenDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Tipo tipo { get; set; }
        public DateTime fecha { get; set; }

        public WorkoutResumenDTO() { }

        public WorkoutResumenDTO(Workout wod)
        {
            this.id = wod.Id;
            this.fecha = wod.Fecha;
            this.nombre = wod.Nombre;
            this.tipo = wod.Tipo;
        }
    }

    public class WorkoutDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public Tipo tipo { get; set; }
        public DateTime fecha { get; set; }
        public int tiempo_maximo_minuto { get; set; }
        public int tiempo_maximo_segundo { get; set; }
        public float? rx { get; set; }
        public int? rondas { get; set; }
        public int? vueltas_completas { get; set; }
        public int? repeticiones_extra { get; set; }
        public int? rondas_grupo_ejercicio { get; set; }
        public int? tiempo_finalizacion_minuto { get; set; }
        public int? tiempo_finalizacion_segundo { get; set; }
        public Estado? estado { get; set; }
        public WorkoutMovementDTO[] movimientos { get; set; }

        public WorkoutDTO() {
            this.movimientos = new WorkoutMovementDTO[] { };
        }

        public WorkoutDTO(Workout wod)
        {
            this.id = wod.Id;
            this.fecha = wod.Fecha;
            this.nombre = wod.Nombre;
            this.tipo = wod.Tipo;
            this.tiempo_maximo_minuto = wod.TiempoMaximoMinuto;
            this.tiempo_maximo_segundo = wod.TiempoMaximoSegundo;
            this.rx = wod.Rx;
            this.rondas = wod.Rondas;
            this.vueltas_completas = wod.VueltasCompletas;
            this.repeticiones_extra = wod.RepeticionesExtra;
            this.rondas_grupo_ejercicio = wod.RondasGrupoEjercicio;
            this.tiempo_finalizacion_minuto = wod.TiempoFinalizacionMinuto;
            this.tiempo_finalizacion_segundo = wod.TiempoFinalizacionSegundo;
            this.estado = wod.WorkoutEstado;

            this.movimientos = wod.Movimientos.Select(x => new WorkoutMovementDTO(x)).ToArray();
        }
    }

    public class WorkoutNuevoDTO
    {
        [MaxLength(50)]
        public string nombre { get; set; }

        [Required]
        public Tipo tipo { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public int tiempo_maximo_minuto { get; set; }

        [Required]
        public int tiempo_maximo_segundo { get; set; }

        public float? rx { get; set; }
        public int? rondas { get; set; }
        public int? vueltas_completas { get; set; }
        public int? repeticiones_extra { get; set; }
        public int? rondas_grupo_ejercicio { get; set; }
        public int? tiempo_finalizacion_minuto { get; set; }
        public int? tiempo_finalizacion_segundo { get; set; }

        public int? setRondas(WorkoutNuevoDTO dto)
        {
            switch (dto.tipo)
            {
                case Tipo.rounds_per_time:
                    rondas = dto.rondas;
                    break;
                case Tipo.chipper:
                    rondas = 1;
                    break;
                case Tipo.emom:
                    rondas = dto.tiempo_maximo_minuto;
                    break;
                case Tipo.e2mo2m:
                    rondas = dto.tiempo_maximo_minuto / 2;
                    break;
                case Tipo.otm:
                    rondas = dto.tiempo_maximo_minuto;
                    break;
                case Tipo.ot2m:
                    rondas = dto.tiempo_maximo_minuto / 2;
                    break;
            }
            return rondas;
        }
    }
}
