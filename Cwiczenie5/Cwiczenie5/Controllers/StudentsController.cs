using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie5.DTOs.Requests;
using Cwiczenie5.DTOs.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie5.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {


        //1.zwraca liste studentów
        [HttpGet]
        [Route("api/students/lista")]
        public IActionResult GetStudents()
        {
            var db = new _2019SBDContext();
            var res = db.Student.ToList();

            return Ok(res);
        }



        //2. modyfikacja danych studenta

        [HttpPost]
        [Route("api/students/modifyStudent")] //zmień na student
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            var db = new _2019SBDContext();
         
         
            var s = new Student
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate


            };
             
            db.Attach(s);

            if(request.FirstName != null)
            {
                db.Entry(s).Property("FirstName").IsModified = true;

            }

            if (request.LastName != null)
            {
                db.Entry(s).Property("LastName").IsModified = true;

            }

            if (request.BirthDate != null)
            {
                db.Entry(s).Property("BirthDate").IsModified = true;

            }

            db.SaveChanges(); 
            var db2 = new _2019SBDContext();


            var res = db2.Student
                   .Where(d => d.IndexNumber==request.IndexNumber)
                   .FirstOrDefault();

           

            var response = new ModifyStudentResponse();

            response.IndexNumber = res.IndexNumber;
            response.FirstName = res.FirstName;
            response.LastName = res.LastName;
            response.BirthDate = res.BirthDate;




            return Ok(response);
        }



        //3. usunięcie studenta
        [HttpPost]
        [Route("api/students/deleteStudent")] //zmień na student
        public IActionResult DeleteStudent(ModifyStudentRequest request)
        {

            var db = new _2019SBDContext();
            var student = new Student
            {
                IndexNumber = request.IndexNumber
            };

            db.Attach(student);
           db.Remove(student);
         

            db.SaveChanges();
            return Ok(request.IndexNumber + " zostal usunięty");
        }
    }

}
