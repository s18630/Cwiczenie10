using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwiczenie5.DTOs.Responses
{
    public class ModifyStudentResponse
    {
        public string IndexNumber { get; set; }

        public int Semester { get; set; }

        public DateTime StartDate { get; set; }

        public string Studies { get; set; }

        public int IdEnrollment { get; set; }

        


    }
}
