using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_First.Models;

namespace WebApi_First.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public List<Department> GetDepartments()
        {
            List<Department> result = new List<Department>();
           using (var db=new organizationContext())
            {
                result=db.Departments.ToList();

            }
           return result;
        }
        [HttpGet]
        public Department? GetDept(int id)
        {
            Department? d = new Department();
            using (var db = new organizationContext())
            {
                d = db.Departments.Find(id);
            }
            return d;
        }
        [HttpPut]
        public String UpdateDepartment(Department department)
        {
            Department? department1 = new Department();
            using(var db = new organizationContext())
            {
                department1=db.Departments.Find(department.Id);

                department1.Name= department.Name;
              //  db.Departments.Add(department1);
                db.SaveChanges();

                return "Dept updated successfully";
            }
        }

        [HttpDelete]
        public String DeleteDepartment(int id)
        {
            Department? department = new Department();
            using( var db = new organizationContext())
            {
               department= db.Departments.Find(id);
                db.Remove(department);
                db.SaveChanges();
            }
            return "Dept deleted successfully";
        }
      

        [HttpPost]
        public String InsertDepartment(Department department) 
        {
           // Department department1 = new Department();
          
            using(var db=new organizationContext()) 
            {
               
                    db.Departments.Add(department);
                    db.SaveChanges();

                return "Dept added successfully";
               
               
            }

        }
        
        
    }
}
