using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeDataEntity;

namespace WebApplication_sample2.Controllers
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        Student_recordsEntities emp = new Student_recordsEntities();
        public IEnumerable<Employee> Get()
        {
            using (emp)
            {
                return emp.Employees.ToList();
            }
        }
        public Employee Get(int id)
        {
            using (emp)
            {
                return emp.Employees.FirstOrDefault(ed => ed.ID == id);
            }
        }

        [HttpPost]
        [Route("input")]
        public Employee saveData(Employee e)
        {
            using (emp)
            {
                emp.Employees.Add(e);
                emp.SaveChanges();
                return emp.Employees.Where(es => es.Name == e.Name).FirstOrDefault();
            }
        }
        [HttpPut]
        [Route("putinput/{id}")]
        public Employee putData(int id, Employee e)
        {
            using (emp)
            {
                var emplo = emp.Employees.Where(es => es.ID == id).FirstOrDefault();
                emplo.Name = e.Name;
                emplo.Salary = e.Salary;
                emplo.Age = e.Age;
                emplo.Sex = e.Sex;
                emp.Entry(emplo).State = System.Data.Entity.EntityState.Modified;
                emp.SaveChanges();
                return emp.Employees.Where(es => es.ID == id).FirstOrDefault();
            }
        }
        [HttpDelete]
        [Route("deleteinput/{id}")]
        public Employee deletedata(int id)
        {
            using (emp)
            {
                var emp12 = emp.Employees.Where(est => est.ID == id).FirstOrDefault();
                emp.Entry(emp12).State = System.Data.Entity.EntityState.Deleted;
                emp.SaveChanges();          
                return emp.Employees.Where(es => es.ID == id).FirstOrDefault();
            }
        }
        //public Employee put(int id,Employee e)
        //{
        //    using (emp)
        //    {
        //        if (em)
        //        string name1 = e.Name;

        //        return ;
        //    }
        //}
    }
}
