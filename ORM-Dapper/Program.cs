using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

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
            
            var departmentRepo = new DepartmentRepo(connection);
            var department = departmentRepo.GetAllProducts();
            foreach (var dept in department)
            {
                Console.WriteLine($"DeptID: {dept.DepartmentId} | Name: {dept.Name}");
            }
        }
    }
}
