using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using LiveChartsCore.Kernel.Sketches;

namespace Catalogo.ViewModels;

public partial class GraphViewModel: ObservableObject
{
    private readonly IServiceRepository<Product> _productService;
    private readonly IServiceRepository<Category> _categoryService;

    [ObservableProperty]
    private ObservableCollection<ISeries> _PieSeries = new();

    public GraphViewModel(IServiceRepository<Category> categoryService, IServiceRepository<Product> productService)
    {
        _categoryService = categoryService;
        _productService = productService;
        ConfigurePieSeries();
    }

    private void ConfigurePieSeries()
    {

        var groupedProducts = _productService.ObtenerTodos()
            .GroupBy(p => p.Category.Nombre)
            .Select(group => new { Name = group.Key, Count = group.Count() });

        foreach (var group in groupedProducts)
        {
            PieSeries.Add(new PieSeries
            {
                Name = group.Name,
                Values = new[] { (double)group.Count }  // Convertimos Count a double
            });
        }
    }
}
