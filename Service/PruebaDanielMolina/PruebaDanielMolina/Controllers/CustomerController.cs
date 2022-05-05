using Microsoft.AspNetCore.Mvc;
using PruebaDanielMolina.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaDanielMolina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public CustomerController(AplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                clientes = _context.Clientes.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}