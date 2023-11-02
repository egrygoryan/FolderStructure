using FolderStructure.Data.Configuration;
using FolderStructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderStructure.Data.Context;

public class FolderContext : DbContext
{
    //As type parameter for DBSet must be used separate entity
    //just for saving time the model class is used
    internal DbSet<Folder> Folders { get; set; }

    public FolderContext(DbContextOptions<FolderContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new FolderConfiguration());
    }
}