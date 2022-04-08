using ApiPrueba.Context;
using ApiPrueba.DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPrueba.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaDbContext _context;

        public FacturaController(FacturaDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.Factura.ToList());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}", Name = "GetFactura")]
        public ActionResult Get(int id)
        {
            try
            {
                var factura = _context.Factura.FirstOrDefault(f => f.FacturaId == id);
                return Ok(factura);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Factura factura)
        {
            try
            {
                _context.Factura.Add(factura);
                _context.SaveChanges();
                return CreatedAtRoute("GetFactura", new { id = factura.ClienteId }, factura);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Factura factura)
        {

            try
            {
                if (factura.FacturaId == null)
                {
                    _context.Entry(factura).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetCliente", new { id = factura.FacturaId }, factura);

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
                var factura = _context.Factura.FirstOrDefault(not => not.ClienteId == id);
                if (factura != null)
                {
                    _context.Factura.Remove(factura);
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

