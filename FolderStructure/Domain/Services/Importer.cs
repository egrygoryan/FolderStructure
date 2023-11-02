using FolderStructure.Data.Repository;
using System.Text;

namespace FolderStructure.Domain.Services;

public class Importer : IImporter
{
    private readonly IParseStrategy _parseStrategy;
    private readonly IFolderRepository _repo;
    public Importer(IParseStrategy parseStrategy,
        IFolderRepository repo) =>
        (_parseStrategy, _repo) = (parseStrategy, repo);

    public async Task<bool> ImportFile(IFormFile file)
    {
        if (file is not null && file.Length > 0)
        {
            var sb = new StringBuilder();
            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    sb.AppendLine(await reader.ReadLineAsync());
            }
            var result = _parseStrategy.ParseData(sb.ToString());
            await _repo.AddFolders(result);

            return true;
        }
        return false;
    }
}
