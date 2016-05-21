namespace TrainingApp.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TrainingApp.TrainingAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TrainingApp.TrainingAppContext context)
        {
            context.Movements.AddOrUpdate(new Movement[] {
                new Movement { Id = 1, Nombre = "Double under", Elemento = TipoElemento.soga },
                new Movement { Id = 2, Nombre = "Deadlift", Elemento = TipoElemento.barra },
                new Movement { Id = 3, Nombre = "Pull up", Elemento = TipoElemento.barra_dominadas },
                new Movement { Id = 4, Nombre = "Box jump pass over", Elemento = TipoElemento.cajon },
                new Movement { Id = 5, Nombre = "Wall ball", Elemento = TipoElemento.pelota },
                new Movement { Id = 6, Nombre = "ketllebell snatch", Elemento = TipoElemento.ketllebell },
                new Movement { Id = 7, Nombre = "Knees to elbows", Elemento = TipoElemento.barra_dominadas },
                new Movement { Id = 8, Nombre = "ketllebell crossfit swing", Elemento = TipoElemento.ketllebell },
                new Movement { Id = 9, Nombre = "Burpee", Elemento = TipoElemento.libre }
            });

            context.Workouts.AddOrUpdate(
                new WorkoutOnMinute { Id = 1, Nombre = "Martes 17.05.16", Fecha = new DateTime(2016, 05, 17), TiempoMaximoMinuto = 18, TiempoMaximoSegundo = 0, Rx = 24, Tipo = Tipo.otm, RondasTotales = 18, RondasGrupoEjercicio = 3 },
                new WorkoutPerTime { Id = 2, Nombre = "Miercoles 18.05.16", Fecha = new DateTime(2016, 08, 18), TiempoMaximoMinuto = 25, TiempoMaximoSegundo = 0, Rx = 70, Rondas = 1, TiempoFinalizacionMinuto = 24, TiempoFinalizacionSegundo = 04 }
            );

            context.WorkoutMovements.AddOrUpdate(new WorkoutMovement[] {
                new WorkoutMovement { WorkoutId = 1, MovementId = 6, Repeticiones = 12, Minuto = 1, PesoEjecutado = 16, Completo = true },
                new WorkoutMovement { WorkoutId = 1, MovementId = 9, Repeticiones = 1, Minuto = 1, Completo = true },
                new WorkoutMovement { WorkoutId = 1, MovementId = 7, Repeticiones = 12, Minuto = 2, Completo = true },
                new WorkoutMovement { WorkoutId = 1, MovementId = 9, Repeticiones = 2, Minuto = 2, Completo = true },
                new WorkoutMovement { WorkoutId = 1, MovementId = 8, Repeticiones = 12, Minuto = 3,  PesoEjecutado = 21, Completo = true },
                new WorkoutMovement { WorkoutId = 1, MovementId = 9, Repeticiones = 3, Minuto = 3, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 1, Repeticiones = 100, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 2, Repeticiones = 50, PesoEjecutado = 65, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 3, Repeticiones = 50, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 4, Repeticiones = 50, Altura = 60, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 5, Repeticiones = 50, PesoEjecutado = 9, Completo = true },
                new WorkoutMovement { WorkoutId = 2, MovementId = 1, Repeticiones = 100, Completo = true }
            });
        }
    }
}
