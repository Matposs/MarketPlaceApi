using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{

    [ApiController]
    [Route("api/consumidor")]
    public class ConsumidorController : ControllerBase
    {
        private readonly DataContext _context;

        public ConsumidorController(DataContext context) =>
            _context = context;
    
        // POST: /api/consumidor/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Consumidor consumidor)
        {
            _context.Consumidores.Add(consumidor);
            _context.SaveChanges();
            return Created("", consumidor);
        }
                // GET: /api/consumidor/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Consumidores.ToList());

                // GET: /api/consumidor/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute] string cpf)
        {
            Consumidor consumidor = _context.Consumidores.
                FirstOrDefault(f => f.Cpf.Equals(cpf));
            return consumidor != null ? Ok(consumidor) : NotFound();
        }

         // DELETE: /api/consumidor/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Consumidor consumidor = _context.Consumidores.Find(id);
            if (consumidor != null)
            {
                _context.Consumidores.Remove(consumidor);
                _context.SaveChanges();
                return Ok(consumidor);
            }
            return NotFound();
        }

        // PATCH: /api/consumidor/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Consumidor consumidor)
        {
            try
            {
                _context.Consumidores.Update(consumidor);
                _context.SaveChanges();
                return Ok(consumidor);
            }
            catch
            {
                return NotFound();
            }
    }
}
}