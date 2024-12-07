namespace Umbl.Data.Repository
{
    using System.Collections.Generic;
    using global::Umbl.Models;

    namespace Umbl.Data.Repository
    {
        public interface IPontoColetaRepository
        {
            IEnumerable<PontoColetaModel> GetAll();
            PontoColetaModel GetById(int id);
            void Add(PontoColetaModel pontoColeta);
            void Update(PontoColetaModel pontoColeta);
            void Delete(int id);
        }

    }

}
