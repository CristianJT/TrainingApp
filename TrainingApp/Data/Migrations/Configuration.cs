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
                new Movement { Id = 5, Nombre = "Hand stand walk (HSW)", Elemento = TipoElemento.libre },
                new Movement { Id = 6, Nombre = "Pull up", Elemento = TipoElemento.barra_dominadas },
                new Movement { Id = 7, Nombre = "Front squat", Elemento = TipoElemento.barra },
                new Movement { Id = 8, Nombre = "Push press", Elemento = TipoElemento.barra },
                new Movement { Id = 9, Nombre = "Thruster", Elemento = TipoElemento.barra },
                new Movement { Id = 10, Nombre = "Toes to bar (TTB)", Elemento = TipoElemento.barra_dominadas },
                new Movement { Id = 11, Nombre = "Jumping lunges", Elemento = TipoElemento.libre },
                new Movement { Id = 12, Nombre = "Burpee box jump pass over", Elemento = TipoElemento.cajon }
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
                },
                new Workout
                {
                    Id = 2,
                    Tipo = WodTipo.met_con,
                    SubTipo = EntrenamientoTipo.chipper,
                    GrupoTipo = GrupoTipo.individual,
                    Nombre = "Miercoles 15.06.16",
                    Fecha = new DateTime(2016, 06, 15),
                    TiempoMaximoMinuto = 30,
                    TiempoMaximoSegundo = 0,
                    TiempoFinalizacionMinuto = 28,
                    TiempoFinalizacionSegundo = 42
                },
                new Workout
                {
                    Id = 3,
                    Tipo = WodTipo.met_con,
                    SubTipo = EntrenamientoTipo.rounds_per_time,
                    GrupoTipo = GrupoTipo.individual,
                    Nombre = "Sabado 18.06.16",
                    Fecha = new DateTime(2016, 06, 18),
                    Rondas = 7,
                    Rx = 40,
                    Detalle = "200 m run entre rounds",
                    TiempoMaximoMinuto = 20,
                    TiempoMaximoSegundo = 0,
                    TiempoFinalizacionMinuto = 18,
                    TiempoFinalizacionSegundo = 36
                },
                new Workout
                {
                    Id = 4,
                    Tipo = WodTipo.met_con,
                    SubTipo = EntrenamientoTipo.amrap,
                    GrupoTipo = GrupoTipo.individual,
                    Nombre = "Martes 21.06.16",
                    Fecha = new DateTime(2016, 06, 21),
                    TiempoMaximoMinuto = 15,
                    TiempoMaximoSegundo = 0,
                    VueltasCompletas = 4
                },
                new Workout
                {
                    Id = 5,
                    Tipo = WodTipo.met_con,
                    SubTipo = EntrenamientoTipo.rounds_per_time,
                    GrupoTipo = GrupoTipo.individual,
                    Nombre = "Jueves 09.06.16",
                    Fecha = new DateTime(2016, 06, 09),
                    Rondas = 3,
                    Rx = 70,
                    TiempoMaximoMinuto = 20,
                    TiempoMaximoSegundo = 0,
                    TiempoFinalizacionMinuto = 15,
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
                new WorkoutMovement { Id = 11, WorkoutId = 1, MovementId = 5, Repeticiones = 15, Detalle = "15m HSW (prueba)", Completo = true },

                new WorkoutMovement { Id = 12, WorkoutId = 2, MovementId = 2, Repeticiones = 60, PesoEjecutado = 60, Completo = true },
                new WorkoutMovement { Id = 13, WorkoutId = 2, MovementId = 6, Repeticiones = 30, Completo = true },
                new WorkoutMovement { Id = 14, WorkoutId = 2, MovementId = 7, Repeticiones = 60, PesoEjecutado = 50, Completo = true },
                new WorkoutMovement { Id = 15, WorkoutId = 2, MovementId = 6, Repeticiones = 20, Completo = true },
                new WorkoutMovement { Id = 16, WorkoutId = 2, MovementId = 8, Repeticiones = 60, PesoEjecutado = 40, Completo = true },
                new WorkoutMovement { Id = 17, WorkoutId = 2, MovementId = 6, Repeticiones = 10, Completo = true },

                new WorkoutMovement { Id = 18, WorkoutId = 3, MovementId = 9, Repeticiones = 21, RondaNumero = 1, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 19, WorkoutId = 3, MovementId = 9, Repeticiones = 18, RondaNumero = 2, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 20, WorkoutId = 3, MovementId = 9, Repeticiones = 15, RondaNumero = 3, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 21, WorkoutId = 3, MovementId = 9, Repeticiones = 12, RondaNumero = 4, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 22, WorkoutId = 3, MovementId = 9, Repeticiones = 9, RondaNumero = 5, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 23, WorkoutId = 3, MovementId = 9, Repeticiones = 6, RondaNumero = 6, PesoEjecutado = 35, Completo = true },
                new WorkoutMovement { Id = 24, WorkoutId = 3, MovementId = 9, Repeticiones = 3, RondaNumero = 7, PesoEjecutado = 35, Completo = true },

                new WorkoutMovement { Id = 25, WorkoutId = 4, MovementId = 10, MovimientoAlternativo = "Knees to elbows (KTE)", Repeticiones = 15 },
                new WorkoutMovement { Id = 26, WorkoutId = 4, MovementId = 11, Repeticiones = 30 },
                new WorkoutMovement { Id = 27, WorkoutId = 4, MovementId = 1, Repeticiones = 45 },

                new WorkoutMovement { Id = 28, WorkoutId = 5, MovementId = 4, Repeticiones = 21, RondaNumero = 1, Completo = true },
                new WorkoutMovement { Id = 29, WorkoutId = 5, MovementId = 12, Repeticiones = 21, RondaNumero = 1, Altura = 60, Completo = true },
                new WorkoutMovement { Id = 30, WorkoutId = 5, MovementId = 2, Repeticiones = 21, RondaNumero = 1, PesoEjecutado = 70, Completo = true },
                new WorkoutMovement { Id = 31, WorkoutId = 5, MovementId = 4, Repeticiones = 15, RondaNumero = 2, Completo = true },
                new WorkoutMovement { Id = 32, WorkoutId = 5, MovementId = 12, Repeticiones = 15, RondaNumero = 2, Altura = 60, Completo = true },
                new WorkoutMovement { Id = 33, WorkoutId = 5, MovementId = 2, Repeticiones = 15, RondaNumero = 2, PesoEjecutado = 70, Completo = true },
                new WorkoutMovement { Id = 34, WorkoutId = 5, MovementId = 4, Repeticiones = 9, RondaNumero = 3, Completo = true },
                new WorkoutMovement { Id = 35, WorkoutId = 5, MovementId = 12, Repeticiones = 9, RondaNumero = 3, Altura = 60, Completo = true },
                new WorkoutMovement { Id = 36, WorkoutId = 5, MovementId = 2, Repeticiones = 9, RondaNumero = 3, PesoEjecutado = 70, Completo = true }
            });
        }
    }
}
