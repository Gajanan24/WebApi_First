using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_First.Models;

namespace WebApi_First.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public List<Employee> GetEmployees() 
        {
            List<Employee> list=new List<Employee>();

             using( var db=new organizationContext() )
            {
                    list=db.Employees.ToList();
                    

            }
            return list;
        }
        [HttpPost]
        public String InsertEmp(Employee emp)
        {
            using( var db=new organizationContext() )
            {
                db.Employees.Add( emp );
                db.SaveChanges();
            }

            return "Employee added Successfully";
        }

        [HttpGet]
        public Employee GetEmployee(int id) 
        {
            Employee emp= new Employee();  
            
            using( var db=new organizationContext() )
            {
              emp=  db.Employees.Find(id);

            }
            return emp;
        }
        [HttpPut]
        public String UpdateEmployee(Employee emp)
        {
            Employee? employee=new Employee();
            
          
            using( var db=new organizationContext())
            {
               employee= db.Employees.Find(emp.Id);
                employee.Name=emp.Name;
                employee.Password=emp.Password;
                employee.Email=emp.Email;
                employee.Contact=emp.Contact;
                employee.Address=emp.Address;
                employee.DepartmentId=emp.DepartmentId;
                db.SaveChanges();

            }
            return "Updated Successfully";
        }
        [HttpDelete]
        public String DeleteEmployee(int id) 
        {
            Employee? e = new Employee();
            using ( var db=new organizationContext() ) 
            {
              e=  db.Employees.Find(id);   
                if (e==null)
                {
                    return "Employee not found";
                }
                else
                {
                    db.Employees.Remove(e);
                    db.SaveChanges();
                    return "Emp deleted succesfully";
                }
            }
           
        }
    }
}
