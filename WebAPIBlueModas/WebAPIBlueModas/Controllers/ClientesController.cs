using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIBlueModas.Dominio;
using WebAPIBlueModas.Repository;

namespace WebAPIBlueModas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IWebAPIBlueModasRepository _repository;

        public ClientesController(IWebAPIBlueModasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Clientes -------------------------------------------------------//
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var clientes = await _repository.GetAllClientes();

                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Clientes/5 -------------------------------------------------------//
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(string id)
        {
            try
            {
                var cliente = await _repository.GetByClienteId(id);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Clientes/Nome -------------------------------------------------------//
        [HttpGet("Nome/{nome}")]
        public async Task<IActionResult> GetClientesNome(string nome)
        {
            try
            {
                var cliente = await _repository.GetClientesNome(nome);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Clientes/5 -------------------------------------------------------//
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(string id, Cliente model)
        {
            try
            {
                var cliente = await _repository.GetByClienteId(id);

                if (cliente != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())

                        return Ok("Atualização Realizada!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Eroo: {ex}");
            }

            return BadRequest($"Não Atualizado!");
        }

        // POST: api/Clientes -------------------------------------------------------//
        [HttpPost]
        public async Task<IActionResult> Post(Cliente model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não salvou");
        }

        //DELETE: api/Clientes/5 -------------------------------------------------------//
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(string id)
        {
            try
            {
                var cliente = await _repository.GetByClienteId(id);

                if (cliente != null)
                {
                    _repository.Delete(cliente);

                    if (await _repository.SaveChangeAsync())

                        return Ok("Delete Realizado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Eroo: {ex}");
            }

            return BadRequest($"Não Deletado!");

        }
    }
}
