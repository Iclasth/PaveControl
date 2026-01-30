using Microsoft.EntityFrameworkCore;
using PaveControl.Models;

namespace PaveControl.Data
{
    public class PaveControlDbContext : DbContext
    {
        public PaveControlDbContext(DbContextOptions<PaveControlDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
    }
}
