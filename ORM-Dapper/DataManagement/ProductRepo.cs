using System.Data;
using Dapper;

namespace ORM_Dapper.DataManagement;

public class ProductRepo : IProductRepo
{
    private readonly IDbConnection _connection;

    public ProductRepo(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products;");
    }

    public void CreateAProduct(string name, double price, int categoryID)
    {
        var item = new Product()
        {
            Name = name,
            Price = price,
            CategoryId = categoryID,
        };
        string sql = "INSERT INTO Products (Name, Price, CategoryID) " +
                     "VALUES (@Name, @Price, @CategoryID)";
        _connection.Execute(sql, item);
    }

    public void UpdateSaleItems(int discountPercentage)
    {
        double factor = 1 - (discountPercentage / 100.0);
        string sql = "UPDATE Products " +
                     "SET Price = Price * @Factor " +
                     "WHERE OnSale = 1";
        _connection.Execute(sql, new { Factor = factor });
    }

    public void DeleteProduct(int productId)
    {
        _connection.Execute("DELETE FROM reviews WHERE ProductID = @productId", new { productId });
        _connection.Execute("DELETE FROM sales WHERE ProductID = @productId", new { productId });
        _connection.Execute("DELETE FROM products WHERE ProductID = @productId", new { productId });
    }
}

//Create the DeleteProduct method HINT: You will need to delete records from the
//Sales table and the Reviews table where that Product may be referenced.
//You can do this all in the DeleteProduct method you are creating