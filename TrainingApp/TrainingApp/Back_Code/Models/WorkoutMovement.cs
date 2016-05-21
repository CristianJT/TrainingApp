﻿namespace TrainingApp
{

    public class WorkoutMovement
    {
        public int Id { get; set; }

        public int WorkoutId { get; set; }

        public int MovementId { get; set; }

        public int Repeticiones { get; set; }

        public float? PesoEjecutado { get; set; }

        public float? PesoAlternativo1 { get; set; }

        public decimal? Distancia { get; set; }

        public decimal? Altura { get; set; }

        public bool Restriccion { get; set; }

        public string RestriccionTipo { get; set; }

        public bool Adaptacion { get; set; }

        public string AdaptacionTipo { get; set; }

        public int? Minuto { get; set; }

        public bool Completo { get; set; }

        public virtual Movement Movement { get; set; }

        public virtual Workout Workout { get; set; }

    }

}