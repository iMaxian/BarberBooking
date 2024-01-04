using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BarberBooking.Models;

namespace BarberBooking.Data
{
    public class BarberBookingContext : DbContext
    {
        public BarberBookingContext (DbContextOptions<BarberBookingContext> options)
            : base(options)
        {
        }

        public DbSet<BarberBooking.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<BarberBooking.Models.Barber>? Barber { get; set; }
    }
}
