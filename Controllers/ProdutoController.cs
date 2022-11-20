using System.Collections.Generic;
using System.Linq;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers 
{

    [ApiController]
    [Route("api/produto")]
    public class ProdutoController : ControllerBase
    {
        private readonly DataContext _context;

        public ProdutoController(DataContext context) =>
            _context = context;
    
        // POST: /api/produto/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return Created("", produto);
        }
                // GET: /api/produto/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar() => Ok(_context.Produtos.ToList());

                // GET: /api/produto/buscar/{cpf}
        [HttpGet]
        [Route("buscar/{Id}")]
        public IActionResult Buscar([FromRoute] int Id)
        {
            Produto produto = _context.Produtos.
                FirstOrDefault(f => f.Id.Equals(Id));
            return produto != null ? Ok(produto) : NotFound();
        }

         // DELETE: /api/produto/deletar/{id}
        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            Produto produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            return NotFound();
        }

        // PATCH: /api/produto/alterar
        [HttpPatch]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Produto produto)
        {
            try
            {
                _context.Produtos.Update(produto);
                _context.SaveChanges();
                return Ok(produto);
            }
            catch
            {
                return NotFound();
            }
    }
}
}