using ApiPrueba.Context;
using ApiPrueba.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteDbContext _context;

        public ClienteController(ClienteDbContext dbcontext)
        {
           this._context = dbcontext;
        }

        [HttpGet]   
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Cliente.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}",Name ="GetCliente")]
        public ActionResult Get(int id)
        {
            try
            {
                var cliente = _context.Cliente.FirstOrDefault(f => f.ClienteId == id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]Cliente cliente)
        {
            try
            {
                _context.Cliente.Add(cliente);
                _context.SaveChanges();
                return CreatedAtRoute("GetCliente", new { id = cliente.ClienteId }, cliente);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


       [HttpPut("{id}")]
       public ActionResult Put(int id,[FromBody]Cliente cliente)
        {

            try
            {
                if(cliente.ClienteId == null)
                {
                    _context.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetCliente", new { id = cliente.ClienteId }, cliente);

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
                var noticia = _context.Cliente.FirstOrDefault(not => not.ClienteId == id);
                if (noticia != null)
                {
                    _context.Cliente.Remove(noticia);
                    _context.SaveChanges();
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
