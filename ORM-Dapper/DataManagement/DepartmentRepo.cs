using System.Data;
using Dapper;
using ORM_Dapper;
using ORM_Dapper.DataManagement;


public class DepartmentRepo : IDepartmentRepo
{
    private readonly IDbConnection _connection;

    public DepartmentRepo(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Department> GetAllProducts()
    {
        return _connection.Query<Department>("SELECT * FROM Departments;");
    }

    public void InsertDepartment(Department department)
    {
        _connection.Execute("INSERT INTO Departments (Name) VALUES (@Name)", department);
    }
}