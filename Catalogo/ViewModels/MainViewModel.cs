using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Catalogo.ViewModels;

public partial class MainViewModel(IServiceRepository<Category> _categoryService, IServiceRepository<Product> _productService) : ObservableObject
{
    [ObservableProperty]
    private object _activeView;

    public CategoryViewModel CategoryViewModel { get; } = new CategoryViewModel(_categoryService);
    public HomeViewModel HomeViewModel { get; } = new HomeViewModel();
    public ProductViewModel ProductViewModel { get; } = new ProductViewModel(_productService);

   

    [RelayCommand]
    private void ActivateCategoryView() => ActiveView = CategoryViewModel;

    [RelayCommand]
    private void ActivateHomeView() => ActiveView = HomeViewModel;

    [RelayCommand]
    private void ActivateProductView() => ActiveView = ProductViewModel;
}
