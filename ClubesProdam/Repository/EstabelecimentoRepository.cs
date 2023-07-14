using ClubesProdam.Context;
using ClubesProdam.model;
using ClubesProdam.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubesProdam.Repository
{
    public class EstabelecimentoRepository : BaseRepository, IEstabelecimentoRepository
    {
        private readonly ClubeDbContext _context;

        public EstabelecimentoRepository(ClubeDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Estabelecimento> GetEstabelecimentoByIdAsync(int id)
        {
            return await _context.Estabelecimentos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Estabelecimento>> GetEstabelecimentosAsync()
        {
            return await _context.Estabelecimentos.ToListAsync();
        }
    }
}