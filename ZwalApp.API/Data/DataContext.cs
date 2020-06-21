using Microsoft.EntityFrameworkCore;
using ZwalApp.API.Models;

namespace ZwalApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}
        public DbSet<Value> Values { get; set; }
        
    }
}