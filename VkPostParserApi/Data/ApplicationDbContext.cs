using Microsoft.EntityFrameworkCore;
using VkPostParserApi.Models;

namespace VkPostParserApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<OccurrenceLetter> OccurenceLetters { get; set; }
}