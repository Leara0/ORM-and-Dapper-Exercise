namespace ORM_Dapper.DataManagement;

public interface IProductRepo
{
    public IEnumerable<Product> GetAllProducts();
    public void CreateAProduct(string name, double price, int categoryID);
    public void UpdateSaleItems(int discountPercentage);

    public void DeleteProduct(string name);
}