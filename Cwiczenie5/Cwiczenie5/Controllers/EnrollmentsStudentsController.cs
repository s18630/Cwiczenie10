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




            var db2 = new _2019SBDContext();
            var res2 = db2.Enrollment
                    .Where(d => d.Semester == 1 && d.IdStudy == res.IdStudy)
                    .OrderByDescending(d => d.StartDate) //rosnąco czy malejąco?
                    .FirstOrDefault();

            EnrollStudentResponse esr = new EnrollStudentResponse();

            if (res2 == null)
            {
                //wyszukaj największ idEnrollment

                var res3 = db.Enrollment
                    .OrderByDescending(d => d.IdEnrollment) //rosnąco czy malejąco?
                    .FirstOrDefault();

                int maxIdEnrollment = res3.IdEnrollment;
                //ZMIEŃ UWAGA NA DATE teraz


                esr.StartDate = DateTime.Today;
                //stworz nowy
                var e = new Enrollment()
                {
                    IdEnrollment = maxIdEnrollment + 1,
                    StartDate = esr.StartDate,
                    Semester = 1,
                    IdStudy = res.IdStudy

                };

                db.Enrollment.Add(e);
                esr.IdEnrollment = maxIdEnrollment + 1;

                //    db.SaveChanges();//póżniej zlikwidować !!!!!1111
            }
            else
            {
                esr.IdEnrollment = res2.IdEnrollment;

            }



          


            //  var db4 = new _2019SBDContext();
            var res4 = db2.Student
                    .Where(d => d.IndexNumber == request.IndexNumber).FirstOrDefault();

            if(res4 != null)
            {
                return BadRequest();
            }




            //DODAJ STUDENTA      //sprawdzić jak się savuje bez tamtego
            var s = new Student()
            {
                 IndexNumber=request.IndexNumber,
                 FirstName =request.FirstName,
                 LastName=request.LastName, 
                 BirthDate=request.BirthDate,
                 IdEnrollment =  esr.IdEnrollment 
           };

            db.Student.Add(s);

            db.SaveChanges();//póżniej zlikwidować !!!!!1111

            esr.IndexNumber = s.IndexNumber;
            esr.Studies = request.Studies;
            esr.Semester = 1;
            var res5 = db2.Enrollment
                    .Where(d => d.IdEnrollment== esr.IdEnrollment).FirstOrDefault();
            esr.StartDate = res5.StartDate;


          
            return Ok(esr);
        }



     
        [HttpPost]
        [Route("api/enrollments/promotions")] //zmień na student
        public IActionResult PromoteStudents(PromoteStudentsRequest request)
        {
            var db = new _2019SBDContext();
            //  var res = db.Student.ToList();

            
            var res = db.Studies
               .Where((d) => d.Name == request.Studies ).FirstOrDefault();

            if (res == null)
            {
                return BadRequest();
            }

            var res2 = db.Enrollment
               .Where((d) => d.IdStudy == res.IdStudy && d.Semester == request.Semester).FirstOrDefault();

            if (res == null)
            {
                return BadRequest();
            }

            var res3 = db.Enrollment
              .Where((d) => d.IdStudy == res.IdStudy && d.Semester == request.Semester +1).FirstOrDefault();

            PromoteStudentsResponse response = new PromoteStudentsResponse();

            if (res3 == null)
            {
                //dodaj enrollment 



                var res4 = db.Enrollment
                    .OrderByDescending(d => d.IdEnrollment) //rosnąco czy malejąco?
                    .FirstOrDefault();

                int maxIdEnrollment = res4.IdEnrollment;
               

                response.StartDate = DateTime.Today;
              
                var e = new Enrollment()
                {
                    IdEnrollment = maxIdEnrollment + 1,
                    StartDate = response.StartDate,
                    Semester = request.Semester + 1,
                    IdStudy = res.IdStudy

                };

                db.Enrollment.Add(e);
                response.IdEnrollment = maxIdEnrollment + 1;
            }
            else
            {
                response.IdEnrollment = res3.IdEnrollment;

            }

            db.SaveChanges();




            //teraz trzeba wszystkich studentów zrolować
         /*   var res5 = db.Student
              .Where((d) => d.IdEnrollment== response.IdEnrollment).ToList();


            foreach (Student s in res5)
            {

                s.IdEnrollment = response.IdEnrollment;
              
            }



            db.SaveChanges();

            */


            return Ok(response);
        }



    }

}
