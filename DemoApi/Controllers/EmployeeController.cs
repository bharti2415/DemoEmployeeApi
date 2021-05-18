using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DemoApi.Models;

namespace DemoApi.Controllers
{
    public class EmployeeController : ApiController
    {
        //Get - Reterive Employee
        
        public IHttpActionResult GetAllEmployee()
        {

             
            IList<EmpModel> employee = null;

            using (var x = new EmployeeEntities())
            {
                employee = x.EmpDetails
                    .Select(c => new EmpModel()
                    {
                        ID = c.ID,
                        EmpName = c.EmpName,
                        Phone = c.Phone,
                        Address = c.Address,
                        Email = c.emailID
                    }).ToList<EmpModel>();
            }
            if (employee.Count == 0)
                return NotFound();
            return Ok(employee);
        }

        public IHttpActionResult GetAllEmployee(int id )
        {

            
            IList<EmpDetail> employee = null;

            using (var x = new EmployeeEntities())
            {
                employee = x.EmpDetails.Where(c => c.ID == id).ToList<EmpDetail>();
            }
            if (employee.Count == 0)
                return NotFound();
            return Ok(employee);
        }
        //Post - Create/Insert new employee

        public IHttpActionResult PostNewEmployee(EmpModel emp)

        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Employee ID");
            using (var x = new EmployeeEntities())
            {
                var checkExistingEmp = x.EmpDetails.Where(c => c.ID == emp.ID).FirstOrDefault<EmpDetail>();
                if (checkExistingEmp == null)
                {

                    x.EmpDetails
                       .Add(new EmpDetail()
                       {
                           ID = emp.ID,
                           EmpName = emp.EmpName,
                           Phone = emp.Phone,
                           Address = emp.Address,
                           emailID = emp.Email
                       });

                    x.SaveChanges();
                }
                else
                    return BadRequest("Employee ID already exists.");


            }
            return Ok();
        }

        //Put  - Update employee Details

        public IHttpActionResult PutNewEmployee(EmpModel emp)
        {

            if (!ModelState.IsValid)
                return BadRequest("Invalid Employee ID");



            using (var x = new EmployeeEntities())
            {

                var checkExistingEmp = x.EmpDetails.Where(c => c.ID == emp.ID).FirstOrDefault<EmpDetail>();

                if (checkExistingEmp != null)
                {
                    checkExistingEmp.EmpName = emp.EmpName;
                    checkExistingEmp.Phone = emp.Phone;
                    checkExistingEmp.Address = emp.Address;
                    checkExistingEmp.emailID = emp.Email;

                    x.SaveChanges();
                }
                else
                    return NotFound();

            }
            return Ok();
        }
        //Delete  - delete a record

        public IHttpActionResult DeleteEmployee(int ID)
        {

            if (ID <= 0)
                return BadRequest("Invalid Emp ID");

            using (var x = new EmployeeEntities())
            {

                var Employee = x.EmpDetails.Where(c => c.ID == ID).FirstOrDefault();

                if (Employee != null)
                {
                    x.Entry(Employee).State = System.Data.Entity.EntityState.Deleted;
                    x.SaveChanges();
                    return Ok();
                }
                else
                    return BadRequest("Invalid Emp ID");
            }
        }
    }
}