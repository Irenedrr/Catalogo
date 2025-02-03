using Catalogo.Models;
using Catalogo.Repositories;

namespace Catalogo.Services;

public class ProductoService(IRepository<Product> productRepository) : IServiceRepository<Product>
{
    public void Actualizar(Product obj)
    {
       productRepository.Actualizar(obj);
    }

    public void Agregar(Product obj)
    {
        productRepository.Agregar(obj);
    }

    public void Eliminar(Product obj)
    {
        productRepository.Eliminar(obj);
    }

    public Product ObtenerPorId(int id)
    {
        return productRepository.ObtenerPorId(id);
    }

    public List<Product> ObtenerTodos()
    {
        return productRepository.ObtenerTodos();
    }
}
