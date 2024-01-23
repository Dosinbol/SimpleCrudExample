using CrudExample.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudExample.Data
{
    public class ProjectContext : DbContext
    {
        public DbSet<Parent> Parents { get; set; }
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }
    }
}
