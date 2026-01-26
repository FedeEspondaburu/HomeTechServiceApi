using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class HomeTechServiceDBContext : DbContext
    {
        public HomeTechServiceDBContext(DbContextOptions<HomeTechServiceDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
    }
}
