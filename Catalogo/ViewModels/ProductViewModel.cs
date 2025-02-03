using Catalogo.Models;
using Catalogo.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Catalogo.ViewModels;

public partial class ProductViewModel(IServiceRepository<Product> _productService) : ObservableObject
{
   
}

