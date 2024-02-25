using POC.ApiPostgreDapper.Entities;

namespace POC.ApiPostgreDapper.Services
{
    public interface IEmployeeService
    {
        Task<bool> Create(Employee employee);
        Task<Employee> Get(int id);
        Task<IEnumerable<Employee>> GetList();
        Task<Employee> Update(Employee employee);
        Task<bool> Delete(int id);
    }
}
