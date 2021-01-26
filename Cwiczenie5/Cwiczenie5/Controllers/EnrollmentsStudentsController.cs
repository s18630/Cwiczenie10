using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie5.DTOs.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cwiczenie5.Controllers
{
    // [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsStudentsController : ControllerBase
    {


        //1.zwraca liste studentów
        [HttpPost]
        [Route("api/enrollStudent")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            var db = new _2019SBDContext();
            var res = db.Studies
                .Where((d)=> d.Name==request.Studies).ToList();

            return Ok(res);
        }



        //2. modyfikacja danych studenta
/*
        [HttpPost]
        [Route("api/students/modifyStudent")] //zmień na student
        public IActionResult ModifyStudent(ModifyStudentRequest request)
        {
            var db = new _2019SBDContext();
            //  var res = db.Student.ToList();


            var student = new Student
            {
                IndexNumber = request.IndexNumber,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate
            };
            db.Attach(student);
            //sprawdź czy student istnieje ?
            db.Entry(student).Property("FirstName").IsModified = true;
            db.Entry(student).Property("LastName").IsModified = true;
            db.Entry(student).Property("BirthDate").IsModified = true; // jak sie nie wpisze dodaje się automatyczne jeśli są wymogi null
            //wtedy wtsrępuje bład 
            //spróbuj drugą wersję
            //no i nei sprawdza czy jest student
            //i trzeba podać wszytskie

            db.SaveChanges();




            return Ok(request);
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
        }*/
    }

}
