using EmployeeListAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeeListAPI.Data
{
    public class EmployeeRepository
    {
        private readonly EmployeeDbContext _context;

        public EmployeeRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.FromSqlRaw("EXEC GetAllEmployees").ToListAsync ();
        }

        public async Task<List<Employee>> GetCurrentEmployees()
        {
            return await _context.Employees.FromSqlRaw("EXEC GetCurrentEmployee").ToListAsync();
        }

        public async Task InsertEmployee(Employee employee)
        {
            await _context.Database.ExecuteSqlRawAsync("EXEC InsertEmployee @name, @age, @phone_number, @date_of_birth, @address,@job_title, @salary",
                new SqlParameter("@name", employee.name),
                new SqlParameter("@age", employee.age),
                new SqlParameter("@phone_number", employee.phone_number),
                new SqlParameter("@date_of_birth", employee.date_of_birth.ToDateTime(TimeOnly.MinValue)), 
                new SqlParameter("@address", employee.address),
                new SqlParameter("@job_title", employee.job_title),
                new SqlParameter("@salary", employee.salary));
        }

        public async Task UpdateEmployee(Employee employee)
        {
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC UpdateEmployee @empId, @name, @age, @phone_number, @date_of_birth, @address, @job_title, @salary",
                new SqlParameter("@empId", employee.empId),
                new SqlParameter("@name", employee.name),
                new SqlParameter("@age", employee.age),
                new SqlParameter("@phone_number", employee.phone_number),
                new SqlParameter("@date_of_birth", employee.date_of_birth),
                new SqlParameter("@address", employee.address),
                new SqlParameter("@job_title", employee.job_title),
                new SqlParameter("@salary", employee.salary));
        }

        public async Task RemoveCurrentEmployee(int id)
        {
            var param = new SqlParameter("@empId", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC RemoveCurrentEmployee @empId", param);
        }

        public async Task RetrieveEmployee(int id)
        {
            var param = new SqlParameter("@empId", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC RetrieveEmployee @empId", param);
        }

        public async Task DeleteEmployee(int id)
        {
            var param = new SqlParameter("@empId", id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmployee @empId", param);
        }

    }
}
