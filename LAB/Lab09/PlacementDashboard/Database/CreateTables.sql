
USE PlacementDB;
GO

IF OBJECT_ID('dbo.Students', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.Students
    (
        StudentID INT IDENTITY(1,1) PRIMARY KEY,
        StudentName VARCHAR(100) NOT NULL,
        EnrollmentNo VARCHAR(30) NOT NULL UNIQUE,
        Department VARCHAR(50),
        CGPA DECIMAL(3,2),
        CompanyName VARCHAR(100),
        PackageLPA DECIMAL(8,2),
        PlacementStatus VARCHAR(20) NOT NULL
            DEFAULT 'Not Placed'
    );
END;
GO
