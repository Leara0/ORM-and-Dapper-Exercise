using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper.DataManagement;

namespace ORM_Dapper
{
    public class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("BestBuysConnection");

            IDbConnection connection = new MySqlConnection(connectionString);

            #region departments

            var departmentRepo = new DepartmentRepo(connection);
            var department = departmentRepo.GetAllProducts();

            //foreach (var dept in department)
            //{
            //   Console.WriteLine($"DeptID: {dept.DepartmentId} | Name: {dept.Name}");
            //}

            var category = new Department()
            {
                Name = "Food"
            };
            //departmentRepo.InsertDepartment(category); it worked!!!

            #endregion

            #region products

            var productRepo = new ProductRepo(connection);
            var product = productRepo.GetAllProducts();
            //productRepo.CreateAProduct("Broke phone", 0.00, 3); works!!
            
            // productRepo.UpdateSaleItems(5); works!
            #endregion
        }
    }
}