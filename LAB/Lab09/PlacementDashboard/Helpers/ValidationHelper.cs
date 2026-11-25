
using System;
using System.Globalization;

namespace PlacementDashboard.Helpers
{
    public static class ValidationHelper
    {
        public static bool ValidateStudent(
            string name,
            string enrollment,
            string cgpaText,
            string packageText,
            string status,
            out decimal cgpa,
            out decimal? package,
            out string error)
        {
            cgpa = 0;
            package = null;
            error = "";

            if (string.IsNullOrWhiteSpace(name))
                error = "Enter the student name.";
            else if (string.IsNullOrWhiteSpace(enrollment))
                error = "Enter the enrollment number.";
            else if (!decimal.TryParse(cgpaText,
                NumberStyles.Number, CultureInfo.InvariantCulture, out cgpa)
                || cgpa < 0 || cgpa > 10)
                error = "CGPA must be between 0 and 10.";
            else if (!string.IsNullOrWhiteSpace(packageText))
            {
                decimal value;
                if (!decimal.TryParse(packageText,
                    NumberStyles.Number, CultureInfo.InvariantCulture, out value)
                    || value < 0 || value > 999999.99m)
                    error = "Enter a valid package amount.";
                else
                    package = value;
            }

            if (error == "" &&
                status != "Placed" && status != "Not Placed")
                error = "Select a valid placement status.";

            if (error == "" && status == "Placed" &&
                (package == null))
            {
                // Package is optional; no error is required.
            }

            return error == "";
        }
    }
}
