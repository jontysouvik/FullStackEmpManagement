using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using emp_mgmt_api.DataAccess;
using emp_mgmt_api.Models;

namespace emp_mgmt_api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        [HttpGet("status")]
        public string GetStatus()
        {
            return "working";
        }
        // GET api/employees
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            EmployeesDataAccess da = new EmployeesDataAccess();
            List<Employee> emplist = da.GetAllEmployees();

            return emplist;
        }

        // // GET api/employees/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            EmployeesDataAccess da = new EmployeesDataAccess();
            return da.GetEmployeeById(id);
        }

        // POST api/employees
        [HttpPost]
        public void Post([FromBody]Employee emp)
        {
            EmployeesDataAccess da = new EmployeesDataAccess();
            da.SaveEmployee(emp);

        }

        // // PUT api/employees/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee emp)
        {
            EmployeesDataAccess da = new EmployeesDataAccess();
            da.UpdateEmployee(id, emp);
        }

        // // DELETE api/employees/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EmployeesDataAccess da = new EmployeesDataAccess();
            da.DeleteEmployee(id);

        }
    }
}
