using APIEngine.Context;
using APIEngine.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEngine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EngineController(AppDbContext context)
        {
            this._context = context;
        }

        // GET: api/<EngineController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(_context.db_engine.ToList());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<EngineController>/5
        [HttpGet("{id}", Name ="GetDbEngine")]
        public ActionResult Get(int id)
        {
            try
            {
                var item = _context.db_engine.FirstOrDefault(i => i.id == id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<EngineController>
        [HttpPost]
        public ActionResult Post([FromBody]DB_Engine engine)
        {
            try
            {
                _context.db_engine.Add(engine);
                _context.SaveChanges();
                return CreatedAtRoute("GetDbEngine", new {id=engine.id}, engine);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<EngineController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DB_Engine engine)
        {
            try
            {
                if(engine.id == id)
                {
                    _context.Entry(engine).State = EntityState.Modified;
                    _context.SaveChanges();
                    return CreatedAtRoute("GetDbEngine", new { id = engine.id }, engine);
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

        // DELETE api/<EngineController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var item = _context.db_engine.FirstOrDefault(i => i.id == id);
                if(item != null)
                {
                    _context.db_engine.Remove(item);
                    _context.SaveChanges();
                    return Ok(id);
                }
                else { return BadRequest(); }
            }
            catch (Exception ex )
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
