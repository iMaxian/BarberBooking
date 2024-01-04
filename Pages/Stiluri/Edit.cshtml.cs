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

namespace BarberBooking.Pages.Stiluri
{
    public class EditModel : PageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public EditModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Stil Stil { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stil == null)
            {
                return NotFound();
            }

            var stil =  await _context.Stil.FirstOrDefaultAsync(m => m.ID == id);
            if (stil == null)
            {
                return NotFound();
            }
            Stil = stil;
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

            _context.Attach(Stil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StilExists(Stil.ID))
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

        private bool StilExists(int id)
        {
          return (_context.Stil?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
