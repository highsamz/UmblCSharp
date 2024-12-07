using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbl.Services;

namespace Umbl.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using global::Umbl.Data.Repository.Umbl.Data.Repository;
    using global::Umbl.Models;
    using Microsoft.AspNetCore.Authorization;

    namespace Umbl.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
        public class PontoColetaController : ControllerBase
        {
            private readonly IPontoColetaRepository _repository;

            public PontoColetaController(IPontoColetaRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public ActionResult<PaginatedResult<PontoColetaModel>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
            {
                if (pageNumber <= 0 || pageSize <= 0)
                {
                    return BadRequest("O número da página e o tamanho da página devem ser maiores que zero.");
                }

                var result = _repository.GetAllPaginated(pageNumber, pageSize);

                if (result.Items.Count == 0)
                {
                    return NotFound("Nenhum ponto de coleta encontrado para a página solicitada.");
                }

                return Ok(result);
            }


            [HttpGet("{id}")]
            [Authorize(Roles = "operador,analista,gerente")]
            public ActionResult<PontoColetaModel> GetById(int id)
            {
                var pontoColeta = _repository.GetById(id);
                if (pontoColeta == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                return Ok(pontoColeta);
            }

            [Authorize(Roles = "operador,gerente")]
            [HttpPost]
            public ActionResult<PontoColetaModel> Create([FromBody] PontoColetaModel pontoColeta)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Add(pontoColeta);
                return CreatedAtAction(nameof(GetById), new { id = pontoColeta.Id }, pontoColeta);
            }

            [HttpPut("{id}")]
            [Authorize(Roles = "operador,analista,gerente")]
            public IActionResult Update(int id, [FromBody] PontoColetaModel pontoColeta)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingPonto = _repository.GetById(id);
                if (existingPonto == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                pontoColeta.Id = id;
                _repository.Update(pontoColeta);

                return NoContent();
            }

            [HttpDelete("{id}")]
            [Authorize(Roles = "gerente")]
            public IActionResult Delete(int id)
            {
                var pontoColeta = _repository.GetById(id);
                if (pontoColeta == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                _repository.Delete(id);

                return Ok($"Ponto de coleta com ID {id} foi deletado com sucesso.");
            }


        }
    }
}
