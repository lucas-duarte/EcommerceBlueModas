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
    public class ComprasController : ControllerBase
    {
        private readonly IWebAPIBlueModasRepository _repository;

        public ComprasController(IWebAPIBlueModasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Compras -------------------------------------------------------//
        [HttpGet]
        public async Task<IActionResult> GetCompras()
        {
            try
            {
                var compras = await _repository.GetAllCompras();

                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Compras/5 -------------------------------------------------------//
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompra(int id)
        {
            try
            {
                var compras = await _repository.GetCompraId(id);

                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Compras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(int id, Compra model)
        {
            try
            {
                var compra = await _repository.GetCompraId(id);

                if (compra != null)
                {
                    _repository.Update(model);

                    if (await _repository.SaveChangeAsync())

                        return Ok("Delete Realizado!");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Eroo: {ex}");
            }

            return BadRequest($"Não Atualizado!");

        }

        // POST: api/Compras -------------------------------------------------------//
        [HttpPost]
        public async Task<IActionResult> Post(Compra model)
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

        // DELETE: api/Compras/5 -------------------------------------------------------//
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompra(int id)
        {
            try
            {
                var compra = await _repository.GetCompraId(id);

                if (compra!= null)
                {
                    _repository.Delete(compra);

                    if(await _repository.SaveChangeAsync())

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
