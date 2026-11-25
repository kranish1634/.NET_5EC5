
namespace PlacementDashboard.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }

        public string EnrollmentNo { get; set; }

        public string Department { get; set; }

        public decimal CGPA { get; set; }

        public string CompanyName { get; set; }

        public decimal? PackageLPA { get; set; }

        public string PlacementStatus { get; set; }
    }
}
