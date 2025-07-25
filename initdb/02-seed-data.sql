-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Server version:               9.3.0 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.10.0.7023
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

-- Dumping data for table jobdb.applicantaccounts: ~0 rows (approximately)

-- Dumping data for table jobdb.applicationdocuments: ~2 rows (approximately)
INSERT INTO `applicationdocuments` (`Id`, `ApplicationId`, `DocumentName`, `FilePath`) VALUES
	(1, 1, 'CV_JohnDoe.pdf', '/uploads/cv_johndoe.pdf'),
	(2, 1, 'CoverLetter_JohnDoe.pdf', '/uploads/coverletter_johndoe.pdf');

-- Dumping data for table jobdb.applications: ~2 rows (approximately)
INSERT INTO `applications` (`Id`, `JobId`, `ApplicantFirstName`, `ApplicantSurName`, `DateofBirth`, `Nationality`, `StateofOrigin`, `LGA`, `Email`, `PhoneNumber`, `AppliedOn`, `Status`) VALUES
	(1, 1, 'John', 'Doe', '1990-05-21 00:00:00.000000', 'Nigerian', 'Benue', 'Makurdi', 'john.doe@example.com', '+2348012345678', '2025-07-15 09:08:50.000000', 'Pending'),
	(2, 2, 'Jane', 'Smith', '1988-08-15 00:00:00.000000', 'Nigerian', 'Lagos', 'Ikeja', 'jane.smith@example.com', '+2348098765432', '2025-07-20 09:08:50.000000', 'Shortlisted');

-- Dumping data for table jobdb.departments: ~5 rows (approximately)
INSERT INTO `departments` (`Id`, `Name`, `Code`) VALUES
	(1, 'Human Resources', 'HR'),
	(2, 'Finance', 'FIN'),
	(3, 'Information Technology', 'IT'),
	(4, 'Marketing', 'MKT'),
	(5, 'Operations', 'OPS');

-- Dumping data for table jobdb.documents: ~7 rows (approximately)
INSERT INTO `documents` (`Id`, `DocumentName`, `JobId`) VALUES
	(1, 'Resume', 1),
	(2, 'Cover Letter', 1),
	(3, 'Degree', 1),
	(4, 'Resume', 2),
	(5, 'Cover Letter', 2),
	(6, 'Degree', 2),
	(7, 'Project Plan Sample', 2);

-- Dumping data for table jobdb.jobcategories: ~3 rows (approximately)
INSERT INTO `jobcategories` (`Id`, `Name`, `Description`) VALUES
	(1, 'Technology', 'Jobs related to software, hardware, IT, etc.'),
	(2, 'Administration', 'Administrative and office management roles'),
	(3, 'Academic', 'Teaching and research positions');

-- Dumping data for table jobdb.jobs: ~2 rows (approximately)
INSERT INTO `jobs` (`Id`, `Title`, `Description`, `StartDate`, `ClosingDate`, `DepartmentId`, `CreatedDate`, `Active`, `CategoryId`) VALUES
	(1, 'Software Engineer', 'Bachelor\'s degree in Computer Science or related field,3+ years of experience in software development, Proficiency in C#, .NET, and ASP.NET Core,Knowledge of front-end frameworks like React or Angular, Experience with relational databases (e.g., SQL Server, MySQL), Understanding of RESTful APIs, Strong problem-solving and debugging skills', '2025-07-05 09:08:50.000000', '2025-08-04 09:08:50.000000', 3, '2025-07-25 09:08:50.000000', 1, 1),
	(2, 'Project Manager', 'Bachelor\'s degree in Business, Management, or related field, 5+ years of project management experience, PMP or PRINCE2 certification preferred, Strong leadership and team management skills, Excellent communication and organizational skills, Proficiency with project management tools (e.g., MS Project, Jira), Ability to manage budgets and project timelines', '2025-07-10 09:08:50.000000', '2025-08-09 09:08:50.000000', 1, '2025-07-25 09:08:50.000000', 1, 2);

-- Dumping data for table jobdb.qualifications: ~0 rows (approximately)
INSERT INTO `qualifications` (`Id`, `ApplicationId`, `Title`, `Institution`, `DateObtained`) VALUES
	(1, 1, 'B.Sc. Computer Science', 'University of Abuja', '2015-01-01 00:00:00.000000');

-- Dumping data for table jobdb.verificationtokens: ~0 rows (approximately)

-- Dumping data for table jobdb.workexperiences: ~2 rows (approximately)
INSERT INTO `workexperiences` (`Id`, `ApplicationId`, `CompanyName`, `Position`, `FromDate`, `ToDate`) VALUES
	(1, 1, 'TechSoft Ltd.', 'Software Developer', '2015-01-01 00:00:00.000000', '2018-12-31 00:00:00.000000'),
	(2, 1, 'InnovateX', 'Senior Developer', '2019-01-01 00:00:00.000000', NULL);

-- Dumping data for table jobdb.__efmigrationshistory: ~1 rows (approximately)
INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
	('20250725090851_InitMigration', '8.0.13');

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
