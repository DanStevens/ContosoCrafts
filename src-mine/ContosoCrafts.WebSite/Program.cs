using System.Text.Json;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);

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
app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddRazorPages();
    services.AddControllers();

    var jsonFilePath = Path.Combine(builder.Environment.WebRootPath, "data", "products.json");
    var productService = new InMemoryProductService(LoadProducts(jsonFilePath));
    services.AddSingleton<IProductService>(productService);

    //services.AddTransient<IProductService, JsonFileProductService>();
}

IEnumerable<Product> LoadProducts(string jsonFilePath)
{
    using (var jsonFileReader = File.OpenText(jsonFilePath))
    {
        return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
    }
}

