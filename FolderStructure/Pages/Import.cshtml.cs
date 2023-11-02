using FolderStructure.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FolderStructure.Pages;

public class ImportModel : PageModel
{
    private readonly IImporter _importer;

    public string Message { get; set; }
    public IFormFile ImportedFile { get; set; }

    public ImportModel(IImporter importer) => _importer = importer;
    public async Task<IActionResult> OnPostAsync()
    {
        var status = await _importer.ImportFile(ImportedFile);
        Message = status == true
            ? "File succesfully imported"
            : "Something went wrong";

        return RedirectToPage("/Index");
    }

    public void OnGet()
    {
    }
}
