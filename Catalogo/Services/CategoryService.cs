using Catalogo.Models;
using Catalogo.Repositories;

namespace Catalogo.Services;

public class CategoryService(IRepository<Category> categoryRepository) : IServiceRepository<Category>
{
    public void Actualizar(Category obj)
    {
        categoryRepository.Actualizar(obj);
    }

    public void Agregar(Category obj)
    {
        categoryRepository.Agregar(obj);
    }

    public void Eliminar(Category obj)
    {
        categoryRepository.Eliminar(obj);

    }

    public Category ObtenerPorId(int id)
    {
        return categoryRepository.ObtenerPorId(id);
    }

    public List<Category> ObtenerTodos()
    {
        return categoryRepository.ObtenerTodos();
    }
}
