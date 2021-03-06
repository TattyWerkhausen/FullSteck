using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository.Data;

namespace ProAgil.Repository
{
     public class ProAgilRepository : IProAgilRepository
    {
    private readonly ProAgilContext _context;
    public ProAgilRepository(ProAgilContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    //Gerais
        public void Add<T>(T entity) where T : class
        {
           _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
              _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
              _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

        //Evento
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            //tracking individual
            query = query.AsNoTracking().OrderByDescending(c => c.Data);
            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetEventoAsyncById(int EventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
            query = query.OrderByDescending(c => c.Data).Where(c => c.Id == EventoId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        { 
            IQueryable<Evento> query = _context.Eventos
            .Include(c => c.Lotes)
            .Include(c => c.RedesSociais);

            if(includePalestrantes){
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(pe => pe.Palestrante);
            }
             query = query.OrderBy(p => p.Tema.ToLower().Contains(tema.ToLower()));
            return await query.ToArrayAsync();
        }
         // Palestrante
        public async Task<Palestrante[]> GetAllPalestranteAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(e => e.Evento);
            }
            query = query.OrderBy(p => p.Nome.ToLower().Contains(name.ToLower()));
            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetPalestranteAsync(int PalestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
            .Include(c => c.RedesSociais);

            if(includeEventos){
                query = query
                .Include(pe => pe.PalestranteEventos)
                .ThenInclude(e => e.Evento);
            }
            query = query.OrderBy(p => p.Nome).Where(p => p.Id == PalestranteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}