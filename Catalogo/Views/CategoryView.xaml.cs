using System.Windows;
using System.Windows.Controls;
using Catalogo.Models;
using Catalogo.Repositories;
using Catalogo.Services;
using Catalogo.ViewModels;

namespace Catalogo.Views;

public partial class CategoryView : UserControl
{
    private readonly IRepository<Category> _repository;

    public CategoryView()
    {
        InitializeComponent();
    }

    public CategoryView(IRepository<Category> repository, IServiceRepository<Category> categoryService)
    {
        InitializeComponent();
        _repository = repository;
        DataContext = new CategoryViewModel(categoryService);
    }
}
