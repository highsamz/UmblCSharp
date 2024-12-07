using System.Collections.Generic;
using System.Linq;
using Umbl.Data.Contexts;
using Umbl.Models;
using Microsoft.EntityFrameworkCore;
using Umbl.Data.Repository.Umbl.Data.Repository;

namespace Umbl.Data.Repository
{
    using global::Umbl.Data.Contexts.Umbl.Data.Contexts;
    using global::Umbl.Services;
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

            public PaginatedResult<PontoColetaModel> GetAllPaginated(int pageNumber, int pageSize)
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    throw new ArgumentException("O número da página e o tamanho da página devem ser maiores que zero.");
                }

                try
                {
                    var query = _context.PontosColeta.Include(p => p.EnderecoPontoColetaModel);

                var totalItems = query.Count();

                var items = query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                return new PaginatedResult<PontoColetaModel>
                {
                    Items = items,
                    TotalItems = totalItems,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
                };
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao obter os dados paginados", ex);
                }
            }



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

            public IEnumerable<PontoColetaModel> GetAll()
            {
                throw new NotImplementedException();
            }
        }
    }

}
