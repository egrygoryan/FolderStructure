using FolderStructure.Domain.Models;

namespace FolderStructure.Domain.Services;

public interface IParseStrategy
{
    IEnumerable<Folder> ParseData(string text);
}
