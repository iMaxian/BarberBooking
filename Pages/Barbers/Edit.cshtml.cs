using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarberBooking.Data;
using BarberBooking.Models;

namespace BarberBooking.Pages.Barbers
{
    public class EditModel : PageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public EditModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Barber Barber { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Barber == null)
            {
                return NotFound();
            }

            var barber =  await _context.Barber.FirstOrDefaultAsync(m => m.ID == id);
            if (barber == null)
            {
                return NotFound();
            }
            Barber = barber;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Barber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BarberExists(Barber.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BarberExists(int id)
        {
          return (_context.Barber?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
