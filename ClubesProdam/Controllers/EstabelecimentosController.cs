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
            try
            {
                var estabs = await _repository.GetEstabelecimentosAsync();
                if (estabs.Any())
                {
                    return Ok(estabs);
                }
                else
                {
                    return BadRequest("Nenhum estabelecimento encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a solicitação: {ex}");
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstabsById([FromRoute] int id)
        {
            try
            {
                var estab = await _repository.GetEstabelecimentoByIdAsync(id);

                if (estab != null)
                {
                    return Ok(estab);
                }
                else
                {
                    return NotFound("Nenhum estabelecimento encontrado com este id");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a solicitação: {ex.GetType()}");
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertEstabelecimento([FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _repository.Add(estabelecimento);
                await _repository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetEstabsById), new { id = estabelecimento.Id }, estabelecimento);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a solicitação: {ex.GetType()}");
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstab([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("Id inválido");
                }

                var deletedEstab = await _repository.GetEstabelecimentoByIdAsync(id);
                if (deletedEstab == null)
                {
                    return NotFound("Estabelecimento não encontrado!");
                }

                _repository.Delete(deletedEstab);
                await _repository.SaveChangesAsync();

                return Ok(new { Message = "Deletado com sucesso", Deleted = deletedEstab });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a solicitação: {ex.GetType()}");
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstab(int id, [FromBody] Estabelecimento estabelecimento)
        {
            try
            {
                var dbEstab = await _repository.GetEstabelecimentoByIdAsync(id);
                estabelecimento.Id = dbEstab.Id;

                if (id <= 0)
                {
                    return BadRequest("Usuário não informado");
                }

                dbEstab.CNPJ = estabelecimento.CNPJ ?? dbEstab.CNPJ;
                dbEstab.CEP = estabelecimento.CEP ?? dbEstab.CEP;
                dbEstab.NomeEmpresa = estabelecimento.NomeEmpresa ?? dbEstab.NomeEmpresa;
                dbEstab.TipoEstabelecimento = estabelecimento.TipoEstabelecimento ?? dbEstab.TipoEstabelecimento;

                _repository.Update(dbEstab);

                await _repository.SaveChangesAsync();

                return Ok(new { Message = "Estabelecimento alterado com sucesso", Updated = dbEstab });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar a solicitação: {ex}");
                return StatusCode(500, "Ocorreu um erro ao processar a solicitação");
            }
        }

    }
}