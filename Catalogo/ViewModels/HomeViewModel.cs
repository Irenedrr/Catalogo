using Catalogo.Models;
using Catalogo.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Catalogo.ViewModels;

public partial class HomeViewModel(IServiceRepository<Product> _productService, IServiceRepository<Category> _categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(_categoryService.ObtenerTodos());
    [ObservableProperty]
    private ObservableCollection<Product> _products = new(_productService.ObtenerTodos());

}
