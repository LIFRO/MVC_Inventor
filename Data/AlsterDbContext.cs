using Microsoft.EntityFrameworkCore;
using MVC_Training.Models;

public class AlsterDbContext : DbContext
{
    public AlsterDbContext(DbContextOptions<AlsterDbContext> options) : base(options){}
    
    public DbSet<Alster> Alsters {get; set;}
}