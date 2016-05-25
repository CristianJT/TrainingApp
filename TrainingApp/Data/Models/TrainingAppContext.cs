using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TrainingApp
{
    public class TrainingAppContext : DbContext
    {
    
        public TrainingAppContext() : base("name=TrainingAppDB")
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<TrainingAppContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrainingAppContext, Data.Migrations.Configuration>("TrainingAppContext"));
        }

        public DbSet<Movement> Movements { get; set; }
        public DbSet<WorkoutMovement> WorkoutMovements { get; set; }
        public DbSet<Workout> Workouts { get; set; }
    }
}
