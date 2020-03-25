using Microsoft.EntityFrameworkCore;

namespace PurchOrderWebApi.Models
{
    public class BCPurchOrderContext : DbContext 
    {
        public BCPurchOrderContext
            (DbContextOptions<BCPurchOrderContext> options) : base(options)
        {
            
        }

        public DbSet<BCPurchOrder> BCPurchOrder { get; set;}
    }
}