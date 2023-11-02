using FolderStructure.Domain.Models;

namespace FolderStructure.Domain.Services;

public class ParseTxt : IParseStrategy
{
    public IEnumerable<Folder> ParseData(string text)
    {
        var resultSet = new List<Folder>();
        //dividing string for rows
        try
        {
            var arr = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
            foreach (var line in arr)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;
                //divide each row into separate parts
                var data = line.Split(',');
                var folder = new Folder
                {
                    Id = int.Parse(data[0]),
                    FolderName = data[1],
                    ParentId = int.Parse(data[2])
                };
                resultSet.Add(folder);
            }

        } catch
        {
            throw new InvalidOperationException("Can't perform data parsing");
        }

        return resultSet;
    }
}
