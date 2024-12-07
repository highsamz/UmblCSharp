using Umbl.Models;

namespace Umbl.Services
{
    public interface IPontoColetaService
    {
        IEnumerable<PontoColetaModel> ListarTodos();
        PontoColetaModel ObterPorId(int id);
        void Criar(PontoColetaModel pontoColeta);
        void Atualizar(PontoColetaModel pontoColeta);
        void Remover(int id);
    }


}
