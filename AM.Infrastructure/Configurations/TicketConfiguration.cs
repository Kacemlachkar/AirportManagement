using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new
            {
                t.FlightFK,
                t.PassengerFK,
                t.TicketNbre,

            });

            builder.HasOne(t => t.Flignt)
               .WithMany(f => f.Tickets)
               .HasForeignKey(t => t.FlightFK);

            builder.HasOne(t => t.Passenger)
              .WithMany(p => p.Tickets)
              .HasForeignKey(t => t.PassengerFK);
        }
    }
}
