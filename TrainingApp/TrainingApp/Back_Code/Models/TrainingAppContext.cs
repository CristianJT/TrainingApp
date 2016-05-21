using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public class TrainingAppContext : DbContext
    {
    
        public TrainingAppContext() : base("name=TrainingAppContext")
        {
        }

        public DbSet<Movement> Movements { get; set; }
        public DbSet<WorkoutMovement> WorkoutMovements { get; set; }

        public System.Data.Entity.DbSet<TrainingApp.Workout> Workouts { get; set; }
    }
}
