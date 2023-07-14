using ClubesProdam.model;

namespace ClubesProdam.Repository.Interfaces
{
    public interface IEstabelecimentoRepository : IBaseRepository
    {
        Task<List<Estabelecimento>> GetEstabelecimentosAsync();
        Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id);
    }
}