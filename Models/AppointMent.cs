using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseConnectivityExample.Models
{
    public class AppointMent
    {
        public int PateientId { get; set; }
        public string PatirntName { get; set; }
        public string ContactNumber { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string MedicineName { get; set; }
        public DateTime VisitingDate { get; set; }
        public int DoctorFee { get; set; }


    }
}