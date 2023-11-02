namespace FolderStructure.Domain.Services;

public interface IImporter
{
    Task<bool> ImportFile(IFormFile file);
}