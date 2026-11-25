
using System;
using System.Data;
using System.Data.SqlClient;

namespace PlacementDashboard.Data
{
    public class StudentRepository
    {
        public DataTable GetAllStudents()
        {
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM Students ORDER BY StudentID", con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool AddStudent(
            string name, string enrollment, string department,
            decimal cgpa, string company, decimal? packageLpa,
            string status)
        {
            string query = @"INSERT INTO Students
                (StudentName, EnrollmentNo, Department, CGPA,
                 CompanyName, PackageLPA, PlacementStatus)
                VALUES
                (@Name, @Enrollment, @Department, @CGPA,
                 @Company, @Package, @Status)";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                AddParameters(cmd, name, enrollment, department,
                    cgpa, company, packageLpa, status);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateStudent(
            int id, string name, string enrollment, string department,
            decimal cgpa, string company, decimal? packageLpa,
            string status)
        {
            string query = @"UPDATE Students SET
                StudentName=@Name, EnrollmentNo=@Enrollment,
                Department=@Department, CGPA=@CGPA,
                CompanyName=@Company, PackageLPA=@Package,
                PlacementStatus=@Status
                WHERE StudentID=@ID";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                AddParameters(cmd, name, enrollment, department,
                    cgpa, company, packageLpa, status);

                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteStudent(int id)
        {
            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(
                "DELETE FROM Students WHERE StudentID=@ID", con))
            {
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public DataTable SearchStudents(string keyword)
        {
            string query = @"SELECT * FROM Students
                WHERE StudentName LIKE @Search
                   OR EnrollmentNo LIKE @Search
                   OR Department LIKE @Search
                   OR CompanyName LIKE @Search
                   OR PlacementStatus LIKE @Search
                ORDER BY StudentID";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.Add("@Search", SqlDbType.VarChar, 100)
                    .Value = "%" + keyword + "%";

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public DataTable GetStatistics()
        {
            string query = @"SELECT
                COUNT(*) AS Total,
                COALESCE(SUM(CASE WHEN PlacementStatus='Placed'
                    THEN 1 ELSE 0 END), 0) AS Placed,
                COALESCE(SUM(CASE WHEN PlacementStatus='Not Placed'
                    THEN 1 ELSE 0 END), 0) AS NotPlaced
                FROM Students";

            using (SqlConnection con = DatabaseConnection.GetConnection())
            using (SqlDataAdapter da = new SqlDataAdapter(query, con))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void AddParameters(
            SqlCommand cmd, string name, string enrollment,
            string department, decimal cgpa, string company,
            decimal? packageLpa, string status)
        {
            cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = name;
            cmd.Parameters.Add("@Enrollment", SqlDbType.VarChar, 30).Value = enrollment;
            cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50).Value =
                string.IsNullOrWhiteSpace(department) ? (object)DBNull.Value : department;
            cmd.Parameters.Add("@CGPA", SqlDbType.Decimal).Value = cgpa;
            cmd.Parameters["@CGPA"].Precision = 3;
            cmd.Parameters["@CGPA"].Scale = 2;

            cmd.Parameters.Add("@Company", SqlDbType.VarChar, 100).Value =
                string.IsNullOrWhiteSpace(company) ? (object)DBNull.Value : company;

            cmd.Parameters.Add("@Package", SqlDbType.Decimal).Value =
                packageLpa.HasValue ? (object)packageLpa.Value : DBNull.Value;
            cmd.Parameters["@Package"].Precision = 8;
            cmd.Parameters["@Package"].Scale = 2;

            cmd.Parameters.Add("@Status", SqlDbType.VarChar, 20).Value = status;
        }
    }
}
