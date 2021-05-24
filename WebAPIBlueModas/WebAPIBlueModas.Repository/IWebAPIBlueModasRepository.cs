using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIBlueModas.Dominio;

namespace WebAPIBlueModas.Repository
{
    public interface IWebAPIBlueModasRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        //---------- CLIENTE -------------//
        Task<Cliente[]> GetAllClientes();
        Task<Cliente> GetByClienteId(string id);
        Task<Cliente[]> GetClientesNome(string nome);

        //----------- COMPRA------------//
        Task<Compra[]> GetAllCompras();
        Task<Compra> GetCompraId(int id);

        // ----------- PRODUTOS ---------//

        Task<Produto[]> GetAllProdutos();
        Task<Produto> GetProdutosId(int id);
        Task<Produto[]> GetProdutosNome(string nome);
    }
}
