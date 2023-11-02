using FolderStructure.Data.Context;
using FolderStructure.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FolderStructure.Data.Repository;

public class FolderRepository : IFolderRepository
{
    private readonly FolderContext _ctx;
    public FolderRepository(FolderContext ctx) => _ctx = ctx;

    public async Task AddFolders(IEnumerable<Folder> folders)
    {
        await _ctx.AddRangeAsync(folders);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Folder>> GetAllFolders()
    {
        var all = await _ctx.Folders.ToListAsync();
        return all.Any() ? all : Enumerable.Empty<Folder>();
    }

    public async Task<Folder?> GetFolderById(int id) =>
        await _ctx.Folders.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<IEnumerable<Folder>> GetNestedFolders(int parentId)
    {
        var nested = await _ctx.Folders.Where(x => x.ParentId == parentId).ToListAsync();
        return nested.Any() ? nested : Enumerable.Empty<Folder>();
    }
}
