using System.Collections.ObjectModel;
using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Catalogo.ViewModels;

public partial class CategoryViewModel(IServiceRepository<Category> _categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Category> _categories = new(_categoryService.ObtenerTodos());
    [ObservableProperty] private string nombre;


    private void Limpiar()
    {
        Nombre = string.Empty;
    }

    [RelayCommand]
    private void AddProduct(object parameter)
    {
        if (string.IsNullOrWhiteSpace(Nombre))
            return;

        var category = new Category
        {
            Nombre = Nombre

        };

        _categoryService.Agregar(category);
        Categories.Add(category);

        Limpiar();

    }

}
