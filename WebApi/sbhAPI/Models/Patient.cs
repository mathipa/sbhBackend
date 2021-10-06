using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sbhAPI.Models
{
    public class Patient
    {
        public string FileNo { get; set; }
        public string PatientId { get; set; }
        public string DOB { get; set; }
        public string PassportNo { get; set; }
        public string Gender { get; set; }
        public string Addressline1 { get; set; }
        public string Addressline2 { get; set; }
        public string Addressline3 { get; set; }
        public string Photo { get; set; }
        public string ClinicPractice { get; set; }

    }
}