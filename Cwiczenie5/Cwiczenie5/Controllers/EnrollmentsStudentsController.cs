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
                .Where((d) => d.Name == request.Studies).FirstOrDefault();

            if(res==null)
            {
                return BadRequest(); 
            }


          int idStudies = res.IdStudy;

       /*     var res2 = db.Enrollment
                    .Where(d => d.Semester == 1 && d.IdStudy == idStudies)
                    .OrderByDescending(d => d.StartDate) //rosnąco czy malejąco?
                    .FirstOrDefault();

         int idEnrollment;

            if (res2 == null)
            {
                //wyszukaj największ idEnrollment

                var res3 = db.Enrollment 
                    .OrderBy(d => d.IdEnrollment) //rosnąco czy malejąco?
                    .FirstOrDefault();

                int maxIdEnrollment = res3.IdEnrollment;

                //stworz nowy
                var e = new Enrollment()
             {
                IdEnrollment = maxIdEnrollment+1,
                StartDate = DateTime.Now,
                Semester = 1,
                IdStudy=idStudies

              };

                db.Enrollment.Add(e);

                db.SaveChanges();//póżniej zlikwidować
            }
                   

            */


            //odnajdz najnowszy wpis w enrollments zgodny z id nazwą studiów i wartość semestru 1. 
           



            return Ok(idStudies);
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
