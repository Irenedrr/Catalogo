namespace Catalogo.Models;

public class Category
{
    public int Id { get; set; }
    public string Nombre { get; set; }

    public List<Product> Products { get; set; }
}
