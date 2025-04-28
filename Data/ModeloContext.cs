using AppModelos.Models;
using Microsoft.EntityFrameworkCore;

namespace AppModelos.Data
{
    public class ModeloContext : DbContext
    {
        public DbSet<ModeloModel> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=modelos.sqlite");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
