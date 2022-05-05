using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaDanielMolina.Business;
using PruebaDanielMolina.Models;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaDanielMolina.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public AccountsController(AplicationDbContext context)
        {
            _context = context;
        }

        // GET api/<AccountsController>/5
        [HttpGet("{id}")]
        public ActionResult<Transaccion> Get(int id)
        {
            try
            {
                List<Transaccion> transaccions = new List<Transaccion>();
                transaccions = _context.Transaccions.Where(n => n.IdCliente == id).ToList();

                return Ok(transaccions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AccountsController>
        [HttpPost]
        public ActionResult Post([FromBody] Transaccion transaccion)
        {
            try
            {
                transaccion.Fecha = DateTime.Now;
                Calculation calculation = new Calculation(transaccion);
                transaccion = calculation.GetAccounts();
                _context.Add(transaccion);
                _context.SaveChanges();
                return Ok(transaccion);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AccountsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Transaccion transaccion)
        {
            try
            {
                if (id != transaccion.IdCuenta)
                {
                    return BadRequest();
                }
                else
                {
                    _context.Entry(transaccion).State = EntityState.Modified;
                    _context.Update(transaccion);
                    _context.SaveChanges();
                    return Ok(transaccion);
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}