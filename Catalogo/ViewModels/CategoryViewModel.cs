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

    [ObservableProperty]
    private Category? selectedCategory = new();

    private void Limpiar()
    {
        SelectedCategory = new Category();
    }

    [RelayCommand]
    private void AddCategory()
    {
        if (SelectedCategory == null || string.IsNullOrWhiteSpace(SelectedCategory.Nombre))
            return;

        _categoryService.Agregar(SelectedCategory);
        Categories.Add(SelectedCategory);
        Limpiar();
    }

    [RelayCommand]
    private void EditCategory()
    {
        if (SelectedCategory == null)
            return;

        _categoryService.Actualizar(SelectedCategory);
        Limpiar();
    }

    [RelayCommand]
    private void DeleteCategory()
    {
        if (SelectedCategory == null)
            return;

        _categoryService.Eliminar(SelectedCategory);
        Categories.Remove(SelectedCategory);
        Limpiar();
    }

}
