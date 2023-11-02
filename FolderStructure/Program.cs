//all usings can be transferred into separate GlobalUsings
using FolderStructure.Data.Context;
using FolderStructure.Data.Repository;
using FolderStructure.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//use sqlite as db for convenience 
//In memory db, which provide an ability 
//not to deploy some other servers sql\postgres\etc.
var connectionString = builder.Configuration.GetConnectionString("SqliteDb");
builder.Services.AddDbContext<FolderContext>(options =>
{
    options.UseSqlite(connectionString);
});
builder.Services.AddScoped<IFolderRepository, FolderRepository>();
builder.Services.AddTransient<IImporter, Importer>();
builder.Services.AddTransient<IParseStrategy, ParseTxt>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
