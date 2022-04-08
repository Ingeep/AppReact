using ApiPrueba.Context;
using ApiPrueba.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ServicioDbContextcs _dbContext;

        public ServicioController( ServicioDbContextcs servicio)
        {
             this._dbContext = servicio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_dbContext.Servicio.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetServicio")]
        public ActionResult Get(int id)
        {
            try
            {
                var servicio = _dbContext.Servicio.FirstOrDefault(f => f.ServicioId == id);
                return Ok(servicio);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Servicio servicio)
        {
            try
            {
                _dbContext.Servicio.Add(servicio);
                _dbContext.SaveChanges();
                return CreatedAtRoute("GetServicio", new { id = servicio.ServicioId }, servicio);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Servicio servicio)
        {

            try
            {
                if (servicio.ServicioId == null)
                {
                    _dbContext.Entry(servicio).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _dbContext.SaveChanges();
                    return CreatedAtRoute("GetServicio", new { id = servicio.ServicioId }, servicio);

                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

        }

        //DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var servicio = _dbContext.Servicio.FirstOrDefault(not => not.ServicioId == id);
                if (servicio != null)
                {
                    _dbContext.Servicio.Remove(servicio);
                    _dbContext.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }

}

