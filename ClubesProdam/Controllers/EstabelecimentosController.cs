using ClubesProdam.model;
using ClubesProdam.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClubesProdam.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EstabelecimentosController : ControllerBase
    {
        private readonly IEstabelecimentoRepository _repository;
        public EstabelecimentosController(IEstabelecimentoRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEstabelecimentos()
        {
            var estabs = await _repository.GetEstabelecimentosAsync();
            return estabs.Any() ? Ok(estabs) : BadRequest("Nenhum estabelecimento encontrado");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstabsById([FromRoute] int id)
        {
            var estab = await _repository.GetEstabelecimentoByIdAsync(id);
            return estab != null ? Ok(estab) : BadRequest("Nenhum estabelecimento encontrado com este id");
        }
        [HttpPost]
        public async Task<IActionResult> InsertEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.Add(estabelecimento);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEstabsById), new { id = estabelecimento.Id }, estabelecimento);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstab([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Id inválido");

            var deletedEstab = await _repository.GetEstabelecimentoByIdAsync(id);
            if (deletedEstab == null) return NotFound("Estabelecimento não encontrado!");

            _repository.Delete(deletedEstab);

            await _repository.SaveChangesAsync();

            return Ok(new { Message = "Deletado com suecesso", Deleted = deletedEstab });

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstab(int id, [FromBody] Estabelecimento estabelecimento)
        {
            var dbEstab = await _repository.GetEstabelecimentoByIdAsync(id);
            estabelecimento.Id = dbEstab.Id;

            if (id <= 0) return BadRequest("Usuário não informado");


            dbEstab.CNPJ = estabelecimento.CNPJ ?? dbEstab.CNPJ;
            dbEstab.CNPJ = estabelecimento.CNPJ ?? dbEstab.CNPJ;
            dbEstab.CEP = estabelecimento.CEP ?? dbEstab.CEP;
            dbEstab.NomeEmpresa = estabelecimento.NomeEmpresa ?? dbEstab.NomeEmpresa;
            dbEstab.TipoEstabelecimento = estabelecimento.TipoEstabelecimento ?? dbEstab.TipoEstabelecimento;

            _repository.Update(dbEstab);

            await _repository.SaveChangesAsync();

            return Ok(new { Message = "Estabelecimento alterado com suecesso", Updated = dbEstab });

        }
    }
}