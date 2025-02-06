using System.Collections.ObjectModel;
using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace Catalogo.ViewModels;

public partial class GraphViewModel: ObservableObject
{
    private readonly IServiceRepository<Product> _productService;
    private readonly IServiceRepository<Category> _categoryService;

    public ObservableCollection<ISeries> PieSeries { get; set; } = new();


    public GraphViewModel(IServiceRepository<Category> categoryService, IServiceRepository<Product> productService)
    {
        _categoryService = categoryService;
        _productService = productService;
        ConfigurePieSeries();
    }

    private void ConfigurePieSeries()
    {
        var products = _productService.ObtenerTodos();

        if (products == null || !products.Any())
        {
            return; // No hay productos, evitamos errores
        }

        var groupedProducts = products
            .GroupBy(p => p.Category?.Nombre ?? "Sin Categoría")
            .Select(group => new { Name = group.Key, Count = group.Count() });

        foreach (var group in groupedProducts)
        {
            PieSeries.Add(new PieSeries<int>
            {
                Name = group.Name,
                Values = new[] { group.Count }
            });

        }
    }

}
