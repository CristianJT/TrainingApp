﻿using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace TrainingApp
{
    [RoutePrefix("api/wods")]
    public class WorkoutsController : ApiController
    {
        private TrainingAppContext db = new TrainingAppContext();

        //GET: api/wods
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetWorkouts()
        {
            Workout[] wods = db.Workouts.AsNoTracking().ToArray();

            if (wods.Length == 0)
            {
                return Ok(new WorkoutResumenDTO[] { });
            }

            WorkoutResumenDTO[] dtos = wods.Select(x => new WorkoutResumenDTO(x)).ToArray();

            return Ok(dtos);
        }

        //GET: api/wods/{id}
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(WorkoutDTO))]
        public IHttpActionResult GetWorkout(int id)
        {
            Workout workout = db.Workouts.Include(w=> w.Movimientos)
                                         .Where(x=> x.Id == id).AsNoTracking()
                                         .FirstOrDefault();
            if (workout == null)
            {
                return NotFound();
            }

            WorkoutDTO dto = new WorkoutDTO(workout);
            return Ok(dto);
        }

        // POST: api/wods
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(WorkoutResumenDTO))]
        public IHttpActionResult CreateWorkout(WorkoutNuevoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Workout wod = new Workout();
            wod.Nombre = dto.nombre;
            wod.Tipo = dto.workout_tipo;
            wod.SubTipo = dto.entrenamiento_tipo;
            wod.GrupoTipo = dto.grupo_tipo;
            wod.Fecha = dto.fecha;
            wod.Detalle = dto.detalle;
            wod.TiempoMaximoMinuto = dto.tiempo_maximo_minuto;
            wod.TiempoMaximoSegundo = dto.tiempo_maximo_segundo;
            wod.Rx = dto.rx;  
            wod.VueltasCompletas = dto.vueltas_completas;
            wod.RepeticionesExtra = dto.repeticiones_extra;
            wod.TiempoFinalizacionMinuto = dto.tiempo_finalizacion_minuto;
            wod.TiempoFinalizacionSegundo = dto.tiempo_finalizacion_segundo;
            wod.Rondas = dto.setRondas(dto);
            wod.RondasGrupoEjercicio = dto.rondas_grupo_ejercicio;
            
            db.Workouts.Add(wod);
            db.SaveChanges();

            return Ok(new WorkoutResumenDTO(wod));
        }

        // POST: api/wods/{id}/movimientos
        [Route("{id}/movimientos")]
        [HttpPost]
        public IHttpActionResult AddWorkoutMovements(int id, WorkoutMovementNuevoDTO[] dtos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return NotFound();
            }

            WorkoutMovement movement;
            foreach (WorkoutMovementNuevoDTO wm in dtos)
            {
                movement = new WorkoutMovement();
                movement.WorkoutId = id;
                movement.MovementId = wm.movimiento_id;
                movement.MovimientoAlternativo = wm.movimiento_alternativo;
                movement.Repeticiones = wm.repeticiones;
                movement.PesoEjecutado = wm.peso;
                movement.PesoAlternativo = wm.peso_alternativo;
                movement.Distancia = wm.distancia;
                movement.Altura = wm.altura;
                movement.Adaptacion = wm.adaptacion;
                movement.AdaptacionTipo = wm.adaptacion_tipo;
                movement.Restriccion = wm.restriccion;
                movement.RestriccionTipo = wm.restriccion_tipo;
                movement.RondaNumero = wm.ronda;
                movement.MinutoNumero = wm.minuto;
                movement.Unbroken = wm.unbroken;
                movement.Detalle = wm.detalle;
                movement.Completo = wm.completo;

                db.WorkoutMovements.Add(movement);
            }
            db.SaveChanges();

            return Ok();
        }


        // DELETE: api/wods/{id}
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteWorkout(int id)
        {
            Workout workout = db.Workouts.Find(id);
            if (workout == null)
            {
                return NotFound();
            }

            db.Workouts.Remove(workout);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}