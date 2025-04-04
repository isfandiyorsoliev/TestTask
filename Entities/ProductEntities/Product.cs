namespace ProductTask.Entities.ProductEntities;

public class Product: BaseEntityWithDeleted
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}