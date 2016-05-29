using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace TrainingApp
{
    [RoutePrefix("api/movimientos")]
    public class MovementsController : ApiController
    {
        private TrainingAppContext db = new TrainingAppContext();

        // GET: api/movimientos
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetMovements()
        {
            Movement[] mvs = db.Movements.AsNoTracking().ToArray();

            if (mvs.Length == 0)
            {
                return Ok(new MovementResumenDTO[] { });
            }

            MovementResumenDTO[] dtos = mvs.Select(x => new MovementResumenDTO(x)).ToArray();
            return Ok(dtos);
        }

        // GET: api/movimientos/{id}
        [Route("{id}")]
        [HttpGet]
        [ResponseType(typeof(MovementDTO))]
        public IHttpActionResult GetMovement(int id)
        {
            Movement movement = db.Movements.Include(m => m.Wods)
                                            .Where(x => x.Id == id).AsNoTracking()
                                            .FirstOrDefault();
            if (movement == null)
            {
                return NotFound();
            }

            MovementDTO dto = new MovementDTO(movement);
            return Ok(dto);
        }

        // PUT: api/movimientos/{id}
        [Route("{id}")]
        [HttpPut]
        [ResponseType(typeof(MovementResumenDTO))]
        public IHttpActionResult UpdateMovement(int id, MovementNuevoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movement movement = db.Movements.Where(m => m.Id == id).FirstOrDefault();
            if (movement == null)
            {
                return NotFound();
            }

            movement.Nombre = dto.nombre;
            movement.Elemento = dto.tipo_elemento;
            movement.Descripcion = dto.descripcion;

            db.SaveChanges();
            
            return Ok(new MovementResumenDTO(movement));
        }

        // POST: api/movimientos
        [Route("")]
        [HttpPost]
        [ResponseType(typeof(MovementResumenDTO))]
        public IHttpActionResult CreateMovement(MovementNuevoDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movement movement = new Movement();
            movement.Nombre = dto.nombre;
            movement.Elemento = dto.tipo_elemento;
            movement.Descripcion = dto.descripcion;

            db.Movements.Add(movement);
            db.SaveChanges();

            return Ok(new MovementResumenDTO(movement));
        }

        // DELETE: api/movimientos/{id}
        [Route("{id}")]
        [HttpDelete]
        public IHttpActionResult DeleteMovement(int id)
        {
            Movement movement = db.Movements.Where(m => m.Id == id).FirstOrDefault();
            if (movement == null)
            {
                return NotFound();
            }

            db.Movements.Remove(movement);
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