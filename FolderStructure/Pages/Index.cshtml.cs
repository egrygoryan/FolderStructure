using FolderStructure.Data.Repository;
using FolderStructure.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FolderStructure.Pages;
public class IndexModel : PageModel
{
    private readonly IFolderRepository _repo;
    public Folder? Folder { get; set; }
    public IEnumerable<Folder> AllFolders { get; set; }
    public IEnumerable<Folder> NestedFolders { get; set; }
    public string? Message { get; set; }
    public IndexModel(IFolderRepository repo) => _repo = repo;

    public async Task<IActionResult> OnGet(int? id)
    {
        Folder = await _repo.GetFolderById(id ?? 1);
        switch (Folder)
        {
            case not null:
                NestedFolders = await _repo.GetNestedFolders(Folder.Id);
                AllFolders = await _repo.GetAllFolders();
                break;
            default:
                Message = "Folder doesn't exist";
                break;
        }

        return Page();
    }
}
