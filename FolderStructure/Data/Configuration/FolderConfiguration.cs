using FolderStructure.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FolderStructure.Data.Configuration;

public class FolderConfiguration : IEntityTypeConfiguration<Folder>
{
    // Seeding data for DB
    public void Configure(EntityTypeBuilder<Folder> builder)
    {
        builder.HasData(
            new Folder() { Id = 1, FolderName = "Creating Digital Images", ParentId = null },
            new Folder() { Id = 2, FolderName = "Resources", ParentId = 1 },
            new Folder() { Id = 3, FolderName = "Evidence", ParentId = 1 },
            new Folder() { Id = 4, FolderName = "Graphic Products", ParentId = 1 },
            new Folder() { Id = 5, FolderName = "Primary Sources", ParentId = 2 },
            new Folder() { Id = 6, FolderName = "Secondary Sources", ParentId = 2 },
            new Folder() { Id = 7, FolderName = "Process", ParentId = 4 },
            new Folder() { Id = 8, FolderName = "Final Product", ParentId = 4 });
    }
}