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
            //  var res = db.Student.ToList();


            /* var student = new Student
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
            */
            var response = new ModifyStudentRequest();

         

/*
            if (request.LastName != null)
            {
                var s = new Student
                {
                    IndexNumber = request.IndexNumber,
                    FirstName = request.FirstName,
                    BirthDate = request.BirthDate

                    
            };
                db.Attach(s);



            }*/



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
            



            // d1 znajduje sie pod system sledzenie zmian
            // unchanged
            //db.Add(d1);
            //db.Entry(d1).Property("LastName").IsModified = true;
            //db.Entry(d1).State = EntityState.Modified;


            //    db.Entry(s).Property("FirstName").IsModified = true;
            //    db.Entry(s).Property("LastName").IsModified = true;
            //    db.Entry(s).Property("BirthDate").IsModified = true;



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
        }
    }

}
