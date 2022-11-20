using System.Collections.Generic;
using System.Linq;
using API.Models;
using API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/venda")]
    public class VendasController: ControllerBase
    {
        private readonly DataContext _context;
        public VendasController(DataContext context) =>
            _context = context;
        // POST: /api/venda/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Venda venda)
        {
            venda.ValorDaCompra =
                Calculos.CalcularValorProduto
                    (venda.ProdutoPreco, venda.Quantidade);
            _context.Vendas.Add(venda);
            _context.SaveChanges();
            return Created("", venda);
        }

        // GET: /api/venda/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            List <Venda> vendas = 
                _context.Vendas.Include(f => f.Consumidor).ToList();

            if(vendas.Count == 0) return NotFound();

            return Ok(vendas);
        } 

        // // GET: /api/venda/filtrar/mes/ano
        // [HttpGet]
        // [Route("filtrar/{mes}/{ano}")]
        // public IActionResult Filtar([FromRoute] int mes, int ano)
        // {            
        //     return Ok(_context.Folhas.Where
        //         (f => f.CriadoEm.Month == mes && f.CriadoEm.Year == ano).ToList());
        // } 

        // GET: /api/venda/buscar/cpf
        [HttpGet]
        [Route("buscar/{cpf}")]
        public IActionResult Buscar([FromRoute]string cpf)
        {           
            return Ok(
                _context.Vendas
                .Include(f => f.Consumidor)
                .FirstOrDefault
                (f => 
                    f.Consumidor.Cpf.Equals(cpf)));
        }
        
    }
}