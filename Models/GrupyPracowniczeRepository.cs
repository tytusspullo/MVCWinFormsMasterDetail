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
        public GrupyPracowniczeRepository()
        { 
            
        }

        public async Task<List<GrupaPracownicza>> GetAllWithPracownicyAsync()
        {
            using (var context = new AppDbContext())
            {
                return await context.GrupyPracownicze
                    .Include("Pracownicy")
                    .ToListAsync();
            }
        }
        public async Task AddGrupaAsync(GrupaPracownicza grupa)
        {
            using (var context = new AppDbContext())
            {
                context.GrupyPracownicze.Add(grupa);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateGrupaAsync(GrupaPracownicza grupa)
        {
            //change state saving
            using (var context = new AppDbContext())
            {
                context.Entry(grupa).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            //saved
        }
        public async Task DeleteGrupaAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                var grupa = await context.GrupyPracownicze.FindAsync(id);
                if (grupa != null)
                {
                    context.GrupyPracownicze.Remove(grupa);
                    await context.SaveChangesAsync();
                }
            }
        }
        // podobne dla update (Attach + Entry.State = Modified lub bezpośrednie zmiany na tracked), delete, pracownicy
        public void Dispose()
        { 
            //_context.Dispose(); 
        }

        

        
    }
}
