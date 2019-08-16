using System;
using Microsoft.EntityFrameworkCore;
namespace TodoAPI.Data.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
             : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=MvcMovie.db");
        }
        public DbSet<TodoAPI.Data.Models.Movie> Movie { get; set; }
    }
}