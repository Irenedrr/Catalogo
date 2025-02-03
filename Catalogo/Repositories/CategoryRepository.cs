using Catalogo.Data;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositories;

public class CategoryRepository(AppDbContext context) : IRepository<Category>
{
    private readonly AppDbContext _context = context;

    public void Actualizar(Category obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Agregar(Category obj)
    {
        _context.Categories.Add(obj);
        _context.SaveChanges();
    }
    
    public void Eliminar(Category obj)
    {
        var existe = _context.Categories.FirstOrDefault(e => e.Id == obj.Id);

        if (existe != null)
        {
            _context.Categories.Remove(existe);
            _context.SaveChanges();
        }

    }

    public Category ObtenerPorId(int id)
    {
        return _context.Categories.Find(id);
    }

    public List<Category> ObtenerTodos()
    {
        return [.. _context.Categories];

    }
}
