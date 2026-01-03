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
                grupa.IdGrupyPracowniczej = grupa.IdGrupyPracowniczej;  // Już ustawione
                foreach (var p in grupa.Pracownicy.Where(p => p.IdPracownika == 0)) p.IdPracownika = p.IdPracownika;
            }
        }
        public async Task UpdateGrupaAsync(GrupaPracownicza grupaFromUI)
        {
            //change state saving
            using (var context = new AppDbContext())
            {
                var grupaFromDb = await context.GrupyPracownicze
                 .Include(g => g.Pracownicy)
                 .FirstAsync(g => g.IdGrupyPracowniczej == grupaFromUI.IdGrupyPracowniczej);

                grupaFromDb.NazwaGrupyPracowniczej = grupaFromUI.NazwaGrupyPracowniczej;

                var uiIds = grupaFromUI.Pracownicy.Select(p => p.IdPracownika).ToList();
                var toRemove = grupaFromDb.Pracownicy.Where(p => p.IdPracownika != 0 && !uiIds.Contains(p.IdPracownika));
                context.Pracownicy.RemoveRange(toRemove);

                foreach (var p in grupaFromUI.Pracownicy)
                {
                    if (p.IdPracownika == 0)
                        grupaFromDb.Pracownicy.Add(p);
                    else
                    {
                        var existing = grupaFromDb.Pracownicy.First(x => x.IdPracownika == p.IdPracownika);
                        existing.Imie = p.Imie;
                        existing.Nazwisko = p.Nazwisko;
                    }
                }
                await context.SaveChangesAsync();
                //saved
            }
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
        //public async Task AddPracownikAsync(GrupaPracownicza grupa,Pracownik pracownik)
        //{
        //    using (var context = new AppDbContext())
        //    {
        //        context.Entry(grupa).State = EntityState.Modified;
                
        //        await context.SaveChangesAsync();
        //    }
        //}
        // podobne dla update (Attach + Entry.State = Modified lub bezpośrednie zmiany na tracked), delete, pracownicy
        public void Dispose()
        { 
            //_context.Dispose(); 
        }

        

        
    }
}
