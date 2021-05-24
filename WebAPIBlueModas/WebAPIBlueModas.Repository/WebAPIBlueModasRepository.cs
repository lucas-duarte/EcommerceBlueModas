using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIBlueModas.Dominio;

namespace WebAPIBlueModas.Repository
{
    public class WebAPIBlueModasRepository : IWebAPIBlueModasRepository
    {
        private readonly AppDbContext _context;

        public WebAPIBlueModasRepository(AppDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }



        //---------------- select -----------------//

        // ----------- RETORNA TODOS OS CLIENTES -------//
        public async Task<Cliente[]> GetAllClientes()
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Include(c => c.Compras)
                        .ThenInclude(c => c.ComprasProdutos)
                        .Include(c => c.Compras);

            query = query.AsNoTracking().OrderBy(c => c.ClienteId);

            return await query.ToArrayAsync();
        }

        // ----------- RETORNA CLIENTE PELO EMAIL/ID -------//
        public async Task<Cliente> GetByClienteId(string id)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Include(c => c.Compras)
                        .ThenInclude(c => c.ComprasProdutos)
                        .ThenInclude(c => c.Produto);

            query = query.AsNoTracking().OrderBy(c => c.ClienteId);

            return await query.FirstOrDefaultAsync(c => c.ClienteId == id);
        }

        // ----------- RETORNA CLIENTE PELO NOME -------//
        public async Task<Cliente[]> GetClientesNome(string nome)
        {
            IQueryable<Cliente> query = _context.Clientes;

            query = query.Include(c => c.Compras)
                        .ThenInclude(c => c.ComprasProdutos)
                        .Include(c => c.Compras);

            query = query.AsNoTracking()
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.ClienteId);

            return await query.ToArrayAsync();
        }

        //----------- COMPRA -------//

        public async Task<Compra[]> GetAllCompras()
        {
            IQueryable<Compra> query = _context.Compras;

            query = query.Include(c => c.ComprasProdutos).ThenInclude(c => c.Produto);

            query = query.AsNoTracking().OrderBy(c => c.ClienteId);

            return await query.ToArrayAsync();
        }

        public async Task<Compra> GetCompraId(int id)
        {
            IQueryable<Compra> query = _context.Compras;

            query = query.Include(c => c.ComprasProdutos).ThenInclude(c => c.Produto);

            query = query.AsNoTracking().OrderBy(c => c.ClienteId);

            return await query.FirstOrDefaultAsync(c => c.CompraId == id);
        }

        //----------------- PRODUTO ------------//
        public async Task<Produto[]> GetAllProdutos()
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(c => c.ProdutoId);

            return await query.ToArrayAsync();
        }

        public async Task<Produto> GetProdutosId(int id)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking().OrderBy(c => c.ProdutoId);

            return await query.FirstOrDefaultAsync(c => c.ProdutoId == id);
        }

        public async Task<Produto[]> GetProdutosNome(string nome)
        {
            IQueryable<Produto> query = _context.Produtos;

            query = query.AsNoTracking()
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.ProdutoId);

            return await query.ToArrayAsync();
        }
    }
}
