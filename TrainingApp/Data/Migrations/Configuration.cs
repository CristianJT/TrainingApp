namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TrainingApp;

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
                new Movement { Id = 3, Nombre = "Ring dips", Elemento = TipoElemento.anillas },
                new Movement { Id = 4, Nombre = "Hand stand push up (HSPU)", Elemento = TipoElemento.libre },
                new Movement { Id = 5, Nombre = "Hand stand walk (HSW)", Elemento = TipoElemento.libre }
            });

            context.Workouts.AddOrUpdate(
                new Workout { Id = 1,
                    Tipo = WodTipo.met_con,
                    SubTipo = EntrenamientoTipo.rounds_per_time,
                    GrupoTipo = GrupoTipo.individual,
                    Nombre = "Viernes 27.05.16",
                    Fecha = new DateTime(2016, 05, 27),
                    TiempoMaximoMinuto = 20,
                    TiempoMaximoSegundo = 0,
                    Rx = 70,
                    Rondas = 3,
                    Detalle = "Empieza y termina con 15 HSW/HSPU",
                    TiempoFinalizacionMinuto = 20,
                    TiempoFinalizacionSegundo = 0
                }
            );

            context.WorkoutMovements.AddOrUpdate(new WorkoutMovement[] {
                new WorkoutMovement { Id = 1, WorkoutId = 1, MovementId = 5, MovimientoAlternativo = "Hand stand push up (HSPU)", Repeticiones = 15, Detalle = "5m HSW (prueba) + 10 HSPU (estricto)", Completo = true },
                new WorkoutMovement { Id = 2, WorkoutId = 1, MovementId = 2, Repeticiones = 15, RondaNumero = 1, PesoEjecutado = 60, Completo = true },
                new WorkoutMovement { Id = 3, WorkoutId = 1, MovementId = 2, Repeticiones = 15, RondaNumero = 2, PesoEjecutado = 60, Completo = true },
                new WorkoutMovement { Id = 4, WorkoutId = 1, MovementId = 2, Repeticiones = 15, RondaNumero = 3, PesoEjecutado = 60, Completo = true },
                new WorkoutMovement { Id = 5, WorkoutId = 1, MovementId = 1, Repeticiones = 30, RondaNumero = 1, Restriccion = true, RestriccionTipo = "unbroken", Unbroken = true, Completo = true },
                new WorkoutMovement { Id = 6, WorkoutId = 1, MovementId = 1, Repeticiones = 30, RondaNumero = 2, Restriccion = true, RestriccionTipo = "unbroken", Unbroken = false, Detalle = "24 + 6", Completo = true },
                new WorkoutMovement { Id = 7, WorkoutId = 1, MovementId = 1, Repeticiones = 30, RondaNumero = 3, Restriccion = true, RestriccionTipo = "unbroken", Unbroken = true, Completo = true },
                new WorkoutMovement { Id = 8, WorkoutId = 1, MovementId = 3, Repeticiones = 15, RondaNumero = 1, Adaptacion = true, AdaptacionTipo = "cinta roja", Completo = true },
                new WorkoutMovement { Id = 9, WorkoutId = 1, MovementId = 3, Repeticiones = 15, RondaNumero = 2, Adaptacion = true, AdaptacionTipo = "cinta roja", Completo = true },
                new WorkoutMovement { Id = 10, WorkoutId = 1, MovementId = 3, Repeticiones = 15, RondaNumero = 3, Adaptacion = true, AdaptacionTipo = "cinta roja", Completo = true },
                new WorkoutMovement { Id = 11, WorkoutId = 1, MovementId = 5, Repeticiones = 15, Detalle = "15m HSW (prueba)", Completo = true }
            });
        }
    }
}
