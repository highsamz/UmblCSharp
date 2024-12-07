using Umbl.Data.Repository.Umbl.Data.Repository;
using Umbl.Models;

namespace Umbl.Services
{

    namespace Umbl.Services
    {
        public class PontoColetaService : IPontoColetaService
        {
            private readonly IPontoColetaRepository _repository;

            public PontoColetaService(IPontoColetaRepository repository)
            {
                _repository = repository;
            }

            public IEnumerable<PontoColetaModel> ListarTodos()
                => _repository.GetAll();

            public PontoColetaModel ObterPorId(int id)
                => _repository.GetById(id);

            public void Criar(PontoColetaModel pontoColeta)
                => _repository.Add(pontoColeta);

            public void Atualizar(PontoColetaModel pontoColeta)
                => _repository.Update(pontoColeta);

            public void Remover(int id)
                => _repository.Delete(id);
        }
    }


}
