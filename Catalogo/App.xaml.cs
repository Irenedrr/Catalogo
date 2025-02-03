using System.Windows;
using Catalogo.Data;
using Catalogo.Models;
using Catalogo.Repositories;
using Catalogo.Services;
using Catalogo.ViewModels;
using Catalogo.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalogo;


public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        ServiceCollection services = new(); 
        services.AddTransient<MainWindow>();
        services.AddTransient<MainViewModel>();


        services.AddScoped<IRepository<Category>, CategoryRepository>();
        services.AddScoped<IServiceRepository<Category>, CategoryService>();

        // Register IRepository<Product> and ProductService
        services.AddScoped<IRepository<Product>, ProductRepository>();
        services.AddScoped<IServiceRepository<Product>, ProductoService>();

        // Register AppDbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer("Server=localhost,1433;Database=YourDatabaseName;User Id=sa;Password=Interfaces-2425;TrustServerCertificate=True;"));

        var serviceProvider = services.BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.EnsureCreated();

            if (dbContext.Categories.Count<Category>() == 0)
            {
                dbContext.Categories.Add(new Category { Nombre = "Cosas" });
                dbContext.Categories.Add(new Category { Nombre = "Más cosas" });
                dbContext.Products.Add(new Product { Nombre = "Cosa 1", Descripcion = "Descripción de la cosa", Precio = 10, CategoryId = 1,Category = null });
                dbContext.Products.Add(new Product { Nombre = "Cosa 2", Descripcion = "Descripción de la cosa", Precio = 10, CategoryId = 2, Category = null });
                dbContext.Products.Add(new Product { Nombre = "Cosa 3", Descripcion = "Descripción de la cosa", Precio = 10, CategoryId = 1, Category = null });
                dbContext.Products.Add(new Product { Nombre = "Cosa 4", Descripcion = "Descripción de la cosa", Precio = 10, CategoryId = 1, Category = null });
                dbContext.Products.Add(new Product { Nombre = "Cosa 5", Descripcion = "Descripción de la cosa",Precio = 10, CategoryId = 2, Category = null });
            }

            dbContext.SaveChanges();
        }


        var view = serviceProvider.GetService<MainWindow>();
        view.DataContext = serviceProvider.GetService<MainViewModel>();

        view.Show();
    }

}
