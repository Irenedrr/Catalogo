using Catalogo.Data;
using Catalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalogo.Repositories;

public class ProductRepository(AppDbContext context) : IRepository<Product>
{
    private readonly AppDbContext _context = context;
    public void Actualizar(Product obj)
    {
        _context.Entry(obj).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Agregar(Product obj)
    {
        if (string.IsNullOrEmpty(obj.Descripcion))
        {
            throw new ArgumentException("Descripcion cannot be null or empty");
        }
        _context.Products.Add(obj);
        _context.SaveChanges();
    }


    public void Eliminar(Product obj)
    {
        var existe = _context.Products.FirstOrDefault(e => e.Id == obj.Id);

        if (existe != null)
        {
            _context.Products.Remove(existe);
            _context.SaveChanges();
        }
    }

    public Product ObtenerPorId(int id)
    {
        return _context.Products.Find(id);
    }

    public List<Product> ObtenerTodos()
    {
        return [.. _context.Products];
    }
}
