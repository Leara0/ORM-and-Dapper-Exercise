namespace ORM_Dapper.DataManagement;

public interface IDepartmentRepo
{
    public IEnumerable<Department> GetAllDepartments();
    
    public void InsertDepartment(Department department);
}