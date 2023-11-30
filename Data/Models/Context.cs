using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CoreandFood.Data.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-QTKFS4K;" +
                "database=DbCoreFood;integrated security=true");
        }
        public DbSet<Food> Foods { get; set; }//modelin içindekiler tablo formatında sıralanır
        public DbSet<Category> Categories { get; set; }
    }
}
