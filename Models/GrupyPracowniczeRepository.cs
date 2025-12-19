using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MVCWinFormsMasterDetail.Models
{
    internal class GrupyPracowniczeRepository: IGrupyPracowniczeRepository,IDisposable
    {
        private readonly AppDbContext _context;
        public GrupyPracowniczeRepository(AppDbContext context) => _context = context;

        public async Task<List<GrupaPracownicza>> GetAllWithPracownicyAsync()
        {
            return await _context.GrupyPracownicze.Include("Pracownicy").ToListAsync();
        }
        public async Task AddGrupaAsync(GrupaPracownicza grupa)
        {
            _context.GrupyPracownicze.Add(grupa);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateGrupaAsync(GrupaPracownicza g)
        {
            _context.GrupyPracownicze.AddOrUpdate(g);

            //change state saving
            await _context.SaveChangesAsync();
            //saved
        }
        public Task DeleteGrupaAsync(int id)
        {
            throw new NotImplementedException();
        }
        // podobne dla update (Attach + Entry.State = Modified lub bezpośrednie zmiany na tracked), delete, pracownicy
        public void Dispose()
        { 
            _context.Dispose(); 
        }

        

        
    }
}
