using ApiClientes.Models;
using ApiClientes.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiClientes.Controllers
{
    [Route("api/[Controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepositorio;

        public ClientesController(IClienteRepository clienteRepo)
        {
            _clienteRepositorio = clienteRepo;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepositorio.GetAll();
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public IActionResult GetById(int id)
        {
            var cliente = _clienteRepositorio.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return new ObjectResult(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            _clienteRepositorio.Add(cliente);
            return CreatedAtRoute("GetCliente", new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.ClienteId != id)
            {
                return BadRequest();
            }
            var _cliente = _clienteRepositorio.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _cliente.Nome = cliente.Nome;
            _cliente.Email = cliente.Email;
            _cliente.Mailing = cliente.Mailing;
            _cliente.Telefone = cliente.Telefone;
            _cliente.Whatsapp = cliente.Whatsapp;

            _clienteRepositorio.Update(_cliente);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            var _cliente = _clienteRepositorio.Find(id);
            if (_cliente == null)
            {
                return NotFound();
            }
            _clienteRepositorio.Remove(id);
            return new NoContentResult();
        }
    }
}
