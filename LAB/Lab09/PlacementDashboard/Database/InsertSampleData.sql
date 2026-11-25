
USE PlacementDB;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Students)
BEGIN
    INSERT INTO dbo.Students
    (StudentName, EnrollmentNo, Department, CGPA,
     CompanyName, PackageLPA, PlacementStatus)
    VALUES
    ('Amit Patel', 'CE001', 'Computer Engineering',
     8.50, 'TCS', 4.50, 'Placed'),
    ('Priya Shah', 'CE002', 'Computer Engineering',
     9.10, 'Infosys', 5.00, 'Placed'),
    ('Rahul Mehta', 'CE003', 'Information Technology',
     7.60, NULL, NULL, 'Not Placed'),
    ('Neha Joshi', 'CE004', 'Information Technology',
     8.20, 'Wipro', 4.00, 'Placed'),
    ('Karan Singh', 'CE005', 'Computer Engineering',
     7.00, NULL, NULL, 'Not Placed');
END;
GO
