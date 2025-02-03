namespace Catalogo.Services;

public interface IServiceRepository<T> where T : class
{
    public void Agregar(T obj);            
    T ObtenerPorId(int id);               
    List<T> ObtenerTodos();           
    void Eliminar(T obj);         
    void Actualizar(T obj);
}
