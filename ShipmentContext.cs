using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace c_
{

 public class ShipmentContext: DbContext
    {
    

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=DESKTOP-M9PRPPC\MSSQLSERVER01;database=TMS;trusted_connection=true;");
        }
        public DbSet<Shipment> Shipments { get; set; }
        
    }


}