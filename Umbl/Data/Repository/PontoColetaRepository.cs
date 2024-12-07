using System.Collections.Generic;
using System.Linq;
using Umbl.Data.Contexts;
using Umbl.Models;
using Microsoft.EntityFrameworkCore;
using Umbl.Data.Repository.Umbl.Data.Repository;

namespace Umbl.Data.Repository
{
    using global::Umbl.Data.Contexts.Umbl.Data.Contexts;
    using Microsoft.EntityFrameworkCore;

    namespace Umbl.Data.Repository
    {
        public class PontoColetaRepository : IPontoColetaRepository
        {
            private readonly DatabaseContext _context;

            public PontoColetaRepository(DatabaseContext context)
            {
                _context = context;
            }

            public IEnumerable<PontoColetaModel> GetAll()
                => _context.PontosColeta.Include(p => p.EnderecoPontoColetaModel).ToList();

            public PontoColetaModel GetById(int id)
                => _context.PontosColeta.Include(p => p.EnderecoPontoColetaModel).FirstOrDefault(p => p.Id == id);

            public void Add(PontoColetaModel pontoColeta)
            {
                _context.PontosColeta.Add(pontoColeta);
                _context.SaveChanges();
            }

            public void Update(PontoColetaModel pontoColeta)
            {
                _context.PontosColeta.Update(pontoColeta);
                _context.SaveChanges();
            }

            public void Delete(int id)
            {
                var pontoColeta = _context.PontosColeta.Find(id);
                if (pontoColeta != null)
                {
                    _context.PontosColeta.Remove(pontoColeta);
                    _context.SaveChanges();
                }
            }
        }
    }

}
