using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BarberBooking.Data;
using BarberBooking.Models;

namespace BarberBooking.Pages.Barbers
{
    public class IndexModel : PageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public IndexModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

        public IList<Barber> Barber { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Barber != null)
            {
                Barber = await _context.Barber.ToListAsync();
            }
        }
    }
}
