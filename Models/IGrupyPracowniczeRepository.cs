using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCWinFormsMasterDetail.Models
{
    public interface IGrupyPracowniczeRepository
    {
        Task<List<GrupaPracownicza>> GetAllWithPracownicyAsync();
        Task AddGrupaAsync(GrupaPracownicza g);
        Task UpdateGrupaAsync(GrupaPracownicza g);
        Task DeleteGrupaAsync(int id);
    }
}
