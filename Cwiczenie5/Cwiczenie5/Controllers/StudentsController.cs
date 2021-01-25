using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenie5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
       


        [HttpGet]
        public IActionResult GetStudents()
        {
            var db = new _2019SBDContext();
            var res = db.Student.ToList();

            return Ok(res);
        }
    }
}
