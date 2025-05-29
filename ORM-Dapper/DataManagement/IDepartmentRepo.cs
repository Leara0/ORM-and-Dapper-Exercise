namespace ORM_Dapper.DataManagement;

public interface IDepartmentRepo
{
    public IEnumerable<Department> GetAllProducts();
    
    public void InsertDepartment(Department department);
}