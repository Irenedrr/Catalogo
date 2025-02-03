namespace Catalogo.Repositories;

public interface IRepository<T> where T : class
{
    public List<T> ObtenerTodos(); 
    public T ObtenerPorId(int id); 
    public void Agregar(T obj); 
    public void Actualizar(T obj); 
    public void Eliminar(T obj); 
}
