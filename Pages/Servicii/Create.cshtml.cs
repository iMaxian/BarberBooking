using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BarberBooking.Data;
using BarberBooking.Models;

namespace BarberBooking.Pages.Servicii
{
    public class CreateModel : ServiciuStiluriPageModel
    {
        private readonly BarberBooking.Data.BarberBookingContext _context;

        public CreateModel(BarberBooking.Data.BarberBookingContext context)
        {
            _context = context;
        }

       

        public IActionResult OnGet()
        { 
            var barberList = _context.Barber.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });

            ViewData["BarberID"] = new SelectList(_context.Set<Barber>(), "ID", "NumeComplet");
            ViewData["BarberShopID"] = new SelectList(_context.Set<BarberShop>(), "ID", "BarberShop");

            var serviciu = new Serviciu();
            serviciu.ServiciuStiluri = new List<ServiciuStil>();
            PopulateStilAtribuitServiciu(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedStiluri)
        {
            var newServiciu = new Serviciu();
            if (selectedStiluri != null)
            {
                newServiciu.ServiciuStiluri = new List<ServiciuStil>();
                foreach (var cat in selectedStiluri)
                {
                    var catToAdd = new ServiciuStil
                    {
                        StilID = int.Parse(cat)
                    };
                    newServiciu.ServiciuStiluri.Add(catToAdd);
                }
            }
            Serviciu.ServiciuStiluri = newServiciu.ServiciuStiluri;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

        /*
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Serviciu == null || Serviciu == null)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }*/
    }
}
