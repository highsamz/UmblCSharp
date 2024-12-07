using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbl.Services;

namespace Umbl.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using global::Umbl.Data.Repository.Umbl.Data.Repository;
    using global::Umbl.Models;

    namespace Umbl.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public class PontoColetaController : ControllerBase
        {
            private readonly IPontoColetaRepository _repository;

            public PontoColetaController(IPontoColetaRepository repository)
            {
                _repository = repository;
            }

            // GET: api/PontoColeta
            [HttpGet]
            public ActionResult<IEnumerable<PontoColetaModel>> GetAll()
            {
                var pontosColeta = _repository.GetAll();
                return Ok(pontosColeta);
            }

            // GET: api/PontoColeta/{id}
            [HttpGet("{id}")]
            public ActionResult<PontoColetaModel> GetById(int id)
            {
                var pontoColeta = _repository.GetById(id);
                if (pontoColeta == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                return Ok(pontoColeta);
            }

            // POST: api/PontoColeta
            [HttpPost]
            public ActionResult<PontoColetaModel> Create([FromBody] PontoColetaModel pontoColeta)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _repository.Add(pontoColeta);
                return CreatedAtAction(nameof(GetById), new { id = pontoColeta.Id }, pontoColeta);
            }

            // PUT: api/PontoColeta/{id}
            [HttpPut("{id}")]
            public IActionResult Update(int id, [FromBody] PontoColetaModel pontoColeta)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var existingPonto = _repository.GetById(id);
                if (existingPonto == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                // Atualiza as informações do ponto de coleta existente
                pontoColeta.Id = id; // Garante que o ID não será alterado
                _repository.Update(pontoColeta);

                return NoContent();
            }

            // DELETE: api/PontoColeta/{id}
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                var pontoColeta = _repository.GetById(id);
                if (pontoColeta == null)
                    return NotFound($"Ponto de coleta com ID {id} não encontrado.");

                // Exclui o ponto de coleta pelo ID
                _repository.Delete(id);

                return Ok($"Ponto de coleta com ID {id} foi deletado com sucesso.");
            }


        }
    }
}
