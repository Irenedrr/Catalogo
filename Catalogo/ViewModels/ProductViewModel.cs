using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catalogo.ViewModels;

public partial class ProductViewModel(IServiceRepository<Product> _productService, IServiceRepository<Category> _categoryService) : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Product> products = new(_productService.ObtenerTodos());

    [ObservableProperty]
    private ObservableCollection<Category> categories = new(_categoryService.ObtenerTodos());

    [ObservableProperty]
    private Product? selectedProduct = new();

    private void Limpiar()
    {
        SelectedProduct = new Product();
    }

    [RelayCommand]
    private void AddProduct()
    {
        if (SelectedProduct == null || string.IsNullOrWhiteSpace(SelectedProduct.Nombre))
            return;

        _productService.Agregar(SelectedProduct);
        Products.Add(SelectedProduct);
        Limpiar();
    }

    [RelayCommand]
    private void EditProduct()
    {
        if (SelectedProduct == null)
            return;

        _productService.Actualizar(SelectedProduct);
        Limpiar();
    }

    [RelayCommand]
    private void DeleteProduct()
    {
        if (SelectedProduct == null)
            return;

        _productService.Eliminar(SelectedProduct);
        Products.Remove(SelectedProduct);
        Limpiar();
    }

    [RelayCommand]
    private void UploadPhoto()
    {
        OpenFileDialog openFileDialog = new()
        {
            Filter = "Imagenes|*.jpg;*.jpeg;*.png;*.bmp;*.gif"
        };
        if (openFileDialog.ShowDialog() == true)
        {
            SelectedProduct.Foto = openFileDialog.FileName;
        }
    }

}

