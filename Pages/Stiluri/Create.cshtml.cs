using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarberBooking.Data;
using BarberBooking.Models;

namespace BarberBooking.Pages.Stiluri
{
    public class CreateModel : PageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public CreateModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Stil Stil { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Stil == null || Stil == null)
            {
                return Page();
            }

            _context.Stil.Add(Stil);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
