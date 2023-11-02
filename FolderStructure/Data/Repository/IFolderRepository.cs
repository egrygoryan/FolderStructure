using FolderStructure.Domain.Models;

namespace FolderStructure.Data.Repository;

public interface IFolderRepository
{
    Task<Folder?> GetFolderById(int id);
    Task<IEnumerable<Folder>> GetNestedFolders(int parentId);
    Task<IEnumerable<Folder>> GetAllFolders();
    Task AddFolders(IEnumerable<Folder> folders);
}
