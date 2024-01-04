using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarberBooking.Data;
using BarberBooking.Models;
using System.Net;

namespace BarberBooking.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public IndexModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int StilID { get; set; }

        public async Task OnGetAsync(int? id, int? stilID)
        {
            ServiciuD = new ServiciuData();

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Barber)
            .Include(b => b.ServiciuStiluri)
            .ThenInclude(b => b.Stil)
            .AsNoTracking()
            .OrderBy(b => b.Tip_Serviciu)
            .ToListAsync();
            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Stiluri = serviciu.ServiciuStiluri.Select(s => s.Stil);
            }
        }

        /*
        public async Task OnGetAsync()
        {
            if (_context.Serviciu != null)
            {
                Serviciu = await _context.Serviciu
                    .Include(b=>b.Barber)
                    .ToListAsync();
            }
        }*/
    }
}
