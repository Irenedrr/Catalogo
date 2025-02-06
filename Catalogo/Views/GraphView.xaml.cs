using System.Windows.Controls;
using Catalogo.Models;
using Catalogo.Services;
using Catalogo.ViewModels;


namespace Catalogo.Views;

public partial class GraphView : UserControl
{
    public GraphView()
    {
        InitializeComponent();
    }

    public GraphView(IServiceRepository<Category> categoryService, IServiceRepository<Product> productService)
    {
        InitializeComponent();
        DataContext = new GraphViewModel(categoryService, productService);
    }
}
