﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class EmployeesController : ControllerBase
    {
        static List<Employee> employees;
        static EmployeesController()
        {
            employees = new List<Employee>()
            {
            new Employee() { EmployeeId = 1, Name = "Narendra", DOJ = new DateTime(2014, 11, 5), Designation = "Trainee", Salary = 12222.20M },
            new Employee() { EmployeeId = 2, Name = "Narendra", DOJ = new DateTime(2014, 11, 5), Designation = "Trainee", Salary = 12222.20M },
            new Employee() { EmployeeId = 3, Name = "Narendra", DOJ = new DateTime(2014, 11, 5), Designation = "Trainee", Salary = 12222.20M },
            new Employee() { EmployeeId = 4, Name = "Narendra", DOJ = new DateTime(2014, 11, 5), Designation = "Trainee", Salary = 12222.20M },
            };
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            if(employees.Count > 0)
            {
                return Ok(employees);

            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            if(employee == null)
            {
                return BadRequest();
            }
            else
            {
                employees.Add(employee);
                return CreatedAtAction(nameof(GetAllEmployees), new { id = employee.EmployeeId, message = "Data added" });
            }
        }

        [HttpPut]
        public IActionResult PutEmplyoee(int id , Employee employee)
        {
            if(id != employee.EmployeeId)
            {
                return BadRequest();
            }
            var existingEmployee = employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if(existingEmployee == null)
            {
                return NotFound();
            }
            existingEmployee.Name = employee.Name;
            existingEmployee.Designation = employee.Designation;
            existingEmployee.DOJ = employee.DOJ;
            existingEmployee.Salary = employee.Salary;
            return Ok(existingEmployee);
        }

        [HttpDelete]
        
        public IActionResult DeleteEmployee(int id)
        {
            var existingEmployee = employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            if(existingEmployee == null)
            {
                return NotFound();
            }
            employees.Remove(existingEmployee);
            return Ok(existingEmployee.EmployeeId + "Removed");
        }
    }
}
