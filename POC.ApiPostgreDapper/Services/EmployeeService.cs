using POC.ApiPostgreDapper.Entities;

namespace POC.ApiPostgreDapper.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbService _dbService;

        public EmployeeService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<bool> Create(Employee employee)
        {
            int result = await _dbService.ExecuteAsync("INSERT INTO public.Employee (id,name,age,address,mobilenumber) VALUES (@Id,@Name,@Age,@Address,@MobileNumber)", employee);
            return result > 0;
        }

        public async Task<bool> Delete(int id)
        {
            int result = await _dbService.ExecuteAsync("DELETE FROM public.employee WHERE id=@id", new { id });
            return result > 0;
        }

        public async Task<Employee> Get(int id)
        {
            Employee? employee = await _dbService.GetAsync<Employee>("SELECT * FROM public.employee where id=@id", new { id });
            employee ??= new();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetList()
        {
            IEnumerable<Employee> employees = await _dbService.GetAllAsync<Employee>("SELECT * FROM public.employee", new { });
            return employees;
        }

        public async Task<Employee> Update(Employee employee)
        {
            int updateEmployee = await _dbService.ExecuteAsync("UPDATE public.employee SET name=@Name, age=@Age, address=@Address, mobilenumber=@MobileNumber WHERE id=@Id", employee);

            return employee;
        }
    }
}
