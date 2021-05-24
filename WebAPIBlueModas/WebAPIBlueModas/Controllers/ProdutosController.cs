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
    public class ProdutosController : ControllerBase
    {
        private readonly IWebAPIBlueModasRepository _repository;

        public ProdutosController(IWebAPIBlueModasRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult> GetProdutos()
        {
            try
            {
                var produtos = await _repository.GetAllProdutos();

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Produtos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduto(int id)
        {
            try
            {
                var produto = await _repository.GetProdutosId(id);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // GET: api/Produtos/Nome -------------------------------------------------------//
        [HttpGet("Nome/{nome}")]
        public async Task<IActionResult> GetProdutosNome(string nome)
        {
            try
            {
                var produtos = await _repository.GetProdutosNome(nome);

                return Ok(produtos);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT: api/Produtos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto model)
        {
            try
            {
                _repository.Update(model);

                if (await _repository.SaveChangeAsync())
                {
                    return Ok(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não Alterou");
        }

        // POST: api/Produtos
        [HttpPost]
        public async Task<IActionResult> PostProduto(Produto model)
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

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            try
            {
                var produto = await _repository.GetProdutosId(id);

                if (produto != null)
                {
                    _repository.Delete(produto);

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
