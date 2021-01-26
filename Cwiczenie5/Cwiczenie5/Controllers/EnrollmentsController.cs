using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Cwiczenie5.DTOs.Requests;
using Cwiczenie5.DTOs.Responses;
using Cwiczenie5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie5.Controllers
{
    // [Route("api/enrollments")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
     
      

        [HttpPost]
        [Route("api/enrollments")]
        public IActionResult EnrollStudent(EnrollStudentRequest request)
        {
            //1.musi występowac sprawdzenie czy wszystkie dane są pobrane 
            //pobierz dane studenta z request

            //2.sprawdż czy istnieją studia zgodne z nazwą przesłaną przez klienta 
       /*     var db = new _2019SBDContext();



            var res = db.Studies
                     .Where((s) => s.Name == request.Studies)
                     .Select(s => new
                     {
                         id = s.IdStudy
                     }).ToString();
      
            if (res == null)
            {
                return BadRequest();
            }
            else */
                return Ok();






            

         

          

        }







        [HttpPost("api/enrollments/promotions")]

        public IActionResult PromoteStudents(PromoteStudentsRequest request)
        {

            /*   using (SqlConnection con = new SqlConnection(ConString))
               using (SqlCommand com = new SqlCommand())
               {
                   com.Connection = con;

                   con.Open();
                   com.CommandText = "PromoteStudents";
                   //     "EXEc s18630.PromoteStudents @Studies , @Semester";

                   com.CommandType = System.Data.CommandType.StoredProcedure;
                   com.Parameters.AddWithValue("@Studies", SqlDbType.NVarChar).Value = request.Studies;
                   com.Parameters.AddWithValue("@Semester", SqlDbType.Int).Value = request.Semester;


                   //      com.Parameters.AddWithValue("Semester", request.Semester);
                   //     com.Parameters.AddWithValue("Studies ", request.Studies);
                   com.ExecuteNonQuery();
            */


            return Ok();

                
                
          
          



            }

        }




































    }

        

























    

