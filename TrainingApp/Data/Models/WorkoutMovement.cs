using System.ComponentModel.DataAnnotations;

namespace TrainingApp
{

    public class WorkoutMovement
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public int MovementId { get; set; }

        public string MovimientoAlternativo { get; set; }

        [Required]
        public int Repeticiones { get; set; }

        public int? RondaNumero { get; set; }

        public int? MinutoNumero { get; set; }

        public float? PesoEjecutado { get; set; }

        public float? PesoAlternativo { get; set; }

        public decimal? Distancia { get; set; }

        public decimal? Altura { get; set; }

        public bool Restriccion { get; set; }

        public string RestriccionTipo { get; set; }

        public bool Adaptacion { get; set; }

        public string AdaptacionTipo { get; set; }

        public bool Unbroken { get; set; }

        public string Detalle { get; set; }

        public bool Completo { get; set; }

        public virtual Movement Movement { get; set; }

        public virtual Workout Workout { get; set; }

    }

}